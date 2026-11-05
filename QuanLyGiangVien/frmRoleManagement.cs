using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmRoleManagement : System.Windows.Forms.Form
    {
        private AccountService service;
        private Session session;
        private List<GrantRow> grants;
        private Dictionary<int,int> initial;
        private bool loading;
        public frmRoleManagement()
        {
            InitializeComponent();
            btnThemVaiTro.Visible=false; btnSuaVaiTro.Visible=false; btnXoaVaiTro.Visible=false;
            btnThemVaiTro.Enabled=false; btnSuaVaiTro.Enabled=false; btnXoaVaiTro.Enabled=false;
            txtTenVaiTro.ReadOnly=true; txtMoTaVaiTro.ReadOnly=true;
        }
        internal frmRoleManagement(Session current) : this()
        {
            session=current;service=new AccountService(current);
            dgvPhanQuyen.AutoGenerateColumns=false; dgvPhanQuyen.ReadOnly=false;
            colChucNang.DataPropertyName="Title"; colChucNang.ReadOnly=true;
            colDuocXem.DataPropertyName="View";colDuocThem.DataPropertyName="Add";colDuocSua.DataPropertyName="Edit";colDuocXoa.DataPropertyName="Delete";
            txtTenVaiTro.MaxLength=50;txtMoTaVaiTro.MaxLength=200;
            lstVaiTro.SelectedIndexChanged+=(s,e)=>{if(!loading)Ui.Run(this,ShowRole);};
            btnLuuQuyen.Click+=(s,e)=>Ui.Run(this,()=>{
                dgvPhanQuyen.EndEdit(); var r=Selected();
                if(!Ui.Confirm(this,"Lưu thay đổi phân quyền cho "+r.Name+"?"))return;
                service.SaveGrants(r.Id,grants,initial); ShowRole();MessageBox.Show(this,"Đã lưu quyền.");
            });
            Theme.Apply(this); Reload();
        }
        private RoleInfo Selected(){return lstVaiTro.SelectedItem as RoleInfo ?? throw new UserMessage("Hãy chọn vai trò.");}
        private void Reload()
        {
            loading=true;
            try {lstVaiTro.DisplayMember="Name";lstVaiTro.DataSource=service.ListRoles(AccountService.Roles);}
            finally {loading=false;}
            ShowRole();
        }
        private void ShowRole()
        {
            btnLuuQuyen.Enabled=false; dgvPhanQuyen.DataSource=null;
            var r=lstVaiTro.SelectedItem as RoleInfo;
            txtTenVaiTro.Text=r?.Name ?? "";txtMoTaVaiTro.Text=r?.Description ?? "";
            lblVaiTroDangChon.Text=r==null ? "Chọn một vai trò." : "Quyền của vai trò: "+r.Name;
            if(r==null)return;
            grants=service.Permissions(r.Id);initial=grants.ToDictionary(x=>x.Id,x=>x.Mask);dgvPhanQuyen.DataSource=grants;
            using(var db=Session.Open()) btnLuuQuyen.Enabled=session.Can(AccountService.Roles,ActionRight.Edit) && session.Current(db).MaVaiTro!=r.Id;
            foreach(DataGridViewColumn col in dgvPhanQuyen.Columns) col.ReadOnly=col==colChucNang || !btnLuuQuyen.Enabled;
        }

        private void frmRoleManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
