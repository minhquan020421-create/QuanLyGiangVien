using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmSpecialization : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<CHUYEN_MON> rows = new List<CHUYEN_MON>();
        private CHUYEN_MON selected;
        private bool loading;
        private int? maNguoiDung;

        public frmSpecialization()
        {
            InitializeComponent();
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);
        }

        // Constructor mặc định dành cho Designer; khi chạy nhận mã người dùng đã đăng nhập.
        public frmSpecialization(int maNguoiDung) : this()
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
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmSpecialization");
                db = new QuanLyGiangVienDataContext();
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                rows = db.CHUYEN_MONs.Where(x => keyword == "" || x.TenChuyenMon.Contains(keyword) || (byId && x.MaChuyenMon == id))
                    .OrderBy(x => x.MaChuyenMon).ToList();
                dgvDanhSach.DataSource = rows.Select(x => new { x.MaChuyenMon, x.TenChuyenMon, x.MoTa, x.TrangThai }).ToList();
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
            txtMaChuyenMon.Text = "Tự tăng";
            txtTenChuyenMon.Clear(); txtMoTa.Clear(); chkTrangThai.Checked = true;
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading || dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaChuyenMon"].Value);
            selected = rows.FirstOrDefault(x => x.MaChuyenMon == id);
            if (selected == null) return;
            txtMaChuyenMon.Text = selected.MaChuyenMon.ToString(); txtTenChuyenMon.Text = selected.TenChuyenMon; txtMoTa.Text = selected.MoTa; chkTrangThai.Checked = selected.TrangThai;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmSpecialization", adding ? "Them" : "Sua");
                HoangFormHelper.Require(adding || selected != null, "Vui lòng chọn dòng cần sửa.");
                HoangFormHelper.Require(txtTenChuyenMon.Text.Trim().Length > 0, "Vui lòng nhập tên.");
                int currentId = adding ? 0 : selected.MaChuyenMon;
                HoangFormHelper.Require(!db.CHUYEN_MONs.Any(x => x.TenChuyenMon == txtTenChuyenMon.Text.Trim() && x.MaChuyenMon != currentId), "Tên đã tồn tại.");
                HoangFormHelper.Require(adding || db.CHUYEN_MONs.Any(x => x.MaChuyenMon == selected.MaChuyenMon), "Bản ghi đã bị xóa. Hãy làm mới danh sách.");
                writing = true;
                var item = adding ? new CHUYEN_MON() : selected;
                item.TenChuyenMon = txtTenChuyenMon.Text.Trim(); item.MoTa = HoangFormHelper.Optional(txtMoTa.Text); item.TrangThai = chkTrangThai.Checked;
                if (adding) db.CHUYEN_MONs.InsertOnSubmit(item);
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
            if (!HoangFormHelper.Run(this, () => HoangFormHelper.RequireAction(maNguoiDung, "frmSpecialization", "Xoa"))) return;
            if (selected == null) { MessageBox.Show(this, "Vui lòng chọn dòng cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, selected.TenChuyenMon)) return;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmSpecialization", "Xoa");
                HoangFormHelper.Require(!(db.GIANG_VIEN_CHUYEN_MONs.Any(x => x.MaChuyenMon == selected.MaChuyenMon)), "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                db.CHUYEN_MONs.DeleteOnSubmit(selected);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            LoadData();
        }
    }
}
