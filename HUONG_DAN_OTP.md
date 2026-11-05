# Quên mật khẩu bằng OTP Gmail

## Chuẩn bị máy chạy
1. Cài SQL Server, có database QuanLyGiangVien. App.config mặc định dùng .\SQLEXPRESS với Windows Authentication; đổi đúng server của máy nếu khác.
2. Database cũ chạy BoSungEmailKhoiPhuc.sql. Không chạy lại script tạo toàn bộ bảng trên database đang có dữ liệu. Sao lưu trước khi cập nhật.
3. Admin nhập email thật đã xác minh chủ sở hữu vào Email khôi phục của tài khoản. Email gửi không phải email nhận; lúc thử có thể dùng cùng một Gmail cho cả hai. Email khôi phục phải riêng cho từng tài khoản.
4. Tại Gmail gửi mã: bật xác minh hai bước, tạo mật khẩu ứng dụng Google tại https://myaccount.google.com/apppasswords. Không dùng mật khẩu đăng nhập Gmail.
5. Mở PowerShell ở thư mục repository, chạy: & '.\tools\CauHinh-GmailOTP.ps1'. Nhập địa chỉ gửi và mật khẩu ứng dụng trên máy; công cụ che phần nhập mật khẩu.
6. Công cụ chỉ lưu QLGV_GMAIL_USER và QLGV_GMAIL_APP_PASSWORD vào biến môi trường tài khoản Windows, không gửi thư lúc thiết lập. Mỗi tài khoản Windows chạy demo cần cấu hình riêng. Biến môi trường không phải kho mật khẩu mã hóa; chỉ dùng trên máy tin cậy, không chụp/xuất giá trị hoặc đưa lên Git. Không tắt bảo vệ máy nếu PowerShell chặn script; nhờ người phụ trách kiểm tra.
7. Khởi động lại ứng dụng nếu cần. Có Internet để gửi và nhận thư.

## Thử
Login → Quên mật khẩu → nhập tên tài khoản → Gửi mã → mở hộp thư/Spam → nhập OTP và hai ô mật khẩu mới → lưu → đăng nhập bằng mật khẩu mới.
Mã gồm 6 chữ số, hạn 5 phút, tối đa 5 lần nhập sai hợp lệ về định dạng. Hai lần gửi cách nhau tối thiểu 60 giây trong một tiến trình ứng dụng. Yêu cầu gửi lại hủy mã cũ trên form hiện tại. Đóng form hoặc đổi tên tài khoản cũng hủy yêu cầu hiện tại. Mã chưa được lưu database; khởi động lại ứng dụng không giữ yêu cầu cũ.
Chỉ tài khoản hoạt động có email hợp lệ mới được gửi mã. Giao diện phản hồi chung để không tiết lộ tài khoản tồn tại hay bị khóa. Thông báo phản hồi chung không chứng minh thư đã tới; cần kiểm tra hộp thư và hoàn tất đổi mật khẩu khi demo.

## Phạm vi kiểm tra
Ngày 05/11/2026: 20 kiểm tra logic chạy trên database thử riêng, bao gồm mã sai/hết hạn/hủy, giới hạn số lần thử, tài khoản khóa, thông tin đổi sau khi gửi, đặt mật khẩu và nhật ký. Không dùng email thật trong kiểm tra tự động. Không đưa file database, backup, log hay mật khẩu Gmail lên repository.
Hướng dẫn Google: https://support.google.com/accounts/answer/185833?hl=vi
