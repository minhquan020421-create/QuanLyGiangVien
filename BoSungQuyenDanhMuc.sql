USE QuanLyGiangVien;
GO

SET XACT_ABORT ON;
BEGIN TRANSACTION;

DECLARE @MaVaiTro INT;

SELECT @MaVaiTro = MaVaiTro
FROM NGUOI_DUNG
WHERE TenDangNhap = 'admin';

IF @MaVaiTro IS NULL
BEGIN
    ROLLBACK;
    THROW 50001, N'Không tìm thấy tài khoản admin.', 1;
END;

INSERT INTO CHUC_NANG (TenChucNang, MaForm)
SELECT v.TenChucNang, v.MaForm
FROM (VALUES
    (N'Quản lý học vị', 'frmDegree'),
    (N'Quản lý chức vụ', 'frmPosition'),
    (N'Quản lý chuyên môn', 'frmSpecialization')
) AS v(TenChucNang, MaForm)
WHERE NOT EXISTS (
    SELECT 1 FROM CHUC_NANG c
    WHERE c.MaForm = v.MaForm
);

INSERT INTO PHAN_QUYEN
    (MaVaiTro, MaChucNang, DuocXem, DuocThem, DuocSua, DuocXoa)
SELECT @MaVaiTro, c.MaChucNang, 1, 1, 1, 1
FROM CHUC_NANG c
WHERE c.MaForm IN ('frmDegree', 'frmPosition', 'frmSpecialization')
AND NOT EXISTS (
    SELECT 1 FROM PHAN_QUYEN p
    WHERE p.MaVaiTro = @MaVaiTro
      AND p.MaChucNang = c.MaChucNang
);

UPDATE p
SET DuocXem = 1, DuocThem = 1, DuocSua = 1, DuocXoa = 1
FROM PHAN_QUYEN p
JOIN CHUC_NANG c ON c.MaChucNang = p.MaChucNang
WHERE p.MaVaiTro = @MaVaiTro
  AND c.MaForm IN ('frmDegree', 'frmPosition', 'frmSpecialization');

COMMIT;

SELECT c.TenChucNang, p.DuocXem, p.DuocThem, p.DuocSua, p.DuocXoa
FROM PHAN_QUYEN p
JOIN CHUC_NANG c ON c.MaChucNang = p.MaChucNang
WHERE p.MaVaiTro = @MaVaiTro
  AND c.MaForm IN ('frmDegree', 'frmPosition', 'frmSpecialization');