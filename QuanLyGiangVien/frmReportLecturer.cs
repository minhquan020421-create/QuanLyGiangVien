using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyGiangVien
{
    public partial class frmReportLecturer : Form
    {
        private readonly string connectionString;
        private bool loadingFilters;

        private sealed class FilterItem
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public override string ToString() { return Text; }
        }

        private sealed class LecturerReportRow
        {
            public int MaGV { get; set; }
            public string HoTen { get; set; }
            public string TenBoMon { get; set; }
            public string TenHocVi { get; set; }
            public string TenChucVu { get; set; }
        }

        public frmReportLecturer()
        {
            InitializeComponent();
            Theme.Apply(this);
            reportViewerLecturer.BackColor = System.Drawing.Color.White;
            connectionString = DatabaseConnection.CurrentConnectionString;

            Load += frmReportLecturer_Load;
            btnViewReport.Click += btnViewReport_Click;
            btnPrint.Click += btnPrint_Click;
            btnExportPDF.Click += btnExportPDF_Click;
        }

        private void frmReportLecturer_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) return;
            try
            {
                reportViewerLecturer.LocalReport.ReportPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "rptLecturer.rdlc");
                reportViewerLecturer.ProcessingMode = ProcessingMode.Local;
                reportViewerLecturer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewerLecturer.ZoomMode = ZoomMode.PageWidth;
                LoadFilters();
                ShowReport();
            }
            catch (Exception ex)
            {
                ShowError("Không thể mở báo cáo giảng viên", ex);
            }
        }

        private void LoadFilters()
        {
            loadingFilters = true;
            try
            {
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var faculties = db.KHOAs.OrderBy(x => x.TenKhoa)
                        .Select(x => new FilterItem { Id = x.MaKhoa, Text = x.TenKhoa }).ToList();
                    var degrees = db.HOC_VIs.OrderBy(x => x.TenHocVi)
                        .Select(x => new FilterItem { Id = x.MaHocVi, Text = x.TenHocVi }).ToList();

                    faculties.Insert(0, new FilterItem { Id = 0, Text = "Tất cả" });
                    degrees.Insert(0, new FilterItem { Id = 0, Text = "Tất cả" });
                    cboFaculty.DataSource = faculties;
                    cboFaculty.DisplayMember = "Text";
                    cboFaculty.ValueMember = "Id";
                    cboDegree.DataSource = degrees;
                    cboDegree.DisplayMember = "Text";
                    cboDegree.ValueMember = "Id";

                    cboStatus.Items.Clear();
                    cboStatus.Items.Add(new FilterItem { Id = -1, Text = "Tất cả" });
                    cboStatus.Items.Add(new FilterItem { Id = 1, Text = "Đang hoạt động" });
                    cboStatus.Items.Add(new FilterItem { Id = 0, Text = "Ngừng hoạt động" });
                    cboStatus.DisplayMember = "Text";
                    cboStatus.SelectedIndex = 0;
                    LoadDepartments(db, 0);
                }
            }
            finally { loadingFilters = false; }
        }

        private void LoadDepartments(QuanLyGiangVienDataContext db, int facultyId)
        {
            var departments = db.BO_MONs
                .Where(x => facultyId == 0 || x.MaKhoa == facultyId)
                .OrderBy(x => x.TenBoMon)
                .Select(x => new FilterItem { Id = x.MaBoMon, Text = x.TenBoMon }).ToList();
            departments.Insert(0, new FilterItem { Id = 0, Text = "Tất cả" });
            cboDepartment.DataSource = departments;
            cboDepartment.DisplayMember = "Text";
            cboDepartment.ValueMember = "Id";
        }

        private void cboFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingFilters || cboFaculty.SelectedValue == null) return;
            int facultyId = SelectedId(cboFaculty);
            try
            {
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                    LoadDepartments(db, facultyId);
            }
            catch (Exception ex) { ShowError("Không thể tải danh sách bộ môn", ex); }
        }

        private void btnViewReport_Click(object sender, EventArgs e) { ShowReport(); }

        private void ShowReport()
        {
            try
            {
                int facultyId = SelectedId(cboFaculty);
                int departmentId = SelectedId(cboDepartment);
                int degreeId = SelectedId(cboDegree);
                var statusItem = cboStatus.SelectedItem as FilterItem;
                int statusId = statusItem == null ? -1 : statusItem.Id;

                List<LecturerReportRow> rows;
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var query = from gv in db.GIANG_VIENs
                                join bm in db.BO_MONs on gv.MaBoMon equals bm.MaBoMon
                                join hv in db.HOC_VIs on gv.MaHocVi equals hv.MaHocVi
                                join cv0 in db.CHUC_VUs on gv.MaChucVu equals (int?)cv0.MaChucVu into positions
                                from cv in positions.DefaultIfEmpty()
                                where (facultyId == 0 || bm.MaKhoa == facultyId)
                                   && (departmentId == 0 || gv.MaBoMon == departmentId)
                                   && (degreeId == 0 || gv.MaHocVi == degreeId)
                                   && (statusId < 0 || gv.TrangThai == (statusId == 1))
                                orderby gv.MaGV
                                select new LecturerReportRow
                                {
                                    MaGV = gv.MaGV,
                                    HoTen = gv.HoTen,
                                    TenBoMon = bm.TenBoMon,
                                    TenHocVi = hv.TenHocVi,
                                    TenChucVu = cv == null ? "Chưa có chức vụ" : cv.TenChucVu
                                };
                    rows = query.ToList();
                }

                reportViewerLecturer.LocalReport.DataSources.Clear();
                reportViewerLecturer.LocalReport.DataSources.Add(
                    new ReportDataSource("DataSet1", rows));
                reportViewerLecturer.RefreshReport();
                if (rows.Count == 0)
                    lblReportTitle.Text = "DANH SÁCH GIẢNG VIÊN — Không có dữ liệu phù hợp";
                else
                    lblReportTitle.Text = "DANH SÁCH GIẢNG VIÊN";
            }
            catch (Exception ex) { ShowError("Không thể tải dữ liệu báo cáo", ex); }
        }

        private static int SelectedId(ComboBox combo)
        {
            var item = combo.SelectedItem as FilterItem;
            return item == null ? 0 : item.Id;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try { reportViewerLecturer.PrintDialog(); }
            catch (Exception ex) { ShowError("Không thể mở hộp thoại in", ex); }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new SaveFileDialog
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = "BaoCaoDanhSachGiangVien.pdf",
                    Title = "Xuất báo cáo giảng viên"
                })
                {
                    if (dialog.ShowDialog(this) != DialogResult.OK) return;
                    byte[] pdf = reportViewerLecturer.LocalReport.Render("PDF");
                    File.WriteAllBytes(dialog.FileName, pdf);
                    MessageBox.Show(this, "Đã xuất báo cáo PDF thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { ShowError("Không thể xuất báo cáo PDF", ex); }
        }

        private void ShowError(string title, Exception ex)
        {
            MessageBox.Show(this, title + ":\r\n" + ex.Message, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void reportViewerLecturer_Load(object sender, EventArgs e)
        {

        }

        private void btQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
