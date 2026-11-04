# Phần tài khoản và phân quyền — Hào

## Phạm vi bàn giao

- frmLogin: đăng nhập, ghi nhớ tên đăng nhập, hiện/ẩn mật khẩu, giới hạn thử sai tạm thời.
- frmChangePassword: tự đổi mật khẩu; người đủ quyền đặt lại mật khẩu tài khoản khác.
- frmUserManagement và frmUserEdit: tìm/lọc, thêm/sửa, khóa/mở khóa và xóa tài khoản chưa có lịch sử.
- frmRoleManagement: xem và cập nhật quyền theo chức năng. Ba vai trò cố định: Quản trị viên (ADMIN), Giáo vụ, Giảng viên. Không có thao tác thêm/sửa/xóa vai trò.
- Giữ chức vụ Trưởng khoa trong dữ liệu chức vụ; không tạo vai trò Trưởng khoa.
- Giao diện sáng/tối; các form nghiệp vụ được giữ bộ file .cs, .Designer.cs, .resx để chỉnh bằng Designer.

## Chạy thử

1. Mở QuanLyGiangVien/QuanLyGiangVien.slnx bằng Visual Studio có .NET desktop development, .NET Framework 4.8 targeting pack và LINQ to SQL tools.
2. SQL Server Express phải có instance SQLEXPRESS. Dùng script QuanLyGiangVien_CreateTables.sql của nhóm để khởi tạo database mới. Không chạy lại script tạo bảng/seed trên database đang có dữ liệu.
3. Cấu hình kết nối nằm trong App.config; mặc định Windows Authentication, server .\SQLEXPRESS, database QuanLyGiangVien. Máy khác tên server cần sửa cấu hình phù hợp.
4. Nhấn F5: chương trình mở frmLogin, đăng nhập thành công chuyển sang frmMain(session). Không cần đối số --hao.
5. Trên Main, mở nhóm Hệ thống để vào Quản lý người dùng, Phân quyền hoặc Đổi mật khẩu.
6. Tài khoản demo lấy từ script seed của nhóm. Không đưa tài khoản thử hoặc bản sao database cá nhân lên Git.

## Tích hợp frmMain sau này

frmAccountHome chỉ là màn hình chạy thử phân hệ tài khoản, không thay thế frmMain của nhóm. Session.Login trả Session của người dùng hiện tại; frmMain cùng project có thể nhận Session rồi mở frmUserManagement(session), frmRoleManagement(session), frmChangePassword(session).

Dùng session.Can(maForm, ActionRight.View/Add/Edit/Delete) để điều khiển nút/menu. MaForm phải khớp CHUC_NANG trong database. Các thao tác ghi của AccountService vẫn kiểm tra quyền và trạng thái tài khoản tại thời điểm thao tác; không dựa riêng vào việc ẩn nút.

## Quy ước và giới hạn

- LINQ to SQL dùng DBML hiện có của nhóm, .NET Framework 4.8; không chuyển sang Entity Framework.
- Băm mật khẩu đúng quy ước seed: SHA-256 trên UTF-8(password + salt), salt ngẫu nhiên 16 byte biểu diễn hex; hash hex chữ thường. Đây là quy ước môn học, không phải cam kết đạt mọi yêu cầu bảo mật triển khai doanh nghiệp.
- Ghi dữ liệu và nhật ký trong cùng giao dịch; không ghi mật khẩu vào nhật ký.
- Không cho tự khóa/xóa tài khoản đang dùng hoặc tự sửa quyền vai trò đang dùng. Tài khoản đã có lịch sử sử dụng Khóa thay cho Xóa.
- Không kèm thư mục bin, obj, .vs; file .user; database mdf/ldf, bản backup hoặc bộ cài.
- Cần kiểm thử tích hợp lại khi nhóm bổ sung frmMain hoặc đổi tên chức năng/quyền trong database.

## Kiểm tra trước khi bàn giao

Debug/Release build; đăng nhập đúng/sai/trống; thao tác tài khoản; đổi/đặt lại mật khẩu; thu hồi quyền; kiểm tra quyền trong service; cố định vai trò; mở 5 form và theme sáng/tối. Kết quả vòng kiểm tra ngày 02/11/2026: Debug và Release build thành công; 40 kiểm tra chức năng đạt trên database thử riêng; kiểm tra nút Đăng nhập với file ứng dụng đã biên dịch đạt. Database thử đã xóa; không thay đổi dữ liệu nghiệp vụ trên database đang sử dụng. Chưa kiểm thử tích hợp frmMain và các nghiệp vụ của thành viên khác.

## Cập nhật ngày 03/11/2026

- Màn hình tài khoản dùng frmAccountHome có .cs, .Designer.cs và .resx, dựa trên phần kéo thả của Hào. File .cs giữ xử lý sự kiện; vị trí và control nằm trong Designer. Đã thay chỗ mở màn hình trong frmLogin, bỏ AccountHome tạo control bằng code.
- Diagnostics ghi lỗi tại đường dẫn tương đối Logs/sql-yyyyMMdd.log, tính từ thư mục làm việc hiện tại của ứng dụng. Thư mục Logs được bỏ qua bởi Git. Nếu không có quyền ghi, việc ghi log được bỏ qua như trước.


## Tích hợp Main ngày 04/11/2026

- Dùng các nút có sẵn trong Designer của nhóm: btnNguoiDung, btnPhanQuyen, btnDoiMatKhau.
- Truyền cùng Session vào frmUserManagement, frmRoleManagement, frmChangePassword.
- Main đọc quyền xem để bật/tắt hai nút quản lý; kiểm tra lại phiên và quyền khi bấm. Tự đổi mật khẩu chỉ cần phiên hợp lệ.
- Sau khi đóng màn hình con, Main đọc lại quyền. Giữ nguyên kiểm tra quyền tại AccountService.
- Đã thử mở ba màn hình từ Main với tài khoản hoạt động đại diện ba vai trò trên SQL Server hiện có; kiểm tra quyền bật/tắt và tự đổi mật khẩu đều đạt. Lượt này chỉ đọc dữ liệu và mở/đóng form, không lưu thay đổi tài khoản hoặc phân quyền.
- Các mục đào tạo/thống kê/báo cáo và kiểm tra toàn bộ nghiệp vụ thành viên khác nằm ngoài lượt tích hợp này.
