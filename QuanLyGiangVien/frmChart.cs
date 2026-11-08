using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyGiangVien
{
    public partial class frmChart : Form
    {
        private readonly string connectionString;
        private bool loading;

        private sealed class Choice
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private sealed class FacultyStat
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int LecturerCount { get; set; }
            public int ClassCount { get; set; }
            public int TotalHours { get; set; }
        }

        public frmChart()
        {
            InitializeComponent();
            Theme.Apply(this);

            var setting = ConfigurationManager.ConnectionStrings["QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString1"]
                ?? ConfigurationManager.ConnectionStrings["QuanLyGiangVien.Properties.Settings.QuanLyGiangVienConnectionString"];
            if (setting == null || string.IsNullOrWhiteSpace(setting.ConnectionString))
                throw new InvalidOperationException("Không tìm thấy chuỗi kết nối database trong App.config.");
            connectionString = setting.ConnectionString;

            Load += frmChart_Load;
            btQuayLai.Click += (s, e) => Close();
            cboNamHoc.SelectedIndexChanged += FilterChanged;
            cboHocKy.SelectedIndexChanged += FilterChanged;
            cboKhoa.SelectedIndexChanged += FilterChanged;
            comboBox1.SelectedIndexChanged += FilterChanged;
            comboBox2.SelectedIndexChanged += FilterChanged;
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            try
            {
                loading = true;
                LoadFilters();
                ConfigureChart();
                loading = false;
                RefreshStatistics();
            }
            catch (Exception ex)
            {
                loading = false;
                ShowError("Không thể tải thống kê. Hãy kiểm tra SQL Server và cấu hình kết nối.", ex);
            }
        }

        private void LoadFilters()
        {
            using (var db = new QuanLyGiangVienDataContext(connectionString))
            {
                var years = db.NAM_HOCs.OrderByDescending(x => x.TuNam)
                    .Select(x => new Choice { Id = x.MaNamHoc, Name = x.TenNamHoc }).ToList();
                var semesters = db.HOC_Kies.OrderBy(x => x.MaHocKy)
                    .Select(x => new Choice { Id = x.MaHocKy, Name = x.TenHocKy }).ToList();
                var faculties = db.KHOAs.Where(x => x.TrangThai).OrderBy(x => x.TenKhoa)
                    .Select(x => new Choice { Id = x.MaKhoa, Name = x.TenKhoa }).ToList();
                years.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                semesters.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                faculties.Insert(0, new Choice { Id = 0, Name = "Tất cả" });
                BindCombo(cboNamHoc, years);
                BindCombo(cboHocKy, semesters);
                BindCombo(cboKhoa, faculties);

                comboBox1.Items.Clear();
                comboBox1.Items.Add("Giảng viên");
                comboBox1.Items.Add("Lớp học phần");
                comboBox1.Items.Add("Tổng số tiết");
                comboBox1.SelectedIndex = 0;

                comboBox2.Items.Clear();
                comboBox2.Items.Add("Biểu đồ cột");
                comboBox2.Items.Add("Biểu đồ tròn");
                comboBox2.SelectedIndex = 0;
            }
        }

        private static void BindCombo(ComboBox combo, List<Choice> choices)
        {
            combo.DataSource = choices;
            combo.DisplayMember = "Name";
            combo.ValueMember = "Id";
        }

        private static int SelectedId(ComboBox combo)
        {
            var choice = combo.SelectedItem as Choice;
            return choice == null ? 0 : choice.Id;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            if (!loading && IsHandleCreated) RefreshStatistics();
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            RefreshStatistics();
        }

        private void RefreshStatistics()
        {
            if (loading || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || cboKhoa.SelectedItem == null) return;
            try
            {
                int yearId = SelectedId(cboNamHoc);
                int semesterId = SelectedId(cboHocKy);
                int facultyId = SelectedId(cboKhoa);
                List<FacultyStat> stats;

                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var faculties = db.KHOAs.Where(k => k.TrangThai && (facultyId == 0 || k.MaKhoa == facultyId))
                        .OrderBy(k => k.TenKhoa)
                        .Select(k => new FacultyStat
                        {
                            Id = k.MaKhoa,
                            Name = k.TenKhoa,
                            LecturerCount = k.BO_MONs.SelectMany(b => b.GIANG_VIENs).Count(g => g.TrangThai)
                        }).ToList();

                    var classData = (from lop in db.LOP_HOC_PHANs
                                     join hp in db.HOC_PHANs on lop.MaHocPhan equals hp.MaHocPhan
                                     join bm in db.BO_MONs on hp.MaBoMon equals bm.MaBoMon
                                     where lop.TrangThai
                                        && bm.KHOA.TrangThai
                                        && (yearId == 0 || lop.MaNamHoc == yearId)
                                        && (semesterId == 0 || lop.MaHocKy == semesterId)
                                        && (facultyId == 0 || bm.MaKhoa == facultyId)
                                     select new { lop.MaLopHP, bm.MaKhoa }).ToList();
                    var classIds = classData.Select(x => x.MaLopHP).ToList();
                    var hoursByClass = db.PHAN_CONG_GIANG_DAYs
                        .Where(x => classIds.Contains(x.MaLopHP) && x.GIANG_VIEN.TrangThai)
                        .GroupBy(x => x.MaLopHP)
                        .Select(g => new { MaLopHP = g.Key, SoTiet = g.Sum(x => x.SoTiet) }).ToList();

                    stats = faculties.Select(f =>
                    {
                        var facultyClasses = classData.Where(x => x.MaKhoa == f.Id).ToList();
                        var ids = new HashSet<int>(facultyClasses.Select(x => x.MaLopHP));
                        f.ClassCount = facultyClasses.Count;
                        f.TotalHours = hoursByClass.Where(x => ids.Contains(x.MaLopHP)).Sum(x => x.SoTiet);
                        return f;
                    }).ToList();
                }

                int lecturerTotal = stats.Sum(x => x.LecturerCount);
                int classTotal = stats.Sum(x => x.ClassCount);
                int hourTotal = stats.Sum(x => x.TotalHours);
                label3.Text = lecturerTotal.ToString("N0");
                label8.Text = classTotal.ToString("N0");
                label9.Text = hourTotal.ToString("N0");
                label10.Text = stats.Count.ToString("N0");

                string metric = comboBox1.SelectedItem.ToString();
                var points = stats.Select(s => new
                {
                    s.Name,
                    Value = metric == "Lớp học phần" ? s.ClassCount : metric == "Tổng số tiết" ? s.TotalHours : s.LecturerCount
                }).ToList();
                RenderChart(points.Select(x => new KeyValuePair<string, int>(x.Name, x.Value)).ToList(), metric,
                    comboBox2.SelectedIndex == 1);
                Theme.Apply(this);
            }
            catch (Exception ex) { ShowError("Không thể cập nhật thống kê.", ex); }
        }

        private void ConfigureChart()
        {
            chartThongKe.Series.Clear();
            chartThongKe.ChartAreas.Clear();
            chartThongKe.Legends.Clear();
            var area = new ChartArea("ChartArea1");
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -30;
            area.AxisY.Minimum = 0;
            area.AxisY.LabelStyle.Format = "N0";
            chartThongKe.ChartAreas.Add(area);
            chartThongKe.Legends.Add(new Legend("Legend1"));
        }

        private void RenderChart(List<KeyValuePair<string, int>> values, string metric, bool pie)
        {
            chartThongKe.Series.Clear();
            var series = new Series("Số liệu")
            {
                ChartArea = "ChartArea1",
                Legend = "Legend1",
                ChartType = pie ? SeriesChartType.Pie : SeriesChartType.Column,
                // Ten khoa va ti le duoc doc trong chu giai/tooltip; khong chen chu len cac lat banh.
                IsValueShownAsLabel = !pie,
                XValueType = ChartValueType.String
            };
            if (pie)
            {
                // Nhung muc 0 khong tao lat banh, tranh nhan 0% chong len nhau.
                series.Label = string.Empty;
                // Explicitly disable pie labels: the WinForms chart can still render
                // category names when the default PieLabelStyle is enabled.
                series["PieLabelStyle"] = "Disabled";
                series.LegendText = "#VALX";
                chartThongKe.Legends[0].Enabled = true;
                chartThongKe.Legends[0].Docking = Docking.Right;
                chartThongKe.Legends[0].Alignment = StringAlignment.Center;
                // A larger legend font improves readability and scales its color keys.
                chartThongKe.Legends[0].Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            }
            else
            {
                series.Label = "#VALY{N0}";
                chartThongKe.Legends[0].Enabled = false;
            }

            foreach (var point in pie ? values.Where(x => x.Value > 0) : values)
            {
                int index = series.Points.AddXY(point.Key, point.Value);
                if (pie) series.Points[index].Label = string.Empty;
                series.Points[index].ToolTip = point.Key + ": " + point.Value.ToString("N0");
            }
            chartThongKe.Series.Add(series);
            chartThongKe.Titles.Clear();
            chartThongKe.Titles.Add("Thống kê " + metric.ToLowerInvariant() + " theo khoa");
            chartThongKe.Invalidate();
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(this, message + "\r\n" + ex.Message, "Lỗi thống kê", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
