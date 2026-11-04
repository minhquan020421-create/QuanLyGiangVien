using System;
using System.Data.Linq;
using System.Net.Mail;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyGiangVien
{
    internal sealed class HoangFormAccess
    {
        public bool Them { get; set; }
        public bool Sua { get; set; }
        public bool Xoa { get; set; }
        public bool ChiXemCaNhan { get; set; }
        public int? MaGV { get; set; }
    }

    internal static class HoangFormHelper
    {
        internal static void KeepContentScrollable(Panel viewport, Control content)
        {
            // MinimumSize của control co giãn theo DPI, còn AutoScrollMinSize thì không.
            viewport.Layout += (sender, e) =>
            {
                var minimum = content.MinimumSize + viewport.Padding.Size;
                if (viewport.AutoScrollMinSize != minimum)
                    viewport.AutoScrollMinSize = minimum;
            };
            viewport.PerformLayout();
        }

        internal static bool IsLecturer(string roleName)
        {
            return string.Equals(roleName, "Giảng viên", StringComparison.OrdinalIgnoreCase);
        }

        // Chỉ đọc bảng quyền của nhóm; mã người dùng do phần đăng nhập của Hào truyền vào.
        public static HoangFormAccess GetAccess(int? userId, string formName)
        {
            Require(userId.HasValue && userId.Value > 0,
                "Chưa nhận được người dùng đã đăng nhập. Hãy mở chức năng từ màn hình chính.");
            using (var context = new QuanLyGiangVienDataContext())
            {
                var user = context.NGUOI_DUNGs.Where(x => x.MaNguoiDung == userId.Value && x.TrangThai)
                    .Select(x => new { x.MaVaiTro, x.MaGV, TenVaiTro = x.VAI_TRO.TenVaiTro }).SingleOrDefault();
                Require(user != null, "Tài khoản không tồn tại hoặc đã bị khóa.");
                var function = context.CHUC_NANGs.SingleOrDefault(x => x.MaForm == formName);
                Require(function != null, "Chức năng này chưa được cấu hình trong hệ thống phân quyền: " + formName);
                var permission = context.PHAN_QUYENs.SingleOrDefault(x => x.MaVaiTro == user.MaVaiTro && x.MaChucNang == function.MaChucNang);
                Require(permission != null && permission.DuocXem, "Bạn không có quyền xem chức năng này.");
                return new HoangFormAccess
                {
                    Them = permission.DuocThem,
                    Sua = permission.DuocSua,
                    Xoa = permission.DuocXoa,
                    ChiXemCaNhan = IsLecturer(user.TenVaiTro),
                    MaGV = user.MaGV
                };
            }
        }

        public static HoangFormAccess RequireAction(int? userId, string formName, string action)
        {
            // Đọc lại quyền mỗi lần ghi để không dựa riêng vào trạng thái Enabled của nút.
            var access = GetAccess(userId, formName);
            bool allowed = action == "Them" ? access.Them : action == "Sua" ? access.Sua : action == "Xoa" && access.Xoa;
            Require(allowed, "Bạn không có quyền thực hiện thao tác này.");
            return access;
        }

        public static bool Run(IWin32Window owner, Action action)
        {
            try { action(); return true; }
            catch (ChangeConflictException)
            {
                MessageBox.Show(owner, "Dữ liệu đã được người khác sửa hoặc xóa. Hãy tải lại danh sách trước khi thao tác tiếp.", "Xung đột dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(owner, ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, "Không thực hiện được thao tác. Kiểm tra kết nối, dữ liệu trùng và ràng buộc liên quan.\nChi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        public static void Require(bool condition, string message)
        {
            if (!condition) throw new InvalidOperationException(message);
        }

        public static void CheckEmail(string text, bool required)
        {
            Require(!required || text.Length > 0, "Vui lòng nhập email.");
            if (text.Length == 0) return;
            try
            {
                var address = new MailAddress(text);
                Require(address.Address == text && text.Contains("."), "Email không đúng định dạng.");
            }
            catch (FormatException) { throw new InvalidOperationException("Email không đúng định dạng."); }
        }

        public static void CheckPhone(string text)
        {
            if (text.Length == 0) return;
            int digits = 0;
            foreach (char c in text)
            {
                Require(char.IsDigit(c) || c == '+' || c == ' ' || c == '-' || c == '(' || c == ')', "Số điện thoại không hợp lệ.");
                if (char.IsDigit(c)) digits++;
            }
            Require(digits >= 8 && digits <= 15, "Số điện thoại cần từ 8 đến 15 chữ số.");
        }

        public static int? SelectedId(ComboBox combo)
        {
            return combo.SelectedValue is int ? (int?)combo.SelectedValue : null;
        }

        public static bool ConfirmDelete(IWin32Window owner, string name)
        {
            return MessageBox.Show(owner, "Xóa \"" + name + "\"? Thao tác này xóa dữ liệu khỏi cơ sở dữ liệu.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static string Optional(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
    }
}
