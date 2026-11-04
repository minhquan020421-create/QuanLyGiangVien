using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmPosition : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<CHUC_VU> rows = new List<CHUC_VU>();
        private CHUC_VU selected;
        private bool loading;
        private int? maNguoiDung;

        public frmPosition()
        {
            InitializeComponent();
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);
        }

        // Constructor mặc định dành cho Designer; khi chạy nhận mã người dùng đã đăng nhập.
        public frmPosition(int maNguoiDung) : this()
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
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmPosition");
                db = new QuanLyGiangVienDataContext();
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                rows = db.CHUC_VUs.Where(x => keyword == "" || x.TenChucVu.Contains(keyword) || (byId && x.MaChucVu == id))
                    .OrderBy(x => x.MaChucVu).ToList();
                dgvDanhSach.DataSource = rows.Select(x => new { x.MaChucVu, x.TenChucVu }).ToList();
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
            txtMaChucVu.Text = "Tự tăng";
            txtTenChucVu.Clear();
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading || dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaChucVu"].Value);
            selected = rows.FirstOrDefault(x => x.MaChucVu == id);
            if (selected == null) return;
            txtMaChucVu.Text = selected.MaChucVu.ToString(); txtTenChucVu.Text = selected.TenChucVu;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmPosition", adding ? "Them" : "Sua");
                HoangFormHelper.Require(adding || selected != null, "Vui lòng chọn dòng cần sửa.");
                HoangFormHelper.Require(txtTenChucVu.Text.Trim().Length > 0, "Vui lòng nhập tên.");
                int currentId = adding ? 0 : selected.MaChucVu;
                HoangFormHelper.Require(!db.CHUC_VUs.Any(x => x.TenChucVu == txtTenChucVu.Text.Trim() && x.MaChucVu != currentId), "Tên đã tồn tại.");
                HoangFormHelper.Require(adding || db.CHUC_VUs.Any(x => x.MaChucVu == selected.MaChucVu), "Bản ghi đã bị xóa. Hãy làm mới danh sách.");
                writing = true;
                var item = adding ? new CHUC_VU() : selected;
                item.TenChucVu = txtTenChucVu.Text.Trim();
                if (adding) db.CHUC_VUs.InsertOnSubmit(item);
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
            if (!HoangFormHelper.Run(this, () => HoangFormHelper.RequireAction(maNguoiDung, "frmPosition", "Xoa"))) return;
            if (selected == null) { MessageBox.Show(this, "Vui lòng chọn dòng cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, selected.TenChucVu)) return;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmPosition", "Xoa");
                HoangFormHelper.Require(!(db.GIANG_VIENs.Any(x => x.MaChucVu == selected.MaChucVu)), "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                db.CHUC_VUs.DeleteOnSubmit(selected);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            LoadData();
        }
    }
}
