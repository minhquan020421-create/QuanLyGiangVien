using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmTeachingAssignment : Form
    {
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
                        .OrderBy(x => x.HoTen)
                        .Select(x => new { x.MaGV, TenHienThi = x.MaGV + " - " + x.HoTen }).ToList();
                    cboLecturer.DisplayMember = "TenHienThi";
                    cboLecturer.ValueMember = "MaGV";
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
            if (session == null) throw new UserMessage("Bạn chưa đăng nhập.");
            var user = session.Current(db);
            if (!Session.Allows(db, user.MaVaiTro, nameof(frmTeachingAssignment), ActionRight.View))
                throw new UserMessage("Bạn không có quyền xem phân công giảng dạy.");
            return user;
        }

        private static int? GetLecturerScope(NGUOI_DUNG user)
        {
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
                    dangNap = true;
                    cboCourseClass.DataSource = db.LOP_HOC_PHANs
                        .Where(x => x.TrangThai && x.MaNamHoc == maNamHoc && x.MaHocKy == maHocKy)
                        .Where(x => !lecturerScope.HasValue || x.PHAN_CONG_GIANG_DAYs.Any(p => p.MaGV == lecturerScope))
                        .OrderBy(x => x.TenLop)
                        .Select(x => new { x.MaLopHP, TenHienThi = x.TenLop + " - " + x.HOC_PHAN.TenHocPhan })
                        .ToList();
                    cboCourseClass.DisplayMember = "TenHienThi";
                    cboCourseClass.ValueMember = "MaLopHP";
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
            if (!DaChonNamHocVaHocKy() || cboLecturer.SelectedValue == null || cboCourseClass.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn năm học, học kỳ, giảng viên và lớp học phần.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                // Chuyên môn lưu dưới dạng tên tự do, không có khóa liên kết tới học phần.
                // Cảnh báo để người dùng xác nhận khi cách đặt tên môn/chuyên môn khác nhau.
                using (var dbKiemTra = Session.Open())
                {
                    RequireAddPermission(dbKiemTra);
                    var tenHocPhan = dbKiemTra.LOP_HOC_PHANs
                        .Where(x => x.MaLopHP == maLopHP)
                        .Select(x => x.HOC_PHAN.TenHocPhan)
                        .SingleOrDefault();
                    var chuyenMons = dbKiemTra.GIANG_VIEN_CHUYEN_MONs
                        .Where(x => x.MaGV == maGV && x.CHUYEN_MON.TrangThai)
                        .Select(x => x.CHUYEN_MON.TenChuyenMon)
                        .ToList();
                    if (tenHocPhan != null && !chuyenMons.Any(x => ChuyenMonTrungHocPhan(x, tenHocPhan)))
                    {
                        var answer = MessageBox.Show(
                            "Chưa tìm thấy tên chuyên môn trùng với học phần '" + tenHocPhan + "'. Bạn vẫn muốn tiếp tục?",
                            "Xác nhận chuyên môn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (answer != DialogResult.Yes) return;
                    }
                }

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

        private static bool ChuyenMonTrungHocPhan(string tenChuyenMon, string tenHocPhan)
        {
            return ChuanHoaTen(tenChuyenMon) == ChuanHoaTen(tenHocPhan);
        }

        private static string ChuanHoaTen(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) return String.Empty;
            string normalized = value.Normalize(NormalizationForm.FormD);
            var result = new StringBuilder();
            foreach (char c in normalized)
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                    result.Append(char.ToLowerInvariant(c));
            return result.ToString().Replace('đ', 'd').Trim();
        }

        private static bool LaDesignTime()
        {
            return System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
        }

        private static void ShowError(string message, Exception ex)
        {
            MessageBox.Show(message + "\n\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Các event handler này đang được WinForms Designer tham chiếu.
        private void lblLecturer_Click(object sender, EventArgs e) { }
        private void cboLecturer_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblPeriods_Click(object sender, EventArgs e) { }
        private void lblAssignmentList_Click(object sender, EventArgs e) { }
        private void pnlAssignmentInfo_Paint(object sender, PaintEventArgs e) { }
    }
}
