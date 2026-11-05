using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyGiangVien
{
    public partial class frmChartDashboard : Form
    {
        private readonly string connectionString;
        private bool loading;

        private sealed class FilterChoice
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private sealed class ChartPoint
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }

        public frmChartDashboard()
        {
            InitializeComponent();
            connectionString = DatabaseConnection.CurrentConnectionString;
            Load += frmChartDashboard_Load;
            cboNamHoc.SelectedIndexChanged += FilterChanged;
            cboHocKy.SelectedIndexChanged += FilterChanged;
        }

        private void frmChartDashboard_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) return;
            try
            {
                loading = true;
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var years = db.NAM_HOCs.Where(x => x.TrangThai)
                        .OrderByDescending(x => x.TuNam)
                        .Select(x => new FilterChoice { Id = x.MaNamHoc, Name = x.TenNamHoc }).ToList();
                    var semesters = db.HOC_Kies.OrderBy(x => x.MaHocKy)
                        .Select(x => new FilterChoice { Id = x.MaHocKy, Name = x.TenHocKy }).ToList();
                    years.Insert(0, new FilterChoice { Id = 0, Name = "Tất cả" });
                    semesters.Insert(0, new FilterChoice { Id = 0, Name = "Tất cả" });
                    BindCombo(cboNamHoc, years);
                    BindCombo(cboHocKy, semesters);
                }
                ConfigureCharts();
                loading = false;
                RefreshCharts();
            }
            catch (Exception ex)
            {
                loading = false;
                ShowError("Không thể tải dữ liệu thống kê. Hãy kiểm tra SQL Server và App.config.", ex);
            }
        }

        private static void BindCombo(ComboBox combo, List<FilterChoice> values)
        {
            combo.DataSource = values;
            combo.DisplayMember = "Name";
            combo.ValueMember = "Id";
        }

        private void ConfigureCharts()
        {
            SetColumnChart(chtFacultyByDepartment, "Số giảng viên");
            SetColumnChart(chtTeachingLoad, "Số tiết");

            var pie = chtFacultyByDegree.Series[0];
            pie.Name = "Số giảng viên";
            pie.ChartType = SeriesChartType.Pie;
            pie.IsValueShownAsLabel = true;
            pie.Label = "#VALX: #VALY";
            pie.LegendText = "#VALX";
            chtFacultyByDegree.Legends[0].Enabled = true;
        }

        private static void SetColumnChart(Chart chart, string seriesName)
        {
            var series = chart.Series[0];
            series.Name = seriesName;
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.XValueType = ChartValueType.String;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -35;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chart.Legends[0].Enabled = false;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            if (!loading && IsHandleCreated) LoadTeachingLoad();
        }

        private void RefreshCharts()
        {
            LoadLecturersByFaculty();
            LoadTeachingLoad();
            LoadLecturersByDegree();
        }

        private void LoadLecturersByFaculty()
        {
            using (var db = new QuanLyGiangVienDataContext(connectionString))
            {
                var values = db.KHOAs.OrderBy(x => x.TenKhoa)
                    .Select(k => new ChartPoint
                    {
                        Name = k.TenKhoa,
                        Value = k.BO_MONs.SelectMany(b => b.GIANG_VIENs).Count(g => g.TrangThai)
                    }).ToList();
                FillColumn(chtFacultyByDepartment, values);
            }
        }

        private void LoadTeachingLoad()
        {
            try
            {
                int yearId = SelectedId(cboNamHoc);
                int semesterId = SelectedId(cboHocKy);
                using (var db = new QuanLyGiangVienDataContext(connectionString))
                {
                    var values = db.PHAN_CONG_GIANG_DAYs
                        .Where(x => x.GIANG_VIEN.TrangThai && x.LOP_HOC_PHAN.TrangThai
                            && (yearId == 0 || x.LOP_HOC_PHAN.MaNamHoc == yearId)
                            && (semesterId == 0 || x.LOP_HOC_PHAN.MaHocKy == semesterId))
                        .GroupBy(x => new { x.MaGV, x.GIANG_VIEN.HoTen })
                        .Select(g => new ChartPoint { Name = g.Key.HoTen, Value = g.Sum(x => x.SoTiet) })
                        .OrderByDescending(x => x.Value)
                        .ToList();
                    FillColumn(chtTeachingLoad, values);
                }
            }
            catch (Exception ex) { ShowError("Không thể tính khối lượng giảng dạy", ex); }
        }

        private void LoadLecturersByDegree()
        {
            using (var db = new QuanLyGiangVienDataContext(connectionString))
            {
                var values = db.HOC_VIs.OrderBy(x => x.TenHocVi)
                    .Select(h => new ChartPoint
                    {
                        Name = h.TenHocVi,
                        Value = h.GIANG_VIENs.Count(g => g.TrangThai)
                    }).ToList();
                var series = chtFacultyByDegree.Series[0];
                series.Points.Clear();
                foreach (var item in values)
                {
                    int index = series.Points.AddXY(item.Name, item.Value);
                    series.Points[index].LegendText = item.Name;
                    series.Points[index].Label = item.Value.ToString();
                }
            }
        }

        private static void FillColumn(Chart chart, IEnumerable<ChartPoint> values)
        {
            var series = chart.Series[0];
            series.Points.Clear();
            foreach (var item in values)
            {
                int index = series.Points.AddXY(item.Name, item.Value);
                series.Points[index].Label = item.Value.ToString();
                series.Points[index].ToolTip = item.Name + ": " + item.Value;
            }
        }

        private static int SelectedId(ComboBox combo)
        {
            var choice = combo.SelectedItem as FilterChoice;
            return choice == null ? 0 : choice.Id;
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(this, message + "\r\n" + ex.Message, "Lỗi thống kê",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
