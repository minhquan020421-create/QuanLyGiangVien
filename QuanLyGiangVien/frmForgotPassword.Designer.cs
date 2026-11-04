using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    partial class frmForgotPassword
    {
        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.layoutKhoiPhuc = new TableLayoutPanel();
            this.lblTieuDe = new Label();
            this.lblHuongDan = new Label();
            this.lblTenDangNhap = new Label();
            this.txtTenDangNhap = new TextBox();
            this.btnGuiMa = new Button();
            this.lblOtp = new Label();
            this.txtOtp = new TextBox();
            this.layoutMatKhau = new TableLayoutPanel();
            this.lblMatKhauMoi = new Label();
            this.txtMatKhauMoi = new TextBox();
            this.lblNhapLai = new Label();
            this.txtNhapLai = new TextBox();
            this.lblPhanHoi = new Label();
            this.layoutThaoTac = new FlowLayoutPanel();
            this.btnLuuMatKhau = new Button();
            this.btnHuy = new Button();
            this.layoutKhoiPhuc.SuspendLayout();
            this.layoutMatKhau.SuspendLayout();
            this.layoutThaoTac.SuspendLayout();
            this.SuspendLayout();

            this.layoutKhoiPhuc.AutoSize = true;
            this.layoutKhoiPhuc.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutKhoiPhuc.BackColor = Color.FromArgb(27, 39, 58);
            this.layoutKhoiPhuc.ColumnCount = 2;
            this.layoutKhoiPhuc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.layoutKhoiPhuc.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.Controls.Add(this.lblTieuDe, 0, 0);
            this.layoutKhoiPhuc.Controls.Add(this.lblHuongDan, 0, 1);
            this.layoutKhoiPhuc.Controls.Add(this.lblTenDangNhap, 0, 2);
            this.layoutKhoiPhuc.Controls.Add(this.txtTenDangNhap, 0, 3);
            this.layoutKhoiPhuc.Controls.Add(this.btnGuiMa, 1, 3);
            this.layoutKhoiPhuc.Controls.Add(this.lblOtp, 0, 4);
            this.layoutKhoiPhuc.Controls.Add(this.txtOtp, 0, 5);
            this.layoutKhoiPhuc.Controls.Add(this.layoutMatKhau, 0, 6);
            this.layoutKhoiPhuc.Controls.Add(this.lblPhanHoi, 0, 7);
            this.layoutKhoiPhuc.Controls.Add(this.layoutThaoTac, 0, 8);
            this.layoutKhoiPhuc.SetColumnSpan(this.lblTieuDe, 2);
            this.layoutKhoiPhuc.SetColumnSpan(this.lblHuongDan, 2);
            this.layoutKhoiPhuc.SetColumnSpan(this.layoutMatKhau, 2);
            this.layoutKhoiPhuc.SetColumnSpan(this.lblPhanHoi, 2);
            this.layoutKhoiPhuc.SetColumnSpan(this.layoutThaoTac, 2);
            this.layoutKhoiPhuc.Dock = DockStyle.Top;
            this.layoutKhoiPhuc.Name = "layoutKhoiPhuc";
            this.layoutKhoiPhuc.Padding = new Padding(20, 16, 20, 12);
            this.layoutKhoiPhuc.RowCount = 9;
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutKhoiPhuc.TabIndex = 0;

            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTieuDe.Margin = new Padding(0, 0, 0, 4);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Text = "Quên mật khẩu";

            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Dock = DockStyle.Fill;
            this.lblHuongDan.ForeColor = Color.FromArgb(181, 199, 220);
            this.lblHuongDan.Margin = new Padding(0, 0, 0, 14);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Text = "Nhập tên đăng nhập để nhận mã OTP qua email khôi phục, sau đó đặt mật khẩu mới.";

            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.ForeColor = Color.FromArgb(181, 199, 220);
            this.lblTenDangNhap.Margin = new Padding(0, 0, 0, 2);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Text = "Tên đăng nhập";

            this.txtTenDangNhap.AccessibleName = "Tên đăng nhập";
            this.txtTenDangNhap.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.txtTenDangNhap.BackColor = Color.FromArgb(17, 29, 46);
            this.txtTenDangNhap.ForeColor = Color.FromArgb(236, 242, 251);
            this.txtTenDangNhap.Margin = new Padding(0, 0, 8, 0);
            this.txtTenDangNhap.MaxLength = 50;
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.TabIndex = 0;
            this.txtTenDangNhap.TextChanged += new EventHandler(this.txtTenDangNhap_TextChanged);

            this.btnGuiMa.AutoSize = true;
            this.btnGuiMa.BackColor = Color.FromArgb(27, 39, 58);
            this.btnGuiMa.FlatAppearance.BorderColor = Color.FromArgb(62, 82, 110);
            this.btnGuiMa.FlatStyle = FlatStyle.Flat;
            this.btnGuiMa.ForeColor = Color.FromArgb(236, 242, 251);
            this.btnGuiMa.Margin = new Padding(0);
            this.btnGuiMa.MinimumSize = new Size(112, 34);
            this.btnGuiMa.Name = "btnGuiMa";
            this.btnGuiMa.TabIndex = 1;
            this.btnGuiMa.Text = "Gửi mã OTP";
            this.btnGuiMa.UseVisualStyleBackColor = false;
            this.btnGuiMa.Click += new EventHandler(this.btnGuiMa_Click);

            this.lblOtp.AutoSize = true;
            this.lblOtp.ForeColor = Color.FromArgb(181, 199, 220);
            this.lblOtp.Margin = new Padding(0, 10, 0, 2);
            this.lblOtp.Name = "lblOtp";
            this.lblOtp.Text = "Mã OTP (6 chữ số)";

            this.txtOtp.AccessibleName = "Mã OTP 6 chữ số";
            this.txtOtp.BackColor = Color.FromArgb(17, 29, 46);
            this.txtOtp.Enabled = false;
            this.txtOtp.ForeColor = Color.FromArgb(236, 242, 251);
            this.txtOtp.Margin = new Padding(0);
            this.txtOtp.MaxLength = 6;
            this.txtOtp.Name = "txtOtp";
            this.txtOtp.Size = new Size(124, 26);
            this.txtOtp.TabIndex = 2;

            this.layoutMatKhau.AutoSize = true;
            this.layoutMatKhau.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutMatKhau.BackColor = Color.FromArgb(27, 39, 58);
            this.layoutMatKhau.ColumnCount = 2;
            this.layoutMatKhau.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.layoutMatKhau.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            this.layoutMatKhau.Controls.Add(this.lblMatKhauMoi, 0, 0);
            this.layoutMatKhau.Controls.Add(this.txtMatKhauMoi, 0, 1);
            this.layoutMatKhau.Controls.Add(this.lblNhapLai, 1, 0);
            this.layoutMatKhau.Controls.Add(this.txtNhapLai, 1, 1);
            this.layoutMatKhau.Dock = DockStyle.Fill;
            this.layoutMatKhau.Margin = new Padding(0, 10, 0, 0);
            this.layoutMatKhau.Name = "layoutMatKhau";
            this.layoutMatKhau.RowCount = 2;
            this.layoutMatKhau.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutMatKhau.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.layoutMatKhau.TabIndex = 3;

            this.lblMatKhauMoi.AutoSize = true;
            this.lblMatKhauMoi.ForeColor = Color.FromArgb(181, 199, 220);
            this.lblMatKhauMoi.Margin = new Padding(0, 0, 0, 2);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Text = "Mật khẩu mới";

            this.txtMatKhauMoi.AccessibleName = "Mật khẩu mới";
            this.txtMatKhauMoi.BackColor = Color.FromArgb(17, 29, 46);
            this.txtMatKhauMoi.Dock = DockStyle.Fill;
            this.txtMatKhauMoi.Enabled = false;
            this.txtMatKhauMoi.ForeColor = Color.FromArgb(236, 242, 251);
            this.txtMatKhauMoi.Margin = new Padding(0, 0, 8, 0);
            this.txtMatKhauMoi.MaxLength = 128;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.TabIndex = 0;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;

            this.lblNhapLai.AutoSize = true;
            this.lblNhapLai.ForeColor = Color.FromArgb(181, 199, 220);
            this.lblNhapLai.Margin = new Padding(0, 0, 0, 2);
            this.lblNhapLai.Name = "lblNhapLai";
            this.lblNhapLai.Text = "Nhập lại mật khẩu";

            this.txtNhapLai.AccessibleName = "Nhập lại mật khẩu";
            this.txtNhapLai.BackColor = Color.FromArgb(17, 29, 46);
            this.txtNhapLai.Dock = DockStyle.Fill;
            this.txtNhapLai.Enabled = false;
            this.txtNhapLai.ForeColor = Color.FromArgb(236, 242, 251);
            this.txtNhapLai.Margin = new Padding(0);
            this.txtNhapLai.MaxLength = 128;
            this.txtNhapLai.Name = "txtNhapLai";
            this.txtNhapLai.TabIndex = 1;
            this.txtNhapLai.UseSystemPasswordChar = true;

            this.lblPhanHoi.AccessibleName = "Trạng thái khôi phục mật khẩu";
            this.lblPhanHoi.Dock = DockStyle.Fill;
            this.lblPhanHoi.ForeColor = Color.FromArgb(181, 199, 220);
            this.lblPhanHoi.Margin = new Padding(0, 8, 0, 4);
            this.lblPhanHoi.MinimumSize = new Size(0, 50);
            this.lblPhanHoi.Name = "lblPhanHoi";

            this.layoutThaoTac.AutoSize = true;
            this.layoutThaoTac.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.layoutThaoTac.BackColor = Color.FromArgb(27, 39, 58);
            this.layoutThaoTac.Controls.Add(this.btnLuuMatKhau);
            this.layoutThaoTac.Controls.Add(this.btnHuy);
            this.layoutThaoTac.Dock = DockStyle.Fill;
            this.layoutThaoTac.FlowDirection = FlowDirection.RightToLeft;
            this.layoutThaoTac.Margin = new Padding(0);
            this.layoutThaoTac.Name = "layoutThaoTac";
            this.layoutThaoTac.TabIndex = 4;

            this.btnLuuMatKhau.AutoSize = true;
            this.btnLuuMatKhau.BackColor = Color.FromArgb(49, 91, 190);
            this.btnLuuMatKhau.Enabled = false;
            this.btnLuuMatKhau.FlatAppearance.BorderSize = 0;
            this.btnLuuMatKhau.FlatStyle = FlatStyle.Flat;
            this.btnLuuMatKhau.ForeColor = Color.White;
            this.btnLuuMatKhau.Margin = new Padding(8, 0, 0, 0);
            this.btnLuuMatKhau.MinimumSize = new Size(140, 36);
            this.btnLuuMatKhau.Name = "btnLuuMatKhau";
            this.btnLuuMatKhau.TabIndex = 0;
            this.btnLuuMatKhau.Text = "Đặt lại mật khẩu";
            this.btnLuuMatKhau.UseVisualStyleBackColor = false;
            this.btnLuuMatKhau.Click += new EventHandler(this.btnLuuMatKhau_Click);

            this.btnHuy.AutoSize = true;
            this.btnHuy.BackColor = Color.FromArgb(27, 39, 58);
            this.btnHuy.DialogResult = DialogResult.Cancel;
            this.btnHuy.FlatAppearance.BorderColor = Color.FromArgb(62, 82, 110);
            this.btnHuy.FlatStyle = FlatStyle.Flat;
            this.btnHuy.ForeColor = Color.FromArgb(236, 242, 251);
            this.btnHuy.Margin = new Padding(0);
            this.btnHuy.MinimumSize = new Size(80, 36);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;

            this.AcceptButton = this.btnGuiMa;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = Color.FromArgb(16, 23, 37);
            this.CancelButton = this.btnHuy;
            this.ClientSize = new Size(492, 405);
            this.Controls.Add(this.layoutKhoiPhuc);
            this.Font = new Font("Segoe UI", 10F);
            this.ForeColor = Color.FromArgb(236, 242, 251);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new Size(410, 265);
            this.Name = "frmForgotPassword";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Quên mật khẩu — Quản lý giảng viên";
            this.Load += new EventHandler(this.frmForgotPassword_Load);
            this.layoutThaoTac.ResumeLayout(false);
            this.layoutThaoTac.PerformLayout();
            this.layoutMatKhau.ResumeLayout(false);
            this.layoutMatKhau.PerformLayout();
            this.layoutKhoiPhuc.ResumeLayout(false);
            this.layoutKhoiPhuc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TableLayoutPanel layoutKhoiPhuc;
        private Label lblTieuDe;
        private Label lblHuongDan;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Button btnGuiMa;
        private Label lblOtp;
        private TextBox txtOtp;
        private TableLayoutPanel layoutMatKhau;
        private Label lblMatKhauMoi;
        private TextBox txtMatKhauMoi;
        private Label lblNhapLai;
        private TextBox txtNhapLai;
        private Label lblPhanHoi;
        private FlowLayoutPanel layoutThaoTac;
        private Button btnLuuMatKhau;
        private Button btnHuy;
    }
}
