using System;
using System.Collections.Generic;
using System.Data.Linq;
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
                db?.Dispose();
                db = null;
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmDepartment");
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<BO_MON>(x => x.KHOA);
                db.LoadOptions = loadOptions;
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
            if (!ok)
            {
                db?.Dispose();
                db = null;
                rows.Clear();
                dgvDanhSach.DataSource = null;
                cboMaKhoa.DataSource = null;
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
            txtMaBoMon.Text = "Tự tăng";
            txtTenBoMon.Clear(); cboMaKhoa.SelectedIndex = -1; chkTrangThai.Checked = true;
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            selected = null;
            if (dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaBoMon"].Value);
            selected = rows.FirstOrDefault(x => x.MaBoMon == id);
            if (selected == null) return;
            txtMaBoMon.Text = selected.MaBoMon.ToString(); txtTenBoMon.Text = selected.TenBoMon; cboMaKhoa.SelectedValue = selected.MaKhoa; chkTrangThai.Checked = selected.TrangThai;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmDepartment", adding ? "Them" : "Sua");
                string name = txtTenBoMon.Text.Trim();
                HoangFormHelper.Require(name.Length > 0, "Vui lòng nhập tên bộ môn.");
                int? facultyId = HoangFormHelper.SelectedId(cboMaKhoa);
                var faculty = facultyId.HasValue ? db.KHOAs.SingleOrDefault(x => x.MaKhoa == facultyId.Value) : null;
                HoangFormHelper.Require(faculty != null, "Vui lòng chọn khoa hợp lệ.");

                var item = adding ? new BO_MON() : selected;
                item.TenBoMon = name;
                item.KHOA = faculty;
                item.TrangThai = chkTrangThai.Checked;
                if (!adding)
                    HoangFormHelper.Require(db.GetChangeSet().Updates.Count > 0, "Thông tin bộ môn chưa thay đổi.");

                writing = true;
                if (adding) db.BO_MONs.InsertOnSubmit(item);
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
                MessageBox.Show(this, "Vui lòng chọn bộ môn cần sửa.", "Thông báo");
                return;
            }

            Save(false);
        }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(); }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LoadData(); }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var item = selected;
            if (item == null) { MessageBox.Show(this, "Vui lòng chọn bộ môn cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, item.TenBoMon)) return;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmDepartment", "Xoa");
                HoangFormHelper.Require(!(db.GIANG_VIENs.Any(x => x.MaBoMon == item.MaBoMon) || db.HOC_PHANs.Any(x => x.MaBoMon == item.MaBoMon)), "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                db.BO_MONs.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            LoadData();
        }
    }
}
