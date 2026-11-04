IF DB_ID(N'QuanLyGiangVien') IS NULL
BEGIN
    CREATE DATABASE QuanLyGiangVien;
END
GO

USE QuanLyGiangVien;
GO
-- TẠO BẢNG --
CREATE TABLE KHOA
(
    MaKhoa INT IDENTITY(1,1) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NULL,
    SoDienThoai VARCHAR(15) NULL UNIQUE,
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

USE QuanLyGiangVien;
GO

CREATE TABLE BO_MON
(
    MaBoMon INT IDENTITY(1,1) PRIMARY KEY,
    TenBoMon NVARCHAR(100) NOT NULL,
    MaKhoa INT NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_BO_MON_KHOA
        FOREIGN KEY (MaKhoa)
        REFERENCES KHOA(MaKhoa)
);
GO

USE QuanLyGiangVien;
GO

CREATE TABLE HOC_VI
(
    MaHocVi INT IDENTITY(1,1) PRIMARY KEY,
    TenHocVi NVARCHAR(50) NOT NULL UNIQUE
);
GO

USE QuanLyGiangVien;
GO

CREATE TABLE CHUC_VU
(
    MaChucVu INT IDENTITY(1,1) PRIMARY KEY,
    TenChucVu NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE CHUYEN_MON
(
    MaChuyenMon INT IDENTITY(1,1) PRIMARY KEY,
    TenChuyenMon NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(500) NULL,
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE GIANG_VIEN
(
    MaGV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NULL,
    GioiTinh NVARCHAR(10) NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    SoDienThoai VARCHAR(15) NULL,
    DiaChi NVARCHAR(200) NULL,
    NgayVaoTruong DATE NULL,

    MaBoMon INT NOT NULL,
    MaHocVi INT NOT NULL,
    MaChucVu INT NULL,

    TrangThai BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_GIANG_VIEN_BO_MON
        FOREIGN KEY (MaBoMon)
        REFERENCES BO_MON(MaBoMon),

    CONSTRAINT FK_GIANG_VIEN_HOC_VI
        FOREIGN KEY (MaHocVi)
        REFERENCES HOC_VI(MaHocVi),

    CONSTRAINT FK_GIANG_VIEN_CHUC_VU
        FOREIGN KEY (MaChucVu)
        REFERENCES CHUC_VU(MaChucVu)
);
GO

CREATE TABLE GIANG_VIEN_CHUYEN_MON
(
    MaGV INT NOT NULL,
    MaChuyenMon INT NOT NULL,
    LaChuyenMonChinh BIT NOT NULL DEFAULT 0,

    CONSTRAINT PK_GIANG_VIEN_CHUYEN_MON
        PRIMARY KEY (MaGV, MaChuyenMon),

    CONSTRAINT FK_GV_CM_GIANG_VIEN
        FOREIGN KEY (MaGV)
        REFERENCES GIANG_VIEN(MaGV),

    CONSTRAINT FK_GV_CM_CHUYEN_MON
        FOREIGN KEY (MaChuyenMon)
        REFERENCES CHUYEN_MON(MaChuyenMon)
);
GO

CREATE TABLE NAM_HOC
(
    MaNamHoc INT IDENTITY(1,1) PRIMARY KEY,
    TenNamHoc VARCHAR(20) NOT NULL UNIQUE,
    TuNam INT NOT NULL,
    DenNam INT NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1,

    CONSTRAINT CK_NAM_HOC
        CHECK (DenNam > TuNam)
);
GO

CREATE TABLE HOC_KY
(
    MaHocKy INT IDENTITY(1,1) PRIMARY KEY,
    TenHocKy NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE HOC_PHAN
(
    MaHocPhan INT IDENTITY(1,1) PRIMARY KEY,
    TenHocPhan NVARCHAR(150) NOT NULL,
    SoTinChi INT NOT NULL,
    SoTietLyThuyet INT NOT NULL,
    SoTietThucHanh INT NOT NULL,
    MaBoMon INT NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_HOC_PHAN_BO_MON
        FOREIGN KEY (MaBoMon)
        REFERENCES BO_MON(MaBoMon),

    CONSTRAINT CK_HOC_PHAN_TIN_CHI
        CHECK (SoTinChi > 0),

    CONSTRAINT CK_HOC_PHAN_LY_THUYET
        CHECK (SoTietLyThuyet >= 0),

    CONSTRAINT CK_HOC_PHAN_THUC_HANH
        CHECK (SoTietThucHanh >= 0)
);
GO

CREATE TABLE LOP_HOC_PHAN
(
    MaLopHP INT IDENTITY(1,1) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaHocPhan INT NOT NULL,
    MaNamHoc INT NOT NULL,
    MaHocKy INT NOT NULL,
    SoLuongSinhVien INT NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_LOP_HP_HOC_PHAN
        FOREIGN KEY (MaHocPhan)
        REFERENCES HOC_PHAN(MaHocPhan),

    CONSTRAINT FK_LOP_HP_NAM_HOC
        FOREIGN KEY (MaNamHoc)
        REFERENCES NAM_HOC(MaNamHoc),

    CONSTRAINT FK_LOP_HP_HOC_KY
        FOREIGN KEY (MaHocKy)
        REFERENCES HOC_KY(MaHocKy),

    CONSTRAINT CK_LOP_HP_SINH_VIEN
        CHECK (SoLuongSinhVien >= 0)
);
GO

CREATE TABLE PHAN_CONG_GIANG_DAY
(
    MaPhanCong INT IDENTITY(1,1) PRIMARY KEY,
    MaGV INT NOT NULL,
    MaLopHP INT NOT NULL,
    SoTiet INT NOT NULL,
    NgayBatDau DATE NULL,
    NgayKetThuc DATE NULL,
    GhiChu NVARCHAR(500) NULL,

    CONSTRAINT FK_PHAN_CONG_GV
        FOREIGN KEY (MaGV)
        REFERENCES GIANG_VIEN(MaGV),

    CONSTRAINT FK_PHAN_CONG_LOP_HP
        FOREIGN KEY (MaLopHP)
        REFERENCES LOP_HOC_PHAN(MaLopHP),

    CONSTRAINT CK_PHAN_CONG_SO_TIET
        CHECK (SoTiet > 0)
);
GO

CREATE TABLE VAI_TRO
(
    MaVaiTro INT IDENTITY(1,1) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL UNIQUE,
    MoTa NVARCHAR(200) NULL
);
GO

CREATE TABLE CHUC_NANG
(
    MaChucNang INT IDENTITY(1,1) PRIMARY KEY,
    TenChucNang NVARCHAR(100) NOT NULL,
    MaForm VARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE NGUOI_DUNG
(
    MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    Email VARCHAR(254) COLLATE Latin1_General_100_CI_AS NULL,
    MatKhauHash VARCHAR(64) NOT NULL,
    MatKhauSalt VARCHAR(64) NOT NULL,
    MaGV INT NULL,
    MaVaiTro INT NOT NULL,
    TrangThai BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_NGUOI_DUNG_GIANG_VIEN
        FOREIGN KEY (MaGV)
        REFERENCES GIANG_VIEN(MaGV),

    CONSTRAINT FK_NGUOI_DUNG_VAI_TRO
        FOREIGN KEY (MaVaiTro)
        REFERENCES VAI_TRO(MaVaiTro)
);
GO

SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET QUOTED_IDENTIFIER ON;
SET NUMERIC_ROUNDABORT OFF;
CREATE UNIQUE NONCLUSTERED INDEX UX_NGUOI_DUNG_Email
    ON dbo.NGUOI_DUNG (Email) WHERE Email IS NOT NULL;
GO

CREATE TABLE PHAN_QUYEN
(
    MaVaiTro INT NOT NULL,
    MaChucNang INT NOT NULL,
    DuocXem BIT NOT NULL DEFAULT 0,
    DuocThem BIT NOT NULL DEFAULT 0,
    DuocSua BIT NOT NULL DEFAULT 0,
    DuocXoa BIT NOT NULL DEFAULT 0,

    CONSTRAINT PK_PHAN_QUYEN
        PRIMARY KEY (MaVaiTro, MaChucNang),

    CONSTRAINT FK_PHAN_QUYEN_VAI_TRO
        FOREIGN KEY (MaVaiTro)
        REFERENCES VAI_TRO(MaVaiTro),

    CONSTRAINT FK_PHAN_QUYEN_CHUC_NANG
        FOREIGN KEY (MaChucNang)
        REFERENCES CHUC_NANG(MaChucNang)
);
GO

CREATE TABLE NHAT_KY_HE_THONG
(
    MaNhatKy INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT NOT NULL,
    ThoiGian DATETIME NOT NULL DEFAULT GETDATE(),
    HanhDong NVARCHAR(100) NOT NULL,
    NoiDung NVARCHAR(500) NULL,

    CONSTRAINT FK_NHAT_KY_NGUOI_DUNG
        FOREIGN KEY (MaNguoiDung)
        REFERENCES NGUOI_DUNG(MaNguoiDung)
);
GO
-- INSERT DỮ LIỆU MẪU CHO BẢNG --
USE QuanLyGiangVien;
GO

INSERT INTO KHOA (TenKhoa, Email, SoDienThoai, TrangThai)
VALUES
(N'Khoa Công nghệ thông tin', 'cntt@hcmue.edu.vn', '02838352020', 1),
(N'Khoa Toán học', 'toan@hcmue.edu.vn', '02838352021', 1),
(N'Khoa Vật lý', 'vatly@hcmue.edu.vn', '02838352022', 1);
GO

INSERT INTO BO_MON (TenBoMon, MaKhoa, TrangThai)
VALUES
(N'Bộ môn Công nghệ phần mềm', 1, 1),
(N'Bộ môn Hệ thống thông tin', 1, 1),
(N'Bộ môn Khoa học máy tính', 1, 1),
(N'Bộ môn Đại số', 2, 1),
(N'Bộ môn Giải tích', 2, 1),
(N'Bộ môn Vật lý đại cương', 3, 1);
GO

INSERT INTO HOC_VI (TenHocVi)
VALUES
(N'Cử nhân'),
(N'Thạc sĩ'),
(N'Tiến sĩ'),
(N'Phó Giáo sư'),
(N'Giáo sư');
GO

INSERT INTO CHUC_VU (TenChucVu)
VALUES
(N'Giảng viên'),
(N'Giảng viên chính'),
(N'Trưởng bộ môn'),
(N'Phó trưởng bộ môn'),
(N'Trưởng khoa'),
(N'Phó trưởng khoa');
GO

INSERT INTO CHUYEN_MON (TenChuyenMon, MoTa, TrangThai)
VALUES
(N'Lập trình C++', N'Lập trình căn bản và nâng cao với C++', 1),
(N'Lập trình C#', N'Phát triển ứng dụng với C# và .NET', 1),
(N'Cơ sở dữ liệu', N'Hệ quản trị cơ sở dữ liệu và SQL', 1),
(N'Mạng máy tính', N'Mạng máy tính và giao thức mạng', 1),
(N'Trí tuệ nhân tạo', N'Các phương pháp và ứng dụng AI', 1),
(N'Cấu trúc dữ liệu và giải thuật', N'Cấu trúc dữ liệu và các thuật toán', 1);
GO

/* 6. GIANG_VIEN
 Mã bộ môn:
     1 = Công nghệ phần mềm 
     2 = Hệ thống thông tin 
     3 = Khoa học máy tính 
 Mã học vị:
     1 = Cử nhân
     2 = Thạc sĩ
     3 = Tiến sĩ
 Mã chức vụ:
     1 = Giảng viên
     2 = Giảng viên chính
     3 = Trưởng bộ môn
*/ 

INSERT INTO GIANG_VIEN
(
    HoTen,
    NgaySinh,
    GioiTinh,
    Email,
    SoDienThoai,
    DiaChi,
    NgayVaoTruong,
    MaBoMon,
    MaHocVi,
    MaChucVu,
    TrangThai
)
VALUES
(
    N'Nguyễn Văn An',
    '1985-03-15',
    N'Nam',
    'nguyenvanan@hcmue.edu.vn',
    '0901000001',
    N'Thành phố Hồ Chí Minh',
    '2010-09-01',
    1, 3, 3, 1
),
(
    N'Trần Thị Bình',
    '1988-07-20',
    N'Nữ',
    'tranthibinh@hcmue.edu.vn',
    '0901000002',
    N'Thành phố Hồ Chí Minh',
    '2012-09-01',
    2, 3, 2, 1
),
(
    N'Lê Minh Cường',
    '1990-11-05',
    N'Nam',
    'leminhcuong@hcmue.edu.vn',
    '0901000003',
    N'Bình Dương',
    '2015-09-01',
    3, 2, 1, 1
),
(
    N'Phạm Thị Dung',
    '1987-04-12',
    N'Nữ',
    'phamthidung@hcmue.edu.vn',
    '0901000004',
    N'Thành phố Hồ Chí Minh',
    '2011-09-01',
    1, 2, 1, 1
),
(
    N'Võ Hoàng Nam',
    '1983-09-25',
    N'Nam',
    'vohoangnam@hcmue.edu.vn',
    '0901000005',
    N'Thành phố Hồ Chí Minh',
    '2008-09-01',
    2, 3, 3, 1
);
GO

INSERT INTO GIANG_VIEN_CHUYEN_MON
(
    MaGV,
    MaChuyenMon,
    LaChuyenMonChinh
)
VALUES
(1, 1, 1),
(1, 2, 0),
(1, 3, 0),

(2, 3, 1),
(2, 5, 0),

(3, 5, 1),
(3, 6, 0),

(4, 2, 1),
(4, 4, 0),

(5, 3, 1);
GO

INSERT INTO NAM_HOC
(
    TenNamHoc,
    TuNam,
    DenNam,
    TrangThai
)
VALUES
('2024-2025', 2024, 2025, 1),
('2025-2026', 2025, 2026, 1),
('2026-2027', 2026, 2027, 1);
GO

INSERT INTO HOC_KY (TenHocKy)
VALUES
(N'Học kỳ 1'),
(N'Học kỳ 2'),
(N'Học kỳ hè');
GO

INSERT INTO HOC_PHAN
(
    TenHocPhan,
    SoTinChi,
    SoTietLyThuyet,
    SoTietThucHanh,
    MaBoMon,
    TrangThai
)
VALUES
(N'Lập trình C++', 3, 30, 30, 1, 1),
(N'Lập trình hướng đối tượng', 3, 30, 30, 1, 1),
(N'Cơ sở dữ liệu', 3, 30, 30, 2, 1),
(N'Phân tích và thiết kế hệ thống', 3, 30, 15, 2, 1),
(N'Trí tuệ nhân tạo', 3, 30, 30, 3, 1),
(N'Cấu trúc dữ liệu và giải thuật', 4, 45, 30, 3, 1);
GO

/* 
11. LỚP HỌC PHẦN 
Mã học phần: từ 1  đến 6 
Mã năm học : 1=2024-2025, 2=2025-2026, 3=2026-2027
Mã học kì: 1=HK1, 2=HK2, 3=Hè
*/

INSERT INTO LOP_HOC_PHAN
(
    TenLop,
    MaHocPhan,
    MaNamHoc,
    MaHocKy,
    SoLuongSinhVien,
    TrangThai
)
VALUES
(N'Lớp C++ 01', 1, 3, 1, 45, 1),
(N'Lớp OOP 01', 2, 3, 1, 40, 1),
(N'Lớp CSDL 01', 3, 3, 1, 50, 1),
(N'Lớp PTHT 01', 4, 3, 2, 42, 1),
(N'Lớp AI 01', 5, 3, 2, 35, 1),
(N'Lớp CTDL 01', 6, 3, 2, 45, 1);
GO

INSERT INTO PHAN_CONG_GIANG_DAY
(
    MaGV,
    MaLopHP,
    SoTiet,
    NgayBatDau,
    NgayKetThuc,
    GhiChu
)
VALUES
(1, 1, 60, '2026-09-01', '2026-12-31', N'Giảng dạy chính'),
(4, 2, 60, '2026-09-01', '2026-12-31', N'Giảng dạy chính'),
(2, 3, 60, '2026-09-01', '2026-12-31', N'Giảng dạy chính'),
(2, 4, 45, '2027-01-01', '2027-05-31', N'Giảng dạy chính'),
(3, 5, 60, '2027-01-01', '2027-05-31', N'Giảng dạy chính'),
(3, 6, 75, '2027-01-01', '2027-05-31', N'Giảng dạy chính');
GO

INSERT INTO VAI_TRO
(
    TenVaiTro,
    MoTa
)
VALUES
(N'Quản trị viên', N'Quản lý toàn bộ hệ thống'),
(N'Giáo vụ', N'Quản lý thông tin giảng dạy'),
(N'Giảng viên', N'Xem thông tin giảng dạy cá nhân');
GO

INSERT INTO CHUC_NANG
(
    TenChucNang,
    MaForm
)
VALUES
(N'Quản lý giảng viên', 'FrmGiangVien'),
(N'Quản lý khoa', 'FrmKhoa'),
(N'Quản lý bộ môn', 'FrmBoMon'),
(N'Quản lý học phần', 'FrmHocPhan'),
(N'Phân công giảng dạy', 'FrmPhanCong'),
(N'Quản lý người dùng', 'FrmNguoiDung'),
(N'Báo cáo thống kê', 'FrmBaoCao');
GO

-- UPDATE LẠI PHẦN CHỨC NĂNG CỦA DỮ LIỆU MẪU 

USE QuanLyGiangVien;
GO

UPDATE CHUC_NANG
SET TenChucNang = N'Quản lý giảng viên',
    MaForm = 'frmLecturer'
WHERE MaChucNang = 1;

UPDATE CHUC_NANG
SET TenChucNang = N'Quản lý khoa',
    MaForm = 'frmFaculty'
WHERE MaChucNang = 2;

UPDATE CHUC_NANG
SET TenChucNang = N'Quản lý bộ môn',
    MaForm = 'frmDepartment'
WHERE MaChucNang = 3;

UPDATE CHUC_NANG
SET TenChucNang = N'Quản lý học phần',
    MaForm = 'frmCourse'
WHERE MaChucNang = 4;

UPDATE CHUC_NANG
SET TenChucNang = N'Phân công giảng dạy',
    MaForm = 'frmTeachingAssignment'
WHERE MaChucNang = 5;

UPDATE CHUC_NANG
SET TenChucNang = N'Quản lý người dùng',
    MaForm = 'frmUserManagement'
WHERE MaChucNang = 6;

UPDATE CHUC_NANG
SET TenChucNang = N'Thống kê khối lượng giảng dạy',
    MaForm = 'frmTeachingWorkload'
WHERE MaChucNang = 7;

USE QuanLyGiangVien;
GO

INSERT INTO CHUC_NANG
(
    TenChucNang,
    MaForm
)
VALUES
(N'Quản lý phân quyền',            'frmRoleManagement'),
(N'Báo cáo giảng viên',            'frmReportLecturer'),
(N'Báo cáo phân công giảng dạy',   'frmReportTeachingAssignment'),
(N'Thống kê biểu đồ',              'frmChartDashboard');
GO

USE QuanLyGiangVien;
GO

-- Xóa các chức năng thừa từ mã 8 trở lên
DELETE FROM CHUC_NANG
WHERE MaChucNang > 7;
GO

-- Đưa giá trị IDENTITY về 7
DBCC CHECKIDENT ('CHUC_NANG', RESEED, 7);
GO

-- Thêm 4 chức năng mới
INSERT INTO CHUC_NANG
(
    TenChucNang,
    MaForm
)
VALUES
(N'Quản lý phân quyền',            'frmRoleManagement'),
(N'Báo cáo giảng viên',            'frmReportLecturer'),
(N'Báo cáo phân công giảng dạy',   'frmReportTeachingAssignment'),
(N'Thống kê biểu đồ',              'frmChartDashboard');
GO

-- Kiểm tra
SELECT *
FROM CHUC_NANG
ORDER BY MaChucNang;

-- Email khôi phục của tài khoản mẫu được để NULL cho đến khi quản trị viên nhập địa chỉ thật.
INSERT INTO NGUOI_DUNG
(
    TenDangNhap,
    MatKhauHash,
    MatKhauSalt,
    MaGV,
    MaVaiTro,
    TrangThai
)

/*
QUY TẮC ĐẶT MẬT KHẨU 
    Salt = chuỗi ngẫu nhiên 16 byte → lưu dạng HEX 32 ký tự
    Hash = SHA-256(Password + Salt)
    MatKhauHash = HEX 64 ký tự, chữ thường
    MatKhauSalt = HEX 32 ký tự

VÍ DỤ 
Mật khẩu:
Admin@123
Salt:
844be9c31650ad8b6b956becc5b195df
Hash:
f04bbb104b4c6cb3f710656d59d5d8751008ea81e59c83a841eb24b983e9c109
*/

VALUES
(
    'admin',
    'HASH_ADMIN',
    'SALT_ADMIN',
    NULL,
    1,
    1
),
(
    'nguyenvanan',
    'HASH_AN',
    'SALT_AN',
    1,
    3,
    1
),
(
    'tranthibinh',
    'HASH_BINH',
    'SALT_BINH',
    2,
    2,
    1
);
GO

-- UPDATE LẠI PHẦN ADMIN VỀ MẬT KHẨU CHO DỮ LIỆU MẪU

USE QuanLyGiangVien;
GO

UPDATE NGUOI_DUNG
SET
    MatKhauHash = 'f04bbb104b4c6cb3f710656d59d5d8751008ea81e59c83a841eb24b983e9c109',
    MatKhauSalt = '844be9c31650ad8b6b956becc5b195df'
WHERE TenDangNhap = 'admin';

UPDATE NGUOI_DUNG
SET
    MatKhauHash = '1ffa46ed58906e3ff17ce2ff430d6d947aecfb913bae89ca5b328523fd9d84a2',
    MatKhauSalt = '8791d4735cc9e29b14be1c02446b4b2d'
WHERE TenDangNhap = 'nguyenvanan';

UPDATE NGUOI_DUNG
SET
    MatKhauHash = 'c022f5dbc0d14537aed301eacd58fece3ae696b3cd091778b88aa5b5e341e873',
    MatKhauSalt = '544037679d78c547626b2e6d9944b9f8'
WHERE TenDangNhap = 'tranthibinh';

GO
USE QuanLyGiangVien;
GO

/*
LOGIC PHÂN QUYỀN
1. QUẢN TRỊ VIÊN
   - Toàn quyền hệ thống.
   - Được xem, thêm, sửa, xóa tất cả chức năng.
2. GIÁO VỤ
   - Quản lý nghiệp vụ đào tạo:
     + Giảng viên
     + Khoa
     + Bộ môn
     + Học phần
     + Phân công giảng dạy
   - Được xem, thêm, sửa.
   - Không được xóa.
   - Được xem các báo cáo và thống kê.
   - Không được quản lý người dùng và phân quyền.
3. GIẢNG VIÊN
   - Chỉ được xem các thông tin liên quan đến
     giảng dạy:
     + Giảng viên
     + Học phần
     + Phân công giảng dạy
     + Khối lượng giảng dạy
   - Không được thêm, sửa, xóa.
   - Phạm vi dữ liệu cá nhân sẽ được xử lý
     trong logic C# LINQ.
*/
-- Xóa dữ liệu phân quyền cũ
-- Chỉ sử dụng khi muốn tạo lại bảng PHAN_QUYEN từ đầu.
DELETE FROM PHAN_QUYEN;
GO
/*
QUẢN TRỊ VIÊN
MaVaiTro = 1
Toàn quyền tất cả 11 chức năng
*/
INSERT INTO PHAN_QUYEN
(
    MaVaiTro,
    MaChucNang,
    DuocXem,
    DuocThem,
    DuocSua,
    DuocXoa
)
VALUES
(1, 1, 1, 1, 1, 1), -- Quản lý giảng viên
(1, 2, 1, 1, 1, 1), -- Quản lý khoa
(1, 3, 1, 1, 1, 1), -- Quản lý bộ môn
(1, 4, 1, 1, 1, 1), -- Quản lý học phần
(1, 5, 1, 1, 1, 1), -- Phân công giảng dạy
(1, 6, 1, 1, 1, 1), -- Quản lý người dùng
(1, 7, 1, 1, 1, 1), -- Thống kê khối lượng giảng dạy
(1, 8, 1, 1, 1, 1), -- Quản lý phân quyền
(1, 9, 1, 1, 1, 1), -- Báo cáo giảng viên
(1, 10, 1, 1, 1, 1), -- Báo cáo phân công giảng dạy
(1, 11, 1, 1, 1, 1); -- Thống kê biểu đồ
/*
GIÁO VỤ
MaVaiTro = 2
Quản lý nghiệp vụ:
1, 2, 3, 4, 5
Xem + Thêm + Sửa
Không được Xóa
Được xem:
7, 9, 10, 11
*/
INSERT INTO PHAN_QUYEN
(
    MaVaiTro,
    MaChucNang,
    DuocXem,
    DuocThem,
    DuocSua,
    DuocXoa
)
VALUES
(2, 1, 1, 1, 1, 0), -- Quản lý giảng viên
(2, 2, 1, 1, 1, 0), -- Quản lý khoa
(2, 3, 1, 1, 1, 0), -- Quản lý bộ môn
(2, 4, 1, 1, 1, 0), -- Quản lý học phần
(2, 5, 1, 1, 1, 0), -- Phân công giảng dạy
(2, 7, 1, 0, 0, 0), -- Thống kê khối lượng giảng dạy
(2, 9, 1, 0, 0, 0), -- Báo cáo giảng viên
(2, 10, 1, 0, 0, 0), -- Báo cáo phân công giảng dạy
(2, 11, 1, 0, 0, 0); -- Thống kê biểu đồ
/*
GIẢNG VIÊN
MaVaiTro = 3
Chỉ được Xem:
1, 4, 5, 7
*/
INSERT INTO PHAN_QUYEN
(
    MaVaiTro,
    MaChucNang,
    DuocXem,
    DuocThem,
    DuocSua,
    DuocXoa
)
VALUES
(3, 1, 1, 0, 0, 0), -- Quản lý giảng viên
(3, 4, 1, 0, 0, 0), -- Quản lý học phần
(3, 5, 1, 0, 0, 0), -- Phân công giảng dạy
(3, 7, 1, 0, 0, 0); -- Thống kê khối lượng giảng dạy

GO


-- Kiểm tra toàn bộ phân quyền
SELECT
    MaVaiTro,
    MaChucNang,
    DuocXem,
    DuocThem,
    DuocSua,
    DuocXoa
FROM PHAN_QUYEN
ORDER BY MaVaiTro, MaChucNang;
GO

INSERT INTO NHAT_KY_HE_THONG
(
    MaNguoiDung,
    ThoiGian,
    HanhDong,
    NoiDung
)
VALUES
(1, GETDATE(), N'Đăng nhập', N'Quản trị viên đăng nhập hệ thống'),
(1, GETDATE(), N'Tạo dữ liệu', N'Tạo dữ liệu mẫu cho hệ thống'),
(2, GETDATE(), N'Đăng nhập', N'Giảng viên đăng nhập hệ thống'),
(3, GETDATE(), N'Đăng nhập', N'Giáo vụ đăng nhập hệ thống');
GO

--KIỂM TRA BẢNG --
SELECT 'KHOA' AS TenBang, COUNT(*) AS SoDong FROM KHOA
UNION ALL
SELECT 'BO_MON', COUNT(*) FROM BO_MON
UNION ALL
SELECT 'HOC_VI', COUNT(*) FROM HOC_VI
UNION ALL
SELECT 'CHUC_VU', COUNT(*) FROM CHUC_VU
UNION ALL
SELECT 'CHUYEN_MON', COUNT(*) FROM CHUYEN_MON
UNION ALL
SELECT 'GIANG_VIEN', COUNT(*) FROM GIANG_VIEN
UNION ALL
SELECT 'GIANG_VIEN_CHUYEN_MON', COUNT(*) FROM GIANG_VIEN_CHUYEN_MON
UNION ALL
SELECT 'NAM_HOC', COUNT(*) FROM NAM_HOC
UNION ALL
SELECT 'HOC_KY', COUNT(*) FROM HOC_KY
UNION ALL
SELECT 'HOC_PHAN', COUNT(*) FROM HOC_PHAN
UNION ALL
SELECT 'LOP_HOC_PHAN', COUNT(*) FROM LOP_HOC_PHAN
UNION ALL
SELECT 'PHAN_CONG_GIANG_DAY', COUNT(*) FROM PHAN_CONG_GIANG_DAY
UNION ALL
SELECT 'NGUOI_DUNG', COUNT(*) FROM NGUOI_DUNG
UNION ALL
SELECT 'VAI_TRO', COUNT(*) FROM VAI_TRO
UNION ALL
SELECT 'CHUC_NANG', COUNT(*) FROM CHUC_NANG
UNION ALL
SELECT 'PHAN_QUYEN', COUNT(*) FROM PHAN_QUYEN
UNION ALL
SELECT 'NHAT_KY_HE_THONG', COUNT(*) FROM NHAT_KY_HE_THONG;
GO

--TEST LẠI MẬT KHẨU 
SELECT
    TenDangNhap,
    MatKhauHash,
    MatKhauSalt,
    MaGV,
    MaVaiTro,
    TrangThai
FROM NGUOI_DUNG;
-- LƯU Ý cho Hào: Khi Hào làm frmLogin, code C# phải dùng đúng quy tắc: Password người dùng nhập + MatKhauSalt -> SHA-256 -> HEX chữ thường -> so sánh MatKhauHash

/*
NHỮNG PHẦN CẦN KIỂM TRA LẠI 
1. Insert thêm dữ liệu trưởng khoa 
2. frmUserManagement và frmRoleManagement chưa có mã riêng
3. chỉnh sửa lại mk dạng hash & salt 
4. frmRoleManagement trong database 
5. chỉnh tên form tiếng việt thành tiếng anh 
*/
