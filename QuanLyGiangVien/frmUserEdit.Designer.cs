using System.Windows.Forms;
using System.Drawing;
namespace QuanLyGiangVien
{
    partial class frmUserEdit
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.cboGiangVien = new System.Windows.Forms.ComboBox();
            this.txtEmailKhoiPhuc = new System.Windows.Forms.TextBox();
            this.lblEmailKhoiPhuc = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblXacNhanMatKhau = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.lblGiangVien = new System.Windows.Forms.Label();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.pnlThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.lblTieuDe.Location = new System.Drawing.Point(30, 25);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(520, 42);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THÔNG TIN TÀI KHOẢN";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlThongTin.Controls.Add(this.lblThongBao);
            this.pnlThongTin.Controls.Add(this.btnHuy);
            this.pnlThongTin.Controls.Add(this.btnLuu);
            this.pnlThongTin.Controls.Add(this.cboVaiTro);
            this.pnlThongTin.Controls.Add(this.cboGiangVien);
            this.pnlThongTin.Controls.Add(this.txtEmailKhoiPhuc);
            this.pnlThongTin.Controls.Add(this.lblEmailKhoiPhuc);
            this.pnlThongTin.Controls.Add(this.txtMatKhau);
            this.pnlThongTin.Controls.Add(this.txtXacNhanMatKhau);
            this.pnlThongTin.Controls.Add(this.txtTenDangNhap);
            this.pnlThongTin.Controls.Add(this.lblXacNhanMatKhau);
            this.pnlThongTin.Controls.Add(this.lblMatKhau);
            this.pnlThongTin.Controls.Add(this.lblVaiTro);
            this.pnlThongTin.Controls.Add(this.lblGiangVien);
            this.pnlThongTin.Controls.Add(this.lblTenDangNhap);
            this.pnlThongTin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.pnlThongTin.Location = new System.Drawing.Point(30, 90);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(520, 480);
            this.pnlThongTin.TabIndex = 1;
            // 
            // lblThongBao
            // 
            this.lblThongBao.BackColor = System.Drawing.Color.Transparent;
            this.lblThongBao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(157)))));
            this.lblThongBao.Location = new System.Drawing.Point(30, 450);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(460, 25);
            this.lblThongBao.TabIndex = 7;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.btnHuy.Location = new System.Drawing.Point(382, 404);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(108, 42);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(30, 404);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(340, 42);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(30, 198);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(460, 31);
            this.cboVaiTro.TabIndex = 2;
            this.cboVaiTro.SelectedIndexChanged += new System.EventHandler(this.cboVaiTro_SelectedIndexChanged);
            // 
            // cboGiangVien
            // 
            this.cboGiangVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.cboGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiangVien.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGiangVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cboGiangVien.FormattingEnabled = true;
            this.cboGiangVien.Location = new System.Drawing.Point(30, 124);
            this.cboGiangVien.Name = "cboGiangVien";
            this.cboGiangVien.Size = new System.Drawing.Size(460, 33);
            this.cboGiangVien.TabIndex = 1;
            //
            // txtEmailKhoiPhuc
            //
            this.txtEmailKhoiPhuc.AccessibleName = "Email khôi phục";
            this.txtEmailKhoiPhuc.BackColor = System.Drawing.Color.FromArgb(17, 29, 46);
            this.txtEmailKhoiPhuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailKhoiPhuc.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txtEmailKhoiPhuc.ForeColor = System.Drawing.Color.FromArgb(236, 242, 251);
            this.txtEmailKhoiPhuc.Location = new System.Drawing.Point(30, 272);
            this.txtEmailKhoiPhuc.MaxLength = 254;
            this.txtEmailKhoiPhuc.Name = "txtEmailKhoiPhuc";
            this.txtEmailKhoiPhuc.Size = new System.Drawing.Size(460, 31);
            this.txtEmailKhoiPhuc.TabIndex = 3;
            //
            // lblEmailKhoiPhuc
            //
            this.lblEmailKhoiPhuc.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailKhoiPhuc.ForeColor = System.Drawing.Color.FromArgb(181, 199, 220);
            this.lblEmailKhoiPhuc.Location = new System.Drawing.Point(30, 242);
            this.lblEmailKhoiPhuc.Name = "lblEmailKhoiPhuc";
            this.lblEmailKhoiPhuc.Size = new System.Drawing.Size(460, 25);
            this.lblEmailKhoiPhuc.Text = "Email khôi phục (không bắt buộc)";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtMatKhau.Location = new System.Drawing.Point(30, 346);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(220, 31);
            this.txtMatKhau.TabIndex = 4;
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.txtXacNhanMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXacNhanMatKhau.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacNhanMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(270, 346);
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(220, 31);
            this.txtXacNhanMatKhau.TabIndex = 5;
            this.txtXacNhanMatKhau.UseSystemPasswordChar = true;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtTenDangNhap.Location = new System.Drawing.Point(30, 50);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(460, 31);
            this.txtTenDangNhap.TabIndex = 0;
            // 
            // lblXacNhanMatKhau
            // 
            this.lblXacNhanMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblXacNhanMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblXacNhanMatKhau.Location = new System.Drawing.Point(270, 316);
            this.lblXacNhanMatKhau.Name = "lblXacNhanMatKhau";
            this.lblXacNhanMatKhau.Size = new System.Drawing.Size(220, 25);
            this.lblXacNhanMatKhau.TabIndex = 4;
            this.lblXacNhanMatKhau.Text = "Nhập lại mật khẩu";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblMatKhau.Location = new System.Drawing.Point(30, 316);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(220, 25);
            this.lblMatKhau.TabIndex = 3;
            this.lblMatKhau.Text = "Mật khẩu khởi tạo";
            // 
            // lblVaiTro
            // 
            this.lblVaiTro.BackColor = System.Drawing.Color.Transparent;
            this.lblVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.lblVaiTro.Location = new System.Drawing.Point(30, 168);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(460, 25);
            this.lblVaiTro.TabIndex = 2;
            this.lblVaiTro.Text = "Vai trò";
            // 
            // lblGiangVien
            // 
            this.lblGiangVien.BackColor = System.Drawing.Color.Transparent;
            this.lblGiangVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblGiangVien.Location = new System.Drawing.Point(30, 94);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Size = new System.Drawing.Size(460, 25);
            this.lblGiangVien.TabIndex = 1;
            this.lblGiangVien.Text = "Giảng viên";
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblTenDangNhap.Location = new System.Drawing.Point(30, 20);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(460, 25);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            // 
            // frmUserEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(582, 603);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin tài khoản";
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        
        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblXacNhanMatKhau;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.Label lblGiangVien;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblEmailKhoiPhuc;
        private System.Windows.Forms.TextBox txtEmailKhoiPhuc;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.ComboBox cboGiangVien;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Button btnHuy;
    }
}
