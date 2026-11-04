using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    public partial class frmTeachingWorkload : Form
    {
        internal const int DinhMucTietMoiHocKy = 300;
        private readonly Session session;
        private int? lecturerScope;
        private bool dangNapBoLoc;

        public frmTeachingWorkload()
        {
            InitializeComponent();
            Load += frmTeachingWorkload_Load;
        }

        internal frmTeachingWorkload(Session session) : this()
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
        }

        private void frmTeachingWorkload_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            dangNapBoLoc = true;
            try
            {
                using (var db = Session.Open())
                {
                    lecturerScope = GetViewScope(db);
                    cboNamHoc.DataSource = db.NAM_HOCs
                        .Where(x => x.TrangThai)
                        .OrderByDescending(x => x.TuNam)
                        .Select(x => new { x.MaNamHoc, x.TenNamHoc })
                        .ToList();
                    cboNamHoc.DisplayMember = "TenNamHoc";
                    cboNamHoc.ValueMember = "MaNamHoc";

                    cboHocKy.DataSource = db.HOC_Kies
                        .OrderBy(x => x.MaHocKy)
                        .Select(x => new { x.MaHocKy, x.TenHocKy })
                        .ToList();
                    cboHocKy.DisplayMember = "TenHocKy";
                    cboHocKy.ValueMember = "MaHocKy";

                    var khoaItems = db.KHOAs
                        .Where(x => x.TrangThai)
                        .Where(x => !lecturerScope.HasValue ||
                            x.BO_MONs.Any(b => b.GIANG_VIENs.Any(g => g.MaGV == lecturerScope)))
                        .OrderBy(x => x.TenKhoa)
                        .Select(x => new { x.MaKhoa, x.TenKhoa })
                        .ToList();
                    var filters = new List<KhoaFilterItem>
                    {
                        new KhoaFilterItem { MaKhoa = 0, TenKhoa = "Tất cả khoa" }
                    };
                    filters.AddRange(khoaItems.Select(x => new KhoaFilterItem
                    {
                        MaKhoa = x.MaKhoa,
                        TenKhoa = x.TenKhoa
                    }));
                    cboKhoa.DataSource = filters;
                    cboKhoa.DisplayMember = "TenKhoa";
                    cboKhoa.ValueMember = "MaKhoa";
                }

                if (cboNamHoc.Items.Count > 0) cboNamHoc.SelectedIndex = 0;
                if (cboHocKy.Items.Count > 0) cboHocKy.SelectedIndex = 0;
                if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            }
            catch (UserMessage ex)
            {
                CloseForAccessError(ex);
                return;
            }
            catch (Exception ex)
            {
                HienThiLoi("Không tải được danh sách bộ lọc. Hãy kiểm tra SQL Server và chuỗi kết nối trong App.config.", ex);
            }
            finally
            {
                dangNapBoLoc = false;
            }

            LoadWorkload();
        }

        private int? GetViewScope(QuanLyGiangVienDataContext db)
        {
            if (session == null) throw new UserMessage("Bạn chưa đăng nhập.");
            var user = session.Current(db);
            if (!Session.Allows(db, user.MaVaiTro, nameof(frmTeachingWorkload), ActionRight.View))
                throw new UserMessage("Bạn không có quyền xem khối lượng giảng dạy.");
            if (!HoangFormHelper.IsLecturer(user.VAI_TRO.TenVaiTro)) return null;
            return user.MaGV ?? throw new UserMessage("Tài khoản chưa liên kết với hồ sơ giảng viên.");
        }

        private void CloseForAccessError(UserMessage ex)
        {
            MessageBox.Show(this, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        internal static IQueryable<PHAN_CONG_GIANG_DAY> ActiveAssignments(
            QuanLyGiangVienDataContext db, int maNamHoc, int maHocKy)
        {
            return db.PHAN_CONG_GIANG_DAYs.Where(x => x.LOP_HOC_PHAN.TrangThai &&
                x.LOP_HOC_PHAN.MaNamHoc == maNamHoc && x.LOP_HOC_PHAN.MaHocKy == maHocKy &&
                x.GIANG_VIEN.TrangThai);
        }

        private void LoadWorkload()
        {
            dgvTeachingWorkload.Rows.Clear();
            if (cboNamHoc.SelectedValue == null || cboHocKy.SelectedValue == null) return;

            int maNamHoc;
            int maHocKy;
            if (!int.TryParse(Convert.ToString(cboNamHoc.SelectedValue), out maNamHoc) ||
                !int.TryParse(Convert.ToString(cboHocKy.SelectedValue), out maHocKy)) return;

            int maKhoa = 0;
            var khoa = cboKhoa.SelectedItem as KhoaFilterItem;
            if (khoa != null) maKhoa = khoa.MaKhoa;

            try
            {
                using (var db = Session.Open())
                {
                    if (GetViewScope(db) != lecturerScope)
                        throw new UserMessage("Phạm vi dữ liệu đã thay đổi. Hãy mở lại chức năng.");

                    // Đọc danh sách giảng viên trước để vẫn hiện người có tổng số tiết bằng 0.
                    var lecturers = db.GIANG_VIENs
                        .Where(x => x.TrangThai && (maKhoa == 0 || x.BO_MON.MaKhoa == maKhoa))
                        .Where(x => !lecturerScope.HasValue || x.MaGV == lecturerScope)
                        .OrderBy(x => x.HoTen)
                        .Select(x => new
                        {
                            x.MaGV,
                            x.HoTen,
                            TenKhoa = x.BO_MON.KHOA.TenKhoa
                        })
                        .ToList();

                    var assignments = ActiveAssignments(db, maNamHoc, maHocKy)
                        .Where(x => (maKhoa == 0 || x.GIANG_VIEN.BO_MON.MaKhoa == maKhoa) &&
                                    (!lecturerScope.HasValue || x.MaGV == lecturerScope))
                        .Select(x => new { x.MaGV, x.SoTiet })
                        .ToList();

                    var totals = assignments
                        .GroupBy(x => x.MaGV)
                        .ToDictionary(g => g.Key, g => g.Sum(x => x.SoTiet));

                    foreach (var lecturer in lecturers)
                    {
                        int tongTiet;
                        if (!totals.TryGetValue(lecturer.MaGV, out tongTiet)) tongTiet = 0;

                        string trangThai = tongTiet > DinhMucTietMoiHocKy ? "Vượt định mức"
                            : tongTiet < DinhMucTietMoiHocKy ? "Chưa đủ định mức" : "Đạt định mức";

                        dgvTeachingWorkload.Rows.Add(
                            lecturer.MaGV,
                            lecturer.HoTen,
                            lecturer.TenKhoa,
                            tongTiet,
                            DinhMucTietMoiHocKy,
                            trangThai);
                    }
                }
            }
            catch (UserMessage ex) { CloseForAccessError(ex); }
            catch (Exception ex)
            {
                HienThiLoi("Không tính được khối lượng giảng dạy.", ex);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadWorkload();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dangNapBoLoc = true;
            if (cboNamHoc.Items.Count > 0) cboNamHoc.SelectedIndex = 0;
            if (cboHocKy.Items.Count > 0) cboHocKy.SelectedIndex = 0;
            if (cboKhoa.Items.Count > 0) cboKhoa.SelectedIndex = 0;
            dangNapBoLoc = false;
            LoadWorkload();
        }

        private void cboNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNapBoLoc) LoadWorkload();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNapBoLoc) LoadWorkload();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNapBoLoc) LoadWorkload();
        }

        private static void HienThiLoi(string thongBao, Exception ex)
        {
            MessageBox.Show(thongBao + "\n\nChi tiết: " + ex.Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Giữ các handler click do WinForms Designer tham chiếu.
        private void dgvTeachingWorkload_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblNamHoc_Click(object sender, EventArgs e) { }
        private void lblHocKy_Click(object sender, EventArgs e) { }

        private sealed class KhoaFilterItem
        {
            public int MaKhoa { get; set; }
            public string TenKhoa { get; set; }
        }

        private void dgvTeachingWorkload_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
