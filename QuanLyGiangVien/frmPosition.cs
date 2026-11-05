using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmPosition : Form
    {
        private QuanLyGiangVienDataContext db;
        private List<CHUC_VU> rows = new List<CHUC_VU>();
        private CHUC_VU selected;
        private bool loading;
        private int? maNguoiDung;

        public frmPosition()
        {
            InitializeComponent();
            HoangFormHelper.EnableGridBuffering(dgvDanhSach);
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);
        }

        // Constructor mặc định dành cho Designer; khi chạy nhận mã người dùng đã đăng nhập.
        public frmPosition(int maNguoiDung) : this()
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
                access = HoangFormHelper.GetAccess(maNguoiDung, "frmPosition");
                db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString);
                string keyword = txtTimKiem.Text.Trim();
                int id;
                bool byId = int.TryParse(keyword, out id);
                var newRows = db.CHUC_VUs.Where(x => keyword == "" || x.TenChucVu.Contains(keyword) || (byId && x.MaChucVu == id))
                    .OrderBy(x => x.MaChucVu).ToList();
                var displayRows = newRows.Select(x => new { x.MaChucVu, x.TenChucVu }).ToList();
                rows = newRows;
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
            txtMaChucVu.Text = "Tự tăng";
            txtTenChucVu.Clear();
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading) return;
            selected = null;
            if (dgvDanhSach.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvDanhSach.SelectedRows[0].Cells["colMaChucVu"].Value);
            selected = rows.FirstOrDefault(x => x.MaChucVu == id);
            if (selected == null) return;
            txtMaChucVu.Text = selected.MaChucVu.ToString();
            txtTenChucVu.Text = selected.TenChucVu;
        }

        private void Save(bool adding)
        {
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmPosition", adding ? "Them" : "Sua");
                string name = txtTenChucVu.Text.Trim();
                HoangFormHelper.Require(name.Length > 0, "Vui lòng nhập tên chức vụ.");

                var item = adding ? new CHUC_VU() : selected;
                HoangFormHelper.Require(adding || item.TenChucVu != name, "Thông tin chức vụ chưa thay đổi.");

                int currentId = item.MaChucVu;
                HoangFormHelper.Require(!db.CHUC_VUs.Any(x => x.TenChucVu == name && (adding || x.MaChucVu != currentId)),
                    "Tên chức vụ đã tồn tại.");

                writing = true;
                item.TenChucVu = name;
                if (adding) db.CHUC_VUs.InsertOnSubmit(item);
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
                MessageBox.Show(this, "Vui lòng chọn chức vụ cần sửa.", "Thông báo");
                return;
            }

            Save(false);
        }
        private void btnTimKiem_Click(object sender, EventArgs e) { LoadData(); }
        private void btnLamMoi_Click(object sender, EventArgs e) { txtTimKiem.Clear(); LoadData(); }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var item = selected;
            if (item == null)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa.", "Thông báo");
                return;
            }

            if (!HoangFormHelper.ConfirmDelete(this, item.TenChucVu)) return;
            bool permissionChecked = false;
            bool writing = false;
            HoangFormHelper.Run(this, () =>
            {
                HoangFormHelper.RequireAction(maNguoiDung, "frmPosition", "Xoa");
                permissionChecked = true;
                HoangFormHelper.Require(!db.GIANG_VIENs.Any(x => x.MaChucVu == item.MaChucVu),
                    "Dữ liệu đang được sử dụng. Không thể xóa; hãy kiểm tra các bản ghi liên quan.");
                writing = true;
                db.CHUC_VUs.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show(this, "Đã xóa dữ liệu.", "Thông báo");
            });
            if (writing || !permissionChecked) LoadData();
        }
    }
}
