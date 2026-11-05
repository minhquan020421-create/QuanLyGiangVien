using System;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmChangePassword : System.Windows.Forms.Form
    {
        public frmChangePassword() { InitializeComponent(); }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Lấy kích thước thực tế sau khi Windows áp dụng DPI.
            int initialWidth = pnlNoiDungDoiMatKhau.Width;
            int initialHeight = pnlNoiDungDoiMatKhau.Height;
            int maximumWidth = (int)(initialWidth * 1.5);
            int margin = (int)(24.0 * initialWidth / 522);

            // Giữ cửa sổ đủ chỗ hiển thị toàn bộ nội dung.
            MinimumSize = new System.Drawing.Size(
                Math.Max(MinimumSize.Width,
                    initialWidth + Width - ClientSize.Width),
                Math.Max(MinimumSize.Height,
                    initialHeight + Height - ClientSize.Height));

            Action updateLayout = () =>
            {
                int availableWidth = ClientSize.Width - margin * 2;

                pnlNoiDungDoiMatKhau.Width = Math.Max(
                    initialWidth,
                    Math.Min(maximumWidth, availableWidth));

                pnlNoiDungDoiMatKhau.Left = Math.Max(
                    0, (ClientSize.Width - pnlNoiDungDoiMatKhau.Width) / 2);

                pnlNoiDungDoiMatKhau.Top = Math.Max(
                    0, (ClientSize.Height - pnlNoiDungDoiMatKhau.Height) / 2);
            };

            Resize += (sender, args) => updateLayout();
            updateLayout();
        }
        internal frmChangePassword(Session session, AccountRow target=null) : this()
        {
            bool reset=target!=null && target.Id!=session.UserId;
            if(reset)
            {
                if(!session.Can(AccountService.Accounts,ActionRight.Edit)) throw new UserMessage("Bạn không được đặt lại mật khẩu.");
                Text="Đặt lại mật khẩu"; lblTieuDe.Text="ĐẶT LẠI MẬT KHẨU";
                lblMatKhauCu.Text="Tài khoản"; lblIconMatKhauCu.Visible=false;
                txtMatKhauCu.UseSystemPasswordChar=false;txtMatKhauCu.Text=target.Name;txtMatKhauCu.ReadOnly=true;
            }
            txtMatKhauMoi.MaxLength=txtNhapLaiMatKhau.MaxLength=128;
            AcceptButton=btnDoiMatKhau; CancelButton=btnHuy; btnHuy.DialogResult=DialogResult.Cancel;
            btnDoiMatKhau.Click+=(s,e)=>Ui.Run(this,()=>{
                new AccountService(session).ChangePassword(target==null ? (int?)null : target.Id,txtMatKhauCu.Text,txtMatKhauMoi.Text,txtNhapLaiMatKhau.Text);
                MessageBox.Show(this,"Đã lưu mật khẩu mới."); DialogResult=DialogResult.OK;
            },lblThongBao);
            Theme.Apply(this);
        }

        private void pnlNoiDungDoiMatKhau_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
