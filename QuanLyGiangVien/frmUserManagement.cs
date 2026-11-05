using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmUserManagement : System.Windows.Forms.Form
    {
        private Session session;
        private AccountService service;
        private bool mayEdit, mayDelete;
        public frmUserManagement() { InitializeComponent(); }
        internal frmUserManagement(Session current) : this()
        {
            session=current; service=new AccountService(session);
            dgvTaiKhoan.AutoGenerateColumns=false;
            colMaNguoiDung.DataPropertyName="Id"; colTenDangNhap.DataPropertyName="Name";
            colGiangVien.DataPropertyName="Lecturer"; colVaiTro.DataPropertyName="Role"; colTrangThai.DataPropertyName="Status";
            dgvTaiKhoan.ReadOnly=true; dgvTaiKhoan.SelectionMode=DataGridViewSelectionMode.FullRowSelect; dgvTaiKhoan.MultiSelect=false;
            AcceptButton=btnTimKiem;
            cboLocTrangThai.Items.Clear();
            cboLocTrangThai.Items.AddRange(new object[]{"Tất cả trạng thái","Hoạt động","Đã khóa"});
            cboLocTrangThai.SelectedIndex=0;
            var roles=service.ListRoles(AccountService.Accounts);
            roles.Insert(0,new RoleInfo{Name="Tất cả vai trò"});
            cboLocVaiTro.DataSource=roles;
            btnTimKiem.Click+=(s,e)=>Ui.Run(this,RefreshList);
            btnLamMoi.Click+=(s,e)=>Ui.Run(this,()=>{txtTimKiem.Clear();cboLocVaiTro.SelectedIndex=0;cboLocTrangThai.SelectedIndex=0;RefreshList();});
            btnThem.Click+=(s,e)=>Ui.Run(this,()=>Edit(null));
            btnSua.Click+=(s,e)=>Ui.Run(this,()=>Edit(Selected()));
            btnDoiMatKhau.Click+=(s,e)=>Ui.Run(this,()=>{using(var f=new frmChangePassword(session,Selected())) f.ShowDialog(this);});
            btnKhoa.Click+=(s,e)=>Ui.Run(this,()=>SetState(false));
            btnMoKhoa.Click+=(s,e)=>Ui.Run(this,()=>SetState(true));
            btnXoa.Click+=(s,e)=>Ui.Run(this,()=>{var u=Selected(); if(Ui.Confirm(this,"Xóa tài khoản "+u.Name+"?")){service.DeleteAccount(u.Id); RefreshList();}});
            dgvTaiKhoan.SelectionChanged+=(s,e)=>UpdateActions();
            Theme.Apply(this); RefreshList();
        }
        private AccountRow Selected()
        {
            var user=dgvTaiKhoan.CurrentRow?.DataBoundItem as AccountRow;
            return user ?? throw new UserMessage("Hãy chọn một tài khoản.");
        }
        private void Edit(AccountRow user)
        {
            using(var f=new frmUserEdit(session,user)) if(f.ShowDialog(this)==DialogResult.OK) RefreshList();
        }
        private void SetState(bool active)
        {
            var u=Selected();
            if(Ui.Confirm(this,(active ? "Mở khóa " : "Khóa ")+u.Name+"?")){service.SetActive(u.Id,active);RefreshList();}
        }
        private void RefreshList()
        {
            var role=cboLocVaiTro.SelectedItem as RoleInfo;
            int state=cboLocTrangThai.SelectedIndex==1 ? 1 : cboLocTrangThai.SelectedIndex==2 ? 0 : -1;
            dgvTaiKhoan.DataSource=null;
            var rows=service.Users(txtTimKiem.Text,role?.Id ?? 0,state);
            dgvTaiKhoan.DataSource=rows;
            lblTongTaiKhoan.Text="Tổng số tài khoản: "+rows.Count;
            btnThem.Enabled=session.Can(AccountService.Accounts,ActionRight.Add);
            mayEdit=session.Can(AccountService.Accounts,ActionRight.Edit);
            mayDelete=session.Can(AccountService.Accounts,ActionRight.Delete);
            UpdateActions();
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {

        }

        private void UpdateActions()
        {
            var u=dgvTaiKhoan.CurrentRow?.DataBoundItem as AccountRow;
            btnSua.Enabled=btnDoiMatKhau.Enabled=u!=null && mayEdit;
            btnKhoa.Enabled=u!=null && u.Id!=session.UserId && u.Active && mayEdit;
            btnMoKhoa.Enabled=u!=null && !u.Active && mayEdit;
            btnXoa.Enabled=u!=null && u.Id!=session.UserId && mayDelete;
        }
    }
}
