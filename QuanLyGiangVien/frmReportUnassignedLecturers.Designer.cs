namespace QuanLyGiangVien
{
    partial class frmReportUnassignedLecturers
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
            this.buttonQuaylai = new System.Windows.Forms.Button();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblDegree = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlFilter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQuaylai
            // 
            this.buttonQuaylai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuaylai.AutoSize = true;
            this.buttonQuaylai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.buttonQuaylai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuaylai.ForeColor = System.Drawing.Color.White;
            this.buttonQuaylai.Location = new System.Drawing.Point(1151, 836);
            this.buttonQuaylai.Name = "buttonQuaylai";
            this.buttonQuaylai.Size = new System.Drawing.Size(256, 39);
            this.buttonQuaylai.TabIndex = 18;
            this.buttonQuaylai.Text = "Quay lại";
            this.buttonQuaylai.UseVisualStyleBackColor = false;
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFaculty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblFaculty.Location = new System.Drawing.Point(20, 15);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(88, 25);
            this.lblFaculty.TabIndex = 0;
            this.lblFaculty.Text = "Năm học";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.BackColor = System.Drawing.SystemColors.Window;
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Location = new System.Drawing.Point(25, 43);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(250, 28);
            this.cboNamHoc.TabIndex = 1;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblDepartment.Location = new System.Drawing.Point(310, 15);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(71, 25);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Học kỳ";
            // 
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(315, 43);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(250, 28);
            this.cboHocKy.TabIndex = 3;
            // 
            // lblDegree
            // 
            this.lblDegree.AutoSize = true;
            this.lblDegree.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDegree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblDegree.Location = new System.Drawing.Point(600, 15);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(56, 25);
            this.lblDegree.TabIndex = 2;
            this.lblDegree.Text = "Khoa";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(605, 43);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(250, 28);
            this.cboKhoa.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(20, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bộ môn ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(25, 114);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(250, 28);
            this.comboBox1.TabIndex = 6;
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnViewReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.Color.White;
            this.btnViewReport.Location = new System.Drawing.Point(482, 107);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(174, 36);
            this.btnViewReport.TabIndex = 5;
            this.btnViewReport.Text = "🔍 Xem báo cáo";
            this.btnViewReport.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(676, 107);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 36);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "▣ In";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnExportPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Location = new System.Drawing.Point(780, 107);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(137, 36);
            this.btnExportPDF.TabIndex = 8;
            this.btnExportPDF.Text = "▣ Xuất PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlFilter.Controls.Add(this.btnExportPDF);
            this.pnlFilter.Controls.Add(this.btnPrint);
            this.pnlFilter.Controls.Add(this.btnViewReport);
            this.pnlFilter.Controls.Add(this.comboBox1);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.cboKhoa);
            this.pnlFilter.Controls.Add(this.lblDegree);
            this.pnlFilter.Controls.Add(this.cboHocKy);
            this.pnlFilter.Controls.Add(this.lblDepartment);
            this.pnlFilter.Controls.Add(this.cboNamHoc);
            this.pnlFilter.Controls.Add(this.lblFaculty);
            this.pnlFilter.Location = new System.Drawing.Point(0, 89);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1419, 163);
            this.pnlFilter.TabIndex = 15;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(11, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(766, 45);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "BÁO CÁO GIẢNG VIÊN CHƯA ĐƯỢC PHÂN CÔNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1419, 97);
            this.panelHeader.TabIndex = 14;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyGiangVien.rptfrmReportUnassignedLecturers.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 249);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1419, 569);
            this.reportViewer1.TabIndex = 16;
            // 
            // frmReportUnassignedLecturers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1419, 887);
            this.Controls.Add(this.buttonQuaylai);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.reportViewer1);
            this.MinimumSize = new System.Drawing.Size(1357, 943);
            this.Name = "frmReportUnassignedLecturers";
            this.Text = "Báo cáo giảng viên chưa được phân công";
            this.Load += new System.EventHandler(this.frmReportUnassignedLecturers_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonQuaylai;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelHeader;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
