using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmDegree : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<HOC_VI> rows = new List<HOC_VI>();
        private HOC_VI selected;
        private bool loading;
        private int? maNguoiDung;

        public frmDegree()
        {
            InitializeComponent();
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);
        }

        // Constructor mặc định dành cho Designer; khi chạy nhận mã người dùng đã đăng nhập.
        public frmDegree(int maNguoiDung) : this()
        {
            this.maNguoiDung = maNguoiDung;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Designer chỉ hiển thị giao diện, không đọc dữ liệu hoặc kiểm tra quyền.
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            Theme.Apply(this);
            LoadData();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            loading = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            selected = null;
            HoangFormAccess access = null;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                db?.Dispose();
                db = null;
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmDegree");
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                var newRows = db.HOC_VIs.Where(x => keyword == "" || x.TenHocVi.Contains(keyword) || (byId && x.MaHocVi == id))
                    .OrderBy(x => x.MaHocVi).ToList();
                var displayRows = newRows.Select(x => new { x.MaHocVi, x.TenHocVi }).ToList();
                rows = newRows;
                HoangFormHelper.BindGrid(dgvDanhSach, displayRows);
                lblKetQua.Text = rows.Count + " kết quả";
            });
            if (!ok)
            {
                db?.Dispose();
                db = null;
                rows.Clear();
                dgvDanhSach.DataSource = null;
                lblKetQua.Text = "Chưa tải được dữ liệu";
            }
            ClearInput();
            loading = false;
            btnThem.Enabled = ok && access.Them;
            btnSua.Enabled = ok && access.Sua;
            btnXoa.Enabled = ok && access.Xoa;
        }

        private void ClearInput()
        {
            selected = null;
            txtMaHocVi.Text = "Tự tăng";
            txtTenHocVi.Clear();
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            selected = null;
            if (dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaHocVi"].Value);
            selected = rows.FirstOrDefault(x => x.MaHocVi == id);
            if (selected == null) return;
            txtMaHocVi.Text = selected.MaHocVi.ToString();
            txtTenHocVi.Text = selected.TenHocVi;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmDegree", adding ? "Them" : "Sua");
                string name = txtTenHocVi.Text.Trim();
                HoangFormHelper.Require(name.Length > 0, "Vui lòng nhập tên học vị.");

                var item = adding ? new HOC_VI() : selected;
                HoangFormHelper.Require(adding || item.TenHocVi != name, "Thông tin học vị chưa thay đổi.");

                int currentId = item.MaHocVi;
                HoangFormHelper.Require(!db.HOC_VIs.Any(x => x.TenHocVi == name && (adding || x.MaHocVi != currentId)),
                    "Tên học vị đã tồn tại.");

                writing = true;
                item.TenHocVi = name;
                if (adding) db.HOC_VIs.InsertOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã lưu dữ liệu.", "Thông báo");
            });
            // Giữ dữ liệu nhập khi kiểm tra sai; bỏ entity chờ lưu nếu SubmitChanges lỗi.
            if (writing) LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e) { Save(true); }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                MessageBox.Show(this, "Vui lòng chọn học vị cần sửa.", "Thông báo");
                return;
            }

            Save(false);
        }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(); }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LoadData(); }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var item = selected;
            if (item == null)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa.", "Thông báo");
                return;
            }

            if (!HoangFormHelper.ConfirmDelete(this, item.TenHocVi)) return;
            bool permissionChecked = false;
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmDegree", "Xoa");
                permissionChecked = true;
                HoangFormHelper.Require(!db.GIANG_VIENs.Any(x => x.MaHocVi == item.MaHocVi),
                    "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                writing = true;
                db.HOC_VIs.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            if (writing || !permissionChecked) LoadData();
        }
    }
}
