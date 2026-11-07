USE QuanLyGiangVien;
GO

-- Chạy một lần cho ba danh mục; các lần sau giữ quyền quản trị viên đã chỉnh.
-- Marker dùng chung với CatalogPermissionUpgrade trong ứng dụng.
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @MaVaiTro INT;
    SELECT @MaVaiTro = MaVaiTro
    FROM dbo.VAI_TRO
    WHERE TenVaiTro = N'Quản trị viên';

    IF @MaVaiTro IS NULL
        THROW 50011, N'Không tìm thấy vai trò Quản trị viên trong database đang chọn.', 1;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.NHAT_KY_HE_THONG WITH (UPDLOCK, HOLDLOCK)
        WHERE HanhDong = N'Nâng cấp dữ liệu'
          AND NoiDung = N'CatalogPermissions.v1'
    )
    BEGIN
        DECLARE @NguoiGhiNhatKy INT;
        SELECT TOP (1) @NguoiGhiNhatKy = MaNguoiDung
        FROM dbo.NGUOI_DUNG
        ORDER BY TrangThai DESC, MaNguoiDung;

        IF @NguoiGhiNhatKy IS NULL
            THROW 50012, N'Database chưa có tài khoản để ghi nhận nâng cấp quyền danh mục.', 1;

        INSERT INTO dbo.CHUC_NANG (TenChucNang, MaForm)
        SELECT v.TenChucNang, v.MaForm
        FROM (VALUES
            (N'Quản lý học vị', 'frmDegree'),
            (N'Quản lý chức vụ', 'frmPosition'),
            (N'Quản lý chuyên môn', 'frmSpecialization')
        ) AS v(TenChucNang, MaForm)
        WHERE NOT EXISTS (
            SELECT 1 FROM dbo.CHUC_NANG c WITH (UPDLOCK, HOLDLOCK)
            WHERE c.MaForm = v.MaForm
        );

        INSERT INTO dbo.PHAN_QUYEN
            (MaVaiTro, MaChucNang, DuocXem, DuocThem, DuocSua, DuocXoa)
        SELECT @MaVaiTro, c.MaChucNang, 1, 1, 1, 1
        FROM dbo.CHUC_NANG c
        WHERE c.MaForm IN ('frmDegree', 'frmPosition', 'frmSpecialization')
        AND NOT EXISTS (
            SELECT 1 FROM dbo.PHAN_QUYEN p WITH (UPDLOCK, HOLDLOCK)
            WHERE p.MaVaiTro = @MaVaiTro
              AND p.MaChucNang = c.MaChucNang
        );

        UPDATE p
        SET DuocXem = 1, DuocThem = 1, DuocSua = 1, DuocXoa = 1
        FROM dbo.PHAN_QUYEN p
        JOIN dbo.CHUC_NANG c ON c.MaChucNang = p.MaChucNang
        WHERE p.MaVaiTro = @MaVaiTro
          AND c.MaForm IN ('frmDegree', 'frmPosition', 'frmSpecialization');

        INSERT INTO dbo.NHAT_KY_HE_THONG (MaNguoiDung, ThoiGian, HanhDong, NoiDung)
        VALUES (@NguoiGhiNhatKy, GETDATE(), N'Nâng cấp dữ liệu', N'CatalogPermissions.v1');
    END;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO

-- Có chức năng chưa có nghĩa đã có quyền: luôn xem cả vai trò và bốn cột quyền.
SELECT r.TenVaiTro, v.MaForm, c.TenChucNang,
       p.DuocXem, p.DuocThem, p.DuocSua, p.DuocXoa
FROM dbo.VAI_TRO r
CROSS JOIN (VALUES ('frmDegree'), ('frmPosition'), ('frmSpecialization')) AS v(MaForm)
LEFT JOIN dbo.CHUC_NANG c ON c.MaForm = v.MaForm
LEFT JOIN dbo.PHAN_QUYEN p ON p.MaVaiTro = r.MaVaiTro AND p.MaChucNang = c.MaChucNang
WHERE r.TenVaiTro = N'Quản trị viên'
ORDER BY v.MaForm;
GO
