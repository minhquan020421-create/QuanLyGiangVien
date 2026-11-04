using System;
using System.Collections.Generic;
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
            rows.Clear();
            dgvDanhSach.DataSource = null;
            cboMaBoMon.DataSource = null;
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

                cboMaBoMon.DisplayMember = "TenBoMon";
                cboMaBoMon.ValueMember = "MaBoMon";
                cboMaBoMon.DataSource = departments.OrderBy(x => x.TenBoMon)
                    .Select(x => new { x.MaBoMon, x.TenBoMon }).ToList();
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                rows = courses.Where(x => keyword == "" || x.TenHocPhan.Contains(keyword) || (byId && x.MaHocPhan == id))
                    .OrderBy(x => x.MaHocPhan).ToList();
                dgvDanhSach.DataSource = rows.Select(x => new { x.MaHocPhan, x.TenHocPhan, x.SoTinChi, x.SoTietLyThuyet, x.SoTietThucHanh, x.TrangThai, TenBoMon = x.BO_MON.TenBoMon }).ToList();
                lblKetQua.Text = rows.Count + " kết quả";
            });
            if (!ok) lblKetQua.Text = "Chưa tải được dữ liệu";
            loading = false;
            ClearInput();
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
            if (loading || dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaHocPhan"].Value);
            selected = rows.FirstOrDefault(x => x.MaHocPhan == id);
            if (selected == null) return;
            txtMaHocPhan.Text = selected.MaHocPhan.ToString(); txtTenHocPhan.Text = selected.TenHocPhan; numSoTinChi.Value = selected.SoTinChi; numSoTietLyThuyet.Value = selected.SoTietLyThuyet; numSoTietThucHanh.Value = selected.SoTietThucHanh; cboMaBoMon.SelectedValue = selected.MaBoMon; chkTrangThai.Checked = selected.TrangThai;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                RequireCourseAction(adding ? "Them" : "Sua");
                HoangFormHelper.Require(adding || selected != null, "Vui lòng chọn dòng cần sửa.");
                HoangFormHelper.Require(txtTenHocPhan.Text.Trim().Length > 0, "Vui lòng nhập tên.");
                int? MaBoMon = HoangFormHelper.SelectedId(cboMaBoMon);
                HoangFormHelper.Require(MaBoMon.HasValue && db.BO_MONs.Any(x => x.MaBoMon == MaBoMon.Value), "Vui lòng chọn bộ môn hợp lệ.");
                HoangFormHelper.Require(adding || db.HOC_PHANs.Any(x => x.MaHocPhan == selected.MaHocPhan), "Bản ghi đã bị xóa. Hãy làm mới danh sách.");
                writing = true;
                var item = adding ? new HOC_PHAN() : selected;
                item.TenHocPhan = txtTenHocPhan.Text.Trim(); item.SoTinChi = (int)numSoTinChi.Value; item.SoTietLyThuyet = (int)numSoTietLyThuyet.Value; item.SoTietThucHanh = (int)numSoTietThucHanh.Value; item.BO_MON = db.BO_MONs.Single(x => x.MaBoMon == MaBoMon.Value); item.TrangThai = chkTrangThai.Checked;
                if (adding) db.HOC_PHANs.InsertOnSubmit(item);
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

        private void RequireCourseAction(string action)
        {
            var access = HoangFormHelper.RequireAction(maNguoiDung, "frmCourse", action);
            HoangFormHelper.Require(!access.ChiXemCaNhan, "Tài khoản giảng viên chỉ được xem học phần đã phân công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!HoangFormHelper.Run(this, () => RequireCourseAction("Xoa"))) return;
            if (selected == null) { MessageBox.Show(this, "Vui lòng chọn dòng cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, selected.TenHocPhan)) return;
            HoangFormHelper.Run(this, () =>
            {
                RequireCourseAction("Xoa");
                HoangFormHelper.Require(!(db.LOP_HOC_PHANs.Any(x => x.MaHocPhan == selected.MaHocPhan)), "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                db.HOC_PHANs.DeleteOnSubmit(selected);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            LoadData();
        }
    }
}
