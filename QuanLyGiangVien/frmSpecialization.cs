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
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
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
            txtTenChuyenMon.Clear();
            txtMoTa.Clear();
            chkTrangThai.Checked = true;
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            selected = null;
            if (dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaChuyenMon"].Value);
            selected = rows.FirstOrDefault(x => x.MaChuyenMon == id);
            if (selected == null) return;
            txtMaChuyenMon.Text = selected.MaChuyenMon.ToString();
            txtTenChuyenMon.Text = selected.TenChuyenMon;
            txtMoTa.Text = selected.MoTa;
            chkTrangThai.Checked = selected.TrangThai;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmSpecialization", adding ? "Them" : "Sua");
                string name = txtTenChuyenMon.Text.Trim();
                string description = HoangFormHelper.Optional(txtMoTa.Text);
                bool active = chkTrangThai.Checked;
                HoangFormHelper.Require(name.Length > 0, "Vui lòng nhập tên chuyên môn.");

                var item = adding ? new CHUYEN_MON() : selected;
                bool nameChanged = item.TenChuyenMon != name;
                HoangFormHelper.Require(adding || nameChanged || item.MoTa != description || item.TrangThai != active,
                    "Thông tin chuyên môn chưa thay đổi.");

                if (adding || nameChanged)
                {
                    int currentId = item.MaChuyenMon;
                    HoangFormHelper.Require(!db.CHUYEN_MONs.Any(x => x.TenChuyenMon == name && (adding || x.MaChuyenMon != currentId)),
                        "Tên chuyên môn đã tồn tại.");
                }

                writing = true;
                item.TenChuyenMon = name;
                item.MoTa = description;
                item.TrangThai = active;
                if (adding) db.CHUYEN_MONs.InsertOnSubmit(item);
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
                MessageBox.Show(this, "Vui lòng chọn chuyên môn cần sửa.", "Thông báo");
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

            if (!HoangFormHelper.ConfirmDelete(this, item.TenChuyenMon)) return;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmSpecialization", "Xoa");
                HoangFormHelper.Require(!db.GIANG_VIEN_CHUYEN_MONs.Any(x => x.MaChuyenMon == item.MaChuyenMon),
                    "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                db.CHUYEN_MONs.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            LoadData();
        }
    }
}
