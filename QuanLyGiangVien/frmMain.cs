using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmMain : Form
    {
        private const string LecturerForm = nameof(frmLecturer);
        private const string FacultyForm = nameof(frmFaculty);
        private const string CourseForm = nameof(frmCourse);
        private const string AssignmentForm = nameof(frmTeachingAssignment);
        private const string WorkloadForm = nameof(frmTeachingWorkload);
        private const string ChartForm = nameof(frmChartDashboard);
        private const int StartYear = 2025;
        private const int EndYear = 2026;
        private const string NoAccess = "Không có quyền";
        private const string NoData = "Chưa có dữ liệu";
        private const string LoadError = "Lỗi tải dữ liệu";

        private readonly Session session;
        private readonly List<NavigationItem> navigation = new List<NavigationItem>();
        private bool loadingSemesters;

        private sealed class NavigationItem
        {
            public Button Button { get; set; }
            public string FormName { get; set; }
            public bool FullScopeOnly { get; set; }
        }

        private sealed class SemesterChoice
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public frmMain()
        {
            InitializeComponent();
            HoangFormHelper.KeepContentScrollable(pnlContent, layoutDashboard);
        }

        internal frmMain(Session current) : this()
        {
            session = current ?? throw new ArgumentNullException(nameof(current));
            lblWelcome.Text = "Xin chào, " + session.Username;

            AddRoute(btnNguoiDung, AccountService.Accounts, s => new frmUserManagement(s), refresh: true);
            AddRoute(btnDoiMatKhau, null, s => new frmChangePassword(s), refresh: true);
            AddRoute(btnPhanQuyen, AccountService.Roles, s => new frmRoleManagement(s), refresh: true);

            AddRoute(btnKhoa, FacultyForm, s => new frmFaculty(s.UserId), refresh: true);
            AddRoute(btnBoMon, "frmDepartment", s => new frmDepartment(s.UserId));
            AddRoute(btnGiangVien, LecturerForm, s => new frmLecturer(s.UserId), refresh: true);
            AddRoute(btnHocVi, "frmDegree", s => new frmDegree(s.UserId));
            AddRoute(btnChucVu, "frmPosition", s => new frmPosition(s.UserId));
            AddRoute(btnChuyenMon, "frmSpecialization", s => new frmSpecialization(s.UserId));
            AddRoute(btnHocPhan, CourseForm, s => new frmCourse(s.UserId), refresh: true);

            AddRoute(btnPhanCong, AssignmentForm, s => new frmTeachingAssignment(s), refresh: true);
            AddRoute(btnKhoiLuong, WorkloadForm, s => new frmTeachingWorkload(s));
            AddRoute(btnBieuDo, ChartForm, s => new frmChartDashboard(), fullScopeOnly: true);
            AddRoute(btnBieuDoTongQuan, ChartForm, s => new frmChartDashboard(), fullScopeOnly: true);
            AddRoute(btnBaoCaoGiangVien, "frmReportLecturer", s => new frmReportLecturer(), fullScopeOnly: true);
            AddRoute(btnBaoCaoPhanCong, "frmReportTeachingAssignment", s => new frmReportTeachingAssignment(), fullScopeOnly: true);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnHeThong.Tag = pnlHeThong;
            btnDanhMuc.Tag = pnlDanhMuc;
            btnDaoTao.Tag = pnlDaoTao;
            btnThongKe.Tag = pnlThongKe;
            btnBaoCao.Tag = pnlBaoCao;
            pnlHeThong.Visible = pnlDanhMuc.Visible = pnlDaoTao.Visible = pnlThongKe.Visible = pnlBaoCao.Visible = false;
            lblWorkloadTitle.Text = $"Khối lượng giảng dạy · Năm học {StartYear}–{EndYear}";
            Theme.Apply(this);

            var workArea = Screen.FromControl(this).WorkingArea;
            if (Width > workArea.Width || Height > workArea.Height)
                SetBounds(workArea.Left, workArea.Top, Math.Min(Width, workArea.Width), Math.Min(Height, workArea.Height));
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            pnlContent.AutoScrollPosition = Point.Empty;
            RefreshDashboard();
        }

        private void btnNhom_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var group = (Control)button.Tag;
            group.Visible = !group.Visible;
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            Ui.Run(this, Theme.Toggle);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // frmLogin hiện lại khi hộp thoại Main đóng.
            if (Ui.Confirm(this, "Bạn có chắc chắn đăng xuất?"))
                Close();
        }

        private void AddRoute(Button button, string formName, Func<Session, Form> createForm,
            bool refresh = false, bool fullScopeOnly = false)
        {
            var item = new NavigationItem { Button = button, FormName = formName, FullScopeOnly = fullScopeOnly };
            navigation.Add(item);
            button.Click += (sender, e) => OpenForm(item, createForm, refresh);
        }

        private void OpenForm(NavigationItem item, Func<Session, Form> createForm, bool refresh)
        {
            Ui.Run(this, () =>
            {
                if (session == null)
                    throw new UserMessage("Bạn chưa đăng nhập.");

                using (var db = Session.Open())
                {
                    var user = session.Current(db);
                    if ((item.FullScopeOnly && HoangFormHelper.IsLecturer(user.VAI_TRO.TenVaiTro)) ||
                        (item.FormName != null && !Session.Allows(db, user.MaVaiTro, item.FormName, ActionRight.View)))
                    {
                        item.Button.Enabled = false;
                        throw new UserMessage("Bạn không có quyền mở chức năng này.");
                    }
                }

                try
                {
                    using (var form = createForm(session))
                    {
                        var workArea = Screen.FromControl(this).WorkingArea;
                        form.Size = new Size(Math.Min(form.Width, workArea.Width), Math.Min(form.Height, workArea.Height));
                        form.ShowDialog(this);
                    }
                }
                finally
                {
                    if (refresh)
                        RefreshDashboard();
                }
            });
        }

        private void RefreshDashboard()
        {
            foreach (var item in navigation)
                item.Button.Enabled = false;

            SetCounts(LoadError);
            cboHocKy.Enabled = false;
            lblWorkload.Text = LoadError;

            Ui.Run(this, () =>
            {
                if (session == null)
                {
                    SetCounts(NoAccess);
                    lblWorkload.Text = NoAccess;
                    throw new UserMessage("Bạn chưa đăng nhập.");
                }

                using (var db = Session.Open())
                {
                    var user = session.Current(db);
                    var rights = new HashSet<string>(db.PHAN_QUYENs
                        .Where(p => p.MaVaiTro == user.MaVaiTro && p.DuocXem)
                        .Select(p => p.CHUC_NANG.MaForm), StringComparer.OrdinalIgnoreCase);
                    bool personal = HoangFormHelper.IsLecturer(user.VAI_TRO.TenVaiTro);

                    foreach (var item in navigation)
                        item.Button.Enabled = (!personal || !item.FullScopeOnly) &&
                            (item.FormName == null || rights.Contains(item.FormName));

                    LoadCounts(db, user.MaGV, personal, rights);
                    if (rights.Contains(WorkloadForm))
                    {
                        int semester = LoadSemesters(db);
                        if (semester != 0)
                        {
                            lblWorkload.Text = LoadError;
                            lblWorkload.Text = CalculateWorkload(db, user, semester);
                        }
                    }
                    else
                        lblWorkload.Text = NoAccess;
                }
            }, lblDashboardMessage);
        }

        private void SetCounts(string text)
        {
            lblSoGiangVien.Text = lblSoKhoa.Text = lblSoHocPhan.Text = lblSoLop.Text = text;
        }

        private void LoadCounts(QuanLyGiangVienDataContext db, int? lecturerId, bool personal, HashSet<string> rights)
        {
            var lecturers = db.GIANG_VIENs.AsQueryable();
            var courses = db.HOC_PHANs.AsQueryable();
            var classes = db.LOP_HOC_PHANs.AsQueryable();
            if (personal)
            {
                lecturers = lecturers.Where(g => g.MaGV == lecturerId);
                classes = classes.Where(c => c.PHAN_CONG_GIANG_DAYs.Any(a => a.MaGV == lecturerId));
                courses = courses.Where(c => c.LOP_HOC_PHANs.Any(l => l.PHAN_CONG_GIANG_DAYs.Any(a => a.MaGV == lecturerId)));
            }

            string lecturerCount = rights.Contains(LecturerForm)
                ? FormatCount(lecturers.Where(g => g.TrangThai), lecturers) : NoAccess;
            string facultyCount = !personal && rights.Contains(FacultyForm)
                ? FormatCount(db.KHOAs.Where(k => k.TrangThai), db.KHOAs) : NoAccess;
            string courseCount = rights.Contains(CourseForm)
                ? FormatCount(courses.Where(c => c.TrangThai), courses) : NoAccess;
            string classCount = rights.Contains(AssignmentForm)
                ? FormatCount(classes.Where(c => c.TrangThai), classes) : NoAccess;

            lblSoGiangVien.Text = lecturerCount;
            lblSoKhoa.Text = facultyCount;
            lblSoHocPhan.Text = courseCount;
            lblSoLop.Text = classCount;
            lblScope.Text = personal ? "Bản ghi đang hoạt động trong phạm vi cá nhân."
                : "Bản ghi đang hoạt động thuộc các chức năng bạn được phép xem.";
        }

        private static string FormatCount<T>(IQueryable<T> active, IQueryable<T> scope)
        {
            int count = active.Count();
            return count != 0 || scope.Any() ? count.ToString("N0") : NoData;
        }

        private int LoadSemesters(QuanLyGiangVienDataContext db)
        {
            int previous = cboHocKy.SelectedValue is int ? (int)cboHocKy.SelectedValue : 0;
            var semesters = db.HOC_Kies.OrderBy(k => k.MaHocKy)
                .Select(k => new SemesterChoice { Id = k.MaHocKy, Name = k.TenHocKy }).ToList();

            loadingSemesters = true;
            try
            {
                semesters.Insert(0, new SemesterChoice { Name = "Chọn học kỳ" });
                cboHocKy.DataSource = semesters;
                cboHocKy.SelectedValue = semesters.Any(k => k.Id == previous) ? previous : 0;
            }
            finally
            {
                loadingSemesters = false;
            }

            cboHocKy.Enabled = semesters.Count > 1;
            lblWorkload.Text = cboHocKy.Enabled ? "Chọn học kỳ để xem tỷ lệ." : NoData;
            return cboHocKy.SelectedValue is int ? (int)cboHocKy.SelectedValue : 0;
        }

        private void cboHocKy_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!loadingSemesters)
                RefreshWorkload();
        }

        private void RefreshWorkload()
        {
            if (!cboHocKy.Enabled)
                return;

            int semester = cboHocKy.SelectedValue is int ? (int)cboHocKy.SelectedValue : 0;
            if (semester == 0)
            {
                lblWorkload.Text = "Chọn học kỳ để xem tỷ lệ.";
                return;
            }

            Ui.Run(this, () =>
            {
                if (session == null)
                    throw new UserMessage("Bạn chưa đăng nhập.");

                using (var db = Session.Open())
                {
                    var user = session.Current(db);
                    if (!Session.Allows(db, user.MaVaiTro, WorkloadForm, ActionRight.View))
                    {
                        cboHocKy.Enabled = false;
                        lblWorkload.Text = NoAccess;
                        return;
                    }

                    lblWorkload.Text = CalculateWorkload(db, user, semester);
                }
            }, lblWorkload);
        }

        private static string CalculateWorkload(QuanLyGiangVienDataContext db, NGUOI_DUNG user, int semester)
        {
            var year = db.NAM_HOCs.FirstOrDefault(y => y.TuNam == StartYear && y.DenNam == EndYear);
            if (year == null)
                return "Chưa có dữ liệu năm học.";

            var lecturers = db.GIANG_VIENs.Where(g => g.TrangThai);
            var assignments = frmTeachingWorkload.ActiveAssignments(db, year.MaNamHoc, semester);
            if (HoangFormHelper.IsLecturer(user.VAI_TRO.TenVaiTro))
            {
                int? lecturerId = user.MaGV;
                lecturers = lecturers.Where(g => g.MaGV == lecturerId);
                assignments = assignments.Where(a => a.MaGV == lecturerId);
            }

            int denominator = lecturers.Count();
            if (denominator == 0)
                return "Chưa có giảng viên đang hoạt động trong phạm vi xem.";

            var totals = assignments.GroupBy(a => a.MaGV).Select(g => g.Sum(a => a.SoTiet));
            int quota = frmTeachingWorkload.DinhMucTietMoiHocKy;
            int meets = totals.Count(t => t == quota);
            int exceeds = totals.Count(t => t > quota);
            return $"Đạt {quota} tiết: {(double)meets / denominator:P1}  ({meets}/{denominator})" +
                Environment.NewLine + $"Vượt {quota} tiết: {(double)exceeds / denominator:P1}  ({exceeds}/{denominator})";
        }
    }
}
