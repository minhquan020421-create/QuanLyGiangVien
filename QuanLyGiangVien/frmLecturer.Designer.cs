namespace QuanLyGiangVien
{
    partial class frmLecturer
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
            this.layouttxtMaGV = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaGV = new System.Windows.Forms.Label();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.layouttxtHoTen = new System.Windows.Forms.TableLayoutPanel();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.layouttxtEmail = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.layoutdtpNgaySinh = new System.Windows.Forms.TableLayoutPanel();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.layoutcboGioiTinh = new System.Windows.Forms.TableLayoutPanel();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.layouttxtSoDienThoai = new System.Windows.Forms.TableLayoutPanel();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.layouttxtDiaChi = new System.Windows.Forms.TableLayoutPanel();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.layoutdtpNgayVaoTruong = new System.Windows.Forms.TableLayoutPanel();
            this.lblNgayVaoTruong = new System.Windows.Forms.Label();
            this.dtpNgayVaoTruong = new System.Windows.Forms.DateTimePicker();
            this.layoutcboMaKhoa = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.cboMaKhoa = new System.Windows.Forms.ComboBox();
            this.layoutcboMaBoMon = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaBoMon = new System.Windows.Forms.Label();
            this.cboMaBoMon = new System.Windows.Forms.ComboBox();
            this.layoutcboMaHocVi = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaHocVi = new System.Windows.Forms.Label();
            this.cboMaHocVi = new System.Windows.Forms.ComboBox();
            this.layoutcboMaChucVu = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaChucVu = new System.Windows.Forms.Label();
            this.cboMaChucVu = new System.Windows.Forms.ComboBox();
            this.layoutchkTrangThai = new System.Windows.Forms.TableLayoutPanel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.chkTrangThai = new System.Windows.Forms.CheckBox();
            this.pnlNut = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.layoutLoc = new System.Windows.Forms.TableLayoutPanel();
            this.layoutcboLocKhoa = new System.Windows.Forms.TableLayoutPanel();
            this.lblcboLocKhoa = new System.Windows.Forms.Label();
            this.cboLocKhoa = new System.Windows.Forms.ComboBox();
            this.layoutcboLocBoMon = new System.Windows.Forms.TableLayoutPanel();
            this.lblcboLocBoMon = new System.Windows.Forms.Label();
            this.cboLocBoMon = new System.Windows.Forms.ComboBox();
            this.layoutcboLocHocVi = new System.Windows.Forms.TableLayoutPanel();
            this.lblcboLocHocVi = new System.Windows.Forms.Label();
            this.cboLocHocVi = new System.Windows.Forms.ComboBox();
            this.layoutcboLocTrangThai = new System.Windows.Forms.TableLayoutPanel();
            this.lblcboLocTrangThai = new System.Windows.Forms.Label();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
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
            this.layouttxtMaGV.SuspendLayout();
            this.layouttxtHoTen.SuspendLayout();
            this.layouttxtEmail.SuspendLayout();
            this.layoutdtpNgaySinh.SuspendLayout();
            this.layoutcboGioiTinh.SuspendLayout();
            this.layouttxtSoDienThoai.SuspendLayout();
            this.layouttxtDiaChi.SuspendLayout();
            this.layoutdtpNgayVaoTruong.SuspendLayout();
            this.layoutcboMaKhoa.SuspendLayout();
            this.layoutcboMaBoMon.SuspendLayout();
            this.layoutcboMaHocVi.SuspendLayout();
            this.layoutcboMaChucVu.SuspendLayout();
            this.layoutchkTrangThai.SuspendLayout();
            this.pnlNut.SuspendLayout();
            this.layoutLoc.SuspendLayout();
            this.layoutcboLocKhoa.SuspendLayout();
            this.layoutcboLocBoMon.SuspendLayout();
            this.layoutcboLocHocVi.SuspendLayout();
            this.layoutcboLocTrangThai.SuspendLayout();
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
            this.pnlCuon.Size = new System.Drawing.Size(1200, 712);
            this.pnlCuon.TabIndex = 0;
            // 
            // layoutChinh
            // 
            this.layoutChinh.ColumnCount = 1;
            this.layoutChinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutChinh.Controls.Add(this.layoutNhap, 0, 0);
            this.layoutChinh.Controls.Add(this.pnlNut, 0, 1);
            this.layoutChinh.Controls.Add(this.layoutLoc, 0, 2);
            this.layoutChinh.Controls.Add(this.layoutTim, 0, 3);
            this.layoutChinh.Controls.Add(this.lblKetQua, 0, 4);
            this.layoutChinh.Controls.Add(this.dgvDanhSach, 0, 5);
            this.layoutChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutChinh.Location = new System.Drawing.Point(9, 9);
            this.layoutChinh.Margin = new System.Windows.Forms.Padding(0);
            this.layoutChinh.MinimumSize = new System.Drawing.Size(882, 777);
            this.layoutChinh.Name = "layoutChinh";
            this.layoutChinh.Padding = new System.Windows.Forms.Padding(3);
            this.layoutChinh.RowCount = 6;
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutChinh.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutChinh.Size = new System.Drawing.Size(1182, 777);
            this.layoutChinh.TabIndex = 0;
            // 
            // layoutNhap
            // 
            this.layoutNhap.AutoSize = true;
            this.layoutNhap.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutNhap.ColumnCount = 4;
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutNhap.Controls.Add(this.layouttxtMaGV, 0, 0);
            this.layoutNhap.Controls.Add(this.layouttxtHoTen, 1, 0);
            this.layoutNhap.Controls.Add(this.layouttxtEmail, 2, 0);
            this.layoutNhap.Controls.Add(this.layoutdtpNgaySinh, 3, 0);
            this.layoutNhap.Controls.Add(this.layoutcboGioiTinh, 0, 1);
            this.layoutNhap.Controls.Add(this.layouttxtSoDienThoai, 1, 1);
            this.layoutNhap.Controls.Add(this.layouttxtDiaChi, 2, 1);
            this.layoutNhap.Controls.Add(this.layoutdtpNgayVaoTruong, 3, 1);
            this.layoutNhap.Controls.Add(this.layoutcboMaKhoa, 0, 2);
            this.layoutNhap.Controls.Add(this.layoutcboMaBoMon, 1, 2);
            this.layoutNhap.Controls.Add(this.layoutcboMaHocVi, 2, 2);
            this.layoutNhap.Controls.Add(this.layoutcboMaChucVu, 3, 2);
            this.layoutNhap.Controls.Add(this.layoutchkTrangThai, 0, 3);
            this.layoutNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutNhap.Location = new System.Drawing.Point(3, 3);
            this.layoutNhap.Margin = new System.Windows.Forms.Padding(0);
            this.layoutNhap.Name = "layoutNhap";
            this.layoutNhap.RowCount = 4;
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.Size = new System.Drawing.Size(1176, 301);
            this.layoutNhap.TabIndex = 0;
            // 
            // layouttxtMaGV
            // 
            this.layouttxtMaGV.AutoSize = true;
            this.layouttxtMaGV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtMaGV.ColumnCount = 1;
            this.layouttxtMaGV.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtMaGV.Controls.Add(this.lblMaGV, 0, 0);
            this.layouttxtMaGV.Controls.Add(this.txtMaGV, 0, 1);
            this.layouttxtMaGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtMaGV.Location = new System.Drawing.Point(6, 3);
            this.layouttxtMaGV.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtMaGV.Name = "layouttxtMaGV";
            this.layouttxtMaGV.RowCount = 2;
            this.layouttxtMaGV.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMaGV.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMaGV.Size = new System.Drawing.Size(282, 65);
            this.layouttxtMaGV.TabIndex = 0;
            // 
            // lblMaGV
            // 
            this.lblMaGV.AutoSize = true;
            this.lblMaGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaGV.Location = new System.Drawing.Point(0, 0);
            this.lblMaGV.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaGV.Name = "lblMaGV";
            this.lblMaGV.Size = new System.Drawing.Size(282, 25);
            this.lblMaGV.TabIndex = 0;
            this.lblMaGV.Text = "Mã GV (tự tăng)";
            // 
            // txtMaGV
            // 
            this.txtMaGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaGV.Location = new System.Drawing.Point(0, 29);
            this.txtMaGV.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtMaGV.MaxLength = 20;
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.ReadOnly = true;
            this.txtMaGV.Size = new System.Drawing.Size(282, 33);
            this.txtMaGV.TabIndex = 1;
            this.txtMaGV.TabStop = false;
            // 
            // layouttxtHoTen
            // 
            this.layouttxtHoTen.AutoSize = true;
            this.layouttxtHoTen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtHoTen.ColumnCount = 1;
            this.layouttxtHoTen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtHoTen.Controls.Add(this.lblHoTen, 0, 0);
            this.layouttxtHoTen.Controls.Add(this.txtHoTen, 0, 1);
            this.layouttxtHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtHoTen.Location = new System.Drawing.Point(300, 3);
            this.layouttxtHoTen.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtHoTen.Name = "layouttxtHoTen";
            this.layouttxtHoTen.RowCount = 2;
            this.layouttxtHoTen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtHoTen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtHoTen.Size = new System.Drawing.Size(282, 65);
            this.layouttxtHoTen.TabIndex = 1;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHoTen.Location = new System.Drawing.Point(0, 0);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(282, 25);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoTen.Location = new System.Drawing.Point(0, 29);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(282, 33);
            this.txtHoTen.TabIndex = 3;
            // 
            // layouttxtEmail
            // 
            this.layouttxtEmail.AutoSize = true;
            this.layouttxtEmail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtEmail.ColumnCount = 1;
            this.layouttxtEmail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtEmail.Controls.Add(this.lblEmail, 0, 0);
            this.layouttxtEmail.Controls.Add(this.txtEmail, 0, 1);
            this.layouttxtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtEmail.Location = new System.Drawing.Point(594, 3);
            this.layouttxtEmail.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtEmail.Name = "layouttxtEmail";
            this.layouttxtEmail.RowCount = 2;
            this.layouttxtEmail.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtEmail.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtEmail.Size = new System.Drawing.Size(282, 65);
            this.layouttxtEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(0, 0);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(282, 25);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(0, 29);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(282, 33);
            this.txtEmail.TabIndex = 5;
            // 
            // layoutdtpNgaySinh
            // 
            this.layoutdtpNgaySinh.AutoSize = true;
            this.layoutdtpNgaySinh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutdtpNgaySinh.ColumnCount = 1;
            this.layoutdtpNgaySinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutdtpNgaySinh.Controls.Add(this.lblNgaySinh, 0, 0);
            this.layoutdtpNgaySinh.Controls.Add(this.dtpNgaySinh, 0, 1);
            this.layoutdtpNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutdtpNgaySinh.Location = new System.Drawing.Point(888, 3);
            this.layoutdtpNgaySinh.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutdtpNgaySinh.Name = "layoutdtpNgaySinh";
            this.layoutdtpNgaySinh.RowCount = 2;
            this.layoutdtpNgaySinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutdtpNgaySinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutdtpNgaySinh.Size = new System.Drawing.Size(282, 65);
            this.layoutdtpNgaySinh.TabIndex = 3;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgaySinh.Location = new System.Drawing.Point(0, 0);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(282, 25);
            this.lblNgaySinh.TabIndex = 6;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(0, 29);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.ShowCheckBox = true;
            this.dtpNgaySinh.Size = new System.Drawing.Size(282, 33);
            this.dtpNgaySinh.TabIndex = 7;
            // 
            // layoutcboGioiTinh
            // 
            this.layoutcboGioiTinh.AutoSize = true;
            this.layoutcboGioiTinh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboGioiTinh.ColumnCount = 1;
            this.layoutcboGioiTinh.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboGioiTinh.Controls.Add(this.lblGioiTinh, 0, 0);
            this.layoutcboGioiTinh.Controls.Add(this.cboGioiTinh, 0, 1);
            this.layoutcboGioiTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboGioiTinh.Location = new System.Drawing.Point(6, 77);
            this.layoutcboGioiTinh.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboGioiTinh.Name = "layoutcboGioiTinh";
            this.layoutcboGioiTinh.RowCount = 2;
            this.layoutcboGioiTinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboGioiTinh.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboGioiTinh.Size = new System.Drawing.Size(282, 65);
            this.layoutcboGioiTinh.TabIndex = 4;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGioiTinh.Location = new System.Drawing.Point(0, 0);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(282, 25);
            this.lblGioiTinh.TabIndex = 8;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Location = new System.Drawing.Point(0, 31);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(282, 33);
            this.cboGioiTinh.TabIndex = 9;
            // 
            // layouttxtSoDienThoai
            // 
            this.layouttxtSoDienThoai.AutoSize = true;
            this.layouttxtSoDienThoai.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtSoDienThoai.ColumnCount = 1;
            this.layouttxtSoDienThoai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtSoDienThoai.Controls.Add(this.lblSoDienThoai, 0, 0);
            this.layouttxtSoDienThoai.Controls.Add(this.txtSoDienThoai, 0, 1);
            this.layouttxtSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtSoDienThoai.Location = new System.Drawing.Point(300, 77);
            this.layouttxtSoDienThoai.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtSoDienThoai.Name = "layouttxtSoDienThoai";
            this.layouttxtSoDienThoai.RowCount = 2;
            this.layouttxtSoDienThoai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtSoDienThoai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtSoDienThoai.Size = new System.Drawing.Size(282, 65);
            this.layouttxtSoDienThoai.TabIndex = 5;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDienThoai.Location = new System.Drawing.Point(0, 0);
            this.lblSoDienThoai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(282, 25);
            this.lblSoDienThoai.TabIndex = 10;
            this.lblSoDienThoai.Text = "Số điện thoại";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(0, 29);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(282, 33);
            this.txtSoDienThoai.TabIndex = 11;
            // 
            // layouttxtDiaChi
            // 
            this.layouttxtDiaChi.AutoSize = true;
            this.layouttxtDiaChi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtDiaChi.ColumnCount = 1;
            this.layouttxtDiaChi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtDiaChi.Controls.Add(this.lblDiaChi, 0, 0);
            this.layouttxtDiaChi.Controls.Add(this.txtDiaChi, 0, 1);
            this.layouttxtDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtDiaChi.Location = new System.Drawing.Point(594, 77);
            this.layouttxtDiaChi.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtDiaChi.Name = "layouttxtDiaChi";
            this.layouttxtDiaChi.RowCount = 2;
            this.layouttxtDiaChi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtDiaChi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtDiaChi.Size = new System.Drawing.Size(282, 65);
            this.layouttxtDiaChi.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDiaChi.Location = new System.Drawing.Point(0, 0);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(282, 25);
            this.lblDiaChi.TabIndex = 12;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiaChi.Location = new System.Drawing.Point(0, 29);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtDiaChi.MaxLength = 200;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(282, 33);
            this.txtDiaChi.TabIndex = 13;
            // 
            // layoutdtpNgayVaoTruong
            // 
            this.layoutdtpNgayVaoTruong.AutoSize = true;
            this.layoutdtpNgayVaoTruong.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutdtpNgayVaoTruong.ColumnCount = 1;
            this.layoutdtpNgayVaoTruong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutdtpNgayVaoTruong.Controls.Add(this.lblNgayVaoTruong, 0, 0);
            this.layoutdtpNgayVaoTruong.Controls.Add(this.dtpNgayVaoTruong, 0, 1);
            this.layoutdtpNgayVaoTruong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutdtpNgayVaoTruong.Location = new System.Drawing.Point(888, 77);
            this.layoutdtpNgayVaoTruong.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutdtpNgayVaoTruong.Name = "layoutdtpNgayVaoTruong";
            this.layoutdtpNgayVaoTruong.RowCount = 2;
            this.layoutdtpNgayVaoTruong.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutdtpNgayVaoTruong.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutdtpNgayVaoTruong.Size = new System.Drawing.Size(282, 65);
            this.layoutdtpNgayVaoTruong.TabIndex = 7;
            // 
            // lblNgayVaoTruong
            // 
            this.lblNgayVaoTruong.AutoSize = true;
            this.lblNgayVaoTruong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayVaoTruong.Location = new System.Drawing.Point(0, 0);
            this.lblNgayVaoTruong.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblNgayVaoTruong.Name = "lblNgayVaoTruong";
            this.lblNgayVaoTruong.Size = new System.Drawing.Size(282, 25);
            this.lblNgayVaoTruong.TabIndex = 14;
            this.lblNgayVaoTruong.Text = "Ngày vào trường";
            // 
            // dtpNgayVaoTruong
            // 
            this.dtpNgayVaoTruong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNgayVaoTruong.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayVaoTruong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayVaoTruong.Location = new System.Drawing.Point(0, 29);
            this.dtpNgayVaoTruong.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.dtpNgayVaoTruong.Name = "dtpNgayVaoTruong";
            this.dtpNgayVaoTruong.ShowCheckBox = true;
            this.dtpNgayVaoTruong.Size = new System.Drawing.Size(282, 33);
            this.dtpNgayVaoTruong.TabIndex = 15;
            // 
            // layoutcboMaKhoa
            // 
            this.layoutcboMaKhoa.AutoSize = true;
            this.layoutcboMaKhoa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboMaKhoa.ColumnCount = 1;
            this.layoutcboMaKhoa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboMaKhoa.Controls.Add(this.lblMaKhoa, 0, 0);
            this.layoutcboMaKhoa.Controls.Add(this.cboMaKhoa, 0, 1);
            this.layoutcboMaKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboMaKhoa.Location = new System.Drawing.Point(6, 151);
            this.layoutcboMaKhoa.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboMaKhoa.Name = "layoutcboMaKhoa";
            this.layoutcboMaKhoa.RowCount = 2;
            this.layoutcboMaKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaKhoa.Size = new System.Drawing.Size(282, 65);
            this.layoutcboMaKhoa.TabIndex = 8;
            // 
            // lblMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaKhoa.Location = new System.Drawing.Point(0, 0);
            this.lblMaKhoa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new System.Drawing.Size(282, 25);
            this.lblMaKhoa.TabIndex = 16;
            this.lblMaKhoa.Text = "Khoa";
            // 
            // cboMaKhoa
            // 
            this.cboMaKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaKhoa.Location = new System.Drawing.Point(0, 29);
            this.cboMaKhoa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboMaKhoa.Name = "cboMaKhoa";
            this.cboMaKhoa.Size = new System.Drawing.Size(282, 33);
            this.cboMaKhoa.TabIndex = 17;
            this.cboMaKhoa.SelectedIndexChanged += new System.EventHandler(this.cboMaKhoa_SelectedIndexChanged);
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
            this.layoutcboMaBoMon.Location = new System.Drawing.Point(300, 151);
            this.layoutcboMaBoMon.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboMaBoMon.Name = "layoutcboMaBoMon";
            this.layoutcboMaBoMon.RowCount = 2;
            this.layoutcboMaBoMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaBoMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaBoMon.Size = new System.Drawing.Size(282, 65);
            this.layoutcboMaBoMon.TabIndex = 9;
            // 
            // lblMaBoMon
            // 
            this.lblMaBoMon.AutoSize = true;
            this.lblMaBoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaBoMon.Location = new System.Drawing.Point(0, 0);
            this.lblMaBoMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaBoMon.Name = "lblMaBoMon";
            this.lblMaBoMon.Size = new System.Drawing.Size(282, 25);
            this.lblMaBoMon.TabIndex = 18;
            this.lblMaBoMon.Text = "Bộ môn";
            // 
            // cboMaBoMon
            // 
            this.cboMaBoMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaBoMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaBoMon.Location = new System.Drawing.Point(0, 31);
            this.cboMaBoMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboMaBoMon.Name = "cboMaBoMon";
            this.cboMaBoMon.Size = new System.Drawing.Size(282, 33);
            this.cboMaBoMon.TabIndex = 19;
            // 
            // layoutcboMaHocVi
            // 
            this.layoutcboMaHocVi.AutoSize = true;
            this.layoutcboMaHocVi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboMaHocVi.ColumnCount = 1;
            this.layoutcboMaHocVi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboMaHocVi.Controls.Add(this.lblMaHocVi, 0, 0);
            this.layoutcboMaHocVi.Controls.Add(this.cboMaHocVi, 0, 1);
            this.layoutcboMaHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboMaHocVi.Location = new System.Drawing.Point(594, 151);
            this.layoutcboMaHocVi.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboMaHocVi.Name = "layoutcboMaHocVi";
            this.layoutcboMaHocVi.RowCount = 2;
            this.layoutcboMaHocVi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaHocVi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaHocVi.Size = new System.Drawing.Size(282, 65);
            this.layoutcboMaHocVi.TabIndex = 10;
            // 
            // lblMaHocVi
            // 
            this.lblMaHocVi.AutoSize = true;
            this.lblMaHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaHocVi.Location = new System.Drawing.Point(0, 0);
            this.lblMaHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaHocVi.Name = "lblMaHocVi";
            this.lblMaHocVi.Size = new System.Drawing.Size(282, 25);
            this.lblMaHocVi.TabIndex = 20;
            this.lblMaHocVi.Text = "Học vị";
            // 
            // cboMaHocVi
            // 
            this.cboMaHocVi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaHocVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaHocVi.Location = new System.Drawing.Point(0, 31);
            this.cboMaHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboMaHocVi.Name = "cboMaHocVi";
            this.cboMaHocVi.Size = new System.Drawing.Size(282, 33);
            this.cboMaHocVi.TabIndex = 21;
            // 
            // layoutcboMaChucVu
            // 
            this.layoutcboMaChucVu.AutoSize = true;
            this.layoutcboMaChucVu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboMaChucVu.ColumnCount = 1;
            this.layoutcboMaChucVu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboMaChucVu.Controls.Add(this.lblMaChucVu, 0, 0);
            this.layoutcboMaChucVu.Controls.Add(this.cboMaChucVu, 0, 1);
            this.layoutcboMaChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboMaChucVu.Location = new System.Drawing.Point(888, 151);
            this.layoutcboMaChucVu.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboMaChucVu.Name = "layoutcboMaChucVu";
            this.layoutcboMaChucVu.RowCount = 2;
            this.layoutcboMaChucVu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaChucVu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboMaChucVu.Size = new System.Drawing.Size(282, 65);
            this.layoutcboMaChucVu.TabIndex = 11;
            // 
            // lblMaChucVu
            // 
            this.lblMaChucVu.AutoSize = true;
            this.lblMaChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaChucVu.Location = new System.Drawing.Point(0, 0);
            this.lblMaChucVu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaChucVu.Name = "lblMaChucVu";
            this.lblMaChucVu.Size = new System.Drawing.Size(282, 25);
            this.lblMaChucVu.TabIndex = 22;
            this.lblMaChucVu.Text = "Chức vụ";
            // 
            // cboMaChucVu
            // 
            this.cboMaChucVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaChucVu.Location = new System.Drawing.Point(0, 31);
            this.cboMaChucVu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboMaChucVu.Name = "cboMaChucVu";
            this.cboMaChucVu.Size = new System.Drawing.Size(282, 33);
            this.cboMaChucVu.TabIndex = 23;
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
            this.layoutchkTrangThai.Location = new System.Drawing.Point(6, 225);
            this.layoutchkTrangThai.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutchkTrangThai.Name = "layoutchkTrangThai";
            this.layoutchkTrangThai.RowCount = 2;
            this.layoutchkTrangThai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutchkTrangThai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutchkTrangThai.Size = new System.Drawing.Size(282, 70);
            this.layoutchkTrangThai.TabIndex = 12;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Location = new System.Drawing.Point(0, 0);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(282, 25);
            this.lblTrangThai.TabIndex = 24;
            this.lblTrangThai.Text = "Trạng thái";
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
            this.chkTrangThai.Size = new System.Drawing.Size(282, 38);
            this.chkTrangThai.TabIndex = 25;
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
            this.pnlNut.Location = new System.Drawing.Point(9, 307);
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
            this.btnThem.TabIndex = 26;
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
            this.btnSua.TabIndex = 27;
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
            this.btnXoa.TabIndex = 28;
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
            this.btnLamMoi.TabIndex = 29;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // layoutLoc
            // 
            this.layoutLoc.AutoSize = true;
            this.layoutLoc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutLoc.ColumnCount = 4;
            this.layoutLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutLoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutLoc.Controls.Add(this.layoutcboLocKhoa, 0, 0);
            this.layoutLoc.Controls.Add(this.layoutcboLocBoMon, 1, 0);
            this.layoutLoc.Controls.Add(this.layoutcboLocHocVi, 2, 0);
            this.layoutLoc.Controls.Add(this.layoutcboLocTrangThai, 3, 0);
            this.layoutLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutLoc.Location = new System.Drawing.Point(3, 364);
            this.layoutLoc.Margin = new System.Windows.Forms.Padding(0);
            this.layoutLoc.Name = "layoutLoc";
            this.layoutLoc.RowCount = 1;
            this.layoutLoc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutLoc.Size = new System.Drawing.Size(1176, 74);
            this.layoutLoc.TabIndex = 2;
            // 
            // layoutcboLocKhoa
            // 
            this.layoutcboLocKhoa.AutoSize = true;
            this.layoutcboLocKhoa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboLocKhoa.ColumnCount = 1;
            this.layoutcboLocKhoa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboLocKhoa.Controls.Add(this.lblcboLocKhoa, 0, 0);
            this.layoutcboLocKhoa.Controls.Add(this.cboLocKhoa, 0, 1);
            this.layoutcboLocKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboLocKhoa.Location = new System.Drawing.Point(6, 3);
            this.layoutcboLocKhoa.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboLocKhoa.Name = "layoutcboLocKhoa";
            this.layoutcboLocKhoa.RowCount = 2;
            this.layoutcboLocKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboLocKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboLocKhoa.Size = new System.Drawing.Size(282, 65);
            this.layoutcboLocKhoa.TabIndex = 0;
            // 
            // lblcboLocKhoa
            // 
            this.lblcboLocKhoa.AutoSize = true;
            this.lblcboLocKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblcboLocKhoa.Location = new System.Drawing.Point(0, 0);
            this.lblcboLocKhoa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblcboLocKhoa.Name = "lblcboLocKhoa";
            this.lblcboLocKhoa.Size = new System.Drawing.Size(282, 25);
            this.lblcboLocKhoa.TabIndex = 30;
            this.lblcboLocKhoa.Text = "Lọc khoa";
            // 
            // cboLocKhoa
            // 
            this.cboLocKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocKhoa.Location = new System.Drawing.Point(0, 29);
            this.cboLocKhoa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboLocKhoa.Name = "cboLocKhoa";
            this.cboLocKhoa.Size = new System.Drawing.Size(282, 33);
            this.cboLocKhoa.TabIndex = 31;
            this.cboLocKhoa.SelectedIndexChanged += new System.EventHandler(this.cboLocKhoa_SelectedIndexChanged);
            // 
            // layoutcboLocBoMon
            // 
            this.layoutcboLocBoMon.AutoSize = true;
            this.layoutcboLocBoMon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboLocBoMon.ColumnCount = 1;
            this.layoutcboLocBoMon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboLocBoMon.Controls.Add(this.lblcboLocBoMon, 0, 0);
            this.layoutcboLocBoMon.Controls.Add(this.cboLocBoMon, 0, 1);
            this.layoutcboLocBoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboLocBoMon.Location = new System.Drawing.Point(300, 3);
            this.layoutcboLocBoMon.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboLocBoMon.Name = "layoutcboLocBoMon";
            this.layoutcboLocBoMon.RowCount = 2;
            this.layoutcboLocBoMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboLocBoMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboLocBoMon.Size = new System.Drawing.Size(282, 65);
            this.layoutcboLocBoMon.TabIndex = 1;
            // 
            // lblcboLocBoMon
            // 
            this.lblcboLocBoMon.AutoSize = true;
            this.lblcboLocBoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblcboLocBoMon.Location = new System.Drawing.Point(0, 0);
            this.lblcboLocBoMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblcboLocBoMon.Name = "lblcboLocBoMon";
            this.lblcboLocBoMon.Size = new System.Drawing.Size(282, 25);
            this.lblcboLocBoMon.TabIndex = 32;
            this.lblcboLocBoMon.Text = "Lọc bộ môn";
            // 
            // cboLocBoMon
            // 
            this.cboLocBoMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocBoMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocBoMon.Location = new System.Drawing.Point(0, 31);
            this.cboLocBoMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboLocBoMon.Name = "cboLocBoMon";
            this.cboLocBoMon.Size = new System.Drawing.Size(282, 33);
            this.cboLocBoMon.TabIndex = 33;
            // 
            // layoutcboLocHocVi
            // 
            this.layoutcboLocHocVi.AutoSize = true;
            this.layoutcboLocHocVi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboLocHocVi.ColumnCount = 1;
            this.layoutcboLocHocVi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboLocHocVi.Controls.Add(this.lblcboLocHocVi, 0, 0);
            this.layoutcboLocHocVi.Controls.Add(this.cboLocHocVi, 0, 1);
            this.layoutcboLocHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboLocHocVi.Location = new System.Drawing.Point(594, 3);
            this.layoutcboLocHocVi.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboLocHocVi.Name = "layoutcboLocHocVi";
            this.layoutcboLocHocVi.RowCount = 2;
            this.layoutcboLocHocVi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboLocHocVi.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboLocHocVi.Size = new System.Drawing.Size(282, 65);
            this.layoutcboLocHocVi.TabIndex = 2;
            // 
            // lblcboLocHocVi
            // 
            this.lblcboLocHocVi.AutoSize = true;
            this.lblcboLocHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblcboLocHocVi.Location = new System.Drawing.Point(0, 0);
            this.lblcboLocHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblcboLocHocVi.Name = "lblcboLocHocVi";
            this.lblcboLocHocVi.Size = new System.Drawing.Size(282, 25);
            this.lblcboLocHocVi.TabIndex = 34;
            this.lblcboLocHocVi.Text = "Lọc học vị";
            // 
            // cboLocHocVi
            // 
            this.cboLocHocVi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocHocVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocHocVi.Location = new System.Drawing.Point(0, 31);
            this.cboLocHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboLocHocVi.Name = "cboLocHocVi";
            this.cboLocHocVi.Size = new System.Drawing.Size(282, 33);
            this.cboLocHocVi.TabIndex = 35;
            // 
            // layoutcboLocTrangThai
            // 
            this.layoutcboLocTrangThai.AutoSize = true;
            this.layoutcboLocTrangThai.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutcboLocTrangThai.ColumnCount = 1;
            this.layoutcboLocTrangThai.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutcboLocTrangThai.Controls.Add(this.lblcboLocTrangThai, 0, 0);
            this.layoutcboLocTrangThai.Controls.Add(this.cboLocTrangThai, 0, 1);
            this.layoutcboLocTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutcboLocTrangThai.Location = new System.Drawing.Point(888, 3);
            this.layoutcboLocTrangThai.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutcboLocTrangThai.Name = "layoutcboLocTrangThai";
            this.layoutcboLocTrangThai.RowCount = 2;
            this.layoutcboLocTrangThai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboLocTrangThai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutcboLocTrangThai.Size = new System.Drawing.Size(282, 65);
            this.layoutcboLocTrangThai.TabIndex = 3;
            // 
            // lblcboLocTrangThai
            // 
            this.lblcboLocTrangThai.AutoSize = true;
            this.lblcboLocTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblcboLocTrangThai.Location = new System.Drawing.Point(0, 0);
            this.lblcboLocTrangThai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblcboLocTrangThai.Name = "lblcboLocTrangThai";
            this.lblcboLocTrangThai.Size = new System.Drawing.Size(282, 25);
            this.lblcboLocTrangThai.TabIndex = 36;
            this.lblcboLocTrangThai.Text = "Lọc trạng thái";
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.Location = new System.Drawing.Point(0, 31);
            this.cboLocTrangThai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(282, 33);
            this.cboLocTrangThai.TabIndex = 37;
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
            this.layoutTim.Location = new System.Drawing.Point(3, 438);
            this.layoutTim.Margin = new System.Windows.Forms.Padding(0);
            this.layoutTim.Name = "layoutTim";
            this.layoutTim.RowCount = 1;
            this.layoutTim.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutTim.Size = new System.Drawing.Size(1176, 74);
            this.layoutTim.TabIndex = 3;
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
            this.lblTimKiem.TabIndex = 38;
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
            this.txtTimKiem.TabIndex = 39;
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
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm / Lọc";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKetQua.Location = new System.Drawing.Point(9, 515);
            this.lblKetQua.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(1164, 25);
            this.lblKetQua.TabIndex = 4;
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
            this.dgvDanhSach.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(9, 552);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(6);
            this.dgvDanhSach.MinimumSize = new System.Drawing.Size(0, 195);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 62;
            this.dgvDanhSach.RowTemplate.Height = 26;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(1164, 216);
            this.dgvDanhSach.TabIndex = 5;
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);
            // 
            // pnlCuoi
            // 
            this.pnlCuoi.AutoSize = true;
            this.pnlCuoi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlCuoi.Controls.Add(this.btnQuayLai);
            this.pnlCuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCuoi.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlCuoi.Location = new System.Drawing.Point(0, 712);
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
            this.btnQuayLai.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            // frmLecturer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnQuayLai;
            this.ClientSize = new System.Drawing.Size(1200, 780);
            this.Controls.Add(this.pnlCuon);
            this.Controls.Add(this.pnlCuoi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(709, 452);
            this.Name = "frmLecturer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý giảng viên";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlCuon.ResumeLayout(false);
            this.layoutChinh.ResumeLayout(false);
            this.layoutChinh.PerformLayout();
            this.layoutNhap.ResumeLayout(false);
            this.layoutNhap.PerformLayout();
            this.layouttxtMaGV.ResumeLayout(false);
            this.layouttxtMaGV.PerformLayout();
            this.layouttxtHoTen.ResumeLayout(false);
            this.layouttxtHoTen.PerformLayout();
            this.layouttxtEmail.ResumeLayout(false);
            this.layouttxtEmail.PerformLayout();
            this.layoutdtpNgaySinh.ResumeLayout(false);
            this.layoutdtpNgaySinh.PerformLayout();
            this.layoutcboGioiTinh.ResumeLayout(false);
            this.layoutcboGioiTinh.PerformLayout();
            this.layouttxtSoDienThoai.ResumeLayout(false);
            this.layouttxtSoDienThoai.PerformLayout();
            this.layouttxtDiaChi.ResumeLayout(false);
            this.layouttxtDiaChi.PerformLayout();
            this.layoutdtpNgayVaoTruong.ResumeLayout(false);
            this.layoutdtpNgayVaoTruong.PerformLayout();
            this.layoutcboMaKhoa.ResumeLayout(false);
            this.layoutcboMaKhoa.PerformLayout();
            this.layoutcboMaBoMon.ResumeLayout(false);
            this.layoutcboMaBoMon.PerformLayout();
            this.layoutcboMaHocVi.ResumeLayout(false);
            this.layoutcboMaHocVi.PerformLayout();
            this.layoutcboMaChucVu.ResumeLayout(false);
            this.layoutcboMaChucVu.PerformLayout();
            this.layoutchkTrangThai.ResumeLayout(false);
            this.layoutchkTrangThai.PerformLayout();
            this.pnlNut.ResumeLayout(false);
            this.pnlNut.PerformLayout();
            this.layoutLoc.ResumeLayout(false);
            this.layoutLoc.PerformLayout();
            this.layoutcboLocKhoa.ResumeLayout(false);
            this.layoutcboLocKhoa.PerformLayout();
            this.layoutcboLocBoMon.ResumeLayout(false);
            this.layoutcboLocBoMon.PerformLayout();
            this.layoutcboLocHocVi.ResumeLayout(false);
            this.layoutcboLocHocVi.PerformLayout();
            this.layoutcboLocTrangThai.ResumeLayout(false);
            this.layoutcboLocTrangThai.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel layouttxtMaGV;
        private System.Windows.Forms.TableLayoutPanel layouttxtHoTen;
        private System.Windows.Forms.TableLayoutPanel layouttxtEmail;
        private System.Windows.Forms.TableLayoutPanel layoutdtpNgaySinh;
        private System.Windows.Forms.TableLayoutPanel layoutcboGioiTinh;
        private System.Windows.Forms.TableLayoutPanel layouttxtSoDienThoai;
        private System.Windows.Forms.TableLayoutPanel layouttxtDiaChi;
        private System.Windows.Forms.TableLayoutPanel layoutdtpNgayVaoTruong;
        private System.Windows.Forms.TableLayoutPanel layoutcboMaKhoa;
        private System.Windows.Forms.TableLayoutPanel layoutcboMaBoMon;
        private System.Windows.Forms.TableLayoutPanel layoutcboMaHocVi;
        private System.Windows.Forms.TableLayoutPanel layoutcboMaChucVu;
        private System.Windows.Forms.TableLayoutPanel layoutchkTrangThai;
        private System.Windows.Forms.FlowLayoutPanel pnlNut;
        private System.Windows.Forms.TableLayoutPanel layoutLoc;
        private System.Windows.Forms.TableLayoutPanel layoutcboLocKhoa;
        private System.Windows.Forms.TableLayoutPanel layoutcboLocBoMon;
        private System.Windows.Forms.TableLayoutPanel layoutcboLocHocVi;
        private System.Windows.Forms.TableLayoutPanel layoutcboLocTrangThai;
        private System.Windows.Forms.TableLayoutPanel layoutTim;
        private System.Windows.Forms.TableLayoutPanel layoutTuKhoa;
        private System.Windows.Forms.Label lblMaGV;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblNgayVaoTruong;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoTruong;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.ComboBox cboMaKhoa;
        private System.Windows.Forms.Label lblMaBoMon;
        private System.Windows.Forms.ComboBox cboMaBoMon;
        private System.Windows.Forms.Label lblMaHocVi;
        private System.Windows.Forms.ComboBox cboMaHocVi;
        private System.Windows.Forms.Label lblMaChucVu;
        private System.Windows.Forms.ComboBox cboMaChucVu;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.CheckBox chkTrangThai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblcboLocKhoa;
        private System.Windows.Forms.ComboBox cboLocKhoa;
        private System.Windows.Forms.Label lblcboLocBoMon;
        private System.Windows.Forms.ComboBox cboLocBoMon;
        private System.Windows.Forms.Label lblcboLocHocVi;
        private System.Windows.Forms.ComboBox cboLocHocVi;
        private System.Windows.Forms.Label lblcboLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayVaoTruong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenBoMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenHocVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenChucVu;
    }
}
