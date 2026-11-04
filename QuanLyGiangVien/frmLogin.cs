using System;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmLogin : System.Windows.Forms.Form
    {
        private int failures;
        private DateTime retryAfter;
        public frmLogin()
        {
            InitializeComponent();
            AcceptButton=btnDangNhap; CancelButton=btnThoat;
            btnThoat.Click+=(s,e)=>Close();
            btnDangNhap.Click+=(s,e)=>Ui.Run(this,SignIn,lblThongBao);
            btnTheme.Click+=(s,e)=>Ui.Run(this,Theme.Toggle,lblThongBao);
            btnHienMatKhau.Click+=(s,e)=>{
                txtMatKhau.UseSystemPasswordChar=!txtMatKhau.UseSystemPasswordChar;
                btnHienMatKhau.AccessibleName=txtMatKhau.UseSystemPasswordChar ? "Hiện mật khẩu" : "Ẩn mật khẩu";
                txtMatKhau.Focus(); txtMatKhau.SelectionStart=txtMatKhau.TextLength;
            };
            Load+=(s,e)=>{ Theme.Apply(this); txtTenDangNhap.Text=Preferences.Values.RememberedName; chkGhiNhoDangNhap.Checked=txtTenDangNhap.TextLength>0; };
            chkGhiNhoDangNhap.AccessibleDescription="Chỉ lưu tên đăng nhập trên máy này.";
            chkGhiNhoDangNhap.CheckedChanged+=(s,e)=>{if(!chkGhiNhoDangNhap.Checked) Ui.Run(this,()=>{Preferences.Values.RememberedName="";Preferences.Values.Save();},lblThongBao);};
            txtMatKhau.MaxLength=128; txtTenDangNhap.MaxLength=50;
        }
        private void SignIn()
        {
            if(DateTime.UtcNow<retryAfter) throw new UserMessage("Đã nhập sai nhiều lần. Vui lòng chờ " + (int)Math.Ceiling((retryAfter-DateTime.UtcNow).TotalSeconds) + " giây rồi đăng nhập lại.");
            Session session;
            try { session=Session.Login(txtTenDangNhap.Text,txtMatKhau.Text); }
            catch(InvalidCredentials) {
                if(++failures>=5){failures=0;retryAfter=DateTime.UtcNow.AddSeconds(15);}
                throw;
            }
            txtMatKhau.Clear(); txtMatKhau.UseSystemPasswordChar=true; btnHienMatKhau.AccessibleName="Hiện mật khẩu"; failures=0; retryAfter=DateTime.MinValue;
            Preferences.Values.RememberedName=chkGhiNhoDangNhap.Checked ? session.Username : "";
            Preferences.Values.Save();
            using (var home = new frmMain(session))
            {
                Hide();
                try { home.ShowDialog(); }
                finally { Show(); Activate(); txtMatKhau.Focus(); }
            }
        }

        private void lblMoTa_Click(object sender, EventArgs e)
        {

        }
    }
}
