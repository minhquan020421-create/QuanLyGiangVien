using System;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;

namespace QuanLyGiangVien
{
    internal static class CatalogPermissionUpgrade
    {
        private const string UpgradeAction = "Nâng cấp dữ liệu";
        private const string Version = "CatalogPermissions.v1";
        private static readonly string[] Forms = { "frmDegree", "frmPosition", "frmSpecialization" };
        private static readonly string[] Titles = { "Quản lý học vị", "Quản lý chức vụ", "Quản lý chuyên môn" };

        internal static void Ensure(int actor)
        {
            for (int attempt = 0; attempt < 3; attempt++)
            {
                try
                {
                    Upgrade(actor);
                    return;
                }
                catch (SqlException error)
                {
                    Diagnostics.SqlFailure(error);
                    // Hai máy có thể cùng nâng cấp. Lần thử lại phải dùng DataContext mới.
                    if (error.Number == 1205 || error.Number == 2601 || error.Number == 2627)
                    {
                        if (attempt < 2) continue;
                        throw new UserMessage("Database đang được cập nhật quyền danh mục. Vui lòng đăng nhập lại.");
                    }
                    if (error.Number == 229 || error.Number == 230)
                        throw new UserMessage("Tài khoản kết nối SQL Server chưa có quyền đọc/ghi CHUC_NANG, PHAN_QUYEN và NHAT_KY_HE_THONG để nâng cấp quyền danh mục.");
                    if (error.Number == 208 || error.Number == 207)
                        throw new UserMessage("Database đang kết nối chưa đúng cấu trúc dự án. Hãy kiểm tra database trong App.config.");
                    throw new UserMessage("Chưa nâng cấp được quyền danh mục trên database đang cấu hình. Vui lòng kiểm tra kết nối rồi đăng nhập lại. Mã SQL: " + error.Number);
                }
                catch (TransactionException)
                {
                    throw new UserMessage("Giao dịch nâng cấp quyền danh mục chưa hoàn tất. Dữ liệu chưa được ghi nhận; vui lòng đăng nhập lại.");
                }
            }
        }

        private static void Upgrade(int actor)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable,
                Timeout = TimeSpan.FromSeconds(30)
            };
            using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            using (var db = new QuanLyGiangVienDataContext(DatabaseConnection.CurrentConnectionString))
            {
                db.CommandTimeout = 15;
                // Nhật ký đã có trong DBML. Giữ dấu phiên bản để không ép lại quyền mỗi lần mở app.
                if (db.NHAT_KY_HE_THONGs.Any(x => x.HanhDong == UpgradeAction && x.NoiDung == Version))
                {
                    transaction.Complete();
                    return;
                }

                var adminRole = db.VAI_TROs.SingleOrDefault(x => x.TenVaiTro == "Quản trị viên");
                if (adminRole == null)
                    throw new UserMessage("Database đang kết nối thiếu vai trò Quản trị viên của dự án. Hãy kiểm tra database trong App.config.");

                var functions = db.CHUC_NANGs.Where(x => Forms.Contains(x.MaForm)).ToList();
                var permissions = db.PHAN_QUYENs.Where(x => x.MaVaiTro == adminRole.MaVaiTro &&
                    Forms.Contains(x.CHUC_NANG.MaForm)).ToList();
                for (int i = 0; i < Forms.Length; i++)
                {
                    var function = functions.SingleOrDefault(x => x.MaForm == Forms[i]);
                    if (function == null)
                    {
                        function = new CHUC_NANG { MaForm = Forms[i], TenChucNang = Titles[i] };
                        db.CHUC_NANGs.InsertOnSubmit(function);
                    }

                    var permission = permissions.SingleOrDefault(x => x.MaChucNang == function.MaChucNang);
                    if (permission == null)
                    {
                        // Gán liên kết để LINQ to SQL tự lấy mã chức năng mới trước khi thêm quyền.
                        permission = new PHAN_QUYEN { MaVaiTro = adminRole.MaVaiTro, CHUC_NANG = function };
                        db.PHAN_QUYENs.InsertOnSubmit(permission);
                    }
                    permission.DuocXem = permission.DuocThem = permission.DuocSua = permission.DuocXoa = true;
                }

                db.NHAT_KY_HE_THONGs.InsertOnSubmit(Session.Log(actor, UpgradeAction, Version));
                db.SubmitChanges();
                // Quyền và dấu phiên bản cùng được commit; có lỗi thì toàn bộ được rollback.
                transaction.Complete();
            }
        }
    }
}
