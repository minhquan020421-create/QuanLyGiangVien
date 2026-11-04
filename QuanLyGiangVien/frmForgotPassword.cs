using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmForgotPassword : Form
    {
        private PasswordRecovery recovery;
        private bool sending;

        public frmForgotPassword()
        {
            InitializeComponent();
        }

        internal frmForgotPassword(string username) : this()
        {
            txtTenDangNhap.Text = username;
        }

        internal string Username => txtTenDangNhap.Text.Trim();
        private bool CanUpdateDialog => !IsDisposed && !Disposing && DialogResult == DialogResult.None;

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            Theme.Apply(this);
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            recovery = null;
            txtOtp.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLai.Clear();
            lblPhanHoi.Text = "";
            UpdateActions();
        }

        private async void btnGuiMa_Click(object sender, EventArgs e)
        {
            if (sending) return;
            string username = Username;
            sending = true;
            lblPhanHoi.Text = "Đang xử lý yêu cầu…";
            UpdateActions();

            try
            {
                var request = await Task.Run(() => PasswordRecovery.Request(username));
                if (!CanUpdateDialog) return;
                recovery = request;
                txtOtp.Clear();
                lblPhanHoi.Text = "Nếu tài khoản đủ điều kiện, mã đã được gửi đến email khôi phục. " +
                    $"Mã có hiệu lực {PasswordRecovery.CodeMinutes} phút.";
            }
            catch (UserMessage error)
            {
                if (CanUpdateDialog) lblPhanHoi.Text = error.Message;
            }
            catch (SqlException error)
            {
                Diagnostics.SqlFailure(error);
                if (CanUpdateDialog)
                    lblPhanHoi.Text = error.Number == 207
                        ? "Chưa cập nhật cột email khôi phục trong cơ sở dữ liệu."
                        : "Chưa truy cập được cơ sở dữ liệu. Hãy thử lại.";
            }
            catch (ConfigurationErrorsException)
            {
                if (CanUpdateDialog) lblPhanHoi.Text = "Không đọc được cấu hình ứng dụng.";
            }
            finally
            {
                sending = false;
                if (CanUpdateDialog) UpdateActions();
            }

            if (CanUpdateDialog && txtOtp.Enabled) txtOtp.Focus();
        }

        private void btnLuuMatKhau_Click(object sender, EventArgs e)
        {
            if (recovery == null || sending) return;

            Ui.Run(this, () =>
            {
                recovery.Reset(txtOtp.Text.Trim(), txtMatKhauMoi.Text, txtNhapLai.Text);
                MessageBox.Show(this, "Đã đổi mật khẩu. Bạn có thể đăng nhập bằng mật khẩu mới.",
                    "Quản lý giảng viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }, lblPhanHoi);

            if (!IsDisposed && DialogResult != DialogResult.OK) UpdateActions();
        }

        private void UpdateActions()
        {
            bool canReset = !sending && recovery != null && recovery.CanReset;
            txtTenDangNhap.ReadOnly = sending;
            btnGuiMa.Enabled = !sending;
            txtOtp.Enabled = txtMatKhauMoi.Enabled = txtNhapLai.Enabled = btnLuuMatKhau.Enabled = canReset;
            AcceptButton = canReset ? btnLuuMatKhau : btnGuiMa;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            recovery = null;
            base.OnFormClosed(e);
        }
    }
}
