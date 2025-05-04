
-- Bảng Khách hàng
CREATE TABLE tblKhach (
    Makhach NVARCHAR(10) PRIMARY KEY,
    Tenkhach NVARCHAR(50),
    Diachi NVARCHAR(50),
    Dienthoai NVARCHAR(15)
);

-- Bảng Nhân viên
CREATE TABLE tblNhanVien (
    MaNV NVARCHAR(10) PRIMARY KEY,
    TenNV NVARCHAR(50),
    Diachi NVARCHAR(50),
    Dienthoai NVARCHAR(15)
);

-- Bảng Quần áo
CREATE TABLE tblQuanAo (
    MaQA NVARCHAR(10) PRIMARY KEY,
    TenQA NVARCHAR(50),
    DonGiaNhap DECIMAL(18,2),
    DonGiaBan DECIMAL(18,2),
    SoLuong INT
);

-- Bảng Hóa đơn nhập
CREATE TABLE tblHoaDonNhap (
    MaHDN NVARCHAR(10) PRIMARY KEY,
    MaNV NVARCHAR(10),
    NgayNhap DATE,
    FOREIGN KEY (MaNV) REFERENCES tblNhanVien(MaNV)
);

-- Bảng Hóa đơn bán
CREATE TABLE tblHoaDonBan (
    MaHDB NVARCHAR(10) PRIMARY KEY,
    MaNV NVARCHAR(10),
    Makhach NVARCHAR(10),
    NgayBan DATE,
    FOREIGN KEY (MaNV) REFERENCES tblNhanVien(MaNV),
    FOREIGN KEY (Makhach) REFERENCES tblKhach(Makhach)
);


-- Dữ liệu mẫu cho bảng tblKhach
INSERT INTO tblKhach (Makhach, Tenkhach, Diachi, Dienthoai) VALUES
('KH001', 'Nguyen Van A', 'Hanoi', '0901234567'),
('KH002', 'Le Thi B', 'HCM', '0912345678');

-- Dữ liệu mẫu cho bảng tblNhanVien
INSERT INTO tblNhanVien (MaNV, TenNV, Diachi, Dienthoai) VALUES
('NV001', 'Tran Van C', 'Danang', '0923456789'),
('NV002', 'Pham Thi D', 'Hue', '0934567890');

-- Dữ liệu mẫu cho bảng tblQuanAo
INSERT INTO tblQuanAo (MaQA, TenQA, DonGiaNhap, DonGiaBan, SoLuong) VALUES
('QA001', 'Ao thun', 100000, 150000, 50),
('QA002', 'Quan jeans', 150000, 200000, 30),
('QA003', 'Ao khoac', 200000, 250000, 20),
('QA004', 'Quan tay', 120000, 180000, 40);

-- Dữ liệu mẫu cho bảng tblHoaDonNhap
INSERT INTO tblHoaDonNhap (MaHDN, MaNV, NgayNhap) VALUES
('HDN001', 'NV001', '2024-04-01'),
('HDN002', 'NV002', '2024-04-02');

-- Dữ liệu mẫu cho bảng tblHoaDonBan
INSERT INTO tblHoaDonBan (MaHDB, MaNV, Makhach, NgayBan) VALUES
('HDB001', 'NV001', 'KH001', '2024-05-01'),
('HDB002', 'NV002', 'KH002', '2024-05-02');

SELECT
  *
FROM tblHoaDonBan;