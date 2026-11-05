using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using QuanLyGiangVien;

namespace QuanLyGiangVien
{
    internal sealed class Choice
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public override string ToString() { return Title; }
    }

    internal sealed class AccountRow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RecoveryEmail { get; set; }
        public string Lecturer { get; set; }
        public int? LecturerId { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
        public string Status { get { return Active ? "Hoạt động" : "Đã khóa"; } }
    }

    internal sealed class RoleInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public override string ToString() { return Name; }
    }

    internal sealed class GrantRow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        internal int Mask { get { return (View ? 1 : 0) | (Add ? 2 : 0) | (Edit ? 4 : 0) | (Delete ? 8 : 0); } }
    }

    internal sealed class AccountService
    {
        internal const string Accounts = "frmUserManagement";
        internal const string Roles = "frmRoleManagement";
        private readonly Session session;
        internal AccountService(Session session) { this.session = session; }

        private NGUOI_DUNG Require(QuanLyGiangVienDataContext db, string form, ActionRight right)
        {
            var actor = session.Current(db);
            if (form != null && !Session.Allows(db, actor.MaVaiTro, form, right))
                throw new UserMessage("Bạn không có quyền thực hiện thao tác này.");
            return actor;
        }

        private T Read<T>(string form, ActionRight right, Func<QuanLyGiangVienDataContext,T> query)
        {
            using (var db = Session.Open()) { Require(db, form, right); return query(db); }
        }

        // Kiểm tra quyền, ghi thay đổi và ghi nhật ký trong cùng một giao dịch.
        private void Write(string form, ActionRight right, string action, Func<QuanLyGiangVienDataContext,NGUOI_DUNG,string> change)
        {
            using (var db = Session.Open())
            {
                if (db.Connection.State != ConnectionState.Open) db.Connection.Open();
                using (var tx = db.Connection.BeginTransaction(IsolationLevel.Serializable))
                {
                    db.Transaction = tx;
                    var actor = Require(db, form, right);
                    string detail = change(db, actor);
                    db.NHAT_KY_HE_THONGs.InsertOnSubmit(Session.Log(actor.MaNguoiDung, action, detail));
                    db.SubmitChanges();
                    tx.Commit();
                }
            }
        }

        internal List<AccountRow> Users(string term, int role, int state)
        {
            return Read(Accounts, ActionRight.View, db =>
            {
                var users = db.NGUOI_DUNGs.AsQueryable();
                if (role != 0) users = users.Where(u => u.MaVaiTro == role);
                if (state >= 0) users = users.Where(u => u.TrangThai == (state == 1));
                if (!string.IsNullOrWhiteSpace(term))
                {
                    string key = term.Trim();
                    users = users.Where(u => u.TenDangNhap.Contains(key) || (u.MaGV.HasValue && u.GIANG_VIEN.HoTen.Contains(key)));
                }
                return users.OrderBy(u => u.TenDangNhap).Select(u => new AccountRow {
                    Id=u.MaNguoiDung, Name=u.TenDangNhap, RecoveryEmail=u.Email, LecturerId=u.MaGV,
                    Lecturer=u.MaGV.HasValue ? u.GIANG_VIEN.HoTen : "—", RoleId=u.MaVaiTro,
                    Role=u.VAI_TRO.TenVaiTro, Active=u.TrangThai
                }).ToList();
            });
        }

        internal List<RoleInfo> ListRoles(string form)
        {
            return Read(form, ActionRight.View, db => db.VAI_TROs.OrderBy(r => r.TenVaiTro)
                .Select(r => new RoleInfo { Id=r.MaVaiTro, Name=r.TenVaiTro, Description=r.MoTa }).ToList());
        }

        internal List<Choice> Lecturers(ActionRight right)
        {
            return Read(Accounts, right, db => db.GIANG_VIENs.OrderBy(g => g.HoTen)
                .Select(g => new Choice { Id=g.MaGV, Title=g.HoTen + " · " + g.Email }).ToList());
        }

        private static NGUOI_DUNG Find(QuanLyGiangVienDataContext db, int id)
        {
            return db.NGUOI_DUNGs.SingleOrDefault(u => u.MaNguoiDung == id) ?? throw new UserMessage("Tài khoản đã được xóa.");
        }

        // Một người quản lý không được cấp hoặc quản trị các quyền vượt quá quyền của mình.
        private static void CheckRoleScope(QuanLyGiangVienDataContext db, int own, int target)
        {
            if (!db.VAI_TROs.Any(r=>r.MaVaiTro==target)) throw new UserMessage("Vai trò đã thay đổi. Hãy tải lại.");
            var mine = db.PHAN_QUYENs.Where(p=>p.MaVaiTro==own).ToDictionary(p=>p.MaChucNang);
            foreach(var p in db.PHAN_QUYENs.Where(p=>p.MaVaiTro==target))
            {
                if (!p.DuocXem && !p.DuocThem && !p.DuocSua && !p.DuocXoa) continue;
                PHAN_QUYEN m;
                if (!mine.TryGetValue(p.MaChucNang,out m) || (p.DuocXem && !m.DuocXem) ||
                    (p.DuocThem && !m.DuocThem) || (p.DuocSua && !m.DuocSua) || (p.DuocXoa && !m.DuocXoa))
                    throw new UserMessage("Vai trò này vượt phạm vi quyền của bạn.");
            }
        }

        internal static string NormalizeRecoveryEmail(string value)
        {
            string email = (value ?? "").Trim();
            if (email.Length == 0) return null;

            // Chấp nhận một địa chỉ ASCII, không kèm tên hiển thị hoặc nhiều người nhận.
            const string atom = @"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+";
            const string domainLabel = @"[A-Za-z0-9](?:[A-Za-z0-9-]{0,61}[A-Za-z0-9])?";
            const string topLevelLabel = @"[A-Za-z](?:[A-Za-z0-9-]{0,61}[A-Za-z0-9])?";
            int at = email.IndexOf('@');
            if (email.Length > 254 || at < 1 || at > 64 ||
                !Regex.IsMatch(email.Substring(0, at), @"\A" + atom + @"(?:\." + atom + @")*\z") ||
                !Regex.IsMatch(email.Substring(at + 1), @"\A(?:" + domainLabel + @"\.)+" + topLevelLabel + @"\z"))
                throw new UserMessage("Email khôi phục không hợp lệ. Hãy nhập một địa chỉ email không dấu, tối đa 254 ký tự.");

            return email;
        }

        internal void SaveAccount(AccountRow original, string name, int? lecturer, int role, string recoveryEmail, string password, string repeat)
        {
            name = (name ?? "").Trim();
            if (!Regex.IsMatch(name, @"\A[A-Za-z0-9_.-]{1,50}\z")) throw new UserMessage("Tên đăng nhập cần 1–50 ký tự: chữ không dấu, số, dấu chấm, gạch dưới hoặc gạch ngang.");
            string email = NormalizeRecoveryEmail(recoveryEmail);
            Write(Accounts, original == null ? ActionRight.Add : ActionRight.Edit, original == null ? "Thêm tài khoản" : "Sửa tài khoản", (db,actor) =>
            {
                CheckRoleScope(db,actor.MaVaiTro,role);
                if (lecturer.HasValue && !db.GIANG_VIENs.Any(g=>g.MaGV==lecturer)) throw new UserMessage("Giảng viên đã thay đổi.");
                int id=original==null ? 0 : original.Id;
                if(db.NGUOI_DUNGs.Any(u=>u.TenDangNhap==name && u.MaNguoiDung!=id)) throw new UserMessage("Tên đăng nhập đã tồn tại.");
                if (email != null && db.NGUOI_DUNGs.Any(u => u.Email == email && u.MaNguoiDung != id))
                    throw new UserMessage("Email khôi phục đã được sử dụng cho tài khoản khác.");
                var user= original == null ? new NGUOI_DUNG { TrangThai=true } : Find(db,id);
                if(original==null) { Passwords.Set(user,password,repeat); db.NGUOI_DUNGs.InsertOnSubmit(user); }
                else
                {
                    CheckRoleScope(db,actor.MaVaiTro,user.MaVaiTro);
                    if(user.MaVaiTro!=original.RoleId || user.MaGV!=original.LecturerId || user.TenDangNhap!=original.Name ||
                        user.Email != original.RecoveryEmail)
                        throw new UserMessage("Tài khoản vừa thay đổi. Hãy làm mới danh sách.");
                    if(user.MaNguoiDung==actor.MaNguoiDung && role!=user.MaVaiTro) throw new UserMessage("Bạn không thể tự đổi vai trò.");
                }
                user.MaGV=lecturer; user.MaVaiTro=role; user.TenDangNhap=name;
                user.Email = email;
                return name;
            });
        }

        internal void SetActive(int id, bool active)
        {
            Write(Accounts,ActionRight.Edit,active ? "Mở khóa" : "Khóa tài khoản",(db,actor)=>{
                var user=Find(db,id); CheckRoleScope(db,actor.MaVaiTro,user.MaVaiTro);
                if(id==actor.MaNguoiDung) throw new UserMessage("Bạn không thể khóa tài khoản đang dùng.");
                user.TrangThai=active; return user.TenDangNhap;
            });
        }

        internal void DeleteAccount(int id)
        {
            Write(Accounts,ActionRight.Delete,"Xóa tài khoản",(db,actor)=>{
                var user=Find(db,id); CheckRoleScope(db,actor.MaVaiTro,user.MaVaiTro);
                if(id==actor.MaNguoiDung) throw new UserMessage("Bạn không thể xóa tài khoản đang dùng.");
                if(db.NHAT_KY_HE_THONGs.Any(x=>x.MaNguoiDung==id)) throw new UserMessage("Tài khoản đã có nhật ký. Hãy dùng chức năng Khóa.");
                db.NGUOI_DUNGs.DeleteOnSubmit(user); return user.TenDangNhap;
            });
        }

        internal void ChangePassword(int? target, string old, string next, string repeat)
        {
            bool self = !target.HasValue || target.Value==session.UserId;
            string stamp=null;
            Write(self ? null : Accounts,ActionRight.Edit,self ? "Đổi mật khẩu" : "Đặt lại mật khẩu",(db,actor)=>{
                var user=self ? actor : Find(db,target.Value);
                if(self && !Passwords.Matches(old,actor)) throw new UserMessage("Mật khẩu hiện tại chưa đúng.");
                if(!self) CheckRoleScope(db,actor.MaVaiTro,user.MaVaiTro);
                if(Passwords.Matches(next,user)) throw new UserMessage("Mật khẩu mới trùng mật khẩu hiện tại.");
                Passwords.Set(user,next,repeat); stamp=user.MatKhauHash; return user.TenDangNhap;
            });
            if(self) session.PasswordChanged(stamp);
        }

        internal List<GrantRow> Permissions(int role)
        {
            return Read(Roles,ActionRight.View,db=>GetGrants(db,role));
        }

        private static List<GrantRow> GetGrants(QuanLyGiangVienDataContext db,int role)
        {
            var stored=db.PHAN_QUYENs.Where(p=>p.MaVaiTro==role).ToDictionary(p=>p.MaChucNang);
            return db.CHUC_NANGs.OrderBy(f=>f.TenChucNang).ToList().Select(f=>{
                PHAN_QUYEN p; stored.TryGetValue(f.MaChucNang,out p);
                return new GrantRow {Id=f.MaChucNang,Title=f.TenChucNang,View=p!=null && p.DuocXem,
                    Add=p!=null && p.DuocThem,Edit=p!=null && p.DuocSua,Delete=p!=null && p.DuocXoa};
            }).ToList();
        }

        internal void SaveGrants(int role, IList<GrantRow> rows, IDictionary<int,int> before)
        {
            Write(Roles,ActionRight.Edit,"Lưu phân quyền",(db,actor)=>{
                if(actor.MaVaiTro==role) throw new UserMessage("Không thể sửa quyền của chính vai trò đang dùng.");
                CheckRoleScope(db,actor.MaVaiTro,role);
                var current=GetGrants(db,role);
                if(current.Count!=rows.Count || rows.Select(r=>r.Id).Distinct().Count()!=rows.Count ||
                   current.Any(r=>!before.ContainsKey(r.Id) || before[r.Id]!=r.Mask) || rows.Any(r=>!before.ContainsKey(r.Id)))
                    throw new UserMessage("Bảng quyền đã thay đổi. Hãy chọn lại vai trò.");
                var mine=GetGrants(db,actor.MaVaiTro).ToDictionary(r=>r.Id);
                var stored=db.PHAN_QUYENs.Where(p=>p.MaVaiTro==role).ToDictionary(p=>p.MaChucNang);
                foreach(var r in rows)
                {
                    if(!r.View && r.Mask!=0) throw new UserMessage("Hãy cấp quyền Xem trước khi cấp Thêm, Sửa hoặc Xóa.");
                    if((r.Mask & ~mine[r.Id].Mask)!=0) throw new UserMessage("Không thể cấp quyền vượt quá quyền của bạn.");
                    PHAN_QUYEN p;
                    if(!stored.TryGetValue(r.Id,out p))
                    {
                        if(r.Mask==0) continue;
                        p=new PHAN_QUYEN {MaVaiTro=role,MaChucNang=r.Id}; db.PHAN_QUYENs.InsertOnSubmit(p);
                    }
                    p.DuocXem=r.View; p.DuocThem=r.Add; p.DuocSua=r.Edit; p.DuocXoa=r.Delete;
                }
                return "Vai trò "+role;
            });
        }

    }
}
