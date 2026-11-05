using System.Windows.Forms;
using System.Drawing;
namespace QuanLyGiangVien
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDangNhap = new System.Windows.Forms.Panel();
            this.lblIconMatKhau = new System.Windows.Forms.Label();
            this.lblIconTaiKhoan = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.chkGhiNhoDangNhap = new System.Windows.Forms.CheckBox();
            this.btnHienMatKhau = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblDangNhap = new System.Windows.Forms.Label();
            this.lblTenHeThong = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.btnTheme = new System.Windows.Forms.Button();
            this.lblIconHocVu = new System.Windows.Forms.Label();
            this.pnlDangNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDangNhap
            // 
            this.pnlDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlDangNhap.Controls.Add(this.lblIconMatKhau);
            this.pnlDangNhap.Controls.Add(this.lblIconTaiKhoan);
            this.pnlDangNhap.Controls.Add(this.lblThongBao);
            this.pnlDangNhap.Controls.Add(this.btnThoat);
            this.pnlDangNhap.Controls.Add(this.btnDangNhap);
            this.pnlDangNhap.Controls.Add(this.chkGhiNhoDangNhap);
            this.pnlDangNhap.Controls.Add(this.btnHienMatKhau);
            this.pnlDangNhap.Controls.Add(this.txtMatKhau);
            this.pnlDangNhap.Controls.Add(this.lblMatKhau);
            this.pnlDangNhap.Controls.Add(this.txtTenDangNhap);
            this.pnlDangNhap.Controls.Add(this.lblTenDangNhap);
            this.pnlDangNhap.Controls.Add(this.lblDangNhap);
            this.pnlDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.pnlDangNhap.Location = new System.Drawing.Point(40, 140);
            this.pnlDangNhap.Name = "pnlDangNhap";
            this.pnlDangNhap.Size = new System.Drawing.Size(440, 390);
            this.pnlDangNhap.TabIndex = 0;
            // 
            // lblIconMatKhau
            // 
            this.lblIconMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblIconMatKhau.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(211)))), ((int)(((byte)(240)))));
            this.lblIconMatKhau.Location = new System.Drawing.Point(30, 158);
            this.lblIconMatKhau.Name = "lblIconMatKhau";
            this.lblIconMatKhau.Size = new System.Drawing.Size(20, 25);
            this.lblIconMatKhau.TabIndex = 8;
            this.lblIconMatKhau.Text = "";
            this.lblIconMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIconTaiKhoan
            // 
            this.lblIconTaiKhoan.AutoSize = true;
            this.lblIconTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.lblIconTaiKhoan.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIconTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(211)))), ((int)(((byte)(240)))));
            this.lblIconTaiKhoan.Location = new System.Drawing.Point(30, 78);
            this.lblIconTaiKhoan.Name = "lblIconTaiKhoan";
            this.lblIconTaiKhoan.Size = new System.Drawing.Size(34, 24);
            this.lblIconTaiKhoan.TabIndex = 7;
            this.lblIconTaiKhoan.Text = "";
            this.lblIconTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThongBao
            // 
            this.lblThongBao.BackColor = System.Drawing.Color.Transparent;
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(157)))));
            this.lblThongBao.Location = new System.Drawing.Point(30, 336);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(380, 40);
            this.lblThongBao.TabIndex = 6;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.btnThoat.Location = new System.Drawing.Point(302, 280);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(108, 42);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(30, 280);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(260, 42);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            // 
            // chkGhiNhoDangNhap
            // 
            this.chkGhiNhoDangNhap.AutoSize = true;
            this.chkGhiNhoDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.chkGhiNhoDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.chkGhiNhoDangNhap.Location = new System.Drawing.Point(30, 236);
            this.chkGhiNhoDangNhap.Name = "chkGhiNhoDangNhap";
            this.chkGhiNhoDangNhap.Size = new System.Drawing.Size(255, 34);
            this.chkGhiNhoDangNhap.TabIndex = 3;
            this.chkGhiNhoDangNhap.Text = "Ghi nhớ tên đăng nhập";
            this.chkGhiNhoDangNhap.UseVisualStyleBackColor = false;
            // 
            // btnHienMatKhau
            // 
            this.btnHienMatKhau.AccessibleName = "Hiện hoặc ẩn mật khẩu";
            this.btnHienMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnHienMatKhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHienMatKhau.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnHienMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHienMatKhau.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.btnHienMatKhau.Location = new System.Drawing.Point(370, 188);
            this.btnHienMatKhau.Name = "btnHienMatKhau";
            this.btnHienMatKhau.Size = new System.Drawing.Size(40, 31);
            this.btnHienMatKhau.TabIndex = 2;
            this.btnHienMatKhau.Text = "";
            this.btnHienMatKhau.UseVisualStyleBackColor = false;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtMatKhau.Location = new System.Drawing.Point(30, 188);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(332, 36);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblMatKhau.Location = new System.Drawing.Point(56, 158);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(354, 25);
            this.lblMatKhau.TabIndex = 3;
            this.lblMatKhau.Text = "Mật khẩu";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtTenDangNhap.Location = new System.Drawing.Point(30, 108);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(380, 36);
            this.txtTenDangNhap.TabIndex = 0;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(56, 78);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(354, 25);
            this.lblTenDangNhap.TabIndex = 1;
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // lblDangNhap
            // 
            this.lblDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lblDangNhap.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.lblDangNhap.Location = new System.Drawing.Point(30, 22);
            this.lblDangNhap.Name = "lblDangNhap";
            this.lblDangNhap.Size = new System.Drawing.Size(380, 35);
            this.lblDangNhap.TabIndex = 0;
            this.lblDangNhap.Text = "Đăng nhập";
            this.lblDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenHeThong
            // 
            this.lblTenHeThong.BackColor = System.Drawing.Color.Transparent;
            this.lblTenHeThong.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenHeThong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.lblTenHeThong.Location = new System.Drawing.Point(96, 32);
            this.lblTenHeThong.Name = "lblTenHeThong";
            this.lblTenHeThong.Size = new System.Drawing.Size(405, 50);
            this.lblTenHeThong.TabIndex = 1;
            this.lblTenHeThong.Text = "QUẢN LÝ GIẢNG VIÊN";
            this.lblTenHeThong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMoTa
            // 
            this.lblMoTa.BackColor = System.Drawing.Color.Transparent;
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblMoTa.Location = new System.Drawing.Point(96, 83);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(380, 28);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Hệ thống quản lý đại học";
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMoTa.Click += new System.EventHandler(this.lblMoTa_Click);
            // 
            // btnTheme
            // 
            this.btnTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnTheme.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnTheme.FlatAppearance.BorderSize = 0;
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheme.ForeColor = System.Drawing.Color.White;
            this.btnTheme.Location = new System.Drawing.Point(180, 544);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(162, 32);
            this.btnTheme.TabIndex = 8;
            this.btnTheme.Text = "Giao diện sáng";
            this.btnTheme.UseVisualStyleBackColor = false;
            this.btnTheme.Click += new System.EventHandler(this.btnTheme_Click);
            // 
            // lblIconHocVu
            // 
            this.lblIconHocVu.BackColor = System.Drawing.Color.Transparent;
            this.lblIconHocVu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 20F);
            this.lblIconHocVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(211)))), ((int)(((byte)(240)))));
            this.lblIconHocVu.Location = new System.Drawing.Point(38, 38);
            this.lblIconHocVu.Name = "lblIconHocVu";
            this.lblIconHocVu.Size = new System.Drawing.Size(48, 44);
            this.lblIconHocVu.TabIndex = 9;
            this.lblIconHocVu.Text = "";
            this.lblIconHocVu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(524, 635);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblTenHeThong);
            this.Controls.Add(this.pnlDangNhap);
            this.Controls.Add(this.btnTheme);
            this.Controls.Add(this.lblIconHocVu);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập — Quản lý giảng viên";
            this.pnlDangNhap.ResumeLayout(false);
            this.pnlDangNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        
        #endregion

        private System.Windows.Forms.Button btnTheme;
        private System.Windows.Forms.Label lblIconHocVu;
        private System.Windows.Forms.Panel pnlDangNhap;
        private System.Windows.Forms.Label lblTenHeThong;
        private System.Windows.Forms.Label lblDangNhap;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Button btnHienMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.CheckBox chkGhiNhoDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label lblIconTaiKhoan;
        private System.Windows.Forms.Label lblIconMatKhau;
    }
}

