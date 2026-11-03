namespace QuanLyGiangVien
{
    partial class frmChartDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.tlpCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chtFacultyByDepartment = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtTeachingLoad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtFacultyByDegree = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.tlpCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtFacultyByDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtTeachingLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtFacultyByDegree)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(58)))), ((int)(((byte)(79)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1178, 85);
            this.panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(371, 45);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "THỐNG KÊ VÀ BIỂU ĐỒ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.cboHocKy);
            this.pnlFilter.Controls.Add(this.lblDepartment);
            this.pnlFilter.Controls.Add(this.cboNamHoc);
            this.pnlFilter.Controls.Add(this.lblFaculty);
            this.pnlFilter.Location = new System.Drawing.Point(0, 91);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1178, 102);
            this.pnlFilter.TabIndex = 3;
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(315, 43);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(250, 29);
            this.cboHocKy.TabIndex = 3;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(310, 15);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(57, 21);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Học kỳ";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Location = new System.Drawing.Point(25, 43);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(250, 29);
            this.cboNamHoc.TabIndex = 1;
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(20, 15);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(73, 21);
            this.lblFaculty.TabIndex = 0;
            this.lblFaculty.Text = "Năm học";
            // 
            // tlpCharts
            // 
            this.tlpCharts.ColumnCount = 2;
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.Controls.Add(this.chtTeachingLoad, 1, 0);
            this.tlpCharts.Controls.Add(this.chtFacultyByDepartment, 0, 0);
            this.tlpCharts.Controls.Add(this.chtFacultyByDegree, 0, 1);
            this.tlpCharts.Location = new System.Drawing.Point(0, 189);
            this.tlpCharts.Name = "tlpCharts";
            this.tlpCharts.Padding = new System.Windows.Forms.Padding(10);
            this.tlpCharts.RowCount = 2;
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.Size = new System.Drawing.Size(1175, 508);
            this.tlpCharts.TabIndex = 4;
            // 
            // chtFacultyByDepartment
            // 
            chartArea2.Name = "ChartArea1";
            this.chtFacultyByDepartment.ChartAreas.Add(chartArea2);
            this.chtFacultyByDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chtFacultyByDepartment.Legends.Add(legend2);
            this.chtFacultyByDepartment.Location = new System.Drawing.Point(15, 15);
            this.chtFacultyByDepartment.Margin = new System.Windows.Forms.Padding(5);
            this.chtFacultyByDepartment.Name = "chtFacultyByDepartment";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chtFacultyByDepartment.Series.Add(series2);
            this.chtFacultyByDepartment.Size = new System.Drawing.Size(567, 234);
            this.chtFacultyByDepartment.TabIndex = 0;
            this.chtFacultyByDepartment.Text = "SỐ GIẢNG VIÊN THEO KHOA";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.DarkBlue;
            title2.Name = "Title1";
            title2.Text = "SỐ GIẢNG VIÊN THEO KHOA";
            this.chtFacultyByDepartment.Titles.Add(title2);
            // 
            // chtTeachingLoad
            // 
            chartArea1.Name = "ChartArea1";
            this.chtTeachingLoad.ChartAreas.Add(chartArea1);
            this.chtTeachingLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chtTeachingLoad.Legends.Add(legend1);
            this.chtTeachingLoad.Location = new System.Drawing.Point(592, 15);
            this.chtTeachingLoad.Margin = new System.Windows.Forms.Padding(5);
            this.chtTeachingLoad.Name = "chtTeachingLoad";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtTeachingLoad.Series.Add(series1);
            this.chtTeachingLoad.Size = new System.Drawing.Size(568, 234);
            this.chtTeachingLoad.TabIndex = 1;
            this.chtTeachingLoad.Text = "SỐ GIẢNG VIÊN THEO KHOA";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.DarkBlue;
            title1.Name = "Title1";
            title1.Text = "KHỐI LƯỢNG GIẢNG DẠY THEO GIẢNG VIÊN";
            this.chtTeachingLoad.Titles.Add(title1);
            // 
            // chtFacultyByDegree
            // 
            this.chtFacultyByDegree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chtFacultyByDegree.ChartAreas.Add(chartArea3);
            this.tlpCharts.SetColumnSpan(this.chtFacultyByDegree, 2);
            legend3.Name = "Legend1";
            this.chtFacultyByDegree.Legends.Add(legend3);
            this.chtFacultyByDegree.Location = new System.Drawing.Point(13, 257);
            this.chtFacultyByDegree.Name = "chtFacultyByDegree";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 3;
            this.chtFacultyByDegree.Series.Add(series3);
            this.chtFacultyByDegree.Size = new System.Drawing.Size(1149, 238);
            this.chtFacultyByDegree.TabIndex = 2;
            this.chtFacultyByDegree.Text = "chart1";
            title3.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "SỐ GIẢNG VIÊN THEO HỌC VỊ";
            this.chtFacultyByDegree.Titles.Add(title3);
            // 
            // frmChartDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1178, 694);
            this.Controls.Add(this.tlpCharts);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "frmChartDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê và biểu đồ";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.tlpCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtFacultyByDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtTeachingLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtFacultyByDegree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.TableLayoutPanel tlpCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtFacultyByDepartment;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtTeachingLoad;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtFacultyByDegree;
    }
}