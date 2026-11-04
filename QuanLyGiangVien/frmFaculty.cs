using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmFaculty : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<KHOA> rows = new List<KHOA>();
        private KHOA selected;
        private bool loading;
        private int? maNguoiDung;

        public frmFaculty()
        {
            InitializeComponent();
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);
        }

        // Constructor mặc định dành cho Designer; khi chạy nhận mã người dùng đã đăng nhập.
        public frmFaculty(int maNguoiDung) : this()
        {
            this.maNguoiDung = maNguoiDung;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Designer chỉ hiển thị giao diện, không đọc dữ liệu hoặc kiểm tra quyền.
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            Theme.Apply(this);
            LoadData();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || DesignMode) return;
            loading = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            selected = null;
            rows.Clear();
            dgvDanhSach.DataSource = null;
            HoangFormAccess access = null;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                if (db != null) db.Dispose();
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmFaculty");
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                rows = db.KHOAs.Where(x => keyword == "" || x.TenKhoa.Contains(keyword) || (byId && x.MaKhoa == id))
                    .OrderBy(x => x.MaKhoa).ToList();
                dgvDanhSach.DataSource = rows.Select(x => new { x.MaKhoa, x.TenKhoa, x.Email, x.SoDienThoai, x.TrangThai }).ToList();
                lblKetQua.Text = rows.Count + " kết quả";
            });
            if (!ok) lblKetQua.Text = "Chưa tải được dữ liệu";
            loading = false;
            ClearInput();
            btnThem.Enabled = ok && access.Them;
            btnSua.Enabled = ok && access.Sua;
            btnXoa.Enabled = ok && access.Xoa;
        }

        private void ClearInput()
        {
            selected = null;
            txtMaKhoa.Text = "Tự tăng";
            txtTenKhoa.Clear(); txtEmail.Clear(); txtSoDienThoai.Clear(); chkTrangThai.Checked = true;
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            selected = null;
            if (dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaKhoa"].Value);
            selected = rows.FirstOrDefault(x => x.MaKhoa == id);
            if (selected == null) return;
            txtMaKhoa.Text = selected.MaKhoa.ToString(); txtTenKhoa.Text = selected.TenKhoa; txtEmail.Text = selected.Email; txtSoDienThoai.Text = selected.SoDienThoai; chkTrangThai.Checked = selected.TrangThai;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmFaculty", adding ? "Them" : "Sua");
                HoangFormHelper.Require(txtTenKhoa.Text.Trim().Length > 0, "Vui lòng nhập tên.");
                HoangFormHelper.CheckEmail(txtEmail.Text.Trim(), false);
                HoangFormHelper.CheckPhone(txtSoDienThoai.Text.Trim());
                int currentId = adding ? 0 : selected.MaKhoa;
                string phone = HoangFormHelper.Optional(txtSoDienThoai.Text);
                // SQL Server UNIQUE hiện tại chỉ cho một khoa có SĐT NULL.
                bool duplicatePhone = phone == null
                    ? db.KHOAs.Any(x => x.MaKhoa != currentId && x.SoDienThoai == null)
                    : db.KHOAs.Any(x => x.MaKhoa != currentId && x.SoDienThoai == phone);
                HoangFormHelper.Require(!duplicatePhone, phone == null
                    ? "Đã có một khoa chưa nhập số điện thoại. Theo cấu hình dữ liệu hiện tại, vui lòng nhập số điện thoại cho khoa này."
                    : "Số điện thoại đã được khoa khác sử dụng.");
                var item = adding ? new KHOA() : selected;
                item.TenKhoa = txtTenKhoa.Text.Trim();
                item.Email = HoangFormHelper.Optional(txtEmail.Text);
                item.SoDienThoai = phone;
                item.TrangThai = chkTrangThai.Checked;

                if (!adding)
                    HoangFormHelper.Require(db.GetChangeSet().Updates.Count > 0, "Thông tin khoa chưa thay đổi.");

                writing = true;
                if (adding) db.KHOAs.InsertOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã lưu dữ liệu.", "Thông báo");
            });
            // Giữ dữ liệu nhập khi kiểm tra sai; bỏ entity chờ lưu nếu SubmitChanges lỗi.
            if (ok || writing) LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e) { Save(true); }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selected == null)
            {
                MessageBox.Show(this, "Vui lòng chọn khoa cần sửa.", "Thông báo");
                return;
            }

            Save(false);
        }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(); }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LoadData(); }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!HoangFormHelper.Run(this, () => HoangFormHelper.RequireAction(maNguoiDung, "frmFaculty", "Xoa"))) return;
            if (selected == null) { MessageBox.Show(this, "Vui lòng chọn dòng cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, selected.TenKhoa)) return;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmFaculty", "Xoa");
                HoangFormHelper.Require(!(db.BO_MONs.Any(x => x.MaKhoa == selected.MaKhoa)), "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                db.KHOAs.DeleteOnSubmit(selected);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            LoadData();
        }
    }
}
