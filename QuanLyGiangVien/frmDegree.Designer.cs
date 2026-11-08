namespace QuanLyGiangVien
{
    partial class frmDegree
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null) db.Dispose();
                if (components != null) components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlCuon = new System.Windows.Forms.Panel();
            this.layoutChinh = new System.Windows.Forms.TableLayoutPanel();
            this.layoutNhap = new System.Windows.Forms.TableLayoutPanel();
            this.layouttxtMaHocVi = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaHocVi = new System.Windows.Forms.Label();
            this.txtMaHocVi = new System.Windows.Forms.TextBox();
            this.layouttxtTenHocVi = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenHocVi = new System.Windows.Forms.Label();
            this.txtTenHocVi = new System.Windows.Forms.TextBox();
            this.pnlNut = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.layoutTim = new System.Windows.Forms.TableLayoutPanel();
            this.layoutTuKhoa = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.pnlCuoi = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.pnlCuon.SuspendLayout();
            this.layoutChinh.SuspendLayout();
            this.layoutNhap.SuspendLayout();
            this.layouttxtMaHocVi.SuspendLayout();
            this.layouttxtTenHocVi.SuspendLayout();
            this.pnlNut.SuspendLayout();
            this.layoutTim.SuspendLayout();
            this.layoutTuKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.pnlCuoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCuon
            // 
            this.pnlCuon.AutoScroll = true;
            this.pnlCuon.Controls.Add(this.layoutChinh);
            this.pnlCuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuon.Location = new System.Drawing.Point(0, 0);
            this.pnlCuon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCuon.Name = "pnlCuon";
            this.pnlCuon.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.pnlCuon.Size = new System.Drawing.Size(1200, 622);
            this.pnlCuon.TabIndex = 0;
            // 
            // layoutChinh
            // 
            this.layoutChinh.ColumnCount = 1;
            this.layoutChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutChinh.Controls.Add(this.layoutNhap, 0, 0);
            this.layoutChinh.Controls.Add(this.pnlNut, 0, 1);
            this.layoutChinh.Controls.Add(this.layoutTim, 0, 2);
            this.layoutChinh.Controls.Add(this.lblKetQua, 0, 3);
            this.layoutChinh.Controls.Add(this.dgvDanhSach, 0, 4);
            this.layoutChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutChinh.Location = new System.Drawing.Point(9, 9);
            this.layoutChinh.Margin = new System.Windows.Forms.Padding(0);
            this.layoutChinh.MinimumSize = new System.Drawing.Size(0, 477);
            this.layoutChinh.Name = "layoutChinh";
            this.layoutChinh.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.layoutChinh.RowCount = 5;
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutChinh.Size = new System.Drawing.Size(1182, 604);
            this.layoutChinh.TabIndex = 0;
            // 
            // layoutNhap
            // 
            this.layoutNhap.AutoSize = true;
            this.layoutNhap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutNhap.ColumnCount = 2;
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.layoutNhap.Controls.Add(this.layouttxtMaHocVi, 0, 0);
            this.layoutNhap.Controls.Add(this.layouttxtTenHocVi, 1, 0);
            this.layoutNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutNhap.Location = new System.Drawing.Point(3, 3);
            this.layoutNhap.Margin = new System.Windows.Forms.Padding(0);
            this.layoutNhap.Name = "layoutNhap";
            this.layoutNhap.RowCount = 1;
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.Size = new System.Drawing.Size(1176, 74);
            this.layoutNhap.TabIndex = 0;
            // 
            // layouttxtMaHocVi
            // 
            this.layouttxtMaHocVi.AutoSize = true;
            this.layouttxtMaHocVi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtMaHocVi.ColumnCount = 1;
            this.layouttxtMaHocVi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtMaHocVi.Controls.Add(this.lblMaHocVi, 0, 0);
            this.layouttxtMaHocVi.Controls.Add(this.txtMaHocVi, 0, 1);
            this.layouttxtMaHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtMaHocVi.Location = new System.Drawing.Point(6, 3);
            this.layouttxtMaHocVi.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtMaHocVi.Name = "layouttxtMaHocVi";
            this.layouttxtMaHocVi.RowCount = 2;
            this.layouttxtMaHocVi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMaHocVi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMaHocVi.Size = new System.Drawing.Size(282, 65);
            this.layouttxtMaHocVi.TabIndex = 0;
            // 
            // lblMaHocVi
            // 
            this.lblMaHocVi.AutoSize = true;
            this.lblMaHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaHocVi.Location = new System.Drawing.Point(0, 0);
            this.lblMaHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaHocVi.Name = "lblMaHocVi";
            this.lblMaHocVi.Size = new System.Drawing.Size(282, 25);
            this.lblMaHocVi.TabIndex = 0;
            this.lblMaHocVi.Text = "Mã (tự tăng)";
            // 
            // txtMaHocVi
            // 
            this.txtMaHocVi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHocVi.Location = new System.Drawing.Point(0, 29);
            this.txtMaHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtMaHocVi.MaxLength = 20;
            this.txtMaHocVi.Name = "txtMaHocVi";
            this.txtMaHocVi.ReadOnly = true;
            this.txtMaHocVi.Size = new System.Drawing.Size(282, 33);
            this.txtMaHocVi.TabIndex = 1;
            this.txtMaHocVi.TabStop = false;
            // 
            // layouttxtTenHocVi
            // 
            this.layouttxtTenHocVi.AutoSize = true;
            this.layouttxtTenHocVi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtTenHocVi.ColumnCount = 1;
            this.layouttxtTenHocVi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtTenHocVi.Controls.Add(this.lblTenHocVi, 0, 0);
            this.layouttxtTenHocVi.Controls.Add(this.txtTenHocVi, 0, 1);
            this.layouttxtTenHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtTenHocVi.Location = new System.Drawing.Point(300, 3);
            this.layouttxtTenHocVi.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtTenHocVi.Name = "layouttxtTenHocVi";
            this.layouttxtTenHocVi.RowCount = 2;
            this.layouttxtTenHocVi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtTenHocVi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtTenHocVi.Size = new System.Drawing.Size(870, 65);
            this.layouttxtTenHocVi.TabIndex = 1;
            // 
            // lblTenHocVi
            // 
            this.lblTenHocVi.AutoSize = true;
            this.lblTenHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenHocVi.Location = new System.Drawing.Point(0, 0);
            this.lblTenHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTenHocVi.Name = "lblTenHocVi";
            this.lblTenHocVi.Size = new System.Drawing.Size(870, 25);
            this.lblTenHocVi.TabIndex = 2;
            this.lblTenHocVi.Text = "Tên học vị";
            // 
            // txtTenHocVi
            // 
            this.txtTenHocVi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenHocVi.Location = new System.Drawing.Point(0, 29);
            this.txtTenHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtTenHocVi.MaxLength = 50;
            this.txtTenHocVi.Name = "txtTenHocVi";
            this.txtTenHocVi.Size = new System.Drawing.Size(870, 33);
            this.txtTenHocVi.TabIndex = 3;
            // 
            // pnlNut
            // 
            this.pnlNut.AutoSize = true;
            this.pnlNut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlNut.Controls.Add(this.btnThem);
            this.pnlNut.Controls.Add(this.btnSua);
            this.pnlNut.Controls.Add(this.btnXoa);
            this.pnlNut.Controls.Add(this.btnLamMoi);
            this.pnlNut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNut.Location = new System.Drawing.Point(9, 80);
            this.pnlNut.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.pnlNut.Name = "pnlNut";
            this.pnlNut.Size = new System.Drawing.Size(1164, 51);
            this.pnlNut.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.Location = new System.Drawing.Point(0, 0);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0, 0, 12, 3);
            this.btnThem.MinimumSize = new System.Drawing.Size(144, 48);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(144, 48);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = true;
            this.btnSua.Location = new System.Drawing.Point(156, 0);
            this.btnSua.Margin = new System.Windows.Forms.Padding(0, 0, 12, 3);
            this.btnSua.MinimumSize = new System.Drawing.Size(144, 48);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(144, 48);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.Location = new System.Drawing.Point(312, 0);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0, 0, 12, 3);
            this.btnXoa.MinimumSize = new System.Drawing.Size(144, 48);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(144, 48);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.AutoSize = true;
            this.btnLamMoi.Location = new System.Drawing.Point(468, 0);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0, 0, 12, 3);
            this.btnLamMoi.MinimumSize = new System.Drawing.Size(144, 48);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(144, 48);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // layoutTim
            // 
            this.layoutTim.AutoSize = true;
            this.layoutTim.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTim.ColumnCount = 2;
            this.layoutTim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutTim.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutTim.Controls.Add(this.layoutTuKhoa, 0, 0);
            this.layoutTim.Controls.Add(this.btnTimKiem, 1, 0);
            this.layoutTim.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutTim.Location = new System.Drawing.Point(3, 137);
            this.layoutTim.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTim.Name = "layoutTim";
            this.layoutTim.RowCount = 1;
            this.layoutTim.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTim.Size = new System.Drawing.Size(1176, 74);
            this.layoutTim.TabIndex = 2;
            // 
            // layoutTuKhoa
            // 
            this.layoutTuKhoa.AutoSize = true;
            this.layoutTuKhoa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutTuKhoa.ColumnCount = 1;
            this.layoutTuKhoa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutTuKhoa.Controls.Add(this.lblTimKiem, 0, 0);
            this.layoutTuKhoa.Controls.Add(this.txtTimKiem, 0, 1);
            this.layoutTuKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutTuKhoa.Location = new System.Drawing.Point(6, 3);
            this.layoutTuKhoa.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutTuKhoa.Name = "layoutTuKhoa";
            this.layoutTuKhoa.RowCount = 2;
            this.layoutTuKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTuKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTuKhoa.Size = new System.Drawing.Size(964, 65);
            this.layoutTuKhoa.TabIndex = 0;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimKiem.Location = new System.Drawing.Point(0, 0);
            this.lblTimKiem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(964, 25);
            this.lblTimKiem.TabIndex = 8;
            this.lblTimKiem.Text = "Tìm theo mã hoặc tên";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(0, 29);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtTimKiem.MaxLength = 150;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(964, 33);
            this.txtTimKiem.TabIndex = 9;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnTimKiem.AutoSize = true;
            this.btnTimKiem.Location = new System.Drawing.Point(982, 17);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(6, 3, 6, 9);
            this.btnTimKiem.MinimumSize = new System.Drawing.Size(188, 48);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(188, 48);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKetQua.Location = new System.Drawing.Point(9, 214);
            this.lblKetQua.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(1164, 25);
            this.lblKetQua.TabIndex = 3;
            this.lblKetQua.Text = "Chưa tải dữ liệu";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            this.dgvDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(9, 251);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvDanhSach.MinimumSize = new System.Drawing.Size(0, 210);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 62;
            this.dgvDanhSach.RowTemplate.Height = 26;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(1164, 344);
            this.dgvDanhSach.TabIndex = 4;
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);
            // 
            // pnlCuoi
            // 
            this.pnlCuoi.AutoSize = true;
            this.pnlCuoi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlCuoi.Controls.Add(this.btnQuayLai);
            this.pnlCuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCuoi.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlCuoi.Location = new System.Drawing.Point(0, 622);
            this.pnlCuoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCuoi.Name = "pnlCuoi";
            this.pnlCuoi.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.pnlCuoi.Size = new System.Drawing.Size(1200, 68);
            this.pnlCuoi.TabIndex = 1;
            this.pnlCuoi.WrapContents = false;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.AutoSize = true;
            this.btnQuayLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnQuayLai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(1004, 10);
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuayLai.MinimumSize = new System.Drawing.Size(168, 48);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(168, 48);
            this.btnQuayLai.TabIndex = 0;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // frmDegree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1200, 690);
            this.Controls.Add(this.pnlCuon);
            this.Controls.Add(this.pnlCuoi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(709, 452);
            this.Name = "frmDegree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý học vị";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlCuon.ResumeLayout(false);
            this.layoutChinh.ResumeLayout(false);
            this.layoutChinh.PerformLayout();
            this.layoutNhap.ResumeLayout(false);
            this.layoutNhap.PerformLayout();
            this.layouttxtMaHocVi.ResumeLayout(false);
            this.layouttxtMaHocVi.PerformLayout();
            this.layouttxtTenHocVi.ResumeLayout(false);
            this.layouttxtTenHocVi.PerformLayout();
            this.pnlNut.ResumeLayout(false);
            this.pnlNut.PerformLayout();
            this.layoutTim.ResumeLayout(false);
            this.layoutTim.PerformLayout();
            this.layoutTuKhoa.ResumeLayout(false);
            this.layoutTuKhoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.pnlCuoi.ResumeLayout(false);
            this.pnlCuoi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Panel pnlCuon;
        private System.Windows.Forms.FlowLayoutPanel pnlCuoi;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.TableLayoutPanel layoutChinh;
        private System.Windows.Forms.TableLayoutPanel layoutNhap;
        private System.Windows.Forms.TableLayoutPanel layouttxtMaHocVi;
        private System.Windows.Forms.TableLayoutPanel layouttxtTenHocVi;
        private System.Windows.Forms.FlowLayoutPanel pnlNut;
        private System.Windows.Forms.TableLayoutPanel layoutTim;
        private System.Windows.Forms.TableLayoutPanel layoutTuKhoa;
        private System.Windows.Forms.Label lblMaHocVi;
        private System.Windows.Forms.TextBox txtMaHocVi;
        private System.Windows.Forms.Label lblTenHocVi;
        private System.Windows.Forms.TextBox txtTenHocVi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHocVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHocVi;
    }
}
