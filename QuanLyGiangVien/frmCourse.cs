using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmCourse : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<HOC_PHAN> rows = new List<HOC_PHAN>();
        private HOC_PHAN selected;
        private bool loading;
        private int? maNguoiDung;

        public frmCourse()
        {
            InitializeComponent();
            HoangFormHelper.EnableGridBuffering(dgvDanhSach);
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);
        }

        // Constructor mặc định dành cho Designer; khi chạy nhận mã người dùng đã đăng nhập.
        public frmCourse(int maNguoiDung) : this()
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
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmCourse");
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<HOC_PHAN>(x => x.BO_MON);
                db.LoadOptions = loadOptions;

                IQueryable<HOC_PHAN> courses = db.HOC_PHANs;
                IQueryable<BO_MON> departments = db.BO_MONs;
                if (access.ChiXemCaNhan)
                {
                    int? lecturerId = access.MaGV;
                    var ownCourseIds = db.PHAN_CONG_GIANG_DAYs
                        .Where(x => x.MaGV == lecturerId)
                        .Select(x => x.LOP_HOC_PHAN.MaHocPhan);
                    courses = courses.Where(x => ownCourseIds.Contains(x.MaHocPhan));
                    departments = departments.Where(x => x.HOC_PHANs.Any(c => ownCourseIds.Contains(c.MaHocPhan)));
                }

                var departmentItems = departments.OrderBy(x => x.TenBoMon)
                    .Select(x => new { x.MaBoMon, x.TenBoMon }).ToList();
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                var newRows = courses.Where(x => keyword == "" || x.TenHocPhan.Contains(keyword) || (byId && x.MaHocPhan == id))
                    .OrderBy(x => x.MaHocPhan).ToList();
                var gridRows = newRows.Select(x => new { x.MaHocPhan, x.TenHocPhan, x.SoTinChi, x.SoTietLyThuyet, x.SoTietThucHanh, x.TrangThai, TenBoMon = x.BO_MON.TenBoMon }).ToList();
                cboMaBoMon.DisplayMember = "TenBoMon";
                cboMaBoMon.ValueMember = "MaBoMon";
                HoangFormHelper.BindLookup(cboMaBoMon, departmentItems);
                rows = newRows;
                HoangFormHelper.BindGrid(dgvDanhSach, gridRows);
                lblKetQua.Text = rows.Count + " kết quả";
            });
            if (!ok)
            {
                db?.Dispose();
                db = null;
                rows.Clear();
                dgvDanhSach.DataSource = null;
                cboMaBoMon.DataSource = null;
                lblKetQua.Text = "Chưa tải được dữ liệu";
            }
            ClearInput();
            loading = false;
            bool canEdit = ok && !access.ChiXemCaNhan;
            btnThem.Enabled = canEdit && access.Them;
            btnSua.Enabled = canEdit && access.Sua;
            btnXoa.Enabled = canEdit && access.Xoa;
        }

        private void ClearInput()
        {
            selected = null;
            txtMaHocPhan.Text = "Tự tăng";
            txtTenHocPhan.Clear(); numSoTinChi.Value = 1; numSoTietLyThuyet.Value = 0; numSoTietThucHanh.Value = 0; cboMaBoMon.SelectedIndex = -1; chkTrangThai.Checked = true;
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            selected = null;
            if (dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaHocPhan"].Value);
            selected = rows.FirstOrDefault(x => x.MaHocPhan == id);
            if (selected == null) return;
            txtMaHocPhan.Text = selected.MaHocPhan.ToString(); txtTenHocPhan.Text = selected.TenHocPhan; numSoTinChi.Value = selected.SoTinChi; numSoTietLyThuyet.Value = selected.SoTietLyThuyet; numSoTietThucHanh.Value = selected.SoTietThucHanh; cboMaBoMon.SelectedValue = selected.MaBoMon; chkTrangThai.Checked = selected.TrangThai;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                RequireCourseAction(adding ? "Them" : "Sua");
                string name = txtTenHocPhan.Text.Trim();
                HoangFormHelper.Require(name.Length > 0, "Vui lòng nhập tên học phần.");
                int? departmentId = HoangFormHelper.SelectedId(cboMaBoMon);
                var department = departmentId.HasValue
                    ? db.BO_MONs.SingleOrDefault(x => x.MaBoMon == departmentId.Value)
                    : null;
                HoangFormHelper.Require(department != null, "Vui lòng chọn bộ môn hợp lệ.");

                var item = adding ? new HOC_PHAN() : selected;
                item.TenHocPhan = name;
                item.SoTinChi = (int)numSoTinChi.Value;
                item.SoTietLyThuyet = (int)numSoTietLyThuyet.Value;
                item.SoTietThucHanh = (int)numSoTietThucHanh.Value;
                item.BO_MON = department;
                item.TrangThai = chkTrangThai.Checked;

                if (!adding)
                    HoangFormHelper.Require(db.GetChangeSet().Updates.Count > 0, "Thông tin học phần chưa thay đổi.");

                writing = true;
                if (adding) db.HOC_PHANs.InsertOnSubmit(item);
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
                MessageBox.Show(this, "Vui lòng chọn học phần cần sửa.", "Thông báo");
                return;
            }

            Save(false);
        }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(); }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LoadData(); }

        private void RequireCourseAction(string action)
        {
            var access = HoangFormHelper.RequireAction(maNguoiDung, "frmCourse", action);
            HoangFormHelper.Require(!access.ChiXemCaNhan, "Tài khoản giảng viên chỉ được xem học phần đã phân công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var item = selected;
            if (item == null) { MessageBox.Show(this, "Vui lòng chọn học phần cần xóa.", "Thông báo"); return; }
            if (!HoangFormHelper.ConfirmDelete(this, item.TenHocPhan)) return;
            bool permissionChecked = false;
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                RequireCourseAction("Xoa");
                permissionChecked = true;
                HoangFormHelper.Require(!db.LOP_HOC_PHANs.Any(x => x.MaHocPhan == item.MaHocPhan), "Học phần đã có lớp học phần, không thể xóa.");
                writing = true;
                db.HOC_PHANs.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            if (writing || !permissionChecked) LoadData();
        }
    }
}
