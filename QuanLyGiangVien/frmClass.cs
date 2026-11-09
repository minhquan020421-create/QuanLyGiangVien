using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    /// <summary>
    /// Quản lý lớp học phần: nạp danh mục tham chiếu, lọc danh sách lớp,
    /// kiểm tra quyền và thực hiện thêm/sửa/xóa qua LINQ to SQL.
    /// </summary>
    public partial class frmClass : Form
    {
        // Quyền lớp học phần hiện được lưu chung dưới mã chức năng phân công giảng dạy.
        private const string PermissionForm = nameof(frmTeachingAssignment);
        private readonly Session session;
        // Chặn sự kiện chọn dòng trong lúc đang bind dữ liệu hoặc đặt lại form.
        private bool loading;
        // ID lớp đang chọn; null nghĩa là thao tác sửa/xóa chưa có bản ghi đích.
        private int? selectedId;

        // DTO giữ đúng các giá trị cần hiện trên lưới, không bind entity LINQ trực tiếp.
        private sealed class ClassRow
        {
            public int MaLopHP { get; set; }
            // Các khóa ngoại ẩn trên lưới để chọn lại đúng ComboBox mà không truy vấn SQL lần nữa.
            public int MaHocPhan { get; set; }
            public int MaNamHoc { get; set; }
            public int MaHocKy { get; set; }
            public string TenLop { get; set; }
            public string HocPhan { get; set; }
            public string BoMon { get; set; }
            public string NamHoc { get; set; }
            public string HocKy { get; set; }
            public int SoLuongSinhVien { get; set; }
            public string TrangThai { get; set; }
        }

        public frmClass()
        {
            InitializeComponent();
            // Tối ưu vẽ lưới và giữ nội dung form cuộn được khi kích thước cửa sổ nhỏ.
            HoangFormHelper.EnableGridBuffering(dgvDanhSach);
            HoangFormHelper.KeepContentScrollable(pnlCuon, layoutChinh);

            // Thêm mới không phụ thuộc dòng đang chọn; sửa/xóa dùng selectedId.
            btnQuayLai.Click += (s, e) => Close();
            btnThem.Click += (s, e) => Save(true);
            btnSua.Click += (s, e) => Save(false);
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += (s, e) => { txtTimKiem.Clear(); LoadData(); };
            btnTimKiem.Click += (s, e) => LoadData();
            txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;
                e.SuppressKeyPress = true;
                LoadData();
            };
            dgvDanhSach.SelectionChanged += dgvDanhSach_SelectionChanged;
            Load += frmClass_Load;
        }

        internal frmClass(Session current) : this()
        {
            // Form được mở từ frmMain nên nhận phiên để kiểm tra quyền mỗi lần ghi dữ liệu.
            session = current ?? throw new ArgumentNullException(nameof(current));
        }

        // Khi chạy thật mới áp dụng theme và đọc SQL; Designer chỉ cần dựng giao diện.
        private void frmClass_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) return;
            Theme.Apply(this);
            LoadData();
        }

        private void LoadData()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode) return;
            loading = true;
            selectedId = null;
            SetActions(false, false, false);

            try
            {
                using (var db = Session.Open())
                {
                    // Xác thực phiên và quyền xem trước khi truy vấn danh sách.
                    var user = GetCurrentUser(db);
                    RequirePermission(db, user.MaVaiTro, ActionRight.View, "Bạn không có quyền xem lớp học phần.");

                    // Nạp các danh mục dùng làm khóa ngoại trên bảng LOP_HOC_PHAN.
                    var years = db.NAM_HOCs.Where(x => x.TrangThai)
                        .OrderByDescending(x => x.TuNam)
                        .Select(x => new { x.MaNamHoc, Ten = x.TenNamHoc }).ToList();
                    var terms = db.HOC_Kies.OrderBy(x => x.MaHocKy)
                        .Select(x => new { x.MaHocKy, Ten = x.TenHocKy }).ToList();
                    var courses = db.HOC_PHANs.Where(x => x.TrangThai)
                        .OrderBy(x => x.TenHocPhan)
                        .Select(x => new { x.MaHocPhan, Ten = x.TenHocPhan + " | " + x.BO_MON.TenBoMon }).ToList();

                    BindCombo(cboNamHoc, years, "Ten", "MaNamHoc");
                    BindCombo(cboHocKy, terms, "Ten", "MaHocKy");
                    BindCombo(cboHocPhan, courses, "Ten", "MaHocPhan");

                    // ID số được tìm như mã lớp; chuỗi khác tìm theo tên lớp hoặc tên học phần.
                    string keyword = txtTimKiem.Text.Trim();
                    int classId;
                    bool hasClassId = int.TryParse(keyword, out classId);
                    List<ClassRow> rows = db.LOP_HOC_PHANs
                        .Where(x => keyword.Length == 0 || x.TenLop.Contains(keyword) ||
                            x.HOC_PHAN.TenHocPhan.Contains(keyword) || (hasClassId && x.MaLopHP == classId))
                        .OrderByDescending(x => x.MaLopHP)
                        .Select(x => new ClassRow
                        {
                            MaLopHP = x.MaLopHP,
                            MaHocPhan = x.MaHocPhan,
                            MaNamHoc = x.MaNamHoc,
                            MaHocKy = x.MaHocKy,
                            TenLop = x.TenLop,
                            HocPhan = x.HOC_PHAN.TenHocPhan,
                            BoMon = x.HOC_PHAN.BO_MON.TenBoMon,
                            NamHoc = x.NAM_HOC.TenNamHoc,
                            HocKy = x.HOC_KY.TenHocKy,
                            SoLuongSinhVien = x.SoLuongSinhVien,
                            TrangThai = x.TrangThai ? "Đang mở" : "Đã đóng"
                        }).ToList();

                    // Ngắt nguồn cũ để lưới tự tạo lại cột theo DTO ClassRow.
                    dgvDanhSach.DataSource = null;
                    dgvDanhSach.DataSource = rows;
                    dgvDanhSach.Columns[nameof(ClassRow.MaHocPhan)].Visible = false;
                    dgvDanhSach.Columns[nameof(ClassRow.MaNamHoc)].Visible = false;
                    dgvDanhSach.Columns[nameof(ClassRow.MaHocKy)].Visible = false;
                    lblKetQua.Text = rows.Count + " kết quả";
                    SetActions(
                        Session.Allows(db, user.MaVaiTro, PermissionForm, ActionRight.Add),
                        Session.Allows(db, user.MaVaiTro, PermissionForm, ActionRight.Edit),
                        Session.Allows(db, user.MaVaiTro, PermissionForm, ActionRight.Delete));
                }

                ResetInputs();
            }
            catch (Exception ex)
            {
                dgvDanhSach.DataSource = null;
                lblKetQua.Text = "Chưa tải được dữ liệu";
                ShowFailure("Không tải được dữ liệu lớp học phần.", ex);
            }
            finally
            {
                loading = false;
            }
        }

        private static void BindCombo<T>(ComboBox combo, IList<T> data, string display, string value)
        {
            // DisplayMember là chữ người dùng nhìn thấy, ValueMember là ID gửi vào SQL.
            combo.DataSource = null;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            combo.DataSource = data;
            if (combo.Items.Count > 0) combo.SelectedIndex = 0;
        }

        private void ResetInputs()
        {
            // Xóa trạng thái chọn để thao tác tiếp theo được hiểu là thêm mới.
            selectedId = null;
            txtMaLopHP.Text = "Tự tăng";
            txtTenLop.Clear();
            numSoLuongSinhVien.Value = numSoLuongSinhVien.Minimum;
            chkTrangThai.Checked = true;
            if (cboHocPhan.Items.Count > 0) cboHocPhan.SelectedIndex = 0;
            if (cboNamHoc.Items.Count > 0) cboNamHoc.SelectedIndex = 0;
            if (cboHocKy.Items.Count > 0) cboHocKy.SelectedIndex = 0;
            dgvDanhSach.ClearSelection();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (loading || dgvDanhSach.SelectedRows.Count == 0) return;
            // Đọc đối tượng đã bind thay vì phụ thuộc tên cột do DataGridView sinh.
            var row = dgvDanhSach.SelectedRows[0].DataBoundItem as ClassRow;
            if (row == null) return;

            loading = true;
            try
            {
                selectedId = row.MaLopHP;
                txtMaLopHP.Text = row.MaLopHP.ToString();
                txtTenLop.Text = row.TenLop;
                numSoLuongSinhVien.Value = Math.Max(numSoLuongSinhVien.Minimum,
                    Math.Min(numSoLuongSinhVien.Maximum, row.SoLuongSinhVien));
                chkTrangThai.Checked = row.TrangThai == "Đang mở";
                // Lấy ID từ DTO đã bind, không mở DataContext thứ hai cho mỗi lần click.
                SelectComboValue(cboHocPhan, row.MaHocPhan);
                SelectComboValue(cboNamHoc, row.MaNamHoc);
                SelectComboValue(cboHocKy, row.MaHocKy);
            }
            catch (Exception ex)
            {
                selectedId = null;
                ShowFailure("Không đọc được lớp học phần đang chọn.", ex);
            }
            finally
            {
                loading = false;
            }
        }

        private static void SelectComboValue(ComboBox combo, int value)
        {
            if (combo.DataSource == null || combo.Items.Count == 0)
            {
                combo.SelectedIndex = -1;
                return;
            }
            combo.SelectedValue = value;
        }

        private void Save(bool adding)
        {
            // Chụp ID trước khi ghi; chỉ nhánh sửa mới bắt buộc phải có ID.
            int? idToEdit = selectedId;
            if (!adding && !idToEdit.HasValue)
            {
                MessageBox.Show(this, "Vui lòng chọn lớp học phần cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (var db = Session.Open())
                {
                    var user = GetCurrentUser(db);
                    RequirePermission(db, user.MaVaiTro, adding ? ActionRight.Add : ActionRight.Edit,
                        "Bạn không có quyền thực hiện thao tác này.");

                    string name = txtTenLop.Text.Trim();
                    if (name.Length == 0) throw new UserMessage("Vui lòng nhập tên lớp.");
                    if (name.Length > 100) throw new UserMessage("Tên lớp không được vượt quá 100 ký tự.");

                    // Chuyển lựa chọn UI thành ID và kiểm tra dữ liệu danh mục vẫn hợp lệ.
                    int courseId = ReadSelectedId(cboHocPhan, "học phần");
                    int yearId = ReadSelectedId(cboNamHoc, "năm học");
                    int termId = ReadSelectedId(cboHocKy, "học kỳ");
                    int studentCount = Decimal.ToInt32(numSoLuongSinhVien.Value);

                    if (!db.HOC_PHANs.Any(x => x.MaHocPhan == courseId && x.TrangThai))
                        throw new UserMessage("Học phần đã chọn không còn hoạt động. Hãy tải lại danh sách.");
                    if (!db.NAM_HOCs.Any(x => x.MaNamHoc == yearId && x.TrangThai))
                        throw new UserMessage("Năm học đã chọn không còn hoạt động. Hãy tải lại danh sách.");
                    if (!db.HOC_Kies.Any(x => x.MaHocKy == termId))
                        throw new UserMessage("Học kỳ đã chọn không còn tồn tại. Hãy tải lại danh sách.");

                    // Tách truy vấn thêm/sửa để không đọc selectedId.Value khi thêm mới (selectedId=null).
                    bool duplicate = adding
                        ? db.LOP_HOC_PHANs.Any(x => x.MaHocPhan == courseId &&
                            x.MaNamHoc == yearId && x.MaHocKy == termId && x.TenLop == name)
                        : db.LOP_HOC_PHANs.Any(x => x.MaHocPhan == courseId &&
                            x.MaNamHoc == yearId && x.MaHocKy == termId && x.TenLop == name &&
                            x.MaLopHP != idToEdit.Value);
                    if (duplicate)
                        throw new UserMessage("Tên lớp này đã tồn tại cho học phần, năm học và học kỳ đã chọn.");

                    // Tạo entity mới hoặc tải entity cần sửa, sau đó gán dữ liệu và SubmitChanges.
                    LOP_HOC_PHAN item;
                    if (adding)
                    {
                        item = new LOP_HOC_PHAN();
                        db.LOP_HOC_PHANs.InsertOnSubmit(item);
                    }
                    else
                    {
                        item = db.LOP_HOC_PHANs.SingleOrDefault(x => x.MaLopHP == idToEdit.Value);
                        if (item == null) throw new UserMessage("Lớp học phần không còn tồn tại. Hãy tải lại danh sách.");
                    }

                    item.TenLop = name;
                    item.MaHocPhan = courseId;
                    item.MaNamHoc = yearId;
                    item.MaHocKy = termId;
                    item.SoLuongSinhVien = studentCount;
                    item.TrangThai = chkTrangThai.Checked;
                    db.SubmitChanges();
                }

                MessageBox.Show(this, adding ? "Đã thêm lớp học phần." : "Đã cập nhật lớp học phần.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                ShowFailure("Không thể " + (adding ? "thêm" : "cập nhật") + " lớp học phần.", ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Không xóa nếu chưa chọn dòng; lớp đã có phân công phải gỡ liên kết trước.
            int? id = selectedId;
            if (!id.HasValue)
            {
                MessageBox.Show(this, "Vui lòng chọn lớp học phần cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Ui.Confirm(this, "Bạn có chắc chắn muốn xóa lớp học phần này?")) return;

            try
            {
                using (var db = Session.Open())
                {
                    var user = GetCurrentUser(db);
                    RequirePermission(db, user.MaVaiTro, ActionRight.Delete, "Bạn không có quyền xóa lớp học phần.");
                    var item = db.LOP_HOC_PHANs.SingleOrDefault(x => x.MaLopHP == id.Value);
                    if (item == null) throw new UserMessage("Lớp học phần không còn tồn tại.");
                    if (db.PHAN_CONG_GIANG_DAYs.Any(x => x.MaLopHP == id.Value))
                        throw new UserMessage("Lớp đã có phân công giảng dạy nên không thể xóa. Hãy bỏ phân công trước hoặc đóng lớp.");
                    db.LOP_HOC_PHANs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                }
                MessageBox.Show(this, "Đã xóa lớp học phần.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex) { ShowFailure("Không thể xóa lớp học phần.", ex); }
        }

        private NGUOI_DUNG GetCurrentUser(QuanLyGiangVienDataContext db)
        {
            // Kiểm tra lại trạng thái tài khoản trong DB, không tin vào phiên UI cũ.
            if (session == null) throw new UserMessage("Phiên đăng nhập không hợp lệ. Hãy mở form từ màn hình chính.");
            return session.Current(db);
        }

        private static void RequirePermission(QuanLyGiangVienDataContext db, int role, ActionRight action, string message)
        {
            // Dùng quyền trong bảng PHAN_QUYEN, không chỉ dựa vào trạng thái Enabled của nút.
            if (!Session.Allows(db, role, PermissionForm, action)) throw new UserMessage(message);
        }

        private static int ReadSelectedId(ComboBox combo, string label)
        {
            // ComboBox có thể rỗng hoặc chưa bind; kiểm tra trước khi chuyển SelectedValue sang int.
            if (combo.SelectedIndex < 0 || combo.SelectedValue == null || combo.SelectedValue == DBNull.Value)
                throw new UserMessage("Vui lòng chọn " + label + ".");
            int value;
            if (!int.TryParse(Convert.ToString(combo.SelectedValue), out value) || value <= 0)
                throw new UserMessage("Giá trị " + label + " không hợp lệ. Hãy tải lại danh sách.");
            return value;
        }

        private void SetActions(bool add, bool edit, bool delete)
        {
            // Giao diện chỉ phản ánh quyền; Save/Delete vẫn kiểm tra lại quyền từ SQL.
            btnThem.Enabled = add;
            btnSua.Enabled = edit;
            btnXoa.Enabled = delete;
        }

        private void ShowFailure(string heading, Exception error)
        {
            // Ghép InnerException để lộ nguyên nhân SQL/LINQ thường nằm ở exception bên trong.
            var message = new StringBuilder(heading);
            var current = error;
            while (current != null)
            {
                message.AppendLine();
                message.Append(current.GetType().Name).Append(": ").Append(current.Message);
                current = current.InnerException;
            }

            // Chỉ hiện lỗi trong hộp thoại, không tạo file log phụ cạnh chương trình.
            MessageBox.Show(this, message.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
