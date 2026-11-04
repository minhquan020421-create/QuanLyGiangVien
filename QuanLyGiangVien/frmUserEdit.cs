using System;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmUserEdit : System.Windows.Forms.Form
    {
        public frmUserEdit(){InitializeComponent();}
        internal frmUserEdit(Session session,AccountRow user) : this()
        {
            var service=new AccountService(session); bool create=user==null;
            var right=create ? ActionRight.Add : ActionRight.Edit;
            if(!session.Can(AccountService.Accounts,right)) throw new UserMessage("Bạn không có quyền sửa thông tin tài khoản.");
            Text=create ? "Thêm tài khoản" : "Sửa tài khoản";
            lblTieuDe.Text=Text.ToUpperInvariant(); txtTenDangNhap.MaxLength=50;
            var people=service.Lecturers(right);people.Insert(0,new Choice{Title="— Chưa gắn giảng viên —"});
            cboGiangVien.DisplayMember="Title";cboGiangVien.ValueMember="Id";cboGiangVien.DataSource=people;
            cboVaiTro.DisplayMember="Name";cboVaiTro.ValueMember="Id";cboVaiTro.DataSource=service.ListRoles(AccountService.Accounts);
            // Người quản lý phải chủ động chọn vai trò khi tạo tài khoản.
            cboVaiTro.SelectedIndex=-1;
            if(!create)
            {
                txtTenDangNhap.Text=user.Name; cboGiangVien.SelectedValue=user.LecturerId ?? 0; cboVaiTro.SelectedValue=user.RoleId;
                txtEmailKhoiPhuc.Text=user.RecoveryEmail ?? "";
                txtMatKhau.Enabled=txtXacNhanMatKhau.Enabled=false;
            }
            txtMatKhau.MaxLength=txtXacNhanMatKhau.MaxLength=128;
            AcceptButton=btnLuu;CancelButton=btnHuy;btnHuy.DialogResult=DialogResult.Cancel;
            btnLuu.Click+=(s,e)=>Ui.Run(this,()=>{
                var role=cboVaiTro.SelectedItem as RoleInfo;
                if(role==null) throw new UserMessage("Hãy chọn vai trò cho tài khoản.");
                var person=cboGiangVien.SelectedItem as Choice;
                service.SaveAccount(user,txtTenDangNhap.Text,person==null || person.Id==0 ? (int?)null : person.Id,
                    role.Id,txtEmailKhoiPhuc.Text,txtMatKhau.Text,txtXacNhanMatKhau.Text);
                DialogResult=DialogResult.OK;
            },lblThongBao);
            Theme.Apply(this);
        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
