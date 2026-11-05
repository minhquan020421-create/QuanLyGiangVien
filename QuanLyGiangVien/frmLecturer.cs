using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmLecturer : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<GIANG_VIEN> rows = new List<GIANG_VIEN>();
        private List<DepartmentItem> departments = new List<DepartmentItem>();
        private GIANG_VIEN selected;
        private bool loading;
        private int? maNguoiDung;

        private sealed class DepartmentItem
        {
            public int Id { get; set; }
            public int FacultyId { get; set; }
            public string Name { get; set; }
        }

        public frmLecturer()
        {
            InitializeComponent();
            HoangFormHelper.EnableGridBuffering(dgvDanhSach);
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);
        }

        // Constructor mặc định dành cho Designer; khi chạy nhận mã người dùng đã đăng nhập.
        public frmLecturer(int maNguoiDung) : this()
        {
            this.maNguoiDung = maNguoiDung;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Designer chỉ hiển thị giao diện, không đọc dữ liệu hoặc kiểm tra quyền.
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            Theme.Apply(this);
            cboGioiTinh.Items.AddRange(new object[] { "", "Nam", "Nữ", "Khác" });
            cboLocTrangThai.Items.AddRange(new object[] { "Tất cả", "Đang hoạt động", "Ngừng hoạt động" });
            cboLocTrangThai.SelectedIndex = 0;
            LoadData(true);
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadData(bool resetFilters)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            int? khoa = resetFilters ? null : HoangFormHelper.SelectedId(cboLocKhoa);
            int? boMon = resetFilters ? null : HoangFormHelper.SelectedId(cboLocBoMon);
            int? hocVi = resetFilters ? null : HoangFormHelper.SelectedId(cboLocHocVi);
            loading = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            selected = null;
            HoangFormAccess access = null;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                db?.Dispose();
                db = null;
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmLecturer");
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<GIANG_VIEN>(x => x.BO_MON);
                loadOptions.LoadWith<BO_MON>(x => x.KHOA);
                loadOptions.LoadWith<GIANG_VIEN>(x => x.HOC_VI);
                loadOptions.LoadWith<GIANG_VIEN>(x => x.CHUC_VU);
                db.LoadOptions = loadOptions;
                var faculties = db.KHOAs.OrderBy(x => x.TenKhoa).Select(x => new { Id = x.MaKhoa, Name = x.TenKhoa }).ToList();
                var degrees = db.HOC_VIs.OrderBy(x => x.TenHocVi).Select(x => new { Id = x.MaHocVi, Name = x.TenHocVi }).ToList();
                var positions = db.CHUC_VUs.OrderBy(x => x.TenChucVu).Select(x => new { Id = x.MaChucVu, Name = x.TenChucVu }).ToList();
                var loadedDepartments = db.BO_MONs.OrderBy(x => x.TenBoMon)
                    .Select(x => new DepartmentItem { Id = x.MaBoMon, FacultyId = x.MaKhoa, Name = x.TenBoMon }).ToList();

                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                int filterFaculty = faculties.Any(x => x.Id == khoa) ? khoa.Value : 0;
                int filterDepartment = loadedDepartments.Any(x => x.Id == boMon && (filterFaculty == 0 || x.FacultyId == filterFaculty))
                    ? boMon.Value : 0;
                int filterDegree = degrees.Any(x => x.Id == hocVi) ? hocVi.Value : 0;
                int state = cboLocTrangThai.SelectedIndex;
                var query = db.GIANG_VIENs.Where(x => keyword == "" || x.HoTen.Contains(keyword) || (byId && x.MaGV == id));
                if (access.ChiXemCaNhan)
                {
                    int? ownId = access.MaGV;
                    query = query.Where(x => x.MaGV == ownId);
                }
                if (filterFaculty > 0) query = query.Where(x => x.BO_MON.MaKhoa == filterFaculty);
                if (filterDepartment > 0) query = query.Where(x => x.MaBoMon == filterDepartment);
                if (filterDegree > 0) query = query.Where(x => x.MaHocVi == filterDegree);
                if (state == 1) query = query.Where(x => x.TrangThai);
                if (state == 2) query = query.Where(x => !x.TrangThai);
                // Truy vấn SQL trước, sau đó giữ entity gốc để LINQ kiểm tra xung đột khi lưu.
                var loadedRows = query.OrderBy(x => x.MaGV).ToList();
                var displayRows = loadedRows.Select(x => new
                {
                    x.MaGV, x.HoTen, x.NgaySinh, x.GioiTinh, x.Email, x.SoDienThoai,
                    x.DiaChi, x.NgayVaoTruong, x.TrangThai,
                    TenKhoa = x.BO_MON.KHOA.TenKhoa,
                    TenBoMon = x.BO_MON.TenBoMon,
                    TenHocVi = x.HOC_VI.TenHocVi,
                    TenChucVu = x.CHUC_VU == null ? "" : x.CHUC_VU.TenChucVu
                }).ToList();

                // Chỉ cập nhật giao diện sau khi toàn bộ dữ liệu đã tải thành công.
                cboMaKhoa.DisplayMember = cboLocKhoa.DisplayMember = "Name";
                cboMaKhoa.ValueMember = cboLocKhoa.ValueMember = "Id";
                HoangFormHelper.BindLookup(cboMaKhoa, faculties.ToList());
                faculties.Insert(0, new { Id = 0, Name = "Tất cả khoa" });
                HoangFormHelper.BindLookup(cboLocKhoa, faculties);
                cboLocKhoa.SelectedValue = filterFaculty;

                cboMaHocVi.DisplayMember = cboLocHocVi.DisplayMember = "Name";
                cboMaHocVi.ValueMember = cboLocHocVi.ValueMember = "Id";
                HoangFormHelper.BindLookup(cboMaHocVi, degrees.ToList());
                degrees.Insert(0, new { Id = 0, Name = "Tất cả học vị" });
                HoangFormHelper.BindLookup(cboLocHocVi, degrees);
                cboLocHocVi.SelectedValue = filterDegree;

                positions.Insert(0, new { Id = 0, Name = "Không có chức vụ" });
                cboMaChucVu.DisplayMember = "Name";
                cboMaChucVu.ValueMember = "Id";
                HoangFormHelper.BindLookup(cboMaChucVu, positions);
                departments = loadedDepartments;
                LoadFilterDepartments(filterDepartment);
                rows = loadedRows;
                HoangFormHelper.BindGrid(dgvDanhSach, displayRows);
                lblKetQua.Text = rows.Count + " kết quả";
            });
            if (!ok)
            {
                db?.Dispose();
                db = null;
                rows.Clear();
                departments.Clear();
                dgvDanhSach.DataSource = null;
                cboMaKhoa.DataSource = cboMaHocVi.DataSource = cboMaChucVu.DataSource = null;
                cboLocKhoa.DataSource = cboLocBoMon.DataSource = cboLocHocVi.DataSource = null;
                lblKetQua.Text = "Chưa tải được dữ liệu";
            }
            ClearInput();
            loading = false;
            btnThem.Enabled = ok && access.Them && !access.ChiXemCaNhan;
            bool canSelectRecord = ok && (!access.ChiXemCaNhan || access.MaGV.HasValue);
            btnSua.Enabled = canSelectRecord && access.Sua;
            btnXoa.Enabled = canSelectRecord && access.Xoa;
        }

        private void LoadFilterDepartments(int? selectedId)
        {
            int khoa = HoangFormHelper.SelectedId(cboLocKhoa) ?? 0;
            var items = departments.Where(x => khoa == 0 || x.FacultyId == khoa)
                .Select(x => new { x.Id, x.Name }).ToList();
            items.Insert(0, new { Id = 0, Name = "Tất cả bộ môn" });
            cboLocBoMon.DisplayMember = "Name";
            cboLocBoMon.ValueMember = "Id";
            HoangFormHelper.BindLookup(cboLocBoMon, items);
            cboLocBoMon.SelectedValue = selectedId ?? 0;
            if (cboLocBoMon.SelectedIndex < 0) cboLocBoMon.SelectedValue = 0;
        }

        private void LoadEntryDepartments()
        {
            int? khoa = HoangFormHelper.SelectedId(cboMaKhoa);
            if (!khoa.HasValue)
            {
                cboMaBoMon.DataSource = null;
                return;
            }
            cboMaBoMon.DisplayMember = "Name";
            cboMaBoMon.ValueMember = "Id";
            var items = departments.Where(x => x.FacultyId == khoa.Value)
                .Select(x => new { x.Id, x.Name }).ToList();
            HoangFormHelper.BindLookup(cboMaBoMon, items);
            cboMaBoMon.SelectedIndex = -1;
        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading || db == null) return;
            HoangFormHelper.Run(this, LoadEntryDepartments);
        }

        private void cboLocKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading || db == null) return;
            HoangFormHelper.Run(this, () => LoadFilterDepartments(null));
        }

        private void ClearInput()
        {
            selected = null;
            txtMaGV.Text = "Tự tăng";
            txtHoTen.Clear(); txtEmail.Clear(); txtSoDienThoai.Clear(); txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Today; dtpNgaySinh.Checked = false;
            dtpNgayVaoTruong.Value = DateTime.Today; dtpNgayVaoTruong.Checked = false;
            cboGioiTinh.SelectedIndex = 0;
            cboMaKhoa.SelectedIndex = -1;
            cboMaBoMon.DataSource = null;
            cboMaHocVi.SelectedIndex = -1;
            if (cboMaChucVu.DataSource != null) cboMaChucVu.SelectedValue = 0;
            chkTrangThai.Checked = true;
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            selected = null;
            if (dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaGV"].Value);
            selected = rows.FirstOrDefault(x => x.MaGV == id);
            if (selected == null) return;
            loading = true;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                txtMaGV.Text = selected.MaGV.ToString();
                txtHoTen.Text = selected.HoTen; txtEmail.Text = selected.Email;
                txtSoDienThoai.Text = selected.SoDienThoai; txtDiaChi.Text = selected.DiaChi;
                cboGioiTinh.SelectedItem = selected.GioiTinh ?? "";
                dtpNgaySinh.Value = selected.NgaySinh ?? DateTime.Today;
                dtpNgaySinh.Checked = selected.NgaySinh.HasValue;
                dtpNgayVaoTruong.Value = selected.NgayVaoTruong ?? DateTime.Today;
                dtpNgayVaoTruong.Checked = selected.NgayVaoTruong.HasValue;
                cboMaKhoa.SelectedValue = selected.BO_MON.MaKhoa;
                LoadEntryDepartments();
                cboMaBoMon.SelectedValue = selected.MaBoMon;
                cboMaHocVi.SelectedValue = selected.MaHocVi;
                cboMaChucVu.SelectedValue = selected.MaChucVu ?? 0;
                chkTrangThai.Checked = selected.TrangThai;
            });
            if (!ok) ClearInput();
            loading = false;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                var permission = HoangFormHelper.RequireAction(maNguoiDung, "frmLecturer", adding ? "Them" : "Sua");
                HoangFormHelper.Require(!permission.ChiXemCaNhan || (!adding && selected.MaGV == permission.MaGV),
                    "Bạn chỉ được thao tác trên hồ sơ giảng viên của mình.");
                string name = txtHoTen.Text.Trim();
                HoangFormHelper.Require(name.Length > 0, "Vui lòng nhập họ tên.");
                string email = txtEmail.Text.Trim();
                HoangFormHelper.CheckEmail(email, true);
                HoangFormHelper.CheckPhone(txtSoDienThoai.Text.Trim());

                DateTime? birth = dtpNgaySinh.Checked ? (DateTime?)dtpNgaySinh.Value.Date : null;
                DateTime? joined = dtpNgayVaoTruong.Checked ? (DateTime?)dtpNgayVaoTruong.Value.Date : null;
                HoangFormHelper.Require(!birth.HasValue || birth.Value <= DateTime.Today, "Ngày sinh không được ở tương lai.");
                HoangFormHelper.Require(!birth.HasValue || !joined.HasValue || joined.Value >= birth.Value, "Ngày vào trường không được trước ngày sinh.");

                int currentId = adding ? 0 : selected.MaGV;
                HoangFormHelper.Require(!db.GIANG_VIENs.Any(x => x.Email == email && x.MaGV != currentId), "Email đã được giảng viên khác sử dụng.");

                int? facultyId = HoangFormHelper.SelectedId(cboMaKhoa);
                int? departmentId = HoangFormHelper.SelectedId(cboMaBoMon);
                int? degreeId = HoangFormHelper.SelectedId(cboMaHocVi);
                int? positionId = HoangFormHelper.SelectedId(cboMaChucVu);
                var department = facultyId.HasValue && departmentId.HasValue
                    ? db.BO_MONs.SingleOrDefault(x => x.MaBoMon == departmentId.Value && x.MaKhoa == facultyId.Value)
                    : null;
                HoangFormHelper.Require(department != null, "Vui lòng chọn khoa và bộ môn phù hợp.");
                var degree = degreeId.HasValue ? db.HOC_VIs.SingleOrDefault(x => x.MaHocVi == degreeId.Value) : null;
                HoangFormHelper.Require(degree != null, "Vui lòng chọn học vị hợp lệ.");
                CHUC_VU position = null;
                if (positionId.HasValue && positionId.Value != 0)
                {
                    position = db.CHUC_VUs.SingleOrDefault(x => x.MaChucVu == positionId.Value);
                    HoangFormHelper.Require(position != null, "Chức vụ không còn tồn tại. Hãy tải lại danh sách.");
                }

                var item = adding ? new GIANG_VIEN() : selected;
                item.HoTen = name;
                item.Email = email;
                item.NgaySinh = birth;
                item.NgayVaoTruong = joined;
                item.GioiTinh = HoangFormHelper.Optional(cboGioiTinh.Text);
                item.SoDienThoai = HoangFormHelper.Optional(txtSoDienThoai.Text);
                item.DiaChi = HoangFormHelper.Optional(txtDiaChi.Text);
                // Dùng entity liên quan: tránh ForeignKeyReferenceAlreadyHasValueException
                // khi navigation property đã được đọc để hiển thị tên.
                item.BO_MON = department;
                item.HOC_VI = degree;
                item.CHUC_VU = position;
                item.TrangThai = chkTrangThai.Checked;
                if (!adding)
                    HoangFormHelper.Require(db.GetChangeSet().Updates.Count > 0, "Thông tin giảng viên chưa thay đổi.");

                writing = true;
                if (adding) db.GIANG_VIENs.InsertOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã lưu giảng viên.", "Thông báo");
            });
            if (writing) LoadData(false);
        }

        private void btnThem_Click(object sender, EventArgs e) { Save(true); }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                MessageBox.Show(this, "Vui lòng chọn giảng viên cần sửa.", "Thông báo");
                return;
            }

            Save(false);
        }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(false); }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThai.SelectedIndex = 0;
            LoadData(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var item = selected;
            if (item == null) { MessageBox.Show(this, "Vui lòng chọn giảng viên cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, item.HoTen)) return;
            bool permissionChecked = false;
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                var permission = HoangFormHelper.RequireAction(maNguoiDung, "frmLecturer", "Xoa");
                HoangFormHelper.Require(!permission.ChiXemCaNhan || item.MaGV == permission.MaGV,
                    "Bạn chỉ được thao tác trên hồ sơ giảng viên của mình.");
                permissionChecked = true;
                int id = item.MaGV;
                HoangFormHelper.Require(!db.PHAN_CONG_GIANG_DAYs.Any(x => x.MaGV == id)
                    && !db.GIANG_VIEN_CHUYEN_MONs.Any(x => x.MaGV == id)
                    && !db.NGUOI_DUNGs.Any(x => x.MaGV == id),
                    "Giảng viên đang có phân công, chuyên môn hoặc tài khoản liên quan. Không thể xóa. Có thể sửa trạng thái thành ngừng hoạt động nếu phù hợp.");
                writing = true;
                db.GIANG_VIENs.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa giảng viên.", "Thông báo");
            });
            if (writing || !permissionChecked) LoadData(false);
        }
    }
}
