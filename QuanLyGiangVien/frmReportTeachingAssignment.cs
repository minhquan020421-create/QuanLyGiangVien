using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyGiangVien
{
    public partial class frmReportTeachingAssignment : Form
    {
        private readonly string connectionString;
        private bool loading;

        private sealed class Choice
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private sealed class AssignmentReportRow
        {
            public int STT { get; set; }
            public string HoTen { get; set; }
            public string TenHocPhan { get; set; }
            public string TenLop { get; set; }
            public string TenHocKy { get; set; }
            public int SoTiet { get; set; }
        }

        public frmReportTeachingAssignment()
        {
            InitializeComponent();
            Theme.Apply(this);
            btQuayLai.Click += (s, e) => Close();
            var cs = ConfigurationManager.ConnectionStrings["QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString1"]
                  ?? ConfigurationManager.ConnectionStrings["QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString"];
            if (cs == null) throw new InvalidOperationException("Không tìm thấy chuỗi kết nối trong App.config.");
            connectionString = cs.ConnectionString;
            cboNamHoc.SelectedIndexChanged += FilterChanged;
            cboHocKy.SelectedIndexChanged += FilterChanged;
            cboKhoa.SelectedIndexChanged += FacultyChanged;
            cboGiangVien.SelectedIndexChanged += FilterChanged;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            btnInBaoCao.Click += btnInBaoCao_Click;
        }

        private void frmReportTeachingAssignment_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime) return;
            try
            {
                reportViewerTeachingAssignment.ProcessingMode = ProcessingMode.Local;
                reportViewerTeachingAssignment.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rptTeachingAssignment.rdlc");
                reportViewerTeachingAssignment.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewerTeachingAssignment.ZoomMode = ZoomMode.PageWidth;
                LoadFilters();
                ShowReport();
            }
            catch (Exception ex) { ShowError("Không thể tải báo cáo phân công", ex); }
        }

        private void LoadFilters()
        {
            loading = true;
            try
            {
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var years = db.NAM_HOCs.Where(x => x.TrangThai).OrderByDescending(x => x.TuNam)
                        .Select(x => new Choice { Id = x.MaNamHoc, Name = x.TenNamHoc }).ToList();
                    var semesters = db.HOC_Kies.OrderBy(x => x.MaHocKy)
                        .Select(x => new Choice { Id = x.MaHocKy, Name = x.TenHocKy }).ToList();
                    var faculties = db.KHOAs.Where(x => x.TrangThai).OrderBy(x => x.TenKhoa)
                        .Select(x => new Choice { Id = x.MaKhoa, Name = x.TenKhoa }).ToList();
                    years.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                    semesters.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                    faculties.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                    SetCombo(cboNamHoc, years);
                    SetCombo(cboHocKy, semesters);
                    SetCombo(cboKhoa, faculties);
                    LoadLecturers(db, 0);
                }
            }
            finally { loading = false; }
        }

        private static void SetCombo(ComboBox combo, List<Choice> items)
        {
            combo.DataSource = items;
            combo.DisplayMember = "Name";
            combo.ValueMember = "Id";
        }

        private void LoadLecturers(QuanLyGiangVienDataContext db, int facultyId)
        {
            var lecturers = db.GIANG_VIENs.Where(x => x.TrangThai && (facultyId == 0 || x.BO_MON.MaKhoa == facultyId))
                .OrderBy(x => x.HoTen).Select(x => new Choice { Id = x.MaGV, Name = x.HoTen }).ToList();
            lecturers.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
            SetCombo(cboGiangVien, lecturers);
        }

        private void FacultyChanged(object sender, EventArgs e)
        {
            if (loading || cboKhoa.SelectedValue == null) return;
            try
            {
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                    LoadLecturers(db, SelectedId(cboKhoa));
                ShowReport();
            }
            catch (Exception ex) { ShowError("Không thể tải danh sách giảng viên", ex); }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            if (!loading && IsHandleCreated) ShowReport();
        }

        private static int SelectedId(ComboBox combo)
        {
            var selected = combo.SelectedItem as Choice;
            return selected == null ? 0 : selected.Id;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e) { ShowReport(); }

        private void ShowReport()
        {
            if (loading || reportViewerTeachingAssignment.LocalReport == null) return;
            try
            {
                int yearId = SelectedId(cboNamHoc);
                int semesterId = SelectedId(cboHocKy);
                int facultyId = SelectedId(cboKhoa);
                int lecturerId = SelectedId(cboGiangVien);
                List<AssignmentReportRow> rows;
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var query = from pc in db.PHAN_CONG_GIANG_DAYs
                                join gv in db.GIANG_VIENs on pc.MaGV equals gv.MaGV
                                join lop in db.LOP_HOC_PHANs on pc.MaLopHP equals lop.MaLopHP
                                join hp in db.HOC_PHANs on lop.MaHocPhan equals hp.MaHocPhan
                                join hk in db.HOC_Kies on lop.MaHocKy equals hk.MaHocKy
                                where (yearId == 0 || lop.MaNamHoc == yearId)
                                   && (semesterId == 0 || lop.MaHocKy == semesterId)
                                   && (facultyId == 0 || gv.BO_MON.MaKhoa == facultyId)
                                   && (lecturerId == 0 || gv.MaGV == lecturerId)
                                orderby gv.HoTen, hp.TenHocPhan, lop.TenLop
                                select new { gv.HoTen, hp.TenHocPhan, lop.TenLop, hk.TenHocKy, pc.SoTiet };
                    var data = query.ToList();
                    rows = data.Select((x, i) => new AssignmentReportRow
                    {
                        STT = i + 1, HoTen = x.HoTen, TenHocPhan = x.TenHocPhan,
                        TenLop = x.TenLop, TenHocKy = x.TenHocKy, SoTiet = x.SoTiet
                    }).ToList();
                }
                reportViewerTeachingAssignment.LocalReport.DataSources.Clear();
                reportViewerTeachingAssignment.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", rows));
                reportViewerTeachingAssignment.RefreshReport();
            }
            catch (Exception ex) { ShowError("Không thể tải dữ liệu phân công", ex); }
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            try { reportViewerTeachingAssignment.PrintDialog(); }
            catch (Exception ex) { ShowError("Không thể mở hộp thoại in", ex); }
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show(this, title + ":\r\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lblDepartment_Click(object sender, EventArgs e) { }
        private void lblStatus_Click(object sender, EventArgs e) { }
    }
}
