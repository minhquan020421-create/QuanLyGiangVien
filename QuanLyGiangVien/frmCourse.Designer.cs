namespace QuanLyGiangVien
{
    partial class frmCourse
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
            this.layouttxtMaHocPhan = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaHocPhan = new System.Windows.Forms.Label();
            this.txtMaHocPhan = new System.Windows.Forms.TextBox();
            this.layouttxtTenHocPhan = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenHocPhan = new System.Windows.Forms.Label();
            this.txtTenHocPhan = new System.Windows.Forms.TextBox();
            this.layoutnumSoTinChi = new System.Windows.Forms.TableLayoutPanel();
            this.lblSoTinChi = new System.Windows.Forms.Label();
            this.numSoTinChi = new System.Windows.Forms.NumericUpDown();
            this.layoutnumSoTietLyThuyet = new System.Windows.Forms.TableLayoutPanel();
            this.lblSoTietLyThuyet = new System.Windows.Forms.Label();
            this.numSoTietLyThuyet = new System.Windows.Forms.NumericUpDown();
            this.layoutnumSoTietThucHanh = new System.Windows.Forms.TableLayoutPanel();
            this.lblSoTietThucHanh = new System.Windows.Forms.Label();
            this.numSoTietThucHanh = new System.Windows.Forms.NumericUpDown();
            this.layoutcboMaBoMon = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaBoMon = new System.Windows.Forms.Label();
            this.cboMaBoMon = new System.Windows.Forms.ComboBox();
            this.layoutchkTrangThai = new System.Windows.Forms.TableLayoutPanel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
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
            this.layouttxtMaHocPhan.SuspendLayout();
            this.layouttxtTenHocPhan.SuspendLayout();
            this.layoutnumSoTinChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTinChi)).BeginInit();
            this.layoutnumSoTietLyThuyet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTietLyThuyet)).BeginInit();
            this.layoutnumSoTietThucHanh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTietThucHanh)).BeginInit();
            this.layoutcboMaBoMon.SuspendLayout();
            this.layoutchkTrangThai.SuspendLayout();
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
            this.pnlCuon.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCuon.Name = "pnlCuon";
            this.pnlCuon.Padding = new System.Windows.Forms.Padding(9);
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
            this.layoutChinh.MinimumSize = new System.Drawing.Size(0, 642);
            this.layoutChinh.Name = "layoutChinh";
            this.layoutChinh.Padding = new System.Windows.Forms.Padding(3);
            this.layoutChinh.RowCount = 5;
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutChinh.Size = new System.Drawing.Size(1182, 642);
            this.layoutChinh.TabIndex = 0;
            // 
            // layoutNhap
            // 
            this.layoutNhap.AutoSize = true;
            this.layoutNhap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutNhap.ColumnCount = 3;
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutNhap.Controls.Add(this.layouttxtMaHocPhan, 0, 0);
            this.layoutNhap.Controls.Add(this.layouttxtTenHocPhan, 1, 0);
            this.layoutNhap.Controls.Add(this.layoutnumSoTinChi, 2, 0);
            this.layoutNhap.Controls.Add(this.layoutnumSoTietLyThuyet, 0, 1);
            this.layoutNhap.Controls.Add(this.layoutnumSoTietThucHanh, 1, 1);
            this.layoutNhap.Controls.Add(this.layoutcboMaBoMon, 2, 1);
            this.layoutNhap.Controls.Add(this.layoutchkTrangThai, 0, 2);
            this.layoutNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutNhap.Location = new System.Drawing.Point(3, 3);
            this.layoutNhap.Margin = new System.Windows.Forms.Padding(0);
            this.layoutNhap.Name = "layoutNhap";
            this.layoutNhap.RowCount = 3;
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.Size = new System.Drawing.Size(1176, 227);
            this.layoutNhap.TabIndex = 0;
            // 
            // layouttxtMaHocPhan
            // 
            this.layouttxtMaHocPhan.AutoSize = true;
            this.layouttxtMaHocPhan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtMaHocPhan.ColumnCount = 1;
            this.layouttxtMaHocPhan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtMaHocPhan.Controls.Add(this.lblMaHocPhan, 0, 0);
            this.layouttxtMaHocPhan.Controls.Add(this.txtMaHocPhan, 0, 1);
            this.layouttxtMaHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtMaHocPhan.Location = new System.Drawing.Point(6, 3);
            this.layouttxtMaHocPhan.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtMaHocPhan.Name = "layouttxtMaHocPhan";
            this.layouttxtMaHocPhan.RowCount = 2;
            this.layouttxtMaHocPhan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMaHocPhan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMaHocPhan.Size = new System.Drawing.Size(379, 65);
            this.layouttxtMaHocPhan.TabIndex = 0;
            // 
            // lblMaHocPhan
            // 
            this.lblMaHocPhan.AutoSize = true;
            this.lblMaHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaHocPhan.Location = new System.Drawing.Point(0, 0);
            this.lblMaHocPhan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaHocPhan.Name = "lblMaHocPhan";
            this.lblMaHocPhan.Size = new System.Drawing.Size(379, 25);
            this.lblMaHocPhan.TabIndex = 0;
            this.lblMaHocPhan.Text = "Mã (tự tăng)";
            // 
            // txtMaHocPhan
            // 
            this.txtMaHocPhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaHocPhan.Location = new System.Drawing.Point(0, 29);
            this.txtMaHocPhan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtMaHocPhan.MaxLength = 20;
            this.txtMaHocPhan.Name = "txtMaHocPhan";
            this.txtMaHocPhan.ReadOnly = true;
            this.txtMaHocPhan.Size = new System.Drawing.Size(379, 33);
            this.txtMaHocPhan.TabIndex = 1;
            this.txtMaHocPhan.TabStop = false;
            // 
            // layouttxtTenHocPhan
            // 
            this.layouttxtTenHocPhan.AutoSize = true;
            this.layouttxtTenHocPhan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtTenHocPhan.ColumnCount = 1;
            this.layouttxtTenHocPhan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtTenHocPhan.Controls.Add(this.lblTenHocPhan, 0, 0);
            this.layouttxtTenHocPhan.Controls.Add(this.txtTenHocPhan, 0, 1);
            this.layouttxtTenHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtTenHocPhan.Location = new System.Drawing.Point(397, 3);
            this.layouttxtTenHocPhan.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtTenHocPhan.Name = "layouttxtTenHocPhan";
            this.layouttxtTenHocPhan.RowCount = 2;
            this.layouttxtTenHocPhan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtTenHocPhan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtTenHocPhan.Size = new System.Drawing.Size(379, 65);
            this.layouttxtTenHocPhan.TabIndex = 1;
            // 
            // lblTenHocPhan
            // 
            this.lblTenHocPhan.AutoSize = true;
            this.lblTenHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenHocPhan.Location = new System.Drawing.Point(0, 0);
            this.lblTenHocPhan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTenHocPhan.Name = "lblTenHocPhan";
            this.lblTenHocPhan.Size = new System.Drawing.Size(379, 25);
            this.lblTenHocPhan.TabIndex = 2;
            this.lblTenHocPhan.Text = "Tên học phần";
            // 
            // txtTenHocPhan
            // 
            this.txtTenHocPhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenHocPhan.Location = new System.Drawing.Point(0, 29);
            this.txtTenHocPhan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtTenHocPhan.MaxLength = 150;
            this.txtTenHocPhan.Name = "txtTenHocPhan";
            this.txtTenHocPhan.Size = new System.Drawing.Size(379, 33);
            this.txtTenHocPhan.TabIndex = 3;
            // 
            // layoutnumSoTinChi
            // 
            this.layoutnumSoTinChi.AutoSize = true;
            this.layoutnumSoTinChi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutnumSoTinChi.ColumnCount = 1;
            this.layoutnumSoTinChi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutnumSoTinChi.Controls.Add(this.lblSoTinChi, 0, 0);
            this.layoutnumSoTinChi.Controls.Add(this.numSoTinChi, 0, 1);
            this.layoutnumSoTinChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutnumSoTinChi.Location = new System.Drawing.Point(788, 3);
            this.layoutnumSoTinChi.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutnumSoTinChi.Name = "layoutnumSoTinChi";
            this.layoutnumSoTinChi.RowCount = 2;
            this.layoutnumSoTinChi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutnumSoTinChi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutnumSoTinChi.Size = new System.Drawing.Size(382, 65);
            this.layoutnumSoTinChi.TabIndex = 2;
            // 
            // lblSoTinChi
            // 
            this.lblSoTinChi.AutoSize = true;
            this.lblSoTinChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoTinChi.Location = new System.Drawing.Point(0, 0);
            this.lblSoTinChi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSoTinChi.Name = "lblSoTinChi";
            this.lblSoTinChi.Size = new System.Drawing.Size(382, 25);
            this.lblSoTinChi.TabIndex = 4;
            this.lblSoTinChi.Text = "Số tín chỉ";
            // 
            // numSoTinChi
            // 
            this.numSoTinChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numSoTinChi.Location = new System.Drawing.Point(0, 29);
            this.numSoTinChi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.numSoTinChi.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numSoTinChi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoTinChi.Name = "numSoTinChi";
            this.numSoTinChi.Size = new System.Drawing.Size(382, 33);
            this.numSoTinChi.TabIndex = 5;
            this.numSoTinChi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // layoutnumSoTietLyThuyet
            // 
            this.layoutnumSoTietLyThuyet.AutoSize = true;
            this.layoutnumSoTietLyThuyet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutnumSoTietLyThuyet.ColumnCount = 1;
            this.layoutnumSoTietLyThuyet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutnumSoTietLyThuyet.Controls.Add(this.lblSoTietLyThuyet, 0, 0);
            this.layoutnumSoTietLyThuyet.Controls.Add(this.numSoTietLyThuyet, 0, 1);
            this.layoutnumSoTietLyThuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutnumSoTietLyThuyet.Location = new System.Drawing.Point(6, 77);
            this.layoutnumSoTietLyThuyet.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutnumSoTietLyThuyet.Name = "layoutnumSoTietLyThuyet";
            this.layoutnumSoTietLyThuyet.RowCount = 2;
            this.layoutnumSoTietLyThuyet.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutnumSoTietLyThuyet.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutnumSoTietLyThuyet.Size = new System.Drawing.Size(379, 65);
            this.layoutnumSoTietLyThuyet.TabIndex = 3;
            // 
            // lblSoTietLyThuyet
            // 
            this.lblSoTietLyThuyet.AutoSize = true;
            this.lblSoTietLyThuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoTietLyThuyet.Location = new System.Drawing.Point(0, 0);
            this.lblSoTietLyThuyet.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSoTietLyThuyet.Name = "lblSoTietLyThuyet";
            this.lblSoTietLyThuyet.Size = new System.Drawing.Size(379, 25);
            this.lblSoTietLyThuyet.TabIndex = 6;
            this.lblSoTietLyThuyet.Text = "Tiết lý thuyết";
            // 
            // numSoTietLyThuyet
            // 
            this.numSoTietLyThuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numSoTietLyThuyet.Location = new System.Drawing.Point(0, 29);
            this.numSoTietLyThuyet.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.numSoTietLyThuyet.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numSoTietLyThuyet.Name = "numSoTietLyThuyet";
            this.numSoTietLyThuyet.Size = new System.Drawing.Size(379, 33);
            this.numSoTietLyThuyet.TabIndex = 7;
            // 
            // layoutnumSoTietThucHanh
            // 
            this.layoutnumSoTietThucHanh.AutoSize = true;
            this.layoutnumSoTietThucHanh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutnumSoTietThucHanh.ColumnCount = 1;
            this.layoutnumSoTietThucHanh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutnumSoTietThucHanh.Controls.Add(this.lblSoTietThucHanh, 0, 0);
            this.layoutnumSoTietThucHanh.Controls.Add(this.numSoTietThucHanh, 0, 1);
            this.layoutnumSoTietThucHanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutnumSoTietThucHanh.Location = new System.Drawing.Point(397, 77);
            this.layoutnumSoTietThucHanh.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutnumSoTietThucHanh.Name = "layoutnumSoTietThucHanh";
            this.layoutnumSoTietThucHanh.RowCount = 2;
            this.layoutnumSoTietThucHanh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutnumSoTietThucHanh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutnumSoTietThucHanh.Size = new System.Drawing.Size(379, 65);
            this.layoutnumSoTietThucHanh.TabIndex = 4;
            // 
            // lblSoTietThucHanh
            // 
            this.lblSoTietThucHanh.AutoSize = true;
            this.lblSoTietThucHanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoTietThucHanh.Location = new System.Drawing.Point(0, 0);
            this.lblSoTietThucHanh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSoTietThucHanh.Name = "lblSoTietThucHanh";
            this.lblSoTietThucHanh.Size = new System.Drawing.Size(379, 25);
            this.lblSoTietThucHanh.TabIndex = 8;
            this.lblSoTietThucHanh.Text = "Tiết thực hành";
            // 
            // numSoTietThucHanh
            // 
            this.numSoTietThucHanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numSoTietThucHanh.Location = new System.Drawing.Point(0, 29);
            this.numSoTietThucHanh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.numSoTietThucHanh.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numSoTietThucHanh.Name = "numSoTietThucHanh";
            this.numSoTietThucHanh.Size = new System.Drawing.Size(379, 33);
            this.numSoTietThucHanh.TabIndex = 9;
            // 
            // layoutcboMaBoMon
            // 
            this.layoutcboMaBoMon.AutoSize = true;
            this.layoutcboMaBoMon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboMaBoMon.ColumnCount = 1;
            this.layoutcboMaBoMon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboMaBoMon.Controls.Add(this.lblMaBoMon, 0, 0);
            this.layoutcboMaBoMon.Controls.Add(this.cboMaBoMon, 0, 1);
            this.layoutcboMaBoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboMaBoMon.Location = new System.Drawing.Point(788, 77);
            this.layoutcboMaBoMon.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboMaBoMon.Name = "layoutcboMaBoMon";
            this.layoutcboMaBoMon.RowCount = 2;
            this.layoutcboMaBoMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaBoMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaBoMon.Size = new System.Drawing.Size(382, 65);
            this.layoutcboMaBoMon.TabIndex = 5;
            // 
            // lblMaBoMon
            // 
            this.lblMaBoMon.AutoSize = true;
            this.lblMaBoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaBoMon.Location = new System.Drawing.Point(0, 0);
            this.lblMaBoMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaBoMon.Name = "lblMaBoMon";
            this.lblMaBoMon.Size = new System.Drawing.Size(382, 25);
            this.lblMaBoMon.TabIndex = 10;
            this.lblMaBoMon.Text = "Bộ môn";
            // 
            // cboMaBoMon
            // 
            this.cboMaBoMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaBoMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaBoMon.Location = new System.Drawing.Point(0, 29);
            this.cboMaBoMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboMaBoMon.Name = "cboMaBoMon";
            this.cboMaBoMon.Size = new System.Drawing.Size(382, 33);
            this.cboMaBoMon.TabIndex = 11;
            // 
            // layoutchkTrangThai
            // 
            this.layoutchkTrangThai.AutoSize = true;
            this.layoutchkTrangThai.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutchkTrangThai.ColumnCount = 1;
            this.layoutchkTrangThai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutchkTrangThai.Controls.Add(this.lblTrangThai, 0, 0);
            this.layoutchkTrangThai.Controls.Add(this.chkTrangThai, 0, 1);
            this.layoutchkTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutchkTrangThai.Location = new System.Drawing.Point(6, 151);
            this.layoutchkTrangThai.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutchkTrangThai.Name = "layoutchkTrangThai";
            this.layoutchkTrangThai.RowCount = 2;
            this.layoutchkTrangThai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutchkTrangThai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutchkTrangThai.Size = new System.Drawing.Size(379, 70);
            this.layoutchkTrangThai.TabIndex = 6;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Location = new System.Drawing.Point(0, 0);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(379, 25);
            this.lblTrangThai.TabIndex = 12;
            this.lblTrangThai.Text = "Đang hoạt động";
            // 
            // chkTrangThai
            // 
            this.chkTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTrangThai.AutoSize = true;
            this.chkTrangThai.Checked = true;
            this.chkTrangThai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrangThai.Location = new System.Drawing.Point(0, 29);
            this.chkTrangThai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.chkTrangThai.MinimumSize = new System.Drawing.Size(0, 38);
            this.chkTrangThai.Name = "chkTrangThai";
            this.chkTrangThai.Size = new System.Drawing.Size(379, 38);
            this.chkTrangThai.TabIndex = 13;
            this.chkTrangThai.Text = "Đang hoạt động";
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
            this.pnlNut.Location = new System.Drawing.Point(9, 233);
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
            this.btnThem.TabIndex = 14;
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
            this.btnSua.TabIndex = 15;
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
            this.btnXoa.TabIndex = 16;
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
            this.btnLamMoi.TabIndex = 17;
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
            this.layoutTim.Location = new System.Drawing.Point(3, 290);
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
            this.lblTimKiem.TabIndex = 18;
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
            this.txtTimKiem.TabIndex = 19;
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
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKetQua.Location = new System.Drawing.Point(9, 367);
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
            this.dgvDanhSach.Location = new System.Drawing.Point(9, 404);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(6);
            this.dgvDanhSach.MinimumSize = new System.Drawing.Size(0, 210);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 62;
            this.dgvDanhSach.RowTemplate.Height = 26;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(1164, 229);
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
            this.pnlCuoi.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnQuayLai.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuayLai.MinimumSize = new System.Drawing.Size(168, 48);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(168, 48);
            this.btnQuayLai.TabIndex = 0;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = false;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // frmCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1200, 690);
            this.Controls.Add(this.pnlCuon);
            this.Controls.Add(this.pnlCuoi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(709, 452);
            this.Name = "frmCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý học phần";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlCuon.ResumeLayout(false);
            this.layoutChinh.ResumeLayout(false);
            this.layoutChinh.PerformLayout();
            this.layoutNhap.ResumeLayout(false);
            this.layoutNhap.PerformLayout();
            this.layouttxtMaHocPhan.ResumeLayout(false);
            this.layouttxtMaHocPhan.PerformLayout();
            this.layouttxtTenHocPhan.ResumeLayout(false);
            this.layouttxtTenHocPhan.PerformLayout();
            this.layoutnumSoTinChi.ResumeLayout(false);
            this.layoutnumSoTinChi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTinChi)).EndInit();
            this.layoutnumSoTietLyThuyet.ResumeLayout(false);
            this.layoutnumSoTietLyThuyet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTietLyThuyet)).EndInit();
            this.layoutnumSoTietThucHanh.ResumeLayout(false);
            this.layoutnumSoTietThucHanh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoTietThucHanh)).EndInit();
            this.layoutcboMaBoMon.ResumeLayout(false);
            this.layoutcboMaBoMon.PerformLayout();
            this.layoutchkTrangThai.ResumeLayout(false);
            this.layoutchkTrangThai.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel layouttxtMaHocPhan;
        private System.Windows.Forms.TableLayoutPanel layouttxtTenHocPhan;
        private System.Windows.Forms.TableLayoutPanel layoutnumSoTinChi;
        private System.Windows.Forms.TableLayoutPanel layoutnumSoTietLyThuyet;
        private System.Windows.Forms.TableLayoutPanel layoutnumSoTietThucHanh;
        private System.Windows.Forms.TableLayoutPanel layoutcboMaBoMon;
        private System.Windows.Forms.TableLayoutPanel layoutchkTrangThai;
        private System.Windows.Forms.FlowLayoutPanel pnlNut;
        private System.Windows.Forms.TableLayoutPanel layoutTim;
        private System.Windows.Forms.TableLayoutPanel layoutTuKhoa;
        private System.Windows.Forms.Label lblMaHocPhan;
        private System.Windows.Forms.TextBox txtMaHocPhan;
        private System.Windows.Forms.Label lblTenHocPhan;
        private System.Windows.Forms.TextBox txtTenHocPhan;
        private System.Windows.Forms.Label lblSoTinChi;
        private System.Windows.Forms.NumericUpDown numSoTinChi;
        private System.Windows.Forms.Label lblSoTietLyThuyet;
        private System.Windows.Forms.NumericUpDown numSoTietLyThuyet;
        private System.Windows.Forms.Label lblSoTietThucHanh;
        private System.Windows.Forms.NumericUpDown numSoTietThucHanh;
        private System.Windows.Forms.Label lblMaBoMon;
        private System.Windows.Forms.ComboBox cboMaBoMon;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHocPhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHocPhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTinChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTietLyThuyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTietThucHanh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenBoMon;
    }
}
