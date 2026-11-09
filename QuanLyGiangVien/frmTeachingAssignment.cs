using System;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    /// <summary>Phân công giảng viên vào lớp cùng khoa, giới hạn số tiết và chống ghi trùng.</summary>
    public partial class frmTeachingAssignment : Form
    {
        // Ngưỡng tải giảng dạy tối đa trong một học kỳ.
        private const int DinhMucTietMoiHocKy = 300;
        private readonly Session session;
        private int? lecturerScope;
        private bool dangNap;

        public frmTeachingAssignment()
        {
            InitializeComponent();
            Theme.Apply(this);
            btQuayLai.Click += (s, e) => Close();
            Load += frmTeachingAssignment_Load;
            cboAcademicYear.SelectedIndexChanged += BoLocThayDoi;
            cboSemester.SelectedIndexChanged += BoLocThayDoi;
            btnAssign.Click += btnAssign_Click;
        }

        internal frmTeachingAssignment(Session session) : this()
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        private void frmTeachingAssignment_Load(object sender, EventArgs e)
        {
            if (LaDesignTime()) return;
            btnAssign.Enabled = false;
            txtPeriods.ReadOnly = true;
            try
            {
                dangNap = true;
                using (var db = Session.Open())
                {
                    // Xác định phạm vi tài khoản: quản lý được thao tác, giảng viên chỉ xem dữ liệu của mình.
                    var user = CurrentViewer(db);
                    lecturerScope = GetLecturerScope(user);
                    btnAssign.Enabled = !lecturerScope.HasValue &&
                        Session.Allows(db, user.MaVaiTro, nameof(frmTeachingAssignment), ActionRight.Add);
                    txtPeriods.ReadOnly = !btnAssign.Enabled;

                    cboAcademicYear.DataSource = db.NAM_HOCs.Where(x => x.TrangThai).OrderByDescending(x => x.TuNam)
                        .Select(x => new { x.MaNamHoc, x.TenNamHoc }).ToList();
                    cboAcademicYear.DisplayMember = "TenNamHoc";
                    cboAcademicYear.ValueMember = "MaNamHoc";
                    cboSemester.DataSource = db.HOC_Kies.OrderBy(x => x.MaHocKy)
                        .Select(x => new { x.MaHocKy, x.TenHocKy }).ToList();
                    cboSemester.DisplayMember = "TenHocKy";
                    cboSemester.ValueMember = "MaHocKy";
                    cboLecturer.DataSource = db.GIANG_VIENs
                        .Where(x => x.TrangThai && (!lecturerScope.HasValue || x.MaGV == lecturerScope))
                        .OrderByDescending(x => x.MaGV)
                        .Select(x => new { x.MaGV, TenHienThi = x.MaGV + " - " + x.HoTen + " | " + x.BO_MON.KHOA.TenKhoa }).ToList();
                    cboLecturer.DisplayMember = "TenHienThi";
                    cboLecturer.ValueMember = "MaGV";
                    cboLecturer.DropDownWidth = Math.Max(cboLecturer.Width, 420);
                }
                dangNap = false;
                LoadCourseClasses();
                LoadAssignments();
            }
            catch (UserMessage ex) { CloseForAccessError(ex); }
            catch (Exception ex)
            {
                dangNap = false;
                ShowError("Không tải được dữ liệu. Hãy kiểm tra SQL Server và chuỗi kết nối trong App.config.", ex);
            }
        }

        private void BoLocThayDoi(object sender, EventArgs e)
        {
            if (dangNap || LaDesignTime()) return;
            LoadCourseClasses();
            LoadAssignments();
        }

        private NGUOI_DUNG CurrentViewer(QuanLyGiangVienDataContext db)
        {
            // Lấy phiên còn hiệu lực và kiểm tra quyền xem trước mọi truy vấn nghiệp vụ.
            if (session == null) throw new UserMessage("Bạn chưa đăng nhập.");
            var user = session.Current(db);
            if (!Session.Allows(db, user.MaVaiTro, nameof(frmTeachingAssignment), ActionRight.View))
                throw new UserMessage("Bạn không có quyền xem phân công giảng dạy.");
            return user;
        }

        private static int? GetLecturerScope(NGUOI_DUNG user)
        {
            // null cho quản lý toàn cục; ID giảng viên cho tài khoản bị giới hạn cá nhân.
            if (!HoangFormHelper.IsLecturer(user.VAI_TRO.TenVaiTro)) return null;
            return user.MaGV ?? throw new UserMessage("Tài khoản chưa liên kết với hồ sơ giảng viên.");
        }

        private NGUOI_DUNG ValidateViewScope(QuanLyGiangVienDataContext db)
        {
            var user = CurrentViewer(db);
            if (GetLecturerScope(user) != lecturerScope)
                throw new UserMessage("Phạm vi dữ liệu đã thay đổi. Hãy mở lại chức năng.");
            return user;
        }

        private void RequireAddPermission(QuanLyGiangVienDataContext db)
        {
            // Chống gọi trực tiếp chức năng ghi dù nút đã bị khóa trên giao diện.
            var user = ValidateViewScope(db);
            if (lecturerScope.HasValue ||
                !Session.Allows(db, user.MaVaiTro, nameof(frmTeachingAssignment), ActionRight.Add))
                throw new UserMessage("Bạn không có quyền thêm phân công giảng dạy.");
        }

        private void CloseForAccessError(UserMessage ex)
        {
            MessageBox.Show(this, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void LoadCourseClasses()
        {
            if (!DaChonNamHocVaHocKy()) return;
            try
            {
                int maNamHoc = Convert.ToInt32(cboAcademicYear.SelectedValue);
                int maHocKy = Convert.ToInt32(cboSemester.SelectedValue);
                using (var db = Session.Open())
                {
                    ValidateViewScope(db);
                    // Tìm khoa của giảng viên đã chọn để lọc lớp đúng phạm vi khoa đó.
                    int? facultyId = null;
                    if (cboLecturer.SelectedValue != null)
                    {
                        int selectedLecturerId = Convert.ToInt32(cboLecturer.SelectedValue);
                        facultyId = db.GIANG_VIENs.Where(x => x.MaGV == selectedLecturerId)
                            .Select(x => (int?)x.BO_MON.MaKhoa).SingleOrDefault();
                    }
                    dangNap = true;
                    // Lop duoc loc dong theo khoa cua giang vien va hoc ky dang chon.
                    // Khong rang buoc theo chuyen mon hay phan cong cu, nen giang vien moi tu dong dung duoc.
                    // Chỉ lấy lớp đang mở đúng năm/kỳ, có học phần thuộc khoa giảng viên.
                    var classes = db.LOP_HOC_PHANs
                        .Where(x => x.TrangThai && x.MaNamHoc == maNamHoc && x.MaHocKy == maHocKy)
                        .Where(x => facultyId.HasValue && x.HOC_PHAN.BO_MON.MaKhoa == facultyId.Value)
                        .Where(x => !lecturerScope.HasValue || x.PHAN_CONG_GIANG_DAYs.Any(p => p.MaGV == lecturerScope))
                        .OrderBy(x => x.TenLop)
                        .Select(x => new { x.MaLopHP, TenHienThi = x.TenLop + " - " + x.HOC_PHAN.TenHocPhan + " | " + x.HOC_PHAN.BO_MON.TenBoMon })
                        .ToList();
                    if (classes.Count == 0)
                        classes.Add(new { MaLopHP = 0, TenHienThi = "Chưa có lớp đang mở trong khoa / học kỳ này" });
                    cboCourseClass.DataSource = classes;
                    cboCourseClass.DisplayMember = "TenHienThi";
                    cboCourseClass.ValueMember = "MaLopHP";
                    cboCourseClass.DropDownWidth = Math.Max(cboCourseClass.Width, 520);
                    dangNap = false;
                }
            }
            catch (UserMessage ex) { CloseForAccessError(ex); }
            catch (Exception ex)
            {
                dangNap = false;
                ShowError("Không tải được lớp học phần.", ex);
            }
        }

        private void LoadAssignments()
        {
            // Hiển thị phân công trong học kỳ đang chọn; giảng viên chỉ thấy phân công của mình.
            if (IsDisposed || DialogResult != DialogResult.None) return;
            dgvAssignments.Rows.Clear();
            if (!DaChonNamHocVaHocKy()) return;
            try
            {
                int maNamHoc = Convert.ToInt32(cboAcademicYear.SelectedValue);
                int maHocKy = Convert.ToInt32(cboSemester.SelectedValue);
                using (var db = Session.Open())
                {
                    ValidateViewScope(db);
                    var rows = db.PHAN_CONG_GIANG_DAYs
                        .Where(x => x.LOP_HOC_PHAN.MaNamHoc == maNamHoc && x.LOP_HOC_PHAN.MaHocKy == maHocKy)
                        .Where(x => !lecturerScope.HasValue || x.MaGV == lecturerScope)
                        .OrderBy(x => x.GIANG_VIEN.HoTen)
                        .Select(x => new {
                            x.MaPhanCong,
                            GiangVien = x.GIANG_VIEN.HoTen,
                            LopHocPhan = x.LOP_HOC_PHAN.TenLop,
                            HocKy = x.LOP_HOC_PHAN.HOC_KY.TenHocKy,
                            x.SoTiet
                        })
                        .ToList();
                    foreach (var row in rows)
                        dgvAssignments.Rows.Add(row.MaPhanCong, row.GiangVien, row.LopHocPhan,
                            row.HocKy, row.SoTiet, "Đã phân công");
                }
            }
            catch (UserMessage ex) { CloseForAccessError(ex); }
            catch (Exception ex) { ShowError("Không tải được danh sách phân công.", ex); }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào UI trước khi mở transaction ghi vào SQL.
            if (!DaChonNamHocVaHocKy() || cboLecturer.SelectedValue == null || cboCourseClass.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn năm học, học kỳ, giảng viên và lớp học phần.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(cboCourseClass.SelectedValue) <= 0)
            {
                MessageBox.Show("Khoa của giảng viên chưa có lớp đang mở trong năm học và học kỳ đã chọn.",
                    "Chưa có lớp để phân công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int soTiet;
            if (!int.TryParse(txtPeriods.Text.Trim(), out soTiet) || soTiet <= 0)
            {
                MessageBox.Show("Số tiết phải là số nguyên lớn hơn 0.", "Dữ liệu chưa hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeriods.Focus();
                return;
            }

            int maNamHoc = Convert.ToInt32(cboAcademicYear.SelectedValue);
            int maHocKy = Convert.ToInt32(cboSemester.SelectedValue);
            int maGV = Convert.ToInt32(cboLecturer.SelectedValue);
            int maLopHP = Convert.ToInt32(cboCourseClass.SelectedValue);
            try
            {
                // Serializable ngăn hai thao tác đồng thời cùng đọc một tổng cũ rồi vượt định mức.
                var options = new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.Serializable };
                using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
                using (var db = Session.Open())
                {
                    RequireAddPermission(db);
                    var giangVien = db.GIANG_VIENs.SingleOrDefault(x => x.MaGV == maGV);
                    var lopHocPhan = db.LOP_HOC_PHANs.SingleOrDefault(x => x.MaLopHP == maLopHP);
                    if (giangVien == null || !giangVien.TrangThai)
                        throw new InvalidOperationException("Giảng viên không tồn tại hoặc đang ngừng hoạt động.");
                    if (lopHocPhan == null || !lopHocPhan.TrangThai || lopHocPhan.MaNamHoc != maNamHoc || lopHocPhan.MaHocKy != maHocKy)
                        throw new InvalidOperationException("Lớp học phần không hợp lệ cho năm học và học kỳ đã chọn.");
                    // Kiểm tra lại trên dữ liệu SQL để không tin riêng danh sách ComboBox đã nạp trước đó.
                    if (lopHocPhan.HOC_PHAN.BO_MON.MaKhoa != giangVien.BO_MON.MaKhoa)
                        throw new InvalidOperationException("Chỉ được phân công giảng viên dạy lớp thuộc khoa của giảng viên.");
                    if (db.PHAN_CONG_GIANG_DAYs.Any(x => x.MaGV == maGV && x.MaLopHP == maLopHP))
                        throw new InvalidOperationException("Giảng viên này đã được phân công lớp học phần đã chọn.");

                    int tongTietHocPhan = lopHocPhan.HOC_PHAN.SoTietLyThuyet + lopHocPhan.HOC_PHAN.SoTietThucHanh;
                    if (soTiet > tongTietHocPhan)
                        throw new InvalidOperationException("Số tiết phân công không được vượt tổng số tiết của học phần (" + tongTietHocPhan + " tiết).");

                    int tongTietDaPhanCong = db.PHAN_CONG_GIANG_DAYs
                        .Where(x => x.MaGV == maGV && x.LOP_HOC_PHAN.MaNamHoc == maNamHoc && x.LOP_HOC_PHAN.MaHocKy == maHocKy)
                        .Sum(x => (int?)x.SoTiet) ?? 0;
                    if (tongTietDaPhanCong + soTiet > DinhMucTietMoiHocKy)
                        throw new InvalidOperationException("Phân công này làm tổng số tiết là " + (tongTietDaPhanCong + soTiet)
                            + ", vượt định mức " + DinhMucTietMoiHocKy + " tiết/học kỳ.");

                    // Tạo bản ghi sau khi qua mọi ràng buộc; Complete xác nhận transaction thành công.
                    db.PHAN_CONG_GIANG_DAYs.InsertOnSubmit(new PHAN_CONG_GIANG_DAY
                    {
                        MaGV = maGV,
                        MaLopHP = maLopHP,
                        SoTiet = soTiet,
                        NgayBatDau = null,
                        NgayKetThuc = null,
                        GhiChu = "Phân công từ frmTeachingAssignment"
                    });
                    db.SubmitChanges();
                    scope.Complete();
                }
                MessageBox.Show("Đã phân công giảng dạy thành công.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPeriods.Clear();
                LoadAssignments();
            }
            catch (UserMessage ex) { CloseForAccessError(ex); }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Không thể phân công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { ShowError("Không lưu được phân công.", ex); }
        }

        private bool DaChonNamHocVaHocKy()
        {
            return cboAcademicYear.SelectedValue is int && cboSemester.SelectedValue is int;
        }

        private static bool LaDesignTime()
        {
            // Không truy vấn cơ sở dữ liệu khi Visual Studio đang mở WinForms Designer.
            return System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
        }

        private static void ShowError(string message, Exception ex)
        {
            MessageBox.Show(message + "\n\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cboLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNap && !LaDesignTime()) LoadCourseClasses();
        }
    }
}
