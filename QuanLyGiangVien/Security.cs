using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using QuanLyGiangVien;

namespace QuanLyGiangVien
{
    internal class UserMessage : Exception
    {
        internal UserMessage(string message) : base(message) { }
    }

    internal sealed class InvalidCredentials : UserMessage
    {
        internal InvalidCredentials() : base("Tên đăng nhập hoặc mật khẩu chưa đúng.") { }
    }

    internal static class Passwords
    {
        internal static string Hash(string password, string salt)
        {
            using (var sha = SHA256.Create())
                return Hex(sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt)));
        }

        private static string Hex(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
        }

        internal static bool Matches(string password, NGUOI_DUNG user)
        {
            string actual = Hash(password, user.MatKhauSalt);
            string expected = user.MatKhauHash;
            if (expected == null || expected.Length != actual.Length) return false;
            int diff = 0;
            for (int i = 0; i < actual.Length; i++) diff |= actual[i] ^ expected[i];
            return diff == 0;
        }

        internal static void Set(NGUOI_DUNG user, string password, string repeat)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || password.Length > 128)
                throw new UserMessage("Mật khẩu mới cần từ 8 đến 128 ký tự.");
            if (password != repeat) throw new UserMessage("Hai mật khẩu mới chưa khớp.");
            byte[] bytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(bytes);
            user.MatKhauSalt = Hex(bytes);
            user.MatKhauHash = Hash(password, user.MatKhauSalt);
        }
    }

    internal enum ActionRight { View, Add, Edit, Delete }

    internal sealed class Session
    {
        internal readonly int UserId;
        internal readonly string Username;
        private string stamp;
        private Session(NGUOI_DUNG user)
        {
            UserId = user.MaNguoiDung;
            Username = user.TenDangNhap;
            stamp = user.MatKhauHash;
        }

        internal static QuanLyGiangVienDataContext Open()
        {
            var db = new QuanLyGiangVienDataContext(DatabaseConnection.GetReadyConnectionString());
            db.CommandTimeout = 15;
            try
            {
                db.Connection.Open();
                return db;
            }
            catch
            {
                db.Dispose();
                throw;
            }
        }

        internal static Session Login(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(password))
                throw new UserMessage("Vui lòng nhập tên đăng nhập và mật khẩu.");
            using (var db = Open())
            {
                var user = db.NGUOI_DUNGs.SingleOrDefault(u => u.TenDangNhap == name.Trim());
                if (user == null || !Passwords.Matches(password, user))
                    throw new InvalidCredentials();
                if (!user.TrangThai) throw new UserMessage("Tài khoản đang bị khóa.");
                if (!HasAccess(db, user.MaVaiTro)) throw new UserMessage("Vai trò của tài khoản chưa được cấp quyền truy cập.");
                db.NHAT_KY_HE_THONGs.InsertOnSubmit(Log(user.MaNguoiDung, "Đăng nhập", "Xác thực thành công"));
                db.SubmitChanges();
                return new Session(user);
            }
        }

        private static bool HasAccess(QuanLyGiangVienDataContext db, int role)
        {
            return db.PHAN_QUYENs.Any(p => p.MaVaiTro == role && p.DuocXem);
        }

        internal NGUOI_DUNG Current(QuanLyGiangVienDataContext db)
        {
            var user = db.NGUOI_DUNGs.SingleOrDefault(u => u.MaNguoiDung == UserId);
            if (user == null || !user.TrangThai || user.MatKhauHash != stamp || !HasAccess(db, user.MaVaiTro))
                throw new UserMessage("Phiên đăng nhập đã hết hiệu lực. Hãy đăng nhập lại.");
            return user;
        }

        internal void PasswordChanged(string hash) { stamp = hash; }

        internal static NHAT_KY_HE_THONG Log(int actor, string action, string detail)
        {
            return new NHAT_KY_HE_THONG { MaNguoiDung = actor, HanhDong = action, NoiDung = detail, ThoiGian = DateTime.Now };
        }

        internal static bool Allows(QuanLyGiangVienDataContext db, int role, string form, ActionRight right)
        {
            var row = db.PHAN_QUYENs.SingleOrDefault(p => p.MaVaiTro == role && p.CHUC_NANG.MaForm == form);
            return row != null && row.DuocXem && (right == ActionRight.View ||
                right == ActionRight.Add && row.DuocThem || right == ActionRight.Edit && row.DuocSua ||
                right == ActionRight.Delete && row.DuocXoa);
        }

        internal bool Can(string form, ActionRight right)
        {
            using (var db = Open()) return Allows(db, Current(db).MaVaiTro, form, right);
        }
    }
}

