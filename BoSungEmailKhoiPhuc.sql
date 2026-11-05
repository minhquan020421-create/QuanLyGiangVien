-- Chạy file này nếu cần cập nhật thủ công cơ sở dữ liệu QuanLyGiangVien.
-- Email được để NULL cho đến khi quản trị viên nhập địa chỉ khôi phục đã xác minh.
-- Chỉ đổi @CopyVerifiedLecturerEmail thành 1 nếu nhóm đã xác minh các địa chỉ
-- GIANG_VIEN.Email là địa chỉ thật do chính chủ tài khoản sử dụng.
-- Giữ giá trị 0 nếu cơ sở dữ liệu có địa chỉ mẫu chưa xác minh.
USE QuanLyGiangVien;
GO

IF DB_NAME() <> N'QuanLyGiangVien'
    THROW 50001, N'Hãy kết nối đúng cơ sở dữ liệu QuanLyGiangVien.', 1;

-- BEGIN RECOVERY EMAIL SCHEMA
SET NOCOUNT ON;
SET XACT_ABORT ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET QUOTED_IDENTIFIER ON;
SET NUMERIC_ROUNDABORT OFF;

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @SchemaLock int;
    EXEC @SchemaLock = sys.sp_getapplock
        @Resource = N'QuanLyGiangVien.RecoveryEmailSchema',
        @LockMode = N'Exclusive',
        @LockOwner = N'Transaction',
        @LockTimeout = 5000;

    IF @SchemaLock < 0
        THROW 50003, N'Cơ sở dữ liệu đang được cập nhật. Hãy thử lại.', 1;

    IF OBJECT_ID(N'dbo.NGUOI_DUNG', N'U') IS NULL
        THROW 50004, N'Không tìm thấy bảng NGUOI_DUNG hoặc không có quyền truy cập bảng.', 1;

    IF COL_LENGTH(N'dbo.NGUOI_DUNG', N'Email') IS NULL
        ALTER TABLE dbo.NGUOI_DUNG
            ADD Email VARCHAR(254) COLLATE Latin1_General_100_CI_AS NULL;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.columns
        WHERE object_id = OBJECT_ID(N'dbo.NGUOI_DUNG')
          AND name = N'Email'
          AND system_type_id = TYPE_ID(N'varchar')
          AND max_length = 254
          AND is_nullable = 1
          AND collation_name = N'Latin1_General_100_CI_AS'
    )
        THROW 50002, N'Cột NGUOI_DUNG.Email hiện có khác định nghĩa yêu cầu. Hãy kiểm tra trước khi cập nhật.', 1;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.NGUOI_DUNG')
          AND name = N'UX_NGUOI_DUNG_Email'
    )
        EXEC(N'CREATE UNIQUE NONCLUSTERED INDEX UX_NGUOI_DUNG_Email
               ON dbo.NGUOI_DUNG (Email) WHERE Email IS NOT NULL;');

    IF EXISTS
    (
        SELECT 1
        FROM sys.indexes
        WHERE object_id = OBJECT_ID(N'dbo.NGUOI_DUNG')
          AND name = N'UX_NGUOI_DUNG_Email'
          AND (is_unique = 0 OR has_filter = 0 OR is_disabled = 1)
    )
        THROW 50005, N'Chỉ mục UX_NGUOI_DUNG_Email hiện có khác định nghĩa yêu cầu.', 1;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
-- END RECOVERY EMAIL SCHEMA

DECLARE @CopyVerifiedLecturerEmail bit = 0;
DECLARE @Backfilled int = 0;

IF @CopyVerifiedLecturerEmail = 1
BEGIN
    -- Bỏ qua email dùng chung cho nhiều tài khoản hoặc đã được tài khoản khác đăng ký.
    EXEC sys.sp_executesql N'
            WITH LinkedEmails AS
            (
                SELECT u.MaNguoiDung, candidate.Email,
                       COUNT(*) OVER (PARTITION BY candidate.Email) AS AccountCount
                FROM dbo.NGUOI_DUNG AS u
                INNER JOIN dbo.GIANG_VIEN AS g ON g.MaGV = u.MaGV
                CROSS APPLY (VALUES (LTRIM(RTRIM(g.Email)) COLLATE Latin1_General_100_CI_AS)) AS candidate(Email)
                CROSS APPLY (VALUES (CHARINDEX(''@'', candidate.Email))) AS separator(Position)
                CROSS APPLY (VALUES
                (
                    LEFT(candidate.Email, CASE WHEN separator.Position > 0 THEN separator.Position - 1 ELSE 0 END),
                    SUBSTRING(candidate.Email, separator.Position + 1, 254)
                )) AS parts(LocalPart, DomainPart)
                WHERE LEN(candidate.Email) <= 254
                  AND separator.Position BETWEEN 2 AND 65
                  AND parts.LocalPart COLLATE Latin1_General_100_BIN2 NOT LIKE ''%[^0-9A-Za-z._+%-]%''
                  AND parts.DomainPart COLLATE Latin1_General_100_BIN2 NOT LIKE ''%[^0-9A-Za-z.-]%''
                  AND parts.DomainPart LIKE ''%_.%_''
                  AND parts.LocalPart NOT LIKE ''.%''
                  AND parts.LocalPart NOT LIKE ''%.''
                  AND parts.LocalPart NOT LIKE ''%..%''
                  AND parts.DomainPart NOT LIKE ''.%''
                  AND parts.DomainPart NOT LIKE ''%.''
                  AND parts.DomainPart NOT LIKE ''%..%''
                  AND parts.DomainPart NOT LIKE ''-%''
                  AND parts.DomainPart NOT LIKE ''%-''
                  AND parts.DomainPart NOT LIKE ''%.-%''
                  AND parts.DomainPart NOT LIKE ''%-.%''
            )
            UPDATE u
            SET Email = linked.Email
            FROM dbo.NGUOI_DUNG AS u
            INNER JOIN LinkedEmails AS linked ON linked.MaNguoiDung = u.MaNguoiDung
            WHERE u.Email IS NULL
              AND linked.AccountCount = 1
              AND NOT EXISTS
              (
                  SELECT 1 FROM dbo.NGUOI_DUNG AS registered WHERE registered.Email = linked.Email
              );

            SET @Backfilled = @@ROWCOUNT;',
        N'@Backfilled int OUTPUT', @Backfilled OUTPUT;
END;

SELECT @Backfilled AS SoEmailDaBoSung;
EXEC(N'SELECT MaNguoiDung, TenDangNhap
       FROM dbo.NGUOI_DUNG
       WHERE Email IS NULL
       ORDER BY TenDangNhap;');
