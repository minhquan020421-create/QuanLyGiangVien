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
            layoutDashboard.Layout += layoutDashboard_Layout;
            lblDashboardMessage.TextChanged += (sender, e) =>
                lblDashboardMessage.Visible = lblDashboardMessage.Text.Length > 0;
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
            // Hai báo cáo mở rộng dùng quyền xem báo cáo phân công đã có trong database.
            AddRoute(btnBaoCaoTaiTrongKhoa, "frmReportTeachingAssignment", s => new frmReportFacultyWorkload(), fullScopeOnly: true);
            AddRoute(btnBaoCaoChuaPhanCong, "frmReportTeachingAssignment", s => new frmReportUnassignedLecturers(), fullScopeOnly: true);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnHeThong.Tag = pnlHeThong;
            btnDanhMuc.Tag = pnlDanhMuc;
            btnDaoTao.Tag = pnlDaoTao;
            btnThongKe.Tag = pnlThongKe;
            btnBaoCao.Tag = pnlBaoCao;
            pnlHeThong.Visible = pnlDanhMuc.Visible = pnlDaoTao.Visible = pnlThongKe.Visible = pnlBaoCao.Visible = false;
            lblWorkloadYear.Text = $"Năm học {StartYear}–{EndYear}";
            lblRateTitleDat.Text = $"Đạt {frmTeachingWorkload.DinhMucTietMoiHocKy} tiết";
            lblRateTitleVuot.Text = $"Vượt {frmTeachingWorkload.DinhMucTietMoiHocKy} tiết";
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
            button.Text = button.Text.TrimEnd(' ', '▸', '▾') + (group.Visible ? "  ▾" : "  ▸");
        }

        private void layoutDashboard_Layout(object sender, LayoutEventArgs e)
        {
            int width = layoutDashboard.ClientSize.Width - layoutDashboard.Padding.Horizontal;
            // Keep the wide row large enough for the number and its status at the current scale.
            int cardWidth = cardGiangVien.MinimumSize.Height * 3 / 2 + cardGiangVien.Margin.Horizontal;
            int columns = width >= 4 * cardWidth ? 4 : 2;
            int rows = 4 / columns;
            if (layoutCounts.ColumnCount != columns)
            {
                var cards = new[] { cardGiangVien, cardKhoa, cardHocPhan, cardLop };
                layoutCounts.SuspendLayout();
                layoutCounts.ColumnCount = columns;
                layoutCounts.RowCount = rows;
                layoutCounts.ColumnStyles.Clear();
                layoutCounts.RowStyles.Clear();
                for (int i = 0; i < columns; i++)
                    layoutCounts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columns));
                for (int i = 0; i < rows; i++)
                    layoutCounts.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / rows));
                for (int i = 0; i < cards.Length; i++)
                    layoutCounts.SetCellPosition(cards[i], new TableLayoutPanelCellPosition(i % columns, i / columns));
                layoutCounts.ResumeLayout();
            }

            int countHeight = rows * (cardGiangVien.MinimumSize.Height + cardGiangVien.Margin.Vertical);
            if (rows == 1)
                countHeight += cardGiangVien.Padding.Vertical;
            var countSize = new Size(0, countHeight);
            if (layoutCounts.MinimumSize != countSize)
                layoutCounts.MinimumSize = countSize;

            int messageHeight = lblDashboardMessage.Text.Length == 0 ? 0 : DashboardRowHeight(lblDashboardMessage, width);
            int height = layoutDashboard.Padding.Vertical + countHeight + messageHeight +
                DashboardRowHeight(layoutOverviewHeader, width) + DashboardRowHeight(layoutWorkload, width);
            if (layoutDashboard.MinimumSize.Height != height)
            {
                layoutDashboard.MinimumSize = new Size(layoutDashboard.MinimumSize.Width, height);
                // The scroll range is calculated after the nested layout has settled.
                if (pnlContent.IsHandleCreated)
                    pnlContent.BeginInvoke((MethodInvoker)pnlContent.PerformLayout);
            }
        }

        private static int DashboardRowHeight(Control control, int width)
        {
            var proposed = new Size(Math.Max(1, width - control.Margin.Horizontal), 0);
            return control.GetPreferredSize(proposed).Height + control.Margin.Vertical;
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
            SetWorkloadStatus(LoadError);

            Ui.Run(this, () =>
            {
                if (session == null)
                {
                    SetCounts(NoAccess);
                    SetWorkloadStatus(NoAccess);
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
                            SetWorkloadStatus(LoadError);
                            LoadWorkload(db, user, semester);
                        }
                    }
                    else
                        lblWorkload.Text = NoAccess;
                }
            }, lblDashboardMessage);
        }

        private void SetCounts(string text)
        {
            ShowCount(lblSoGiangVien, lblTrangThaiGiangVien, text);
            ShowCount(lblSoKhoa, lblTrangThaiKhoa, text);
            ShowCount(lblSoHocPhan, lblTrangThaiHocPhan, text);
            ShowCount(lblSoLop, lblTrangThaiLop, text);
        }

        private static void ShowCount(Label value, Label status, string text)
        {
            bool available = text != NoAccess && text != NoData && text != LoadError;
            value.Text = available ? text : "—";
            status.Text = available ? "Đang hoạt động" : text;
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

            ShowCount(lblSoGiangVien, lblTrangThaiGiangVien, lecturerCount);
            ShowCount(lblSoKhoa, lblTrangThaiKhoa, facultyCount);
            ShowCount(lblSoHocPhan, lblTrangThaiHocPhan, courseCount);
            ShowCount(lblSoLop, lblTrangThaiLop, classCount);
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
                SetWorkloadStatus("Chọn học kỳ để xem tỷ lệ.");
                return;
            }

            SetWorkloadStatus(LoadError);
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

                    LoadWorkload(db, user, semester);
                }
            }, lblWorkload);
        }

        private void SetWorkloadStatus(string text)
        {
            lblSoDat.Text = lblSoVuot.Text = "—";
            lblTiLeDat.Text = lblTiLeVuot.Text = " ";
            lblWorkload.Text = text;
        }

        private void LoadWorkload(QuanLyGiangVienDataContext db, NGUOI_DUNG user, int semester)
        {
            var year = db.NAM_HOCs.FirstOrDefault(y => y.TuNam == StartYear && y.DenNam == EndYear);
            if (year == null)
            {
                lblWorkload.Text = "Chưa có dữ liệu năm học.";
                return;
            }

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
            {
                lblWorkload.Text = "Chưa có giảng viên đang hoạt động trong phạm vi xem.";
                return;
            }

            var totals = assignments.GroupBy(a => a.MaGV).Select(g => g.Sum(a => a.SoTiet));
            int quota = frmTeachingWorkload.DinhMucTietMoiHocKy;
            int meets = totals.Count(t => t == quota);
            int exceeds = totals.Count(t => t > quota);
            lblSoDat.Text = ((double)meets / denominator).ToString("P1");
            lblSoVuot.Text = ((double)exceeds / denominator).ToString("P1");
            lblTiLeDat.Text = $"{meets}/{denominator} giảng viên";
            lblTiLeVuot.Text = $"{exceeds}/{denominator} giảng viên";
            lblWorkload.Text = "Tính trên giảng viên đang hoạt động trong phạm vi xem.";
        }
    }
}
