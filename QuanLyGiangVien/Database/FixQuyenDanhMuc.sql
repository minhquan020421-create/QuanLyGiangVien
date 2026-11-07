USE QuanLyGiangVien;
GO

SET XACT_ABORT ON;
GO

BEGIN TRANSACTION;

-- Them chuc nang Quan ly hoc vi
IF NOT EXISTS (
    SELECT 1 FROM CHUC_NANG
    WHERE MaForm = 'frmDegree'
)
BEGIN
    INSERT INTO CHUC_NANG (TenChucNang, MaForm)
    VALUES (N'Quản lý học vị', 'frmDegree');
END;

-- Them chuc nang Quan ly chuc vu
IF NOT EXISTS (
    SELECT 1 FROM CHUC_NANG
    WHERE MaForm = 'frmPosition'
)
BEGIN
    INSERT INTO CHUC_NANG (TenChucNang, MaForm)
    VALUES (N'Quản lý chức vụ', 'frmPosition');
END;

-- Them chuc nang Quan ly chuyen mon
IF NOT EXISTS (
    SELECT 1 FROM CHUC_NANG
    WHERE MaForm = 'frmSpecialization'
)
BEGIN
    INSERT INTO CHUC_NANG (TenChucNang, MaForm)
    VALUES (N'Quản lý chuyên môn', 'frmSpecialization');
END;

-- Cap quyen cho Admin
INSERT INTO PHAN_QUYEN
    (MaVaiTro, MaChucNang, DuocXem, DuocThem, DuocSua, DuocXoa)
SELECT
    1,
    cn.MaChucNang,
    1, 1, 1, 1
FROM CHUC_NANG cn
WHERE cn.MaForm IN (
    'frmDegree',
    'frmPosition',
    'frmSpecialization'
)
AND NOT EXISTS (
    SELECT 1
    FROM PHAN_QUYEN pq
    WHERE pq.MaVaiTro = 1
      AND pq.MaChucNang = cn.MaChucNang
);

COMMIT TRANSACTION;
GO

SELECT *
FROM CHUC_NANG
WHERE MaForm IN (
    'frmDegree',
    'frmPosition',
    'frmSpecialization'
);
GO