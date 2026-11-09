using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.layoutHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblIconHeThong = new System.Windows.Forms.Label();
            this.lblTieuDeHeThong = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnTheme = new System.Windows.Forms.Button();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.layoutSidebar = new System.Windows.Forms.TableLayoutPanel();
            this.lblIconMenu = new System.Windows.Forms.Label();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.btnHeThong = new System.Windows.Forms.Button();
            this.pnlHeThong = new System.Windows.Forms.TableLayoutPanel();
            this.btnNguoiDung = new System.Windows.Forms.Button();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.btnPhanQuyen = new System.Windows.Forms.Button();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.pnlDanhMuc = new System.Windows.Forms.TableLayoutPanel();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.btnBoMon = new System.Windows.Forms.Button();
            this.btnGiangVien = new System.Windows.Forms.Button();
            this.btnHocVi = new System.Windows.Forms.Button();
            this.btnChucVu = new System.Windows.Forms.Button();
            this.btnChuyenMon = new System.Windows.Forms.Button();
            this.btnHocPhan = new System.Windows.Forms.Button();
            this.btnDaoTao = new System.Windows.Forms.Button();
            this.pnlDaoTao = new System.Windows.Forms.TableLayoutPanel();
            this.btnLopHocPhan = new System.Windows.Forms.Button();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.pnlThongKe = new System.Windows.Forms.TableLayoutPanel();
            this.btnKhoiLuong = new System.Windows.Forms.Button();
            this.btnBieuDo = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.pnlBaoCao = new System.Windows.Forms.TableLayoutPanel();
            this.btnBaoCaoGiangVien = new System.Windows.Forms.Button();
            this.btnBaoCaoPhanCong = new System.Windows.Forms.Button();
            this.btnBaoCaoTaiTrongKhoa = new System.Windows.Forms.Button();
            this.btnBaoCaoChuaPhanCong = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.layoutDashboard = new System.Windows.Forms.TableLayoutPanel();
            this.layoutOverviewHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblTieuDeTongQuan = new System.Windows.Forms.Label();
            this.lblScope = new System.Windows.Forms.Label();
            this.btnBieuDoTongQuan = new System.Windows.Forms.Button();
            this.lblDashboardMessage = new System.Windows.Forms.Label();
            this.layoutCounts = new System.Windows.Forms.TableLayoutPanel();
            this.cardGiangVien = new System.Windows.Forms.TableLayoutPanel();
            this.lblDanhMucGiangVien = new System.Windows.Forms.Label();
            this.lblSoGiangVien = new System.Windows.Forms.Label();
            this.lblTrangThaiGiangVien = new System.Windows.Forms.Label();
            this.cardKhoa = new System.Windows.Forms.TableLayoutPanel();
            this.lblDanhMucKhoa = new System.Windows.Forms.Label();
            this.lblSoKhoa = new System.Windows.Forms.Label();
            this.lblTrangThaiKhoa = new System.Windows.Forms.Label();
            this.cardHocPhan = new System.Windows.Forms.TableLayoutPanel();
            this.lblDanhMucHocPhan = new System.Windows.Forms.Label();
            this.lblSoHocPhan = new System.Windows.Forms.Label();
            this.lblTrangThaiHocPhan = new System.Windows.Forms.Label();
            this.cardLop = new System.Windows.Forms.TableLayoutPanel();
            this.lblDanhMucLop = new System.Windows.Forms.Label();
            this.lblSoLop = new System.Windows.Forms.Label();
            this.lblTrangThaiLop = new System.Windows.Forms.Label();
            this.layoutWorkload = new System.Windows.Forms.TableLayoutPanel();
            this.lblTieuDeKhoiLuong = new System.Windows.Forms.Label();
            this.layoutSemester = new System.Windows.Forms.TableLayoutPanel();
            this.lblWorkloadYear = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.layoutRates = new System.Windows.Forms.TableLayoutPanel();
            this.rateDat = new System.Windows.Forms.TableLayoutPanel();
            this.lblRateTitleDat = new System.Windows.Forms.Label();
            this.lblSoDat = new System.Windows.Forms.Label();
            this.lblTiLeDat = new System.Windows.Forms.Label();
            this.rateVuot = new System.Windows.Forms.TableLayoutPanel();
            this.lblRateTitleVuot = new System.Windows.Forms.Label();
            this.lblSoVuot = new System.Windows.Forms.Label();
            this.lblTiLeVuot = new System.Windows.Forms.Label();
            this.lblWorkload = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.layoutHeader.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.layoutSidebar.SuspendLayout();
            this.pnlHeThong.SuspendLayout();
            this.pnlDanhMuc.SuspendLayout();
            this.pnlDaoTao.SuspendLayout();
            this.pnlThongKe.SuspendLayout();
            this.pnlBaoCao.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.layoutDashboard.SuspendLayout();
            this.layoutOverviewHeader.SuspendLayout();
            this.layoutCounts.SuspendLayout();
            this.cardGiangVien.SuspendLayout();
            this.cardKhoa.SuspendLayout();
            this.cardHocPhan.SuspendLayout();
            this.cardLop.SuspendLayout();
            this.layoutWorkload.SuspendLayout();
            this.layoutSemester.SuspendLayout();
            this.layoutRates.SuspendLayout();
            this.rateDat.SuspendLayout();
            this.rateVuot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.layoutHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(33, 12, 27, 12);
            this.pnlHeader.Size = new System.Drawing.Size(1785, 129);
            this.pnlHeader.TabIndex = 0;
            // 
            // layoutHeader
            // 
            this.layoutHeader.ColumnCount = 3;
            this.layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutHeader.Controls.Add(this.lblIconHeThong, 0, 0);
            this.layoutHeader.Controls.Add(this.lblTieuDeHeThong, 1, 0);
            this.layoutHeader.Controls.Add(this.lblWelcome, 1, 1);
            this.layoutHeader.Controls.Add(this.btnTheme, 2, 0);
            this.layoutHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutHeader.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutHeader.Location = new System.Drawing.Point(33, 12);
            this.layoutHeader.Margin = new System.Windows.Forms.Padding(4);
            this.layoutHeader.Name = "layoutHeader";
            this.layoutHeader.RowCount = 2;
            this.layoutHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layoutHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutHeader.Size = new System.Drawing.Size(1725, 105);
            this.layoutHeader.TabIndex = 0;
            // 
            // lblIconHeThong
            // 
            this.lblIconHeThong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIconHeThong.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblIconHeThong.Location = new System.Drawing.Point(0, 16);
            this.lblIconHeThong.Margin = new System.Windows.Forms.Padding(0, 0, 18, 0);
            this.lblIconHeThong.Name = "lblIconHeThong";
            this.layoutHeader.SetRowSpan(this.lblIconHeThong, 2);
            this.lblIconHeThong.Size = new System.Drawing.Size(84, 72);
            this.lblIconHeThong.TabIndex = 0;
            this.lblIconHeThong.Text = "GV";
            this.lblIconHeThong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeHeThong
            // 
            this.lblTieuDeHeThong.AutoEllipsis = true;
            this.lblTieuDeHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDeHeThong.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeHeThong.Location = new System.Drawing.Point(102, 0);
            this.lblTieuDeHeThong.Margin = new System.Windows.Forms.Padding(0);
            this.lblTieuDeHeThong.Name = "lblTieuDeHeThong";
            this.lblTieuDeHeThong.Size = new System.Drawing.Size(1411, 63);
            this.lblTieuDeHeThong.TabIndex = 1;
            this.lblTieuDeHeThong.Text = "Quản lý giảng viên";
            this.lblTieuDeHeThong.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoEllipsis = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWelcome.Location = new System.Drawing.Point(102, 67);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(1411, 38);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Xin chào";
            // 
            // btnTheme
            // 
            this.btnTheme.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTheme.AutoSize = true;
            this.btnTheme.Location = new System.Drawing.Point(1517, 21);
            this.btnTheme.Margin = new System.Windows.Forms.Padding(4);
            this.btnTheme.MinimumSize = new System.Drawing.Size(204, 63);
            this.btnTheme.Name = "btnTheme";
            this.layoutHeader.SetRowSpan(this.btnTheme, 2);
            this.btnTheme.Size = new System.Drawing.Size(204, 63);
            this.btnTheme.TabIndex = 0;
            this.btnTheme.Text = "Giao diện sáng";
            this.btnTheme.UseVisualStyleBackColor = true;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.AutoScroll = true;
            this.pnlSidebar.Controls.Add(this.layoutSidebar);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 129);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(21, 21, 21, 12);
            this.pnlSidebar.Size = new System.Drawing.Size(327, 929);
            this.pnlSidebar.TabIndex = 1;
            // 
            // layoutSidebar
            // 
            this.layoutSidebar.AutoSize = true;
            this.layoutSidebar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutSidebar.ColumnCount = 1;
            this.layoutSidebar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSidebar.Controls.Add(this.lblIconMenu, 0, 0);
            this.layoutSidebar.Controls.Add(this.btnTongQuan, 0, 1);
            this.layoutSidebar.Controls.Add(this.btnHeThong, 0, 2);
            this.layoutSidebar.Controls.Add(this.pnlHeThong, 0, 3);
            this.layoutSidebar.Controls.Add(this.btnDanhMuc, 0, 4);
            this.layoutSidebar.Controls.Add(this.pnlDanhMuc, 0, 5);
            this.layoutSidebar.Controls.Add(this.btnDaoTao, 0, 6);
            this.layoutSidebar.Controls.Add(this.pnlDaoTao, 0, 7);
            this.layoutSidebar.Controls.Add(this.btnThongKe, 0, 8);
            this.layoutSidebar.Controls.Add(this.pnlThongKe, 0, 9);
            this.layoutSidebar.Controls.Add(this.btnBaoCao, 0, 10);
            this.layoutSidebar.Controls.Add(this.pnlBaoCao, 0, 11);
            this.layoutSidebar.Controls.Add(this.btnDangXuat, 0, 12);
            this.layoutSidebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutSidebar.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutSidebar.Location = new System.Drawing.Point(21, 21);
            this.layoutSidebar.Margin = new System.Windows.Forms.Padding(4);
            this.layoutSidebar.Name = "layoutSidebar";
            this.layoutSidebar.RowCount = 13;
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSidebar.Size = new System.Drawing.Size(259, 1717);
            this.layoutSidebar.TabIndex = 0;
            // 
            // lblIconMenu
            // 
            this.lblIconMenu.AutoSize = true;
            this.lblIconMenu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblIconMenu.Location = new System.Drawing.Point(8, 2);
            this.lblIconMenu.Margin = new System.Windows.Forms.Padding(8, 2, 0, 15);
            this.lblIconMenu.Name = "lblIconMenu";
            this.lblIconMenu.Size = new System.Drawing.Size(128, 25);
            this.lblIconMenu.TabIndex = 0;
            this.lblIconMenu.Text = "CHỨC NĂNG";
            // 
            // btnTongQuan
            // 
            this.btnTongQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTongQuan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTongQuan.Location = new System.Drawing.Point(0, 42);
            this.btnTongQuan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Padding = new System.Windows.Forms.Padding(14, 0, 8, 0);
            this.btnTongQuan.Size = new System.Drawing.Size(259, 64);
            this.btnTongQuan.TabIndex = 0;
            this.btnTongQuan.Text = "Tổng quan";
            this.btnTongQuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTongQuan.UseVisualStyleBackColor = true;
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            // 
            // btnHeThong
            // 
            this.btnHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHeThong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHeThong.Location = new System.Drawing.Point(0, 114);
            this.btnHeThong.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnHeThong.Name = "btnHeThong";
            this.btnHeThong.Padding = new System.Windows.Forms.Padding(14, 0, 8, 0);
            this.btnHeThong.Size = new System.Drawing.Size(259, 64);
            this.btnHeThong.TabIndex = 1;
            this.btnHeThong.Text = "Hệ thống  ▸";
            this.btnHeThong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHeThong.UseVisualStyleBackColor = true;
            this.btnHeThong.Click += new System.EventHandler(this.btnNhom_Click);
            // 
            // pnlHeThong
            // 
            this.pnlHeThong.AutoSize = true;
            this.pnlHeThong.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlHeThong.ColumnCount = 1;
            this.pnlHeThong.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlHeThong.Controls.Add(this.btnNguoiDung, 0, 0);
            this.pnlHeThong.Controls.Add(this.btnDoiMatKhau, 0, 1);
            this.pnlHeThong.Controls.Add(this.btnPhanQuyen, 0, 2);
            this.pnlHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeThong.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnlHeThong.Location = new System.Drawing.Point(15, 186);
            this.pnlHeThong.Margin = new System.Windows.Forms.Padding(15, 0, 0, 9);
            this.pnlHeThong.Name = "pnlHeThong";
            this.pnlHeThong.RowCount = 3;
            this.pnlHeThong.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlHeThong.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlHeThong.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlHeThong.Size = new System.Drawing.Size(244, 186);
            this.pnlHeThong.TabIndex = 2;
            // 
            // btnNguoiDung
            // 
            this.btnNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNguoiDung.Enabled = false;
            this.btnNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnNguoiDung.Location = new System.Drawing.Point(0, 0);
            this.btnNguoiDung.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnNguoiDung.Name = "btnNguoiDung";
            this.btnNguoiDung.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnNguoiDung.Size = new System.Drawing.Size(244, 54);
            this.btnNguoiDung.TabIndex = 0;
            this.btnNguoiDung.Text = "Quản lý người dùng";
            this.btnNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNguoiDung.UseVisualStyleBackColor = true;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDoiMatKhau.Enabled = false;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDoiMatKhau.Location = new System.Drawing.Point(0, 62);
            this.btnDoiMatKhau.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnDoiMatKhau.Size = new System.Drawing.Size(244, 54);
            this.btnDoiMatKhau.TabIndex = 1;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            // 
            // btnPhanQuyen
            // 
            this.btnPhanQuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPhanQuyen.Enabled = false;
            this.btnPhanQuyen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnPhanQuyen.Location = new System.Drawing.Point(0, 124);
            this.btnPhanQuyen.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnPhanQuyen.Name = "btnPhanQuyen";
            this.btnPhanQuyen.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnPhanQuyen.Size = new System.Drawing.Size(244, 54);
            this.btnPhanQuyen.TabIndex = 2;
            this.btnPhanQuyen.Text = "Vai trò và phân quyền";
            this.btnPhanQuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhanQuyen.UseVisualStyleBackColor = true;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDanhMuc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDanhMuc.Location = new System.Drawing.Point(0, 381);
            this.btnDanhMuc.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Padding = new System.Windows.Forms.Padding(14, 0, 8, 0);
            this.btnDanhMuc.Size = new System.Drawing.Size(259, 64);
            this.btnDanhMuc.TabIndex = 3;
            this.btnDanhMuc.Text = "Danh mục  ▸";
            this.btnDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnNhom_Click);
            // 
            // pnlDanhMuc
            // 
            this.pnlDanhMuc.AutoSize = true;
            this.pnlDanhMuc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDanhMuc.ColumnCount = 1;
            this.pnlDanhMuc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlDanhMuc.Controls.Add(this.btnKhoa, 0, 0);
            this.pnlDanhMuc.Controls.Add(this.btnBoMon, 0, 1);
            this.pnlDanhMuc.Controls.Add(this.btnGiangVien, 0, 2);
            this.pnlDanhMuc.Controls.Add(this.btnHocVi, 0, 3);
            this.pnlDanhMuc.Controls.Add(this.btnChucVu, 0, 4);
            this.pnlDanhMuc.Controls.Add(this.btnChuyenMon, 0, 5);
            this.pnlDanhMuc.Controls.Add(this.btnHocPhan, 0, 6);
            this.pnlDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDanhMuc.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnlDanhMuc.Location = new System.Drawing.Point(15, 453);
            this.pnlDanhMuc.Margin = new System.Windows.Forms.Padding(15, 0, 0, 9);
            this.pnlDanhMuc.Name = "pnlDanhMuc";
            this.pnlDanhMuc.RowCount = 7;
            this.pnlDanhMuc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDanhMuc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDanhMuc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDanhMuc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDanhMuc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDanhMuc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDanhMuc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDanhMuc.Size = new System.Drawing.Size(244, 434);
            this.pnlDanhMuc.TabIndex = 4;
            // 
            // btnKhoa
            // 
            this.btnKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKhoa.Enabled = false;
            this.btnKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnKhoa.Location = new System.Drawing.Point(0, 0);
            this.btnKhoa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnKhoa.Size = new System.Drawing.Size(244, 54);
            this.btnKhoa.TabIndex = 0;
            this.btnKhoa.Text = "Khoa";
            this.btnKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhoa.UseVisualStyleBackColor = true;
            // 
            // btnBoMon
            // 
            this.btnBoMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBoMon.Enabled = false;
            this.btnBoMon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBoMon.Location = new System.Drawing.Point(0, 62);
            this.btnBoMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnBoMon.Name = "btnBoMon";
            this.btnBoMon.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnBoMon.Size = new System.Drawing.Size(244, 54);
            this.btnBoMon.TabIndex = 1;
            this.btnBoMon.Text = "Bộ môn";
            this.btnBoMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoMon.UseVisualStyleBackColor = true;
            // 
            // btnGiangVien
            // 
            this.btnGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGiangVien.Enabled = false;
            this.btnGiangVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnGiangVien.Location = new System.Drawing.Point(0, 124);
            this.btnGiangVien.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnGiangVien.Name = "btnGiangVien";
            this.btnGiangVien.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnGiangVien.Size = new System.Drawing.Size(244, 54);
            this.btnGiangVien.TabIndex = 2;
            this.btnGiangVien.Text = "Giảng viên";
            this.btnGiangVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiangVien.UseVisualStyleBackColor = true;
            // 
            // btnHocVi
            // 
            this.btnHocVi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHocVi.Enabled = false;
            this.btnHocVi.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHocVi.Location = new System.Drawing.Point(0, 186);
            this.btnHocVi.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnHocVi.Name = "btnHocVi";
            this.btnHocVi.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnHocVi.Size = new System.Drawing.Size(244, 54);
            this.btnHocVi.TabIndex = 3;
            this.btnHocVi.Text = "Học vị";
            this.btnHocVi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocVi.UseVisualStyleBackColor = true;
            // 
            // btnChucVu
            // 
            this.btnChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChucVu.Enabled = false;
            this.btnChucVu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnChucVu.Location = new System.Drawing.Point(0, 248);
            this.btnChucVu.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnChucVu.Name = "btnChucVu";
            this.btnChucVu.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnChucVu.Size = new System.Drawing.Size(244, 54);
            this.btnChucVu.TabIndex = 4;
            this.btnChucVu.Text = "Chức vụ";
            this.btnChucVu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChucVu.UseVisualStyleBackColor = true;
            // 
            // btnChuyenMon
            // 
            this.btnChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChuyenMon.Enabled = false;
            this.btnChuyenMon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnChuyenMon.Location = new System.Drawing.Point(0, 310);
            this.btnChuyenMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnChuyenMon.Name = "btnChuyenMon";
            this.btnChuyenMon.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnChuyenMon.Size = new System.Drawing.Size(244, 54);
            this.btnChuyenMon.TabIndex = 5;
            this.btnChuyenMon.Text = "Chuyên môn";
            this.btnChuyenMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChuyenMon.UseVisualStyleBackColor = true;
            // 
            // btnHocPhan
            // 
            this.btnHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHocPhan.Enabled = false;
            this.btnHocPhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnHocPhan.Location = new System.Drawing.Point(0, 372);
            this.btnHocPhan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnHocPhan.Name = "btnHocPhan";
            this.btnHocPhan.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnHocPhan.Size = new System.Drawing.Size(244, 54);
            this.btnHocPhan.TabIndex = 6;
            this.btnHocPhan.Text = "Học phần";
            this.btnHocPhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocPhan.UseVisualStyleBackColor = true;
            // 
            // btnDaoTao
            // 
            this.btnDaoTao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDaoTao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDaoTao.Location = new System.Drawing.Point(0, 896);
            this.btnDaoTao.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnDaoTao.Name = "btnDaoTao";
            this.btnDaoTao.Padding = new System.Windows.Forms.Padding(14, 0, 8, 0);
            this.btnDaoTao.Size = new System.Drawing.Size(259, 64);
            this.btnDaoTao.TabIndex = 5;
            this.btnDaoTao.Text = "Đào tạo  ▸";
            this.btnDaoTao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDaoTao.UseVisualStyleBackColor = true;
            this.btnDaoTao.Click += new System.EventHandler(this.btnNhom_Click);
            // 
            // pnlDaoTao
            // 
            this.pnlDaoTao.AutoSize = true;
            this.pnlDaoTao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDaoTao.ColumnCount = 1;
            this.pnlDaoTao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlDaoTao.Controls.Add(this.btnLopHocPhan, 0, 0);
            this.pnlDaoTao.Controls.Add(this.btnPhanCong, 0, 1);
            this.pnlDaoTao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDaoTao.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnlDaoTao.Location = new System.Drawing.Point(15, 968);
            this.pnlDaoTao.Margin = new System.Windows.Forms.Padding(15, 0, 0, 9);
            this.pnlDaoTao.Name = "pnlDaoTao";
            this.pnlDaoTao.RowCount = 2;
            this.pnlDaoTao.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDaoTao.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDaoTao.Size = new System.Drawing.Size(244, 124);
            this.pnlDaoTao.TabIndex = 6;
            // 
            // btnLopHocPhan
            // 
            this.btnLopHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLopHocPhan.Enabled = false;
            this.btnLopHocPhan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLopHocPhan.Location = new System.Drawing.Point(0, 0);
            this.btnLopHocPhan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnLopHocPhan.Name = "btnLopHocPhan";
            this.btnLopHocPhan.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnLopHocPhan.Size = new System.Drawing.Size(244, 54);
            this.btnLopHocPhan.TabIndex = 0;
            this.btnLopHocPhan.Text = "Lớp học phần";
            this.btnLopHocPhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLopHocPhan.UseVisualStyleBackColor = true;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPhanCong.Enabled = false;
            this.btnPhanCong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnPhanCong.Location = new System.Drawing.Point(0, 62);
            this.btnPhanCong.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnPhanCong.Size = new System.Drawing.Size(244, 54);
            this.btnPhanCong.TabIndex = 1;
            this.btnPhanCong.Text = "Phân công giảng dạy";
            this.btnPhanCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhanCong.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.Location = new System.Drawing.Point(0, 1101);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(14, 0, 8, 0);
            this.btnThongKe.Size = new System.Drawing.Size(259, 64);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống kê  ▸";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnNhom_Click);
            // 
            // pnlThongKe
            // 
            this.pnlThongKe.AutoSize = true;
            this.pnlThongKe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlThongKe.ColumnCount = 1;
            this.pnlThongKe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlThongKe.Controls.Add(this.btnKhoiLuong, 0, 0);
            this.pnlThongKe.Controls.Add(this.btnBieuDo, 0, 1);
            this.pnlThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThongKe.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnlThongKe.Location = new System.Drawing.Point(15, 1173);
            this.pnlThongKe.Margin = new System.Windows.Forms.Padding(15, 0, 0, 9);
            this.pnlThongKe.Name = "pnlThongKe";
            this.pnlThongKe.RowCount = 2;
            this.pnlThongKe.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlThongKe.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlThongKe.Size = new System.Drawing.Size(244, 124);
            this.pnlThongKe.TabIndex = 8;
            // 
            // btnKhoiLuong
            // 
            this.btnKhoiLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKhoiLuong.Enabled = false;
            this.btnKhoiLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnKhoiLuong.Location = new System.Drawing.Point(0, 0);
            this.btnKhoiLuong.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnKhoiLuong.Name = "btnKhoiLuong";
            this.btnKhoiLuong.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnKhoiLuong.Size = new System.Drawing.Size(244, 54);
            this.btnKhoiLuong.TabIndex = 0;
            this.btnKhoiLuong.Text = "Khối lượng giảng dạy";
            this.btnKhoiLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhoiLuong.UseVisualStyleBackColor = true;
            // 
            // btnBieuDo
            // 
            this.btnBieuDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBieuDo.Enabled = false;
            this.btnBieuDo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBieuDo.Location = new System.Drawing.Point(0, 62);
            this.btnBieuDo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnBieuDo.Name = "btnBieuDo";
            this.btnBieuDo.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnBieuDo.Size = new System.Drawing.Size(244, 54);
            this.btnBieuDo.TabIndex = 1;
            this.btnBieuDo.Text = "Biểu đồ";
            this.btnBieuDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBieuDo.UseVisualStyleBackColor = true;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBaoCao.Location = new System.Drawing.Point(0, 1306);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Padding = new System.Windows.Forms.Padding(14, 0, 8, 0);
            this.btnBaoCao.Size = new System.Drawing.Size(259, 64);
            this.btnBaoCao.TabIndex = 9;
            this.btnBaoCao.Text = "Báo cáo  ▸";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnNhom_Click);
            // 
            // pnlBaoCao
            // 
            this.pnlBaoCao.AutoSize = true;
            this.pnlBaoCao.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBaoCao.ColumnCount = 1;
            this.pnlBaoCao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBaoCao.Controls.Add(this.btnBaoCaoGiangVien, 0, 0);
            this.pnlBaoCao.Controls.Add(this.btnBaoCaoPhanCong, 0, 1);
            this.pnlBaoCao.Controls.Add(this.btnBaoCaoTaiTrongKhoa, 0, 2);
            this.pnlBaoCao.Controls.Add(this.btnBaoCaoChuaPhanCong, 0, 3);
            this.pnlBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBaoCao.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.pnlBaoCao.Location = new System.Drawing.Point(15, 1378);
            this.pnlBaoCao.Margin = new System.Windows.Forms.Padding(15, 0, 0, 9);
            this.pnlBaoCao.Name = "pnlBaoCao";
            this.pnlBaoCao.RowCount = 4;
            this.pnlBaoCao.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlBaoCao.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlBaoCao.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlBaoCao.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlBaoCao.Size = new System.Drawing.Size(244, 248);
            this.pnlBaoCao.TabIndex = 10;
            // 
            // btnBaoCaoGiangVien
            // 
            this.btnBaoCaoGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBaoCaoGiangVien.Enabled = false;
            this.btnBaoCaoGiangVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBaoCaoGiangVien.Location = new System.Drawing.Point(0, 0);
            this.btnBaoCaoGiangVien.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnBaoCaoGiangVien.Name = "btnBaoCaoGiangVien";
            this.btnBaoCaoGiangVien.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnBaoCaoGiangVien.Size = new System.Drawing.Size(244, 54);
            this.btnBaoCaoGiangVien.TabIndex = 0;
            this.btnBaoCaoGiangVien.Text = "Danh sách giảng viên";
            this.btnBaoCaoGiangVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoGiangVien.UseVisualStyleBackColor = true;
            // 
            // btnBaoCaoPhanCong
            // 
            this.btnBaoCaoPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBaoCaoPhanCong.Enabled = false;
            this.btnBaoCaoPhanCong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBaoCaoPhanCong.Location = new System.Drawing.Point(0, 62);
            this.btnBaoCaoPhanCong.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnBaoCaoPhanCong.Name = "btnBaoCaoPhanCong";
            this.btnBaoCaoPhanCong.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnBaoCaoPhanCong.Size = new System.Drawing.Size(244, 54);
            this.btnBaoCaoPhanCong.TabIndex = 1;
            this.btnBaoCaoPhanCong.Text = "Phân công giảng dạy";
            this.btnBaoCaoPhanCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoPhanCong.UseVisualStyleBackColor = true;
            // 
            // btnBaoCaoTaiTrongKhoa
            // 
            this.btnBaoCaoTaiTrongKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBaoCaoTaiTrongKhoa.Enabled = false;
            this.btnBaoCaoTaiTrongKhoa.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBaoCaoTaiTrongKhoa.Location = new System.Drawing.Point(0, 124);
            this.btnBaoCaoTaiTrongKhoa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnBaoCaoTaiTrongKhoa.Name = "btnBaoCaoTaiTrongKhoa";
            this.btnBaoCaoTaiTrongKhoa.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnBaoCaoTaiTrongKhoa.Size = new System.Drawing.Size(244, 54);
            this.btnBaoCaoTaiTrongKhoa.TabIndex = 2;
            this.btnBaoCaoTaiTrongKhoa.Text = "Tải trọng theo khoa";
            this.btnBaoCaoTaiTrongKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoTaiTrongKhoa.UseVisualStyleBackColor = true;
            // 
            // btnBaoCaoChuaPhanCong
            // 
            this.btnBaoCaoChuaPhanCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBaoCaoChuaPhanCong.Enabled = false;
            this.btnBaoCaoChuaPhanCong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBaoCaoChuaPhanCong.Location = new System.Drawing.Point(0, 186);
            this.btnBaoCaoChuaPhanCong.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.btnBaoCaoChuaPhanCong.Name = "btnBaoCaoChuaPhanCong";
            this.btnBaoCaoChuaPhanCong.Padding = new System.Windows.Forms.Padding(21, 0, 8, 0);
            this.btnBaoCaoChuaPhanCong.Size = new System.Drawing.Size(244, 54);
            this.btnBaoCaoChuaPhanCong.TabIndex = 3;
            this.btnBaoCaoChuaPhanCong.Text = "Giảng viên chưa phân công";
            this.btnBaoCaoChuaPhanCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoChuaPhanCong.UseVisualStyleBackColor = true;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.Location = new System.Drawing.Point(0, 1653);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(14, 0, 8, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(259, 64);
            this.btnDangXuat.TabIndex = 11;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.layoutDashboard);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(327, 129);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1458, 929);
            this.pnlContent.TabIndex = 2;
            // 
            // layoutDashboard
            // 
            this.layoutDashboard.ColumnCount = 1;
            this.layoutDashboard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutDashboard.Controls.Add(this.layoutOverviewHeader, 0, 0);
            this.layoutDashboard.Controls.Add(this.lblDashboardMessage, 0, 1);
            this.layoutDashboard.Controls.Add(this.layoutCounts, 0, 2);
            this.layoutDashboard.Controls.Add(this.layoutWorkload, 0, 3);
            this.layoutDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutDashboard.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutDashboard.Location = new System.Drawing.Point(0, 0);
            this.layoutDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.layoutDashboard.MinimumSize = new System.Drawing.Size(534, 951);
            this.layoutDashboard.Name = "layoutDashboard";
            this.layoutDashboard.Padding = new System.Windows.Forms.Padding(30, 21, 30, 24);
            this.layoutDashboard.RowCount = 4;
            this.layoutDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutDashboard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutDashboard.Size = new System.Drawing.Size(1458, 951);
            this.layoutDashboard.TabIndex = 0;
            // 
            // layoutOverviewHeader
            // 
            this.layoutOverviewHeader.AutoSize = true;
            this.layoutOverviewHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutOverviewHeader.ColumnCount = 2;
            this.layoutOverviewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutOverviewHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutOverviewHeader.Controls.Add(this.lblTieuDeTongQuan, 0, 0);
            this.layoutOverviewHeader.Controls.Add(this.lblScope, 0, 1);
            this.layoutOverviewHeader.Controls.Add(this.btnBieuDoTongQuan, 1, 0);
            this.layoutOverviewHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOverviewHeader.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutOverviewHeader.Location = new System.Drawing.Point(39, 21);
            this.layoutOverviewHeader.Margin = new System.Windows.Forms.Padding(9, 0, 9, 12);
            this.layoutOverviewHeader.Name = "layoutOverviewHeader";
            this.layoutOverviewHeader.RowCount = 2;
            this.layoutOverviewHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutOverviewHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutOverviewHeader.Size = new System.Drawing.Size(1380, 102);
            this.layoutOverviewHeader.TabIndex = 0;
            // 
            // lblTieuDeTongQuan
            // 
            this.lblTieuDeTongQuan.AutoSize = true;
            this.lblTieuDeTongQuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDeTongQuan.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTongQuan.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDeTongQuan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.lblTieuDeTongQuan.Name = "lblTieuDeTongQuan";
            this.lblTieuDeTongQuan.Size = new System.Drawing.Size(1167, 70);
            this.lblTieuDeTongQuan.TabIndex = 0;
            this.lblTieuDeTongQuan.Text = "Tổng quan";
            // 
            // lblScope
            // 
            this.lblScope.AutoSize = true;
            this.lblScope.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScope.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblScope.Location = new System.Drawing.Point(0, 74);
            this.lblScope.Margin = new System.Windows.Forms.Padding(0);
            this.lblScope.Name = "lblScope";
            this.lblScope.Size = new System.Drawing.Size(1167, 28);
            this.lblScope.TabIndex = 1;
            this.lblScope.Text = "Bản ghi đang hoạt động trong phạm vi được xem.";
            // 
            // btnBieuDoTongQuan
            // 
            this.btnBieuDoTongQuan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBieuDoTongQuan.AutoSize = true;
            this.btnBieuDoTongQuan.Enabled = false;
            this.btnBieuDoTongQuan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBieuDoTongQuan.Location = new System.Drawing.Point(1182, 19);
            this.btnBieuDoTongQuan.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnBieuDoTongQuan.MinimumSize = new System.Drawing.Size(168, 63);
            this.btnBieuDoTongQuan.Name = "btnBieuDoTongQuan";
            this.layoutOverviewHeader.SetRowSpan(this.btnBieuDoTongQuan, 2);
            this.btnBieuDoTongQuan.Size = new System.Drawing.Size(198, 63);
            this.btnBieuDoTongQuan.TabIndex = 0;
            this.btnBieuDoTongQuan.Text = "Mở biểu đồ";
            this.btnBieuDoTongQuan.UseVisualStyleBackColor = true;
            // 
            // lblDashboardMessage
            // 
            this.lblDashboardMessage.AccessibleName = "Trạng thái tải tổng quan";
            this.lblDashboardMessage.AutoSize = true;
            this.lblDashboardMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDashboardMessage.Location = new System.Drawing.Point(39, 135);
            this.lblDashboardMessage.Margin = new System.Windows.Forms.Padding(9, 0, 9, 2);
            this.lblDashboardMessage.Name = "lblDashboardMessage";
            this.lblDashboardMessage.Size = new System.Drawing.Size(1380, 28);
            this.lblDashboardMessage.TabIndex = 1;
            this.lblDashboardMessage.Visible = false;
            // 
            // layoutCounts
            // 
            this.layoutCounts.AutoSize = true;
            this.layoutCounts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutCounts.ColumnCount = 2;
            this.layoutCounts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutCounts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutCounts.Controls.Add(this.cardGiangVien, 0, 0);
            this.layoutCounts.Controls.Add(this.cardKhoa, 1, 0);
            this.layoutCounts.Controls.Add(this.cardHocPhan, 0, 1);
            this.layoutCounts.Controls.Add(this.cardLop, 1, 1);
            this.layoutCounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutCounts.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutCounts.Location = new System.Drawing.Point(30, 165);
            this.layoutCounts.Margin = new System.Windows.Forms.Padding(0);
            this.layoutCounts.Name = "layoutCounts";
            this.layoutCounts.RowCount = 2;
            this.layoutCounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutCounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutCounts.Size = new System.Drawing.Size(1398, 412);
            this.layoutCounts.TabIndex = 2;
            // 
            // cardGiangVien
            // 
            this.cardGiangVien.ColumnCount = 1;
            this.cardGiangVien.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardGiangVien.Controls.Add(this.lblDanhMucGiangVien, 0, 0);
            this.cardGiangVien.Controls.Add(this.lblSoGiangVien, 0, 1);
            this.cardGiangVien.Controls.Add(this.lblTrangThaiGiangVien, 0, 2);
            this.cardGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardGiangVien.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.cardGiangVien.Location = new System.Drawing.Point(9, 9);
            this.cardGiangVien.Margin = new System.Windows.Forms.Padding(9);
            this.cardGiangVien.MinimumSize = new System.Drawing.Size(0, 188);
            this.cardGiangVien.Name = "cardGiangVien";
            this.cardGiangVien.Padding = new System.Windows.Forms.Padding(20, 16, 20, 15);
            this.cardGiangVien.RowCount = 3;
            this.cardGiangVien.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cardGiangVien.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardGiangVien.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cardGiangVien.Size = new System.Drawing.Size(681, 188);
            this.cardGiangVien.TabIndex = 0;
            // 
            // lblDanhMucGiangVien
            // 
            this.lblDanhMucGiangVien.AutoSize = true;
            this.lblDanhMucGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDanhMucGiangVien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDanhMucGiangVien.Location = new System.Drawing.Point(20, 16);
            this.lblDanhMucGiangVien.Margin = new System.Windows.Forms.Padding(0);
            this.lblDanhMucGiangVien.Name = "lblDanhMucGiangVien";
            this.lblDanhMucGiangVien.Size = new System.Drawing.Size(641, 30);
            this.lblDanhMucGiangVien.TabIndex = 0;
            this.lblDanhMucGiangVien.Text = "Giảng viên";
            // 
            // lblSoGiangVien
            // 
            this.lblSoGiangVien.AccessibleName = "Số giảng viên đang hoạt động";
            this.lblSoGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoGiangVien.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            this.lblSoGiangVien.Location = new System.Drawing.Point(20, 46);
            this.lblSoGiangVien.Margin = new System.Windows.Forms.Padding(0);
            this.lblSoGiangVien.Name = "lblSoGiangVien";
            this.lblSoGiangVien.Size = new System.Drawing.Size(641, 99);
            this.lblSoGiangVien.TabIndex = 1;
            this.lblSoGiangVien.Text = "—";
            this.lblSoGiangVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrangThaiGiangVien
            // 
            this.lblTrangThaiGiangVien.AutoSize = true;
            this.lblTrangThaiGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThaiGiangVien.Location = new System.Drawing.Point(20, 145);
            this.lblTrangThaiGiangVien.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrangThaiGiangVien.Name = "lblTrangThaiGiangVien";
            this.lblTrangThaiGiangVien.Size = new System.Drawing.Size(641, 28);
            this.lblTrangThaiGiangVien.TabIndex = 2;
            this.lblTrangThaiGiangVien.Text = "Đang tải…";
            // 
            // cardKhoa
            // 
            this.cardKhoa.ColumnCount = 1;
            this.cardKhoa.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardKhoa.Controls.Add(this.lblDanhMucKhoa, 0, 0);
            this.cardKhoa.Controls.Add(this.lblSoKhoa, 0, 1);
            this.cardKhoa.Controls.Add(this.lblTrangThaiKhoa, 0, 2);
            this.cardKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardKhoa.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.cardKhoa.Location = new System.Drawing.Point(708, 9);
            this.cardKhoa.Margin = new System.Windows.Forms.Padding(9);
            this.cardKhoa.MinimumSize = new System.Drawing.Size(0, 188);
            this.cardKhoa.Name = "cardKhoa";
            this.cardKhoa.Padding = new System.Windows.Forms.Padding(20, 16, 20, 15);
            this.cardKhoa.RowCount = 3;
            this.cardKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cardKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardKhoa.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cardKhoa.Size = new System.Drawing.Size(681, 188);
            this.cardKhoa.TabIndex = 1;
            // 
            // lblDanhMucKhoa
            // 
            this.lblDanhMucKhoa.AutoSize = true;
            this.lblDanhMucKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDanhMucKhoa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDanhMucKhoa.Location = new System.Drawing.Point(20, 16);
            this.lblDanhMucKhoa.Margin = new System.Windows.Forms.Padding(0);
            this.lblDanhMucKhoa.Name = "lblDanhMucKhoa";
            this.lblDanhMucKhoa.Size = new System.Drawing.Size(641, 30);
            this.lblDanhMucKhoa.TabIndex = 0;
            this.lblDanhMucKhoa.Text = "Khoa";
            // 
            // lblSoKhoa
            // 
            this.lblSoKhoa.AccessibleName = "Số khoa đang hoạt động";
            this.lblSoKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoKhoa.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            this.lblSoKhoa.Location = new System.Drawing.Point(20, 46);
            this.lblSoKhoa.Margin = new System.Windows.Forms.Padding(0);
            this.lblSoKhoa.Name = "lblSoKhoa";
            this.lblSoKhoa.Size = new System.Drawing.Size(641, 99);
            this.lblSoKhoa.TabIndex = 1;
            this.lblSoKhoa.Text = "—";
            this.lblSoKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrangThaiKhoa
            // 
            this.lblTrangThaiKhoa.AutoSize = true;
            this.lblTrangThaiKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThaiKhoa.Location = new System.Drawing.Point(20, 145);
            this.lblTrangThaiKhoa.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrangThaiKhoa.Name = "lblTrangThaiKhoa";
            this.lblTrangThaiKhoa.Size = new System.Drawing.Size(641, 28);
            this.lblTrangThaiKhoa.TabIndex = 2;
            this.lblTrangThaiKhoa.Text = "Đang tải…";
            // 
            // cardHocPhan
            // 
            this.cardHocPhan.ColumnCount = 1;
            this.cardHocPhan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardHocPhan.Controls.Add(this.lblDanhMucHocPhan, 0, 0);
            this.cardHocPhan.Controls.Add(this.lblSoHocPhan, 0, 1);
            this.cardHocPhan.Controls.Add(this.lblTrangThaiHocPhan, 0, 2);
            this.cardHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardHocPhan.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.cardHocPhan.Location = new System.Drawing.Point(9, 215);
            this.cardHocPhan.Margin = new System.Windows.Forms.Padding(9);
            this.cardHocPhan.MinimumSize = new System.Drawing.Size(0, 188);
            this.cardHocPhan.Name = "cardHocPhan";
            this.cardHocPhan.Padding = new System.Windows.Forms.Padding(20, 16, 20, 15);
            this.cardHocPhan.RowCount = 3;
            this.cardHocPhan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cardHocPhan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardHocPhan.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cardHocPhan.Size = new System.Drawing.Size(681, 188);
            this.cardHocPhan.TabIndex = 2;
            // 
            // lblDanhMucHocPhan
            // 
            this.lblDanhMucHocPhan.AutoSize = true;
            this.lblDanhMucHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDanhMucHocPhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDanhMucHocPhan.Location = new System.Drawing.Point(20, 16);
            this.lblDanhMucHocPhan.Margin = new System.Windows.Forms.Padding(0);
            this.lblDanhMucHocPhan.Name = "lblDanhMucHocPhan";
            this.lblDanhMucHocPhan.Size = new System.Drawing.Size(641, 30);
            this.lblDanhMucHocPhan.TabIndex = 0;
            this.lblDanhMucHocPhan.Text = "Học phần";
            // 
            // lblSoHocPhan
            // 
            this.lblSoHocPhan.AccessibleName = "Số học phần đang hoạt động";
            this.lblSoHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoHocPhan.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            this.lblSoHocPhan.Location = new System.Drawing.Point(20, 46);
            this.lblSoHocPhan.Margin = new System.Windows.Forms.Padding(0);
            this.lblSoHocPhan.Name = "lblSoHocPhan";
            this.lblSoHocPhan.Size = new System.Drawing.Size(641, 99);
            this.lblSoHocPhan.TabIndex = 1;
            this.lblSoHocPhan.Text = "—";
            this.lblSoHocPhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrangThaiHocPhan
            // 
            this.lblTrangThaiHocPhan.AutoSize = true;
            this.lblTrangThaiHocPhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThaiHocPhan.Location = new System.Drawing.Point(20, 145);
            this.lblTrangThaiHocPhan.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrangThaiHocPhan.Name = "lblTrangThaiHocPhan";
            this.lblTrangThaiHocPhan.Size = new System.Drawing.Size(641, 28);
            this.lblTrangThaiHocPhan.TabIndex = 2;
            this.lblTrangThaiHocPhan.Text = "Đang tải…";
            // 
            // cardLop
            // 
            this.cardLop.ColumnCount = 1;
            this.cardLop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardLop.Controls.Add(this.lblDanhMucLop, 0, 0);
            this.cardLop.Controls.Add(this.lblSoLop, 0, 1);
            this.cardLop.Controls.Add(this.lblTrangThaiLop, 0, 2);
            this.cardLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardLop.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.cardLop.Location = new System.Drawing.Point(708, 215);
            this.cardLop.Margin = new System.Windows.Forms.Padding(9);
            this.cardLop.MinimumSize = new System.Drawing.Size(0, 188);
            this.cardLop.Name = "cardLop";
            this.cardLop.Padding = new System.Windows.Forms.Padding(20, 16, 20, 15);
            this.cardLop.RowCount = 3;
            this.cardLop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cardLop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardLop.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.cardLop.Size = new System.Drawing.Size(681, 188);
            this.cardLop.TabIndex = 3;
            // 
            // lblDanhMucLop
            // 
            this.lblDanhMucLop.AutoSize = true;
            this.lblDanhMucLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDanhMucLop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDanhMucLop.Location = new System.Drawing.Point(20, 16);
            this.lblDanhMucLop.Margin = new System.Windows.Forms.Padding(0);
            this.lblDanhMucLop.Name = "lblDanhMucLop";
            this.lblDanhMucLop.Size = new System.Drawing.Size(641, 30);
            this.lblDanhMucLop.TabIndex = 0;
            this.lblDanhMucLop.Text = "Lớp học phần";
            // 
            // lblSoLop
            // 
            this.lblSoLop.AccessibleName = "Số lớp học phần đang hoạt động";
            this.lblSoLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoLop.Font = new System.Drawing.Font("Segoe UI", 27F, System.Drawing.FontStyle.Bold);
            this.lblSoLop.Location = new System.Drawing.Point(20, 46);
            this.lblSoLop.Margin = new System.Windows.Forms.Padding(0);
            this.lblSoLop.Name = "lblSoLop";
            this.lblSoLop.Size = new System.Drawing.Size(641, 99);
            this.lblSoLop.TabIndex = 1;
            this.lblSoLop.Text = "—";
            this.lblSoLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrangThaiLop
            // 
            this.lblTrangThaiLop.AutoSize = true;
            this.lblTrangThaiLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrangThaiLop.Location = new System.Drawing.Point(20, 145);
            this.lblTrangThaiLop.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrangThaiLop.Name = "lblTrangThaiLop";
            this.lblTrangThaiLop.Size = new System.Drawing.Size(641, 28);
            this.lblTrangThaiLop.TabIndex = 2;
            this.lblTrangThaiLop.Text = "Đang tải…";
            // 
            // layoutWorkload
            // 
            this.layoutWorkload.AutoSize = true;
            this.layoutWorkload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.layoutWorkload.ColumnCount = 1;
            this.layoutWorkload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutWorkload.Controls.Add(this.lblTieuDeKhoiLuong, 0, 0);
            this.layoutWorkload.Controls.Add(this.layoutSemester, 0, 1);
            this.layoutWorkload.Controls.Add(this.layoutRates, 0, 2);
            this.layoutWorkload.Controls.Add(this.lblWorkload, 0, 3);
            this.layoutWorkload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutWorkload.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutWorkload.Location = new System.Drawing.Point(39, 587);
            this.layoutWorkload.Margin = new System.Windows.Forms.Padding(9, 10, 9, 0);
            this.layoutWorkload.Name = "layoutWorkload";
            this.layoutWorkload.Padding = new System.Windows.Forms.Padding(21, 15, 21, 14);
            this.layoutWorkload.RowCount = 4;
            this.layoutWorkload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutWorkload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutWorkload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutWorkload.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutWorkload.Size = new System.Drawing.Size(1380, 340);
            this.layoutWorkload.TabIndex = 1;
            // 
            // lblTieuDeKhoiLuong
            // 
            this.lblTieuDeKhoiLuong.AutoSize = true;
            this.lblTieuDeKhoiLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTieuDeKhoiLuong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeKhoiLuong.Location = new System.Drawing.Point(21, 15);
            this.lblTieuDeKhoiLuong.Margin = new System.Windows.Forms.Padding(0);
            this.lblTieuDeKhoiLuong.Name = "lblTieuDeKhoiLuong";
            this.lblTieuDeKhoiLuong.Size = new System.Drawing.Size(1338, 45);
            this.lblTieuDeKhoiLuong.TabIndex = 0;
            this.lblTieuDeKhoiLuong.Text = "Khối lượng giảng dạy";
            // 
            // layoutSemester
            // 
            this.layoutSemester.AutoSize = true;
            this.layoutSemester.ColumnCount = 2;
            this.layoutSemester.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSemester.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutSemester.Controls.Add(this.lblWorkloadYear, 0, 0);
            this.layoutSemester.Controls.Add(this.cboHocKy, 1, 0);
            this.layoutSemester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutSemester.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutSemester.Location = new System.Drawing.Point(21, 63);
            this.layoutSemester.Margin = new System.Windows.Forms.Padding(0, 3, 0, 10);
            this.layoutSemester.Name = "layoutSemester";
            this.layoutSemester.RowCount = 1;
            this.layoutSemester.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutSemester.Size = new System.Drawing.Size(1338, 44);
            this.layoutSemester.TabIndex = 1;
            // 
            // lblWorkloadYear
            // 
            this.lblWorkloadYear.AutoSize = true;
            this.lblWorkloadYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkloadYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWorkloadYear.Location = new System.Drawing.Point(0, 0);
            this.lblWorkloadYear.Margin = new System.Windows.Forms.Padding(0);
            this.lblWorkloadYear.Name = "lblWorkloadYear";
            this.lblWorkloadYear.Size = new System.Drawing.Size(1134, 44);
            this.lblWorkloadYear.TabIndex = 0;
            this.lblWorkloadYear.Text = "Năm học";
            this.lblWorkloadYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboHocKy
            // 
            this.cboHocKy.AccessibleName = "Học kỳ";
            this.cboHocKy.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cboHocKy.DisplayMember = "Name";
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.Enabled = false;
            this.cboHocKy.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.cboHocKy.Location = new System.Drawing.Point(1142, 3);
            this.cboHocKy.Margin = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(196, 38);
            this.cboHocKy.TabIndex = 0;
            this.cboHocKy.ValueMember = "Id";
            this.cboHocKy.SelectedValueChanged += new System.EventHandler(this.cboHocKy_SelectedValueChanged);
            // 
            // layoutRates
            // 
            this.layoutRates.AutoSize = true;
            this.layoutRates.ColumnCount = 2;
            this.layoutRates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutRates.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutRates.Controls.Add(this.rateDat, 0, 0);
            this.layoutRates.Controls.Add(this.rateVuot, 1, 0);
            this.layoutRates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRates.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.layoutRates.Location = new System.Drawing.Point(21, 117);
            this.layoutRates.Margin = new System.Windows.Forms.Padding(0);
            this.layoutRates.Name = "layoutRates";
            this.layoutRates.RowCount = 1;
            this.layoutRates.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRates.Size = new System.Drawing.Size(1338, 172);
            this.layoutRates.TabIndex = 2;
            // 
            // rateDat
            // 
            this.rateDat.AutoSize = true;
            this.rateDat.ColumnCount = 1;
            this.rateDat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rateDat.Controls.Add(this.lblRateTitleDat, 0, 0);
            this.rateDat.Controls.Add(this.lblSoDat, 0, 1);
            this.rateDat.Controls.Add(this.lblTiLeDat, 0, 2);
            this.rateDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rateDat.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.rateDat.Location = new System.Drawing.Point(0, 0);
            this.rateDat.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.rateDat.Name = "rateDat";
            this.rateDat.Padding = new System.Windows.Forms.Padding(14, 9, 14, 9);
            this.rateDat.RowCount = 3;
            this.rateDat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rateDat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rateDat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rateDat.Size = new System.Drawing.Size(663, 172);
            this.rateDat.TabIndex = 0;
            // 
            // lblRateTitleDat
            // 
            this.lblRateTitleDat.AutoSize = true;
            this.lblRateTitleDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRateTitleDat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRateTitleDat.Location = new System.Drawing.Point(14, 9);
            this.lblRateTitleDat.Margin = new System.Windows.Forms.Padding(0);
            this.lblRateTitleDat.Name = "lblRateTitleDat";
            this.lblRateTitleDat.Size = new System.Drawing.Size(635, 28);
            this.lblRateTitleDat.TabIndex = 0;
            this.lblRateTitleDat.Text = "Đạt định mức";
            // 
            // lblSoDat
            // 
            this.lblSoDat.AccessibleName = "Tỷ lệ đạt định mức";
            this.lblSoDat.AutoSize = true;
            this.lblSoDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoDat.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblSoDat.Location = new System.Drawing.Point(14, 37);
            this.lblSoDat.Margin = new System.Windows.Forms.Padding(0);
            this.lblSoDat.Name = "lblSoDat";
            this.lblSoDat.Size = new System.Drawing.Size(635, 98);
            this.lblSoDat.TabIndex = 1;
            this.lblSoDat.Text = "—";
            this.lblSoDat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTiLeDat
            // 
            this.lblTiLeDat.AutoSize = true;
            this.lblTiLeDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTiLeDat.Location = new System.Drawing.Point(14, 135);
            this.lblTiLeDat.Margin = new System.Windows.Forms.Padding(0);
            this.lblTiLeDat.Name = "lblTiLeDat";
            this.lblTiLeDat.Size = new System.Drawing.Size(635, 28);
            this.lblTiLeDat.TabIndex = 2;
            this.lblTiLeDat.Text = " ";
            // 
            // rateVuot
            // 
            this.rateVuot.AutoSize = true;
            this.rateVuot.ColumnCount = 1;
            this.rateVuot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rateVuot.Controls.Add(this.lblRateTitleVuot, 0, 0);
            this.rateVuot.Controls.Add(this.lblSoVuot, 0, 1);
            this.rateVuot.Controls.Add(this.lblTiLeVuot, 0, 2);
            this.rateVuot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rateVuot.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.rateVuot.Location = new System.Drawing.Point(675, 0);
            this.rateVuot.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.rateVuot.Name = "rateVuot";
            this.rateVuot.Padding = new System.Windows.Forms.Padding(14, 9, 14, 9);
            this.rateVuot.RowCount = 3;
            this.rateVuot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rateVuot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rateVuot.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rateVuot.Size = new System.Drawing.Size(663, 172);
            this.rateVuot.TabIndex = 1;
            // 
            // lblRateTitleVuot
            // 
            this.lblRateTitleVuot.AutoSize = true;
            this.lblRateTitleVuot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRateTitleVuot.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRateTitleVuot.Location = new System.Drawing.Point(14, 9);
            this.lblRateTitleVuot.Margin = new System.Windows.Forms.Padding(0);
            this.lblRateTitleVuot.Name = "lblRateTitleVuot";
            this.lblRateTitleVuot.Size = new System.Drawing.Size(635, 28);
            this.lblRateTitleVuot.TabIndex = 0;
            this.lblRateTitleVuot.Text = "Vượt định mức";
            // 
            // lblSoVuot
            // 
            this.lblSoVuot.AccessibleName = "Tỷ lệ vượt định mức";
            this.lblSoVuot.AutoSize = true;
            this.lblSoVuot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoVuot.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblSoVuot.Location = new System.Drawing.Point(14, 37);
            this.lblSoVuot.Margin = new System.Windows.Forms.Padding(0);
            this.lblSoVuot.Name = "lblSoVuot";
            this.lblSoVuot.Size = new System.Drawing.Size(635, 98);
            this.lblSoVuot.TabIndex = 1;
            this.lblSoVuot.Text = "—";
            this.lblSoVuot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTiLeVuot
            // 
            this.lblTiLeVuot.AutoSize = true;
            this.lblTiLeVuot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTiLeVuot.Location = new System.Drawing.Point(14, 135);
            this.lblTiLeVuot.Margin = new System.Windows.Forms.Padding(0);
            this.lblTiLeVuot.Name = "lblTiLeVuot";
            this.lblTiLeVuot.Size = new System.Drawing.Size(635, 28);
            this.lblTiLeVuot.TabIndex = 2;
            this.lblTiLeVuot.Text = " ";
            // 
            // lblWorkload
            // 
            this.lblWorkload.AccessibleName = "Trạng thái tải tỷ lệ";
            this.lblWorkload.AutoSize = true;
            this.lblWorkload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkload.Location = new System.Drawing.Point(21, 298);
            this.lblWorkload.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.lblWorkload.MinimumSize = new System.Drawing.Size(0, 26);
            this.lblWorkload.Name = "lblWorkload";
            this.lblWorkload.Size = new System.Drawing.Size(1338, 28);
            this.lblWorkload.TabIndex = 3;
            this.lblWorkload.Text = "Đang tải…";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1785, 1058);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(822, 504);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý giảng viên";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.pnlHeader.ResumeLayout(false);
            this.layoutHeader.ResumeLayout(false);
            this.layoutHeader.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.layoutSidebar.ResumeLayout(false);
            this.layoutSidebar.PerformLayout();
            this.pnlHeThong.ResumeLayout(false);
            this.pnlDanhMuc.ResumeLayout(false);
            this.pnlDaoTao.ResumeLayout(false);
            this.pnlThongKe.ResumeLayout(false);
            this.pnlBaoCao.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.layoutDashboard.ResumeLayout(false);
            this.layoutDashboard.PerformLayout();
            this.layoutOverviewHeader.ResumeLayout(false);
            this.layoutOverviewHeader.PerformLayout();
            this.layoutCounts.ResumeLayout(false);
            this.cardGiangVien.ResumeLayout(false);
            this.cardGiangVien.PerformLayout();
            this.cardKhoa.ResumeLayout(false);
            this.cardKhoa.PerformLayout();
            this.cardHocPhan.ResumeLayout(false);
            this.cardHocPhan.PerformLayout();
            this.cardLop.ResumeLayout(false);
            this.cardLop.PerformLayout();
            this.layoutWorkload.ResumeLayout(false);
            this.layoutWorkload.PerformLayout();
            this.layoutSemester.ResumeLayout(false);
            this.layoutSemester.PerformLayout();
            this.layoutRates.ResumeLayout(false);
            this.layoutRates.PerformLayout();
            this.rateDat.ResumeLayout(false);
            this.rateDat.PerformLayout();
            this.rateVuot.ResumeLayout(false);
            this.rateVuot.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlHeader;
        private TableLayoutPanel layoutHeader;
        private Label lblIconHeThong;
        private Label lblTieuDeHeThong;
        private Label lblWelcome;
        private Button btnTheme;
        private Panel pnlSidebar;
        private TableLayoutPanel layoutSidebar;
        private Label lblIconMenu;
        private Button btnTongQuan;
        private Button btnHeThong;
        private TableLayoutPanel pnlHeThong;
        private Button btnNguoiDung;
        private Button btnDoiMatKhau;
        private Button btnPhanQuyen;
        private Button btnDanhMuc;
        private TableLayoutPanel pnlDanhMuc;
        private Button btnKhoa;
        private Button btnBoMon;
        private Button btnGiangVien;
        private Button btnHocVi;
        private Button btnChucVu;
        private Button btnChuyenMon;
        private Button btnHocPhan;
        private Button btnDaoTao;
        private TableLayoutPanel pnlDaoTao;
        private Button btnLopHocPhan;
        private Button btnPhanCong;
        private Button btnThongKe;
        private TableLayoutPanel pnlThongKe;
        private Button btnKhoiLuong;
        private Button btnBieuDo;
        private Button btnBaoCao;
        private TableLayoutPanel pnlBaoCao;
        private Button btnBaoCaoGiangVien;
        private Button btnBaoCaoPhanCong;
        private Button btnBaoCaoTaiTrongKhoa;
        private Button btnBaoCaoChuaPhanCong;
        private Button btnDangXuat;
        private Panel pnlContent;
        private TableLayoutPanel layoutDashboard;
        private TableLayoutPanel layoutOverviewHeader;
        private Label lblTieuDeTongQuan;
        private Label lblScope;
        private Button btnBieuDoTongQuan;
        private Label lblDashboardMessage;
        private TableLayoutPanel layoutCounts;
        private TableLayoutPanel cardGiangVien;
        private Label lblDanhMucGiangVien;
        private Label lblSoGiangVien;
        private Label lblTrangThaiGiangVien;
        private TableLayoutPanel cardKhoa;
        private Label lblDanhMucKhoa;
        private Label lblSoKhoa;
        private Label lblTrangThaiKhoa;
        private TableLayoutPanel cardHocPhan;
        private Label lblDanhMucHocPhan;
        private Label lblSoHocPhan;
        private Label lblTrangThaiHocPhan;
        private TableLayoutPanel cardLop;
        private Label lblDanhMucLop;
        private Label lblSoLop;
        private Label lblTrangThaiLop;
        private TableLayoutPanel layoutWorkload;
        private Label lblTieuDeKhoiLuong;
        private TableLayoutPanel layoutSemester;
        private Label lblWorkloadYear;
        private ComboBox cboHocKy;
        private TableLayoutPanel layoutRates;
        private TableLayoutPanel rateDat;
        private Label lblRateTitleDat;
        private Label lblSoDat;
        private Label lblTiLeDat;
        private TableLayoutPanel rateVuot;
        private Label lblRateTitleVuot;
        private Label lblSoVuot;
        private Label lblTiLeVuot;
        private Label lblWorkload;
    }
}

