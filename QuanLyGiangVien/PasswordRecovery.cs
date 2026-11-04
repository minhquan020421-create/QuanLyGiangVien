using System;
using System.Data.Linq;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyGiangVien
{
    internal sealed class PasswordRecovery
    {
        internal const int CodeMinutes = 5;
        private const int MaxAttempts = 5;
        private const int SendIntervalSeconds = 60;
        private static readonly object SendGate = new object();
        private static DateTime nextSendUtc;

        private readonly RecoveryAccount account;
        private readonly string code;
        private readonly DateTime expiresUtc;
        private int wrongAttempts;
        private bool used;

        internal bool CanReset => !used && DateTime.UtcNow < expiresUtc && wrongAttempts < MaxAttempts;

        private sealed class RecoveryAccount
        {
            internal int Id { get; set; }
            internal string Username { get; set; }
            internal string Email { get; set; }
            internal string PasswordHash { get; set; }
            internal string PasswordSalt { get; set; }
        }

        private PasswordRecovery(RecoveryAccount account, string code)
        {
            this.account = account;
            this.code = code;
            expiresUtc = DateTime.UtcNow.AddMinutes(CodeMinutes);
        }

        internal static PasswordRecovery Request(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length > 50)
                throw new UserMessage("Vui lòng nhập tên đăng nhập.");

            string sender = Environment.GetEnvironmentVariable("QLGV_GMAIL_USER");
            string appPassword = Environment.GetEnvironmentVariable("QLGV_GMAIL_APP_PASSWORD");
            if (string.IsNullOrWhiteSpace(sender) || string.IsNullOrWhiteSpace(appPassword))
                throw new UserMessage("Chưa cấu hình Gmail gửi mã. Hãy liên hệ quản trị viên.");

            MailAddress from;
            try { from = new MailAddress(AccountService.NormalizeRecoveryEmail(sender)); }
            catch (UserMessage)
            {
                throw new UserMessage("Địa chỉ Gmail gửi mã trong cấu hình không hợp lệ.");
            }
            appPassword = appPassword.Replace(" ", "").Trim();

            ReserveSend();
            RecoveryAccount target;
            using (var db = Session.Open())
            {
                target = db.NGUOI_DUNGs
                    .Where(u => u.TenDangNhap == username && u.TrangThai && u.Email != null)
                    .Select(u => new RecoveryAccount
                    {
                        Id = u.MaNguoiDung,
                        Username = u.TenDangNhap,
                        Email = u.Email,
                        PasswordHash = u.MatKhauHash,
                        PasswordSalt = u.MatKhauSalt
                    }).SingleOrDefault();
            }

            string otp = CreateCode();
            if (target != null)
            {
                string recipient;
                try { recipient = AccountService.NormalizeRecoveryEmail(target.Email); }
                catch (UserMessage) { recipient = null; }

                if (recipient == null || !SendMail(from, appPassword, recipient, otp))
                    target = null;
            }

            // Keep the same UI response for missing, locked and eligible accounts.
            return new PasswordRecovery(target, otp);
        }

        private static void ReserveSend()
        {
            lock (SendGate)
            {
                var now = DateTime.UtcNow;
                if (now < nextSendUtc)
                {
                    int seconds = (int)Math.Ceiling((nextSendUtc - now).TotalSeconds);
                    throw new UserMessage($"Vui lòng chờ {seconds} giây trước khi gửi lại mã.");
                }

                nextSendUtc = now.AddSeconds(SendIntervalSeconds);
            }
        }

        private static string CreateCode()
        {
            const uint range = 1000000;
            const uint limit = uint.MaxValue - uint.MaxValue % range;
            var bytes = new byte[sizeof(uint)];
            uint sample;
            using (var rng = RandomNumberGenerator.Create())
            {
                do
                {
                    rng.GetBytes(bytes);
                    sample = BitConverter.ToUInt32(bytes, 0);
                } while (sample >= limit);
            }

            return (sample % range).ToString("D6", CultureInfo.InvariantCulture);
        }

        private static bool SendMail(MailAddress sender, string appPassword, string recipient, string otp)
        {
            using (var message = new MailMessage(sender, new MailAddress(recipient)))
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                message.Subject = "Mã khôi phục mật khẩu - Quản lý giảng viên";
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = $"Mã khôi phục mật khẩu của bạn là {otp}.\r\n" +
                    $"Mã có hiệu lực trong {CodeMinutes} phút. Không chia sẻ mã này.\r\n" +
                    "Nếu bạn không yêu cầu khôi phục mật khẩu, hãy bỏ qua email này.";
                message.BodyEncoding = Encoding.UTF8;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(sender.Address, appPassword);
                smtp.Timeout = 15000;
                try
                {
                    smtp.Send(message);
                    return true;
                }
                catch (SmtpException error)
                {
                    Trace.TraceWarning("Gmail OTP SMTP status: {0}", error.StatusCode);
                    return false;
                }
            }
        }

        internal void Reset(string submittedCode, string password, string repeat)
        {
            if (!CanReset)
                throw new UserMessage("Mã không còn hiệu lực. Hãy yêu cầu mã mới.");

            if (submittedCode.Length != code.Length || submittedCode.Any(c => c < '0' || c > '9'))
                throw new UserMessage("Vui lòng nhập mã OTP gồm 6 chữ số.");

            int difference = 0;
            for (int i = 0; i < code.Length; i++)
                difference |= code[i] ^ submittedCode[i];

            if (difference != 0 || account == null)
            {
                wrongAttempts++;
                if (wrongAttempts >= MaxAttempts)
                    throw new UserMessage("Bạn đã nhập sai 5 lần. Hãy yêu cầu mã mới.");
                throw new UserMessage($"Mã OTP chưa đúng. Bạn còn {MaxAttempts - wrongAttempts} lần thử.");
            }

            using (var db = Session.Open())
            {
                var user = db.NGUOI_DUNGs.SingleOrDefault(u => u.MaNguoiDung == account.Id);
                if (user == null || !user.TrangThai || user.TenDangNhap != account.Username || user.Email != account.Email ||
                    user.MatKhauHash != account.PasswordHash || user.MatKhauSalt != account.PasswordSalt ||
                    DateTime.UtcNow >= expiresUtc)
                {
                    used = true;
                    throw new UserMessage("Yêu cầu không còn hiệu lực. Hãy yêu cầu mã mới.");
                }

                if (Passwords.Matches(password, user))
                    throw new UserMessage("Mật khẩu mới trùng mật khẩu hiện tại.");

                Passwords.Set(user, password, repeat);
                db.NHAT_KY_HE_THONGs.InsertOnSubmit(Session.Log(user.MaNguoiDung, "Khôi phục mật khẩu", "Xác thực qua email"));
                try { db.SubmitChanges(); }
                catch (ChangeConflictException)
                {
                    used = true;
                    throw new UserMessage("Thông tin tài khoản đã thay đổi. Hãy yêu cầu mã mới.");
                }

                used = true;
            }
        }
    }
}
