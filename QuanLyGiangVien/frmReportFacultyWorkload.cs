using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyGiangVien
{
    /// <summary>Báo cáo tải trọng từng khoa; trung bình = tổng tiết / số giảng viên đang hoạt động.</summary>
    public partial class frmReportFacultyWorkload : Form
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
            // Tên thuộc tính phải trùng với Fields của DataSet1 trong RDLC.
            public int STT { get; set; }
            public string TenKhoa { get; set; }
            public int SoLop { get; set; }
            public int TongSoTiet { get; set; }
            public decimal TrungBinhTiet { get; set; }
        }

        public frmReportFacultyWorkload()
        {
            InitializeComponent();
            Theme.Apply(this);
            // Giữ vùng RDLC nền trắng để báo cáo dễ đọc ở cả giao diện sáng và tối.
            reportViewer1.BackColor = System.Drawing.Color.White;
            btQuayLai.Click += (s, e) => Close();
            var setting = ConfigurationManager.ConnectionStrings["QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString1"]
                ?? ConfigurationManager.ConnectionStrings["QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString"];
            if (setting == null || string.IsNullOrWhiteSpace(setting.ConnectionString))
                throw new InvalidOperationException("Không tìm thấy chuỗi kết nối database trong App.config.");
            connectionString = setting.ConnectionString;

            Load += frmReportFacultyWorkload_Load;
            btnViewReport.Click += (s, e) => ShowReport();
            btnPrint.Click += (s, e) => PrintReport();
            btnExportPDF.Click += (s, e) => ExportPdf();
        }

        private void frmReportFacultyWorkload_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            try
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                // Nạp report đã nhúng trong assembly; tên phải trùng ResourceName của project.
                reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyGiangVien.rptFacultyWorkload.rdlc";
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                LoadFilters();
                ShowReport();
            }
            catch (Exception ex) { ShowError("Không thể tải báo cáo tải trọng giảng dạy", ex); }
        }

        private void LoadFilters()
        {
            // ID 0 được dành cho lựa chọn "Tất cả" trong các bộ lọc.
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
                }
            }
            finally { loading = false; }
        }

        private static void SetCombo(ComboBox combo, List<Choice> items)
        {
            // Ánh xạ tên lựa chọn ra giao diện và ID làm giá trị lọc.
            combo.DataSource = items;
            combo.DisplayMember = "Name";
            combo.ValueMember = "Id";
        }

        private static int SelectedId(ComboBox combo)
        {
            // Trả 0 nếu chưa chọn để đại diện không giới hạn bộ lọc.
            var item = combo.SelectedItem as Choice;
            return item == null ? 0 : item.Id;
        }

        private void ShowReport()
        {
            // Dựng tập ReportRow và gắn vào ReportViewer ở chế độ xử lý Local.
            if (loading || reportViewer1.LocalReport == null || cboKhoa.SelectedItem == null) return;
            try
            {
                int yearId = SelectedId(cboNamHoc);
                int semesterId = SelectedId(cboHocKy);
                int facultyId = SelectedId(cboKhoa);
                List<ReportRow> rows;
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    // Tải khoa riêng để vẫn có dòng 0 tiết cho khoa chưa mở lớp trong kỳ.
                    var facultyNames = db.KHOAs.Where(k => facultyId == 0 || k.MaKhoa == facultyId)
                        .Select(k => new { k.MaKhoa, k.TenKhoa }).ToList();
                    // Đếm giảng viên trong một truy vấn gộp, tránh truy vấn SQL riêng cho từng khoa.
                    var teacherCounts = db.GIANG_VIENs.Where(g => g.TrangThai)
                        .GroupBy(g => g.BO_MON.MaKhoa)
                        .Select(g => new { MaKhoa = g.Key, SoGiangVien = g.Count() })
                        .ToDictionary(x => x.MaKhoa, x => x.SoGiangVien);
                    var classRows = (from lop in db.LOP_HOC_PHANs
                                     join hp in db.HOC_PHANs on lop.MaHocPhan equals hp.MaHocPhan
                                     join bm in db.BO_MONs on hp.MaBoMon equals bm.MaBoMon
                                     where lop.TrangThai
                                        && (yearId == 0 || lop.MaNamHoc == yearId)
                                        && (semesterId == 0 || lop.MaHocKy == semesterId)
                                        && (facultyId == 0 || bm.MaKhoa == facultyId)
                                     select new { lop.MaLopHP, bm.MaKhoa }).ToList();
                    var classIds = classRows.Select(x => x.MaLopHP).ToList();
                    var hourRows = db.PHAN_CONG_GIANG_DAYs.Where(x => classIds.Contains(x.MaLopHP))
                        .GroupBy(x => x.MaLopHP)
                        .Select(g => new { MaLopHP = g.Key, SoTiet = g.Sum(x => x.SoTiet) }).ToList();
                    // Ghép số lớp/tiết theo khoa; trung bình chia cho số giảng viên đang hoạt động.
                    rows = facultyNames.Select((faculty, index) =>
                    {
                        var facultyClasses = classRows.Where(x => x.MaKhoa == faculty.MaKhoa).ToList();
                        var facultyClassIds = new HashSet<int>(facultyClasses.Select(x => x.MaLopHP));
                        int totalHours = hourRows.Where(x => facultyClassIds.Contains(x.MaLopHP)).Sum(x => x.SoTiet);
                        int teacherCount;
                        if (!teacherCounts.TryGetValue(faculty.MaKhoa, out teacherCount)) teacherCount = 0;
                        return new ReportRow
                        {
                            STT = index + 1,
                            TenKhoa = faculty.TenKhoa,
                            SoLop = facultyClasses.Select(x => x.MaLopHP).Distinct().Count(),
                            TongSoTiet = totalHours,
                            TrungBinhTiet = teacherCount == 0 ? 0m : Math.Round((decimal)totalHours / teacherCount, 2)
                        };
                    }).ToList();
                }

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", rows));
                reportViewer1.RefreshReport();
                lblTitle.Text = rows.Count == 0
                    ? "BÁO CÁO TẢI TRỌNG GIẢNG DẠY THEO KHOA — Không có dữ liệu"
                    : "BÁO CÁO TẢI TRỌNG GIẢNG DẠY THEO KHOA";
            }
            catch (Exception ex) { ShowError("Không thể tải dữ liệu báo cáo", ex); }
        }

        private void PrintReport()
        {
            // Mở hộp thoại in tích hợp của ReportViewer.
            try { reportViewer1.PrintDialog(); }
            catch (Exception ex) { ShowError("Không thể mở hộp thoại in", ex); }
        }

        private void ExportPdf()
        {
            // Render report hiện tại thành PDF tại vị trí người dùng chọn.
            try
            {
                using (var dialog = new SaveFileDialog { Filter = "PDF (*.pdf)|*.pdf", FileName = "BaoCaoTaiTrongGiangDayTheoKhoa.pdf", Title = "Xuất báo cáo tải trọng" })
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
            // Lỗi truy vấn/render được chuyển thành thông báo thân thiện trong form.
            MessageBox.Show(this, title + ":\r\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
