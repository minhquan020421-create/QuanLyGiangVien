using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyGiangVien
{
    public partial class frmReportUnassignedLecturers : Form
    {
        private readonly string connectionString;
        private bool loading;

        private sealed class Choice
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private sealed class ReportRow
        {
            public int STT { get; set; }
            public int MaGV { get; set; }
            public string HoTen { get; set; }
            public string TenBoMon { get; set; }
            public string TenHocVi { get; set; }
            public int SoTiet { get; set; }
        }

        public frmReportUnassignedLecturers()
        {
            InitializeComponent();
            Theme.Apply(this);
            buttonQuaylai.Click += buttonQuaylai_Click;
            var setting = ConfigurationManager.ConnectionStrings["QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString1"]
                ?? ConfigurationManager.ConnectionStrings["QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString"];
            if (setting == null || string.IsNullOrWhiteSpace(setting.ConnectionString))
                throw new InvalidOperationException("Không tìm thấy chuỗi kết nối database trong App.config.");
            connectionString = setting.ConnectionString;

            Load += frmReportUnassignedLecturers_Load;
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            btnViewReport.Click += (s, e) => ShowReport();
            btnPrint.Click += (s, e) => PrintReport();
            btnExportPDF.Click += (s, e) => ExportPdf();
        }

        private void frmReportUnassignedLecturers_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            try
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyGiangVien.rptfrmReportUnassignedLecturers.rdlc";
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                LoadFilters();
                ShowReport();
            }
            catch (Exception ex) { ShowError("Không thể tải báo cáo giảng viên chưa được phân công", ex); }
        }

        private void LoadFilters()
        {
            loading = true;
            try
            {
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var years = db.NAM_HOCs.OrderByDescending(x => x.TuNam).Select(x => new Choice { Id = x.MaNamHoc, Name = x.TenNamHoc }).ToList();
                    var semesters = db.HOC_Kies.OrderBy(x => x.MaHocKy).Select(x => new Choice { Id = x.MaHocKy, Name = x.TenHocKy }).ToList();
                    var faculties = db.KHOAs.OrderBy(x => x.TenKhoa).Select(x => new Choice { Id = x.MaKhoa, Name = x.TenKhoa }).ToList();
                    years.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                    semesters.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                    faculties.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                    SetCombo(cboNamHoc, years);
                    SetCombo(cboHocKy, semesters);
                    SetCombo(cboKhoa, faculties);
                    LoadDepartments(db, 0);
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

        private void LoadDepartments(QuanLyGiangVienDataContext db, int facultyId)
        {
            var departments = db.BO_MONs.Where(x => facultyId == 0 || x.MaKhoa == facultyId)
                .OrderBy(x => x.TenBoMon).Select(x => new Choice { Id = x.MaBoMon, Name = x.TenBoMon }).ToList();
            departments.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
            SetCombo(comboBox1, departments);
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading || cboKhoa.SelectedValue == null) return;
            try
            {
                using (var db = new QuanLyGiangVienDataContext(connectionString)) LoadDepartments(db, SelectedId(cboKhoa));
                ShowReport();
            }
            catch (Exception ex) { ShowError("Không thể tải danh sách bộ môn", ex); }
        }

        private static int SelectedId(ComboBox combo)
        {
            var selected = combo.SelectedItem as Choice;
            return selected == null ? 0 : selected.Id;
        }

        private void ShowReport()
        {
            if (loading || reportViewer1.LocalReport == null || cboKhoa.SelectedItem == null) return;
            try
            {
                int yearId = SelectedId(cboNamHoc);
                int semesterId = SelectedId(cboHocKy);
                int facultyId = SelectedId(cboKhoa);
                int departmentId = SelectedId(comboBox1);
                List<ReportRow> rows;
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var assignedHours = from pc in db.PHAN_CONG_GIANG_DAYs
                                        join lop in db.LOP_HOC_PHANs on pc.MaLopHP equals lop.MaLopHP
                                        where (yearId == 0 || lop.MaNamHoc == yearId)
                                           && (semesterId == 0 || lop.MaHocKy == semesterId)
                                        group pc by pc.MaGV into totals
                                        select new { MaGV = totals.Key, SoTiet = totals.Sum(x => (int?)x.SoTiet) ?? 0 };

                    var data = (from gv in db.GIANG_VIENs
                                join bm in db.BO_MONs on gv.MaBoMon equals bm.MaBoMon
                                join hv in db.HOC_VIs on gv.MaHocVi equals hv.MaHocVi
                                join total in assignedHours on gv.MaGV equals total.MaGV into workload
                                from total in workload.DefaultIfEmpty()
                                where gv.TrangThai
                                   && (facultyId == 0 || bm.MaKhoa == facultyId)
                                   && (departmentId == 0 || gv.MaBoMon == departmentId)
                                   && (total == null || total.SoTiet == 0)
                                orderby bm.TenBoMon, gv.HoTen
                                select new { gv.MaGV, gv.HoTen, bm.TenBoMon, hv.TenHocVi })
                                .ToList();
                    rows = data.Select((x, i) => new ReportRow
                    {
                        STT = i + 1, MaGV = x.MaGV, HoTen = x.HoTen,
                        TenBoMon = x.TenBoMon, TenHocVi = x.TenHocVi, SoTiet = 0
                    }).ToList();
                }

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", rows));
                reportViewer1.RefreshReport();
                lblTitle.Text = rows.Count == 0
                    ? "BÁO CÁO GIẢNG VIÊN CHƯA ĐƯỢC PHÂN CÔNG — Không có dữ liệu phù hợp"
                    : "BÁO CÁO GIẢNG VIÊN CHƯA ĐƯỢC PHÂN CÔNG";
            }
            catch (Exception ex) { ShowError("Không thể tải dữ liệu báo cáo", ex); }
        }

        private void PrintReport()
        {
            try { reportViewer1.PrintDialog(); }
            catch (Exception ex) { ShowError("Không thể mở hộp thoại in", ex); }
        }

        private void ExportPdf()
        {
            try
            {
                using (var dialog = new SaveFileDialog { Filter = "PDF (*.pdf)|*.pdf", FileName = "BaoCaoGiangVienChuaPhanCong.pdf", Title = "Xuất báo cáo" })
                {
                    if (dialog.ShowDialog(this) != DialogResult.OK) return;
                    File.WriteAllBytes(dialog.FileName, reportViewer1.LocalReport.Render("PDF"));
                    MessageBox.Show(this, "Đã xuất báo cáo PDF thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { ShowError("Không thể xuất báo cáo PDF", ex); }
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show(this, title + ":\r\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonQuaylai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e) { }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
