using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmLecturer : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<GIANG_VIEN> rows = new List<GIANG_VIEN>();
        private GIANG_VIEN selected;
        private bool loading;
        private int? maNguoiDung;

        public frmLecturer()
        {
            InitializeComponent();
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
            rows.Clear();
            dgvDanhSach.DataSource = null;
            HoangFormAccess access = null;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                if (db != null) db.Dispose();
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmLecturer");
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
                // ComboBox nhập liệu không có giá trị "Tất cả".
                var faculties = db.KHOAs.OrderBy(x => x.TenKhoa).Select(x => new { Id = x.MaKhoa, Name = x.TenKhoa }).ToList();
                cboMaKhoa.DisplayMember = "Name";
                cboMaKhoa.ValueMember = "Id";
                cboMaKhoa.DataSource = faculties.ToList();
                cboLocKhoa.DisplayMember = "Name";
                cboLocKhoa.ValueMember = "Id";
                faculties.Insert(0, new { Id = 0, Name = "Tất cả khoa" });
                cboLocKhoa.DataSource = faculties;
                cboLocKhoa.SelectedValue = khoa ?? 0;
                if (cboLocKhoa.SelectedIndex < 0) cboLocKhoa.SelectedValue = 0;

                var degrees = db.HOC_VIs.OrderBy(x => x.TenHocVi).Select(x => new { Id = x.MaHocVi, Name = x.TenHocVi }).ToList();
                cboMaHocVi.DisplayMember = "Name";
                cboMaHocVi.ValueMember = "Id";
                cboMaHocVi.DataSource = degrees.ToList();
                cboLocHocVi.DisplayMember = "Name";
                cboLocHocVi.ValueMember = "Id";
                degrees.Insert(0, new { Id = 0, Name = "Tất cả học vị" });
                cboLocHocVi.DataSource = degrees;
                cboLocHocVi.SelectedValue = hocVi ?? 0;
                if (cboLocHocVi.SelectedIndex < 0) cboLocHocVi.SelectedValue = 0;

                var positions = db.CHUC_VUs.OrderBy(x => x.TenChucVu).Select(x => new { Id = x.MaChucVu, Name = x.TenChucVu }).ToList();
                positions.Insert(0, new { Id = 0, Name = "Không có chức vụ" });
                cboMaChucVu.DisplayMember = "Name";
                cboMaChucVu.ValueMember = "Id";
                cboMaChucVu.DataSource = positions;
                LoadFilterDepartments(boMon);

                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                int filterFaculty = HoangFormHelper.SelectedId(cboLocKhoa) ?? 0;
                int filterDepartment = HoangFormHelper.SelectedId(cboLocBoMon) ?? 0;
                int filterDegree = HoangFormHelper.SelectedId(cboLocHocVi) ?? 0;
                int state = cboLocTrangThai.SelectedIndex;
                var query = db.GIANG_VIENs.Where(x => keyword == "" || x.HoTen.Contains(keyword) || (byId && x.MaGV == id));
                if (access.ChiXemCaNhan)
                {
                    int ownId = access.MaGV ?? -1;
                    query = query.Where(x => x.MaGV == ownId);
                }
                if (filterFaculty > 0) query = query.Where(x => x.BO_MON.MaKhoa == filterFaculty);
                if (filterDepartment > 0) query = query.Where(x => x.MaBoMon == filterDepartment);
                if (filterDegree > 0) query = query.Where(x => x.MaHocVi == filterDegree);
                if (state == 1) query = query.Where(x => x.TrangThai);
                if (state == 2) query = query.Where(x => !x.TrangThai);
                // Truy vấn SQL trước, sau đó giữ entity gốc để LINQ kiểm tra xung đột khi lưu.
                rows = query.OrderBy(x => x.MaGV).ToList();
                dgvDanhSach.DataSource = rows.Select(x => new
                {
                    x.MaGV, x.HoTen, x.NgaySinh, x.GioiTinh, x.Email, x.SoDienThoai,
                    x.DiaChi, x.NgayVaoTruong, x.TrangThai,
                    TenKhoa = x.BO_MON.KHOA.TenKhoa,
                    TenBoMon = x.BO_MON.TenBoMon,
                    TenHocVi = x.HOC_VI.TenHocVi,
                    TenChucVu = x.CHUC_VU == null ? "" : x.CHUC_VU.TenChucVu
                }).ToList();
                lblKetQua.Text = rows.Count + " kết quả";
            });
            if (!ok) lblKetQua.Text = "Chưa tải được dữ liệu";
            ClearInput();
            loading = false;
            btnThem.Enabled = ok && access.Them;
            btnSua.Enabled = ok && access.Sua;
            btnXoa.Enabled = ok && access.Xoa;
        }

        private void LoadFilterDepartments(int? selectedId)
        {
            int khoa = HoangFormHelper.SelectedId(cboLocKhoa) ?? 0;
            var items = db.BO_MONs.Where(x => khoa == 0 || x.MaKhoa == khoa)
                .OrderBy(x => x.TenBoMon).Select(x => new { Id = x.MaBoMon, Name = x.TenBoMon }).ToList();
            items.Insert(0, new { Id = 0, Name = "Tất cả bộ môn" });
            cboLocBoMon.DisplayMember = "Name";
            cboLocBoMon.ValueMember = "Id";
            cboLocBoMon.DataSource = items;
            cboLocBoMon.SelectedValue = selectedId ?? 0;
            if (cboLocBoMon.SelectedIndex < 0) cboLocBoMon.SelectedValue = 0;
        }

        private void LoadEntryDepartments()
        {
            cboMaBoMon.DataSource = null;
            int? khoa = HoangFormHelper.SelectedId(cboMaKhoa);
            if (!khoa.HasValue) return;
            cboMaBoMon.DisplayMember = "Name";
            cboMaBoMon.ValueMember = "Id";
            cboMaBoMon.DataSource = db.BO_MONs.Where(x => x.MaKhoa == khoa.Value)
                .OrderBy(x => x.TenBoMon).Select(x => new { Id = x.MaBoMon, Name = x.TenBoMon }).ToList();
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
            // Xóa bộ môn cũ trước khi tải, tránh lọc bộ môn không thuộc khoa mới khi kết nối lỗi.
            cboLocBoMon.DataSource = null;
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
            if (loading || dgvDanhSach.SelectedRows.Count == 0) return;
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
            bool ok = HoangFormHelper.Run(this, () =>
            {
                var permission = HoangFormHelper.RequireAction(maNguoiDung, "frmLecturer", adding ? "Them" : "Sua");
                HoangFormHelper.Require(adding || selected != null, "Vui lòng chọn giảng viên cần sửa.");
                HoangFormHelper.Require(txtHoTen.Text.Trim().Length > 0, "Vui lòng nhập họ tên.");
                HoangFormHelper.Require(!permission.ChiXemCaNhan || (!adding && selected.MaGV == permission.MaGV),
                    "Bạn chỉ được thao tác trên hồ sơ giảng viên của mình.");
                string email = txtEmail.Text.Trim();
                HoangFormHelper.CheckEmail(email, true);
                HoangFormHelper.CheckPhone(txtSoDienThoai.Text.Trim());
                int currentId = adding ? 0 : selected.MaGV;
                HoangFormHelper.Require(!db.GIANG_VIENs.Any(x => x.Email == email && x.MaGV != currentId), "Email đã được giảng viên khác sử dụng.");
                int? khoa = HoangFormHelper.SelectedId(cboMaKhoa);
                int? boMon = HoangFormHelper.SelectedId(cboMaBoMon);
                int? hocVi = HoangFormHelper.SelectedId(cboMaHocVi);
                int? chucVu = HoangFormHelper.SelectedId(cboMaChucVu);
                HoangFormHelper.Require(khoa.HasValue && boMon.HasValue && db.BO_MONs.Any(x => x.MaBoMon == boMon.Value && x.MaKhoa == khoa.Value), "Vui lòng chọn khoa và bộ môn phù hợp.");
                HoangFormHelper.Require(hocVi.HasValue && db.HOC_VIs.Any(x => x.MaHocVi == hocVi.Value), "Vui lòng chọn học vị hợp lệ.");
                HoangFormHelper.Require(!chucVu.HasValue || chucVu == 0 || db.CHUC_VUs.Any(x => x.MaChucVu == chucVu.Value), "Chức vụ không còn tồn tại. Hãy tải lại danh sách.");
                DateTime? birth = dtpNgaySinh.Checked ? (DateTime?)dtpNgaySinh.Value.Date : null;
                DateTime? joined = dtpNgayVaoTruong.Checked ? (DateTime?)dtpNgayVaoTruong.Value.Date : null;
                HoangFormHelper.Require(!birth.HasValue || birth.Value <= DateTime.Today, "Ngày sinh không được ở tương lai.");
                HoangFormHelper.Require(!birth.HasValue || !joined.HasValue || joined.Value >= birth.Value, "Ngày vào trường không được trước ngày sinh.");
                HoangFormHelper.Require(adding || db.GIANG_VIENs.Any(x => x.MaGV == selected.MaGV), "Bản ghi đã bị xóa. Hãy làm mới danh sách.");
                writing = true;
                var item = adding ? new GIANG_VIEN() : selected;
                item.HoTen = txtHoTen.Text.Trim(); item.Email = email;
                item.NgaySinh = birth; item.NgayVaoTruong = joined;
                item.GioiTinh = HoangFormHelper.Optional(cboGioiTinh.Text);
                item.SoDienThoai = HoangFormHelper.Optional(txtSoDienThoai.Text);
                item.DiaChi = HoangFormHelper.Optional(txtDiaChi.Text);
                // Dùng entity liên quan: tránh ForeignKeyReferenceAlreadyHasValueException
                // khi navigation property đã được đọc để hiển thị tên.
                item.BO_MON = db.BO_MONs.Single(x => x.MaBoMon == boMon.Value);
                item.HOC_VI = db.HOC_VIs.Single(x => x.MaHocVi == hocVi.Value);
                item.CHUC_VU = !chucVu.HasValue || chucVu == 0 ? null : db.CHUC_VUs.Single(x => x.MaChucVu == chucVu.Value);
                item.TrangThai = chkTrangThai.Checked;
                if (adding) db.GIANG_VIENs.InsertOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã lưu giảng viên.", "Thông báo");
            });
            if (ok || writing) LoadData(false);
        }

        private void btnThem_Click(object sender, EventArgs e) { Save(true); }
        private void btnSua_Click(object sender, EventArgs e) { Save(false); }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(false); }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            cboLocTrangThai.SelectedIndex = 0;
            LoadData(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!HoangFormHelper.Run(this, () => HoangFormHelper.RequireAction(maNguoiDung, "frmLecturer", "Xoa"))) return;
            if (selected == null) { MessageBox.Show(this, "Vui lòng chọn giảng viên cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, selected.HoTen)) return;
            HoangFormHelper.Run(this, () =>
            {
                var permission = HoangFormHelper.RequireAction(maNguoiDung, "frmLecturer", "Xoa");
                HoangFormHelper.Require(!permission.ChiXemCaNhan || selected.MaGV == permission.MaGV,
                    "Bạn chỉ được thao tác trên hồ sơ giảng viên của mình.");
                int id = selected.MaGV;
                HoangFormHelper.Require(!db.PHAN_CONG_GIANG_DAYs.Any(x => x.MaGV == id)
                    && !db.GIANG_VIEN_CHUYEN_MONs.Any(x => x.MaGV == id)
                    && !db.NGUOI_DUNGs.Any(x => x.MaGV == id),
                    "Giảng viên đang có phân công, chuyên môn hoặc tài khoản liên quan. Không thể xóa. Có thể sửa trạng thái thành ngừng hoạt động nếu phù hợp.");
                db.GIANG_VIENs.DeleteOnSubmit(selected);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa giảng viên.", "Thông báo");
            });
            LoadData(false);
        }
    }
}
