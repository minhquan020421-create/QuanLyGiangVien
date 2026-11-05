namespace QuanLyGiangVien
{
    partial class frmTeachingAssignment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlAssignmentInfo = new System.Windows.Forms.Panel();
            this.btnAssign = new System.Windows.Forms.Button();
            this.txtPeriods = new System.Windows.Forms.TextBox();
            this.lblPeriods = new System.Windows.Forms.Label();
            this.cboCourseClass = new System.Windows.Forms.ComboBox();
            this.lblCourseClass = new System.Windows.Forms.Label();
            this.cboLecturer = new System.Windows.Forms.ComboBox();
            this.lblLecturer = new System.Windows.Forms.Label();
            this.lblTeacher = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cboAcademicYear = new System.Windows.Forms.ComboBox();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.lblAssignmentInfo = new System.Windows.Forms.Label();
            this.lblAssignmentList = new System.Windows.Forms.Label();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.colAssignmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLecturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCourseClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSemester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btQuayLai = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlAssignmentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 83);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTitle.Location = new System.Drawing.Point(12, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(401, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PHÂN CÔNG GIẢNG DẠY";
            // 
            // pnlAssignmentInfo
            // 
            this.pnlAssignmentInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlAssignmentInfo.Controls.Add(this.btnAssign);
            this.pnlAssignmentInfo.Controls.Add(this.txtPeriods);
            this.pnlAssignmentInfo.Controls.Add(this.lblPeriods);
            this.pnlAssignmentInfo.Controls.Add(this.cboCourseClass);
            this.pnlAssignmentInfo.Controls.Add(this.lblCourseClass);
            this.pnlAssignmentInfo.Controls.Add(this.cboLecturer);
            this.pnlAssignmentInfo.Controls.Add(this.lblLecturer);
            this.pnlAssignmentInfo.Controls.Add(this.lblTeacher);
            this.pnlAssignmentInfo.Controls.Add(this.cboSemester);
            this.pnlAssignmentInfo.Controls.Add(this.lblSemester);
            this.pnlAssignmentInfo.Controls.Add(this.cboAcademicYear);
            this.pnlAssignmentInfo.Controls.Add(this.lblAcademicYear);
            this.pnlAssignmentInfo.Controls.Add(this.lblAssignmentInfo);
            this.pnlAssignmentInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAssignmentInfo.Location = new System.Drawing.Point(0, 83);
            this.pnlAssignmentInfo.Name = "pnlAssignmentInfo";
            this.pnlAssignmentInfo.Size = new System.Drawing.Size(1200, 344);
            this.pnlAssignmentInfo.TabIndex = 1;
            this.pnlAssignmentInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlAssignmentInfo_Paint);
            // 
            // btnAssign
            // 
            this.btnAssign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.ForeColor = System.Drawing.Color.White;
            this.btnAssign.Location = new System.Drawing.Point(1029, 290);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(150, 40);
            this.btnAssign.TabIndex = 12;
            this.btnAssign.Text = "PHÂN CÔNG";
            this.btnAssign.UseVisualStyleBackColor = false;
            // 
            // txtPeriods
            // 
            this.txtPeriods.Location = new System.Drawing.Point(101, 290);
            this.txtPeriods.Name = "txtPeriods";
            this.txtPeriods.Size = new System.Drawing.Size(190, 26);
            this.txtPeriods.TabIndex = 11;
            // 
            // lblPeriods
            // 
            this.lblPeriods.AutoSize = true;
            this.lblPeriods.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriods.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblPeriods.Location = new System.Drawing.Point(25, 289);
            this.lblPeriods.Name = "lblPeriods";
            this.lblPeriods.Size = new System.Drawing.Size(69, 28);
            this.lblPeriods.TabIndex = 10;
            this.lblPeriods.Text = "Số tiết";
            this.lblPeriods.Click += new System.EventHandler(this.lblPeriods_Click);
            // 
            // cboCourseClass
            // 
            this.cboCourseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourseClass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCourseClass.FormattingEnabled = true;
            this.cboCourseClass.Location = new System.Drawing.Point(375, 228);
            this.cboCourseClass.Name = "cboCourseClass";
            this.cboCourseClass.Size = new System.Drawing.Size(300, 36);
            this.cboCourseClass.TabIndex = 9;
            // 
            // lblCourseClass
            // 
            this.lblCourseClass.AutoSize = true;
            this.lblCourseClass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblCourseClass.Location = new System.Drawing.Point(370, 197);
            this.lblCourseClass.Name = "lblCourseClass";
            this.lblCourseClass.Size = new System.Drawing.Size(140, 28);
            this.lblCourseClass.TabIndex = 8;
            this.lblCourseClass.Text = "Lớp học phần";
            // 
            // cboLecturer
            // 
            this.cboLecturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLecturer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLecturer.FormattingEnabled = true;
            this.cboLecturer.Location = new System.Drawing.Point(20, 228);
            this.cboLecturer.Name = "cboLecturer";
            this.cboLecturer.Size = new System.Drawing.Size(300, 36);
            this.cboLecturer.TabIndex = 7;
            this.cboLecturer.SelectedIndexChanged += new System.EventHandler(this.cboLecturer_SelectedIndexChanged);
            // 
            // lblLecturer
            // 
            this.lblLecturer.AutoSize = true;
            this.lblLecturer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecturer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblLecturer.Location = new System.Drawing.Point(25, 197);
            this.lblLecturer.Name = "lblLecturer";
            this.lblLecturer.Size = new System.Drawing.Size(113, 28);
            this.lblLecturer.TabIndex = 6;
            this.lblLecturer.Text = "Giảng viên";
            this.lblLecturer.Click += new System.EventHandler(this.lblLecturer_Click);
            // 
            // lblTeacher
            // 
            this.lblTeacher.AutoSize = true;
            this.lblTeacher.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeacher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblTeacher.Location = new System.Drawing.Point(25, 157);
            this.lblTeacher.Name = "lblTeacher";
            this.lblTeacher.Size = new System.Drawing.Size(347, 30);
            this.lblTeacher.TabIndex = 5;
            this.lblTeacher.Text = "GIẢNG VIÊN VÀ LỚP HỌC PHẦN";
            // 
            // cboSemester
            // 
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(375, 86);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(300, 36);
            this.cboSemester.TabIndex = 4;
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblSemester.Location = new System.Drawing.Point(370, 55);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(77, 28);
            this.lblSemester.TabIndex = 3;
            this.lblSemester.Text = "Học kỳ";
            // 
            // cboAcademicYear
            // 
            this.cboAcademicYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAcademicYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAcademicYear.FormattingEnabled = true;
            this.cboAcademicYear.Location = new System.Drawing.Point(20, 86);
            this.cboAcademicYear.Name = "cboAcademicYear";
            this.cboAcademicYear.Size = new System.Drawing.Size(300, 36);
            this.cboAcademicYear.TabIndex = 2;
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcademicYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblAcademicYear.Location = new System.Drawing.Point(25, 55);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(97, 28);
            this.lblAcademicYear.TabIndex = 1;
            this.lblAcademicYear.Text = "Năm học";
            // 
            // lblAssignmentInfo
            // 
            this.lblAssignmentInfo.AutoSize = true;
            this.lblAssignmentInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignmentInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblAssignmentInfo.Location = new System.Drawing.Point(25, 15);
            this.lblAssignmentInfo.Name = "lblAssignmentInfo";
            this.lblAssignmentInfo.Size = new System.Drawing.Size(275, 30);
            this.lblAssignmentInfo.TabIndex = 0;
            this.lblAssignmentInfo.Text = "THÔNG TIN PHÂN CÔNG";
            // 
            // lblAssignmentList
            // 
            this.lblAssignmentList.AutoSize = true;
            this.lblAssignmentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignmentList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblAssignmentList.Location = new System.Drawing.Point(17, 442);
            this.lblAssignmentList.Name = "lblAssignmentList";
            this.lblAssignmentList.Size = new System.Drawing.Size(274, 25);
            this.lblAssignmentList.TabIndex = 2;
            this.lblAssignmentList.Tag = "";
            this.lblAssignmentList.Text = "DANH SÁCH PHÂN CÔNG";
            this.lblAssignmentList.Click += new System.EventHandler(this.lblAssignmentList_Click);
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AllowUserToAddRows = false;
            this.dgvAssignments.AllowUserToDeleteRows = false;
            this.dgvAssignments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.dgvAssignments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(58)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssignments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAssignmentID,
            this.colLecturer,
            this.colCourseClass,
            this.colSemester,
            this.colPeriods,
            this.colStatus});
            this.dgvAssignments.EnableHeadersVisualStyles = false;
            this.dgvAssignments.Location = new System.Drawing.Point(0, 483);
            this.dgvAssignments.MultiSelect = false;
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.ReadOnly = true;
            this.dgvAssignments.RowHeadersVisible = false;
            this.dgvAssignments.RowHeadersWidth = 62;
            this.dgvAssignments.RowTemplate.Height = 28;
            this.dgvAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignments.Size = new System.Drawing.Size(1200, 137);
            this.dgvAssignments.TabIndex = 3;
            // 
            // colAssignmentID
            // 
            this.colAssignmentID.HeaderText = "Mã phân công";
            this.colAssignmentID.MinimumWidth = 8;
            this.colAssignmentID.Name = "colAssignmentID";
            this.colAssignmentID.ReadOnly = true;
            // 
            // colLecturer
            // 
            this.colLecturer.HeaderText = "Giảng viên";
            this.colLecturer.MinimumWidth = 8;
            this.colLecturer.Name = "colLecturer";
            this.colLecturer.ReadOnly = true;
            // 
            // colCourseClass
            // 
            this.colCourseClass.HeaderText = "Lớp học phần";
            this.colCourseClass.MinimumWidth = 8;
            this.colCourseClass.Name = "colCourseClass";
            this.colCourseClass.ReadOnly = true;
            // 
            // colSemester
            // 
            this.colSemester.HeaderText = "Học kỳ";
            this.colSemester.MinimumWidth = 8;
            this.colSemester.Name = "colSemester";
            this.colSemester.ReadOnly = true;
            // 
            // colPeriods
            // 
            this.colPeriods.HeaderText = "Số tiết";
            this.colPeriods.MinimumWidth = 8;
            this.colPeriods.Name = "colPeriods";
            this.colPeriods.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // btQuayLai
            // 
            this.btQuayLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btQuayLai.AutoSize = true;
            this.btQuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuayLai.ForeColor = System.Drawing.Color.White;
            this.btQuayLai.Location = new System.Drawing.Point(932, 639);
            this.btQuayLai.Name = "btQuayLai";
            this.btQuayLai.Size = new System.Drawing.Size(256, 39);
            this.btQuayLai.TabIndex = 13;
            this.btQuayLai.Text = "Quay lại";
            this.btQuayLai.UseVisualStyleBackColor = false;
            // 
            // frmTeachingAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1200, 690);
            this.Controls.Add(this.btQuayLai);
            this.Controls.Add(this.dgvAssignments);
            this.Controls.Add(this.lblAssignmentList);
            this.Controls.Add(this.pnlAssignmentInfo);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(1069, 602);
            this.Name = "frmTeachingAssignment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân công giảng dạy";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlAssignmentInfo.ResumeLayout(false);
            this.pnlAssignmentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlAssignmentInfo;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.Label lblAssignmentInfo;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cboAcademicYear;
        private System.Windows.Forms.ComboBox cboLecturer;
        private System.Windows.Forms.Label lblLecturer;
        private System.Windows.Forms.Label lblTeacher;
        private System.Windows.Forms.Label lblCourseClass;
        private System.Windows.Forms.Label lblPeriods;
        private System.Windows.Forms.ComboBox cboCourseClass;
        private System.Windows.Forms.TextBox txtPeriods;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Label lblAssignmentList;
        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLecturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCourseClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSemester;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriods;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btQuayLai;
    }
}