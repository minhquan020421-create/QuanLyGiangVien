using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmDepartment : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<BO_MON> rows = new List<BO_MON>();
        private BO_MON selected;
        private bool loading;
        private int? maNguoiDung;

        public frmDepartment()
        {
            InitializeComponent();
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);
        }

        // Constructor mặc định dành cho Designer; khi chạy nhận mã người dùng đã đăng nhập.
        public frmDepartment(int maNguoiDung) : this()
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
            rows.Clear();
            dgvDanhSach.DataSource = null;
            HoangFormAccess access = null;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                if (db != null) db.Dispose();
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmDepartment");
                db = new QuanLyGiangVienDataContext();
                cboMaKhoa.DisplayMember = "TenKhoa";
                cboMaKhoa.ValueMember = "MaKhoa";
                cboMaKhoa.DataSource = db.KHOAs.OrderBy(x => x.TenKhoa).Select(x => new { x.MaKhoa, x.TenKhoa }).ToList();
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                rows = db.BO_MONs.Where(x => keyword == "" || x.TenBoMon.Contains(keyword) || (byId && x.MaBoMon == id))
                    .OrderBy(x => x.MaBoMon).ToList();
                dgvDanhSach.DataSource = rows.Select(x => new { x.MaBoMon, x.TenBoMon, x.TrangThai, TenKhoa = x.KHOA.TenKhoa }).ToList();
                lblKetQua.Text = rows.Count + " kết quả";
            });
            if (!ok) lblKetQua.Text = "Chưa tải được dữ liệu";
            loading = false;
            ClearInput();
            btnThem.Enabled = ok && access.Them;
            btnSua.Enabled = ok && access.Sua;
            btnXoa.Enabled = ok && access.Xoa;
        }

        private void ClearInput()
        {
            selected = null;
            txtMaBoMon.Text = "Tự tăng";
            txtTenBoMon.Clear(); cboMaKhoa.SelectedIndex = -1; chkTrangThai.Checked = true;
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading || dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaBoMon"].Value);
            selected = rows.FirstOrDefault(x => x.MaBoMon == id);
            if (selected == null) return;
            txtMaBoMon.Text = selected.MaBoMon.ToString(); txtTenBoMon.Text = selected.TenBoMon; cboMaKhoa.SelectedValue = selected.MaKhoa; chkTrangThai.Checked = selected.TrangThai;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmDepartment", adding ? "Them" : "Sua");
                HoangFormHelper.Require(adding || selected != null, "Vui lòng chọn dòng cần sửa.");
                HoangFormHelper.Require(txtTenBoMon.Text.Trim().Length > 0, "Vui lòng nhập tên.");
                int? MaKhoa = HoangFormHelper.SelectedId(cboMaKhoa);
                HoangFormHelper.Require(MaKhoa.HasValue && db.KHOAs.Any(x => x.MaKhoa == MaKhoa.Value), "Vui lòng chọn khoa hợp lệ.");
                HoangFormHelper.Require(adding || db.BO_MONs.Any(x => x.MaBoMon == selected.MaBoMon), "Bản ghi đã bị xóa. Hãy làm mới danh sách.");
                writing = true;
                var item = adding ? new BO_MON() : selected;
                item.TenBoMon = txtTenBoMon.Text.Trim(); item.KHOA = db.KHOAs.Single(x => x.MaKhoa == MaKhoa.Value); item.TrangThai = chkTrangThai.Checked;
                if (adding) db.BO_MONs.InsertOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã lưu dữ liệu.", "Thông báo");
            });
            // Giữ dữ liệu nhập khi kiểm tra sai; bỏ entity chờ lưu nếu SubmitChanges lỗi.
            if (ok || writing) LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e) { Save(true); }
        private void btnSua_Click(object sender, EventArgs e) { Save(false); }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(); }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LoadData(); }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!HoangFormHelper.Run(this, () => HoangFormHelper.RequireAction(maNguoiDung, "frmDepartment", "Xoa"))) return;
            if (selected == null) { MessageBox.Show(this, "Vui lòng chọn dòng cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, selected.TenBoMon)) return;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmDepartment", "Xoa");
                HoangFormHelper.Require(!(db.GIANG_VIENs.Any(x => x.MaBoMon == selected.MaBoMon) || db.HOC_PHANs.Any(x => x.MaBoMon == selected.MaBoMon)), "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                db.BO_MONs.DeleteOnSubmit(selected);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            LoadData();
        }
    }
}
