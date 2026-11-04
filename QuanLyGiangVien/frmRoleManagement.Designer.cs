using System.Windows.Forms;
using System.Drawing;
namespace QuanLyGiangVien
{
    partial class frmRoleManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlVaiTro = new System.Windows.Forms.Panel();
            this.btnSuaVaiTro = new System.Windows.Forms.Button();
            this.btnXoaVaiTro = new System.Windows.Forms.Button();
            this.btnThemVaiTro = new System.Windows.Forms.Button();
            this.txtMoTaVaiTro = new System.Windows.Forms.TextBox();
            this.lblMoTaVaiTro = new System.Windows.Forms.Label();
            this.txtTenVaiTro = new System.Windows.Forms.TextBox();
            this.lblTenVaiTro = new System.Windows.Forms.Label();
            this.lstVaiTro = new System.Windows.Forms.ListBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.pnlPhanQuyen = new System.Windows.Forms.Panel();
            this.btnLuuQuyen = new System.Windows.Forms.Button();
            this.dgvPhanQuyen = new System.Windows.Forms.DataGridView();
            this.colChucNang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuocXem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDuocThem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDuocSua = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDuocXoa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblVaiTroDangChon = new System.Windows.Forms.Label();
            this.lblTieuDePhanQuyen = new System.Windows.Forms.Label();
            this.btnQuayLaiMain = new System.Windows.Forms.Button();
            this.pnlVaiTro.SuspendLayout();
            this.pnlPhanQuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).BeginInit();
            this.SuspendLayout();
            //
            // lblTieuDe
            //
            this.lblTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(1034, 38);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "VAI TRÒ VÀ PHÂN QUYỀN";
            //
            // pnlVaiTro
            //
            this.pnlVaiTro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlVaiTro.Controls.Add(this.btnSuaVaiTro);
            this.pnlVaiTro.Controls.Add(this.btnXoaVaiTro);
            this.pnlVaiTro.Controls.Add(this.btnThemVaiTro);
            this.pnlVaiTro.Controls.Add(this.txtMoTaVaiTro);
            this.pnlVaiTro.Controls.Add(this.lblMoTaVaiTro);
            this.pnlVaiTro.Controls.Add(this.txtTenVaiTro);
            this.pnlVaiTro.Controls.Add(this.lblTenVaiTro);
            this.pnlVaiTro.Controls.Add(this.lstVaiTro);
            this.pnlVaiTro.Controls.Add(this.lblVaiTro);
            this.pnlVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.pnlVaiTro.Location = new System.Drawing.Point(24, 82);
            this.pnlVaiTro.Name = "pnlVaiTro";
            this.pnlVaiTro.Size = new System.Drawing.Size(260, 540);
            this.pnlVaiTro.TabIndex = 1;
            //
            // btnSuaVaiTro
            //
            this.btnSuaVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnSuaVaiTro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSuaVaiTro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnSuaVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.btnSuaVaiTro.Location = new System.Drawing.Point(96, 450);
            this.btnSuaVaiTro.Name = "btnSuaVaiTro";
            this.btnSuaVaiTro.Size = new System.Drawing.Size(68, 36);
            this.btnSuaVaiTro.TabIndex = 4;
            this.btnSuaVaiTro.Text = "Sửa";
            this.btnSuaVaiTro.UseVisualStyleBackColor = false;
            //
            // btnXoaVaiTro
            //
            this.btnXoaVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.btnXoaVaiTro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaVaiTro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnXoaVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(157)))));
            this.btnXoaVaiTro.Location = new System.Drawing.Point(172, 450);
            this.btnXoaVaiTro.Name = "btnXoaVaiTro";
            this.btnXoaVaiTro.Size = new System.Drawing.Size(68, 36);
            this.btnXoaVaiTro.TabIndex = 5;
            this.btnXoaVaiTro.Text = "Xóa";
            this.btnXoaVaiTro.UseVisualStyleBackColor = false;
            //
            // btnThemVaiTro
            //
            this.btnThemVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnThemVaiTro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemVaiTro.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnThemVaiTro.FlatAppearance.BorderSize = 0;
            this.btnThemVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaiTro.ForeColor = System.Drawing.Color.White;
            this.btnThemVaiTro.Location = new System.Drawing.Point(20, 450);
            this.btnThemVaiTro.Name = "btnThemVaiTro";
            this.btnThemVaiTro.Size = new System.Drawing.Size(68, 36);
            this.btnThemVaiTro.TabIndex = 3;
            this.btnThemVaiTro.Text = "Thêm";
            this.btnThemVaiTro.UseVisualStyleBackColor = false;
            //
            // txtMoTaVaiTro
            //
            this.txtMoTaVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.txtMoTaVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoTaVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtMoTaVaiTro.Location = new System.Drawing.Point(20, 382);
            this.txtMoTaVaiTro.Multiline = true;
            this.txtMoTaVaiTro.Name = "txtMoTaVaiTro";
            this.txtMoTaVaiTro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMoTaVaiTro.Size = new System.Drawing.Size(220, 50);
            this.txtMoTaVaiTro.TabIndex = 2;
            //
            // lblMoTaVaiTro
            //
            this.lblMoTaVaiTro.BackColor = System.Drawing.Color.Transparent;
            this.lblMoTaVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblMoTaVaiTro.Location = new System.Drawing.Point(20, 354);
            this.lblMoTaVaiTro.Name = "lblMoTaVaiTro";
            this.lblMoTaVaiTro.Size = new System.Drawing.Size(220, 25);
            this.lblMoTaVaiTro.TabIndex = 0;
            this.lblMoTaVaiTro.Text = "Mô tả";
            //
            // txtTenVaiTro
            //
            this.txtTenVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.txtTenVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.txtTenVaiTro.Location = new System.Drawing.Point(20, 318);
            this.txtTenVaiTro.Name = "txtTenVaiTro";
            this.txtTenVaiTro.Size = new System.Drawing.Size(220, 30);
            this.txtTenVaiTro.TabIndex = 1;
            //
            // lblTenVaiTro
            //
            this.lblTenVaiTro.BackColor = System.Drawing.Color.Transparent;
            this.lblTenVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblTenVaiTro.Location = new System.Drawing.Point(20, 290);
            this.lblTenVaiTro.Name = "lblTenVaiTro";
            this.lblTenVaiTro.Size = new System.Drawing.Size(220, 25);
            this.lblTenVaiTro.TabIndex = 0;
            this.lblTenVaiTro.Text = "Tên vai trò";
            //
            // lstVaiTro
            //
            this.lstVaiTro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            this.lstVaiTro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstVaiTro.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.lstVaiTro.FormattingEnabled = true;
            this.lstVaiTro.IntegralHeight = false;
            this.lstVaiTro.ItemHeight = 25;
            this.lstVaiTro.Location = new System.Drawing.Point(20, 52);
            this.lstVaiTro.Name = "lstVaiTro";
            this.lstVaiTro.Size = new System.Drawing.Size(220, 220);
            this.lstVaiTro.TabIndex = 0;
            //
            // lblVaiTro
            //
            this.lblVaiTro.BackColor = System.Drawing.Color.Transparent;
            this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.lblVaiTro.Location = new System.Drawing.Point(20, 16);
            this.lblVaiTro.Name = "lblVaiTro";
            this.lblVaiTro.Size = new System.Drawing.Size(220, 28);
            this.lblVaiTro.TabIndex = 0;
            this.lblVaiTro.Text = "Vai trò";
            //
            // pnlPhanQuyen
            //
            this.pnlPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPhanQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.pnlPhanQuyen.Controls.Add(this.btnLuuQuyen);
            this.pnlPhanQuyen.Controls.Add(this.dgvPhanQuyen);
            this.pnlPhanQuyen.Controls.Add(this.lblVaiTroDangChon);
            this.pnlPhanQuyen.Controls.Add(this.lblTieuDePhanQuyen);
            this.pnlPhanQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.pnlPhanQuyen.Location = new System.Drawing.Point(300, 82);
            this.pnlPhanQuyen.Name = "pnlPhanQuyen";
            this.pnlPhanQuyen.Size = new System.Drawing.Size(758, 540);
            this.pnlPhanQuyen.TabIndex = 2;
            //
            // btnLuuQuyen
            //
            this.btnLuuQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuQuyen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            this.btnLuuQuyen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.btnLuuQuyen.FlatAppearance.BorderSize = 0;
            this.btnLuuQuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuQuyen.ForeColor = System.Drawing.Color.White;
            this.btnLuuQuyen.Location = new System.Drawing.Point(578, 480);
            this.btnLuuQuyen.Name = "btnLuuQuyen";
            this.btnLuuQuyen.Size = new System.Drawing.Size(160, 40);
            this.btnLuuQuyen.TabIndex = 3;
            this.btnLuuQuyen.Text = "Lưu quyền";
            this.btnLuuQuyen.UseVisualStyleBackColor = false;
            //
            // dgvPhanQuyen
            //
            this.dgvPhanQuyen.AllowUserToAddRows = false;
            this.dgvPhanQuyen.AllowUserToDeleteRows = false;
            this.dgvPhanQuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhanQuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhanQuyen.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.dgvPhanQuyen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(29)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(211)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhanQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChucNang,
            this.colDuocXem,
            this.colDuocThem,
            this.colDuocSua,
            this.colDuocXoa});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(91)))), ((int)(((byte)(190)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhanQuyen.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhanQuyen.EnableHeadersVisualStyles = false;
            this.dgvPhanQuyen.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.dgvPhanQuyen.Location = new System.Drawing.Point(20, 82);
            this.dgvPhanQuyen.Name = "dgvPhanQuyen";
            this.dgvPhanQuyen.RowHeadersVisible = false;
            this.dgvPhanQuyen.RowHeadersWidth = 51;
            this.dgvPhanQuyen.Size = new System.Drawing.Size(718, 380);
            this.dgvPhanQuyen.TabIndex = 3;
            //
            // colChucNang
            //
            this.colChucNang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colChucNang.FillWeight = 48F;
            this.colChucNang.HeaderText = "Chức năng";
            this.colChucNang.MinimumWidth = 6;
            this.colChucNang.Name = "colChucNang";
            this.colChucNang.ReadOnly = true;
            //
            // colDuocXem
            //
            this.colDuocXem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDuocXem.FillWeight = 13F;
            this.colDuocXem.HeaderText = "Xem";
            this.colDuocXem.MinimumWidth = 6;
            this.colDuocXem.Name = "colDuocXem";
            //
            // colDuocThem
            //
            this.colDuocThem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDuocThem.FillWeight = 13F;
            this.colDuocThem.HeaderText = "Thêm";
            this.colDuocThem.MinimumWidth = 6;
            this.colDuocThem.Name = "colDuocThem";
            //
            // colDuocSua
            //
            this.colDuocSua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDuocSua.FillWeight = 13F;
            this.colDuocSua.HeaderText = "Sửa";
            this.colDuocSua.MinimumWidth = 6;
            this.colDuocSua.Name = "colDuocSua";
            //
            // colDuocXoa
            //
            this.colDuocXoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDuocXoa.FillWeight = 13F;
            this.colDuocXoa.HeaderText = "Xóa";
            this.colDuocXoa.MinimumWidth = 6;
            this.colDuocXoa.Name = "colDuocXoa";
            //
            // lblVaiTroDangChon
            //
            this.lblVaiTroDangChon.BackColor = System.Drawing.Color.Transparent;
            this.lblVaiTroDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(199)))), ((int)(((byte)(220)))));
            this.lblVaiTroDangChon.Location = new System.Drawing.Point(20, 48);
            this.lblVaiTroDangChon.Name = "lblVaiTroDangChon";
            this.lblVaiTroDangChon.Size = new System.Drawing.Size(718, 25);
            this.lblVaiTroDangChon.TabIndex = 1;
            this.lblVaiTroDangChon.Text = "Chọn một vai trò ở danh sách bên trái";
            //
            // lblTieuDePhanQuyen
            //
            this.lblTieuDePhanQuyen.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDePhanQuyen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDePhanQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.lblTieuDePhanQuyen.Location = new System.Drawing.Point(20, 16);
            this.lblTieuDePhanQuyen.Name = "lblTieuDePhanQuyen";
            this.lblTieuDePhanQuyen.Size = new System.Drawing.Size(718, 28);
            this.lblTieuDePhanQuyen.TabIndex = 0;
            this.lblTieuDePhanQuyen.Text = "Quyền theo chức năng";
            //
            // btnQuayLaiMain
            //
            this.btnQuayLaiMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuayLaiMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnQuayLaiMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuayLaiMain.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuayLaiMain.FlatAppearance.BorderSize = 0;
            this.btnQuayLaiMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.btnQuayLaiMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnQuayLaiMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLaiMain.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLaiMain.ForeColor = System.Drawing.Color.White;
            this.btnQuayLaiMain.Location = new System.Drawing.Point(900, 20);
            this.btnQuayLaiMain.Name = "btnQuayLaiMain";
            this.btnQuayLaiMain.Size = new System.Drawing.Size(150, 40);
            this.btnQuayLaiMain.TabIndex = 3;
            this.btnQuayLaiMain.Text = "Quay lại";
            this.btnQuayLaiMain.UseVisualStyleBackColor = false;
            //
            // frmRoleManagement
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(1082, 673);
            this.Controls.Add(this.btnQuayLaiMain);
            this.Controls.Add(this.pnlPhanQuyen);
            this.Controls.Add(this.pnlVaiTro);
            this.Controls.Add(this.lblTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "frmRoleManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "\tVai trò và phân quyền — Quản lý giảng viên";
            this.pnlVaiTro.ResumeLayout(false);
            this.pnlVaiTro.PerformLayout();
            this.pnlPhanQuyen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlVaiTro;
        private System.Windows.Forms.Panel pnlPhanQuyen;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.TextBox txtTenVaiTro;
        private System.Windows.Forms.Label lblTenVaiTro;
        private System.Windows.Forms.ListBox lstVaiTro;
        private System.Windows.Forms.TextBox txtMoTaVaiTro;
        private System.Windows.Forms.Label lblMoTaVaiTro;
        private System.Windows.Forms.Button btnSuaVaiTro;
        private System.Windows.Forms.Button btnXoaVaiTro;
        private System.Windows.Forms.Button btnThemVaiTro;
        private System.Windows.Forms.Label lblTieuDePhanQuyen;
        private System.Windows.Forms.DataGridView dgvPhanQuyen;
        private System.Windows.Forms.Label lblVaiTroDangChon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChucNang;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDuocXem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDuocThem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDuocSua;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDuocXoa;
        private System.Windows.Forms.Button btnLuuQuyen;
        private Button btnQuayLaiMain;
    }
}
