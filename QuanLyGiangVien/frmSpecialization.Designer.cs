namespace QuanLyGiangVien
{
    partial class frmSpecialization
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
            this.layouttxtMaChuyenMon = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaChuyenMon = new System.Windows.Forms.Label();
            this.txtMaChuyenMon = new System.Windows.Forms.TextBox();
            this.layouttxtTenChuyenMon = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenChuyenMon = new System.Windows.Forms.Label();
            this.txtTenChuyenMon = new System.Windows.Forms.TextBox();
            this.layouttxtMoTa = new System.Windows.Forms.TableLayoutPanel();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
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
            this.layouttxtMaChuyenMon.SuspendLayout();
            this.layouttxtTenChuyenMon.SuspendLayout();
            this.layouttxtMoTa.SuspendLayout();
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
            this.layoutChinh.MinimumSize = new System.Drawing.Size(0, 560);
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
            this.layoutNhap.ColumnCount = 3;
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutNhap.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.layoutNhap.Controls.Add(this.layouttxtMaChuyenMon, 0, 0);
            this.layoutNhap.Controls.Add(this.layouttxtTenChuyenMon, 1, 0);
            this.layoutNhap.Controls.Add(this.layouttxtMoTa, 2, 0);
            this.layoutNhap.Controls.Add(this.layoutchkTrangThai, 0, 1);
            this.layoutNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutNhap.Location = new System.Drawing.Point(3, 3);
            this.layoutNhap.Margin = new System.Windows.Forms.Padding(0);
            this.layoutNhap.Name = "layoutNhap";
            this.layoutNhap.RowCount = 2;
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutNhap.Size = new System.Drawing.Size(1176, 153);
            this.layoutNhap.TabIndex = 0;
            // 
            // layouttxtMaChuyenMon
            // 
            this.layouttxtMaChuyenMon.AutoSize = true;
            this.layouttxtMaChuyenMon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtMaChuyenMon.ColumnCount = 1;
            this.layouttxtMaChuyenMon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtMaChuyenMon.Controls.Add(this.lblMaChuyenMon, 0, 0);
            this.layouttxtMaChuyenMon.Controls.Add(this.txtMaChuyenMon, 0, 1);
            this.layouttxtMaChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtMaChuyenMon.Location = new System.Drawing.Point(6, 3);
            this.layouttxtMaChuyenMon.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtMaChuyenMon.Name = "layouttxtMaChuyenMon";
            this.layouttxtMaChuyenMon.RowCount = 2;
            this.layouttxtMaChuyenMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMaChuyenMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMaChuyenMon.Size = new System.Drawing.Size(380, 65);
            this.layouttxtMaChuyenMon.TabIndex = 0;
            // 
            // lblMaChuyenMon
            // 
            this.lblMaChuyenMon.AutoSize = true;
            this.lblMaChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaChuyenMon.Location = new System.Drawing.Point(0, 0);
            this.lblMaChuyenMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMaChuyenMon.Name = "lblMaChuyenMon";
            this.lblMaChuyenMon.Size = new System.Drawing.Size(380, 25);
            this.lblMaChuyenMon.TabIndex = 0;
            this.lblMaChuyenMon.Text = "Mã (tự tăng)";
            // 
            // txtMaChuyenMon
            // 
            this.txtMaChuyenMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaChuyenMon.Location = new System.Drawing.Point(0, 29);
            this.txtMaChuyenMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtMaChuyenMon.MaxLength = 20;
            this.txtMaChuyenMon.Name = "txtMaChuyenMon";
            this.txtMaChuyenMon.ReadOnly = true;
            this.txtMaChuyenMon.Size = new System.Drawing.Size(380, 33);
            this.txtMaChuyenMon.TabIndex = 1;
            this.txtMaChuyenMon.TabStop = false;
            // 
            // layouttxtTenChuyenMon
            // 
            this.layouttxtTenChuyenMon.AutoSize = true;
            this.layouttxtTenChuyenMon.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtTenChuyenMon.ColumnCount = 1;
            this.layouttxtTenChuyenMon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtTenChuyenMon.Controls.Add(this.lblTenChuyenMon, 0, 0);
            this.layouttxtTenChuyenMon.Controls.Add(this.txtTenChuyenMon, 0, 1);
            this.layouttxtTenChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtTenChuyenMon.Location = new System.Drawing.Point(398, 3);
            this.layouttxtTenChuyenMon.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtTenChuyenMon.Name = "layouttxtTenChuyenMon";
            this.layouttxtTenChuyenMon.RowCount = 2;
            this.layouttxtTenChuyenMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtTenChuyenMon.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtTenChuyenMon.Size = new System.Drawing.Size(380, 65);
            this.layouttxtTenChuyenMon.TabIndex = 1;
            // 
            // lblTenChuyenMon
            // 
            this.lblTenChuyenMon.AutoSize = true;
            this.lblTenChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenChuyenMon.Location = new System.Drawing.Point(0, 0);
            this.lblTenChuyenMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTenChuyenMon.Name = "lblTenChuyenMon";
            this.lblTenChuyenMon.Size = new System.Drawing.Size(380, 25);
            this.lblTenChuyenMon.TabIndex = 2;
            this.lblTenChuyenMon.Text = "Tên chuyên môn";
            // 
            // txtTenChuyenMon
            // 
            this.txtTenChuyenMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenChuyenMon.Location = new System.Drawing.Point(0, 29);
            this.txtTenChuyenMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtTenChuyenMon.MaxLength = 100;
            this.txtTenChuyenMon.Name = "txtTenChuyenMon";
            this.txtTenChuyenMon.Size = new System.Drawing.Size(380, 33);
            this.txtTenChuyenMon.TabIndex = 3;
            // 
            // layouttxtMoTa
            // 
            this.layouttxtMoTa.AutoSize = true;
            this.layouttxtMoTa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layouttxtMoTa.ColumnCount = 1;
            this.layouttxtMoTa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layouttxtMoTa.Controls.Add(this.lblMoTa, 0, 0);
            this.layouttxtMoTa.Controls.Add(this.txtMoTa, 0, 1);
            this.layouttxtMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layouttxtMoTa.Location = new System.Drawing.Point(790, 3);
            this.layouttxtMoTa.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layouttxtMoTa.Name = "layouttxtMoTa";
            this.layouttxtMoTa.RowCount = 2;
            this.layouttxtMoTa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMoTa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layouttxtMoTa.Size = new System.Drawing.Size(380, 65);
            this.layouttxtMoTa.TabIndex = 2;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoTa.Location = new System.Drawing.Point(0, 0);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(380, 25);
            this.lblMoTa.TabIndex = 4;
            this.lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoTa.Location = new System.Drawing.Point(0, 29);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.txtMoTa.MaxLength = 500;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(380, 33);
            this.txtMoTa.TabIndex = 5;
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
            this.layoutchkTrangThai.Location = new System.Drawing.Point(6, 77);
            this.layoutchkTrangThai.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.layoutchkTrangThai.Name = "layoutchkTrangThai";
            this.layoutchkTrangThai.RowCount = 2;
            this.layoutchkTrangThai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutchkTrangThai.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutchkTrangThai.Size = new System.Drawing.Size(380, 70);
            this.layoutchkTrangThai.TabIndex = 3;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThai.Location = new System.Drawing.Point(0, 0);
            this.lblTrangThai.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(380, 25);
            this.lblTrangThai.TabIndex = 6;
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
            this.chkTrangThai.Size = new System.Drawing.Size(380, 38);
            this.chkTrangThai.TabIndex = 7;
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
            this.pnlNut.Location = new System.Drawing.Point(9, 159);
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
            this.btnThem.TabIndex = 8;
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
            this.btnSua.TabIndex = 9;
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
            this.btnXoa.TabIndex = 10;
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
            this.btnLamMoi.TabIndex = 11;
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
            this.layoutTim.Location = new System.Drawing.Point(3, 216);
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
            this.lblTimKiem.TabIndex = 12;
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
            this.txtTimKiem.TabIndex = 13;
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
            this.btnTimKiem.TabIndex = 14;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKetQua.Location = new System.Drawing.Point(9, 293);
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
            this.dgvDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.Location = new System.Drawing.Point(9, 330);
            this.dgvDanhSach.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvDanhSach.MinimumSize = new System.Drawing.Size(0, 210);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.ReadOnly = true;
            this.dgvDanhSach.RowHeadersVisible = false;
            this.dgvDanhSach.RowHeadersWidth = 62;
            this.dgvDanhSach.RowTemplate.Height = 26;
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(1164, 265);
            this.dgvDanhSach.TabIndex = 4;
            this.dgvDanhSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellContentClick);
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
            // frmSpecialization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1200, 690);
            this.Controls.Add(this.pnlCuon);
            this.Controls.Add(this.pnlCuoi);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(709, 452);
            this.Name = "frmSpecialization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý chuyên môn";
            this.Load += new System.EventHandler(this.Form_Load);
            this.pnlCuon.ResumeLayout(false);
            this.layoutChinh.ResumeLayout(false);
            this.layoutChinh.PerformLayout();
            this.layoutNhap.ResumeLayout(false);
            this.layoutNhap.PerformLayout();
            this.layouttxtMaChuyenMon.ResumeLayout(false);
            this.layouttxtMaChuyenMon.PerformLayout();
            this.layouttxtTenChuyenMon.ResumeLayout(false);
            this.layouttxtTenChuyenMon.PerformLayout();
            this.layouttxtMoTa.ResumeLayout(false);
            this.layouttxtMoTa.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel layouttxtMaChuyenMon;
        private System.Windows.Forms.TableLayoutPanel layouttxtTenChuyenMon;
        private System.Windows.Forms.TableLayoutPanel layouttxtMoTa;
        private System.Windows.Forms.TableLayoutPanel layoutchkTrangThai;
        private System.Windows.Forms.FlowLayoutPanel pnlNut;
        private System.Windows.Forms.TableLayoutPanel layoutTim;
        private System.Windows.Forms.TableLayoutPanel layoutTuKhoa;
        private System.Windows.Forms.Label lblMaChuyenMon;
        private System.Windows.Forms.TextBox txtMaChuyenMon;
        private System.Windows.Forms.Label lblTenChuyenMon;
        private System.Windows.Forms.TextBox txtTenChuyenMon;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaChuyenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenChuyenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMoTa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTrangThai;
    }
}
