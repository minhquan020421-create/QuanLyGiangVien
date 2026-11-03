namespace QuanLyGiangVien
{
    partial class frmAccountHome
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
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnAccounts = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(28, 24);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(450, 28);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "Tài khoản của tôi";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Location = new System.Drawing.Point(28, 64);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(450, 28);
            this.lblCurrentUser.TabIndex = 2;
            this.lblCurrentUser.Text = "Đã đăng nhập";
            // 
            // btnLogout
            // 
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(28, 292);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(218, 42);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnPassword
            // 
            this.btnPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Location = new System.Drawing.Point(28, 218);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(450, 42);
            this.btnPassword.TabIndex = 2;
            this.btnPassword.Text = "Đổi mật khẩu của tôi";
            this.btnPassword.UseVisualStyleBackColor = true;
            // 
            // btnRoles
            // 
            this.btnRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Location = new System.Drawing.Point(28, 158);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(450, 42);
            this.btnRoles.TabIndex = 1;
            this.btnRoles.Text = "Vai trò và phân quyền";
            this.btnRoles.UseVisualStyleBackColor = true;
            // 
            // btnAccounts
            // 
            this.btnAccounts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccounts.Location = new System.Drawing.Point(28, 110);
            this.btnAccounts.Name = "btnAccounts";
            this.btnAccounts.Size = new System.Drawing.Size(450, 42);
            this.btnAccounts.TabIndex = 0;
            this.btnAccounts.Text = "Quản lý tài khoản";
            this.btnAccounts.UseVisualStyleBackColor = true;
            // 
            // btnTheme
            // 
            this.btnTheme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheme.Location = new System.Drawing.Point(260, 292);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(218, 42);
            this.btnTheme.TabIndex = 4;
            this.btnTheme.Text = "Giao diện tối";
            this.btnTheme.UseVisualStyleBackColor = true;
            // 
            // frmAccountHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(522, 373);
            this.Controls.Add(this.btnTheme);
            this.Controls.Add(this.btnAccounts);
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.btnPassword);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAccountHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài khoản — Quản lý giảng viên";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnTheme;
    }
}