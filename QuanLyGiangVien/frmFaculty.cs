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
            HoangFormHelper.EnableGridBuffering(dgvDanhSach);
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
            HoangFormAccess access = null;
            bool ok = HoangFormHelper.Run(this, () =>
            {
                db?.Dispose();
                db = null;
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmFaculty");
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                var loadedRows = db.KHOAs.Where(x => keyword == "" || x.TenKhoa.Contains(keyword) || (byId && x.MaKhoa == id))
                    .OrderBy(x => x.MaKhoa).ToList();
                var displayRows = loadedRows.Select(x => new { x.MaKhoa, x.TenKhoa, x.Email, x.SoDienThoai, x.TrangThai }).ToList();
                rows = loadedRows;
                HoangFormHelper.BindGrid(dgvDanhSach, displayRows);
                lblKetQua.Text = rows.Count + " kết quả";
            });
            if (!ok)
            {
                db?.Dispose();
                db = null;
                rows.Clear();
                dgvDanhSach.DataSource = null;
                lblKetQua.Text = "Chưa tải được dữ liệu";
            }
            ClearInput();
            loading = false;
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
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["MaKhoa"].Value);
            selected = rows.FirstOrDefault(x => x.MaKhoa == id);
            if (selected == null) return;
            txtMaKhoa.Text = selected.MaKhoa.ToString(); txtTenKhoa.Text = selected.TenKhoa; txtEmail.Text = selected.Email; txtSoDienThoai.Text = selected.SoDienThoai; chkTrangThai.Checked = selected.TrangThai;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmFaculty", adding ? "Them" : "Sua");
                string name = txtTenKhoa.Text.Trim();
                string email = HoangFormHelper.Optional(txtEmail.Text);
                string phone = HoangFormHelper.Optional(txtSoDienThoai.Text);
                HoangFormHelper.Require(name.Length > 0, "Vui lòng nhập tên.");
                HoangFormHelper.CheckEmail(email ?? "", false);
                HoangFormHelper.CheckPhone(phone ?? "");

                if (adding || phone != selected.SoDienThoai)
                {
                    var otherFaculties = db.KHOAs.AsQueryable();
                    if (!adding)
                        otherFaculties = otherFaculties.Where(x => x.MaKhoa != selected.MaKhoa);

                    // Ràng buộc UNIQUE của SoDienThoai chỉ cho một khoa để trống số.
                    bool duplicatePhone = phone == null
                        ? otherFaculties.Any(x => x.SoDienThoai == null)
                        : otherFaculties.Any(x => x.SoDienThoai == phone);
                    HoangFormHelper.Require(!duplicatePhone, phone == null
                        ? "Đã có một khoa chưa nhập số điện thoại. Vui lòng nhập số điện thoại cho khoa này."
                        : "Số điện thoại đã được khoa khác sử dụng.");
                }

                var item = adding ? new KHOA() : selected;
                item.TenKhoa = name;
                item.Email = email;
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
            if (writing) LoadData();
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
            var item = selected;
            if (item == null) { MessageBox.Show(this, "Vui lòng chọn dòng cần xóa."); return; }
            if (!HoangFormHelper.ConfirmDelete(this, item.TenKhoa)) return;
            bool permissionChecked = false;
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmFaculty", "Xoa");
                permissionChecked = true;
                HoangFormHelper.Require(!db.BO_MONs.Any(x => x.MaKhoa == item.MaKhoa), "Khoa còn bộ môn liên kết nên không thể xóa.");
                writing = true;
                db.KHOAs.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            if (writing || !permissionChecked) LoadData();
        }
    }
}

