

-- Tạo bảng tblTheLoai
CREATE TABLE tblTheLoai(
    MaLoai NVARCHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(50)
);

-- Dữ liệu cho bảng tblTheLoai
INSERT INTO tblTheLoai (MaLoai, TenLoai)
VALUES
('TL001', 'Áo thun'),
('TL002', 'Quần jeans'),
('TL003', 'Giày thể thao'),
('TL004', 'Áo sơ mi');

-- Tạo bảng tblSanPham
CREATE TABLE tblSanPham(
    MaSP NVARCHAR(10) PRIMARY KEY,
    TenSP NVARCHAR(50),
    MaLoai NVARCHAR(10),
    FOREIGN KEY (MaLoai) REFERENCES tblTheLoai(MaLoai)
);

-- Dữ liệu cho bảng tblSanPham
INSERT INTO tblSanPham (MaSP, TenSP, MaLoai)
VALUES
('SP001', 'Áo thun nam', 'TL001'),
('SP002', 'Áo thun nữ', 'TL001'),
('SP003', 'Quần jeans nam', 'TL002'),
('SP004', 'Giày thể thao nam', 'TL003'),
('SP005', 'Áo sơ mi nam', 'TL004');

-- Tạo bảng tblNhanVien
CREATE TABLE tblNhanVien(
    MaNV NVARCHAR(10) PRIMARY KEY,
    TenNV NVARCHAR(50),
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    DienThoai NVARCHAR(15)
);

-- Dữ liệu cho bảng tblNhanVien
INSERT INTO tblNhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DienThoai)
VALUES
('NV001', 'Nguyễn Văn A', 'Nam', '1990-05-10', '0123456789'),
('NV002', 'Trần Thị B', 'Nữ', '1992-07-22', '0987654321'),
('NV003', 'Phạm Minh C', 'Nam', '1988-11-15', '0912345678');

-- Tạo bảng tblNhaCungCap
CREATE TABLE tblNhaCungCap(
    MaNCC NVARCHAR(10) PRIMARY KEY,
    TenNCC NVARCHAR(50),
    DiaChi NVARCHAR(50),
    DienThoai NVARCHAR(15)
);

-- Dữ liệu cho bảng tblNhaCungCap
INSERT INTO tblNhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai)
VALUES
('NCC001', 'Công ty Thời Trang A', 'Hà Nội', '0241234567'),
('NCC002', 'Công ty Giày Dép B', 'Hồ Chí Minh', '0282345678');

-- Tạo bảng tblHoaDonBan
CREATE TABLE tblHoaDonBan(
    SoHDB NVARCHAR(20) PRIMARY KEY,
    MaQuanAo NVARCHAR(10),
    SoLuong INT,
    GiamGia DECIMAL(10, 2),
    ThanhTien DECIMAL(10, 2),
    FOREIGN KEY (MaQuanAo) REFERENCES tblSanPham(MaSP)
);

-- Dữ liệu cho bảng tblHoaDonBan
INSERT INTO tblHoaDonBan (SoHDB, MaQuanAo, SoLuong, GiamGia, ThanhTien)
VALUES
('HDB001', 'SP001', 3, 10, 450000),
('HDB002', 'SP002', 2, 5, 400000),
('HDB003', 'SP003', 1, 15, 300000);

-- Tạo bảng tblChiTietHDBan
CREATE TABLE tblChiTietHDBan(
    SoHDB NVARCHAR(20),
    MaNV NVARCHAR(10),
    NgayBan DATE,
    TongTien DECIMAL(10, 2),
    PRIMARY KEY (SoHDB),
    FOREIGN KEY (SoHDB) REFERENCES tblHoaDonBan(SoHDB),
    FOREIGN KEY (MaNV) REFERENCES tblNhanVien(MaNV)
);

-- Dữ liệu cho bảng tblChiTietHDBan
INSERT INTO tblChiTietHDBan (SoHDB, MaNV, NgayBan, TongTien)
VALUES
('HDB001', 'NV001', '2025-05-01', 450000),
('HDB002', 'NV002', '2025-05-02', 400000),
('HDB003', 'NV003', '2025-05-03', 300000);

-- Tạo bảng tblHoaDonNhap
CREATE TABLE tblHoaDonNhap(
    SoHDN NVARCHAR(20) PRIMARY KEY,
    MaQuanAo NVARCHAR(10),
    NgayNhap DATE,
    MaNCC NVARCHAR(10),
    FOREIGN KEY (MaQuanAo) REFERENCES tblSanPham(MaSP),
    FOREIGN KEY (MaNCC) REFERENCES tblNhaCungCap(MaNCC)
);

-- Dữ liệu cho bảng tblHoaDonNhap
INSERT INTO tblHoaDonNhap (SoHDN, MaQuanAo, NgayNhap, MaNCC)
VALUES
('HDN001', 'SP001', '2025-04-01', 'NCC001'),
('HDN002', 'SP002', '2025-04-05', 'NCC002');

-- Tạo bảng tblChiTietHDNhap
CREATE TABLE tblChiTietHDNhap(
    SoHDN NVARCHAR(20),
    MaNV NVARCHAR(10),
    NgayNhap DATE,
    SoLuong INT,
    GiaNhap DECIMAL(10, 2),
    PRIMARY KEY (SoHDN),
    FOREIGN KEY (SoHDN) REFERENCES tblHoaDonNhap(SoHDN),
    FOREIGN KEY (MaNV) REFERENCES tblNhanVien(MaNV)
);

-- Dữ liệu cho bảng tblChiTietHDNhap
INSERT INTO tblChiTietHDNhap (SoHDN, MaNV, NgayNhap, SoLuong, GiaNhap)
VALUES
('HDN001', 'NV001', '2025-04-01', 100, 150000),
('HDN002', 'NV002', '2025-04-05', 50, 200000);

-- Tạo bảng tblCo
CREATE TABLE tblCo(
    MaCo NVARCHAR(10) PRIMARY KEY,
    TenCo NVARCHAR(50)
);

-- Dữ liệu cho bảng tblCo
INSERT INTO tblCo (MaCo, TenCo)
VALUES
('CO001', 'S'),
('CO002', 'M'),
('CO003', 'L'),
('CO004', 'XL');

-- Tạo bảng tblChatLieu
CREATE TABLE tblChatLieu(
    MaChatLieu NVARCHAR(10) PRIMARY KEY,
    TenChatLieu NVARCHAR(50)
);

-- Dữ liệu cho bảng tblChatLieu
INSERT INTO tblChatLieu (MaChatLieu, TenChatLieu)
VALUES
('CL001', 'Cotton'),
('CL002', 'Polyester'),
('CL003', 'Denim'),
('CL004', 'Linen');

-- Tạo bảng tblMau
CREATE TABLE tblMau(
    MaMau NVARCHAR(10) PRIMARY KEY,
    TenMau NVARCHAR(50)
);

-- Dữ liệu cho bảng tblMau
INSERT INTO tblMau (MaMau, TenMau)
VALUES
('M001', 'Đỏ'),
('M002', 'Xanh'),
('M003', 'Trắng'),
('M004', 'Đen');

-- Tạo bảng tblDoiTuong
CREATE TABLE tblDoiTuong(
    MaDoiTuong NVARCHAR(10) PRIMARY KEY,
    TenDoiTuong NVARCHAR(50)
);

-- Dữ liệu cho bảng tblDoiTuong
INSERT INTO tblDoiTuong (MaDoiTuong, TenDoiTuong)
VALUES
('DT001', 'Nam'),
('DT002', 'Nữ'),
('DT003', 'Trẻ em'),
('DT004', 'Unisex');

-- Tạo bảng tblMua
CREATE TABLE tblMua(
    MaMua NVARCHAR(10) PRIMARY KEY,
    TenMua NVARCHAR(50)
);

-- Dữ liệu cho bảng tblMua
INSERT INTO tblMua (MaMua, TenMua)
VALUES
('MUA001', 'Mùa hè'),
('MUA002', 'Mùa đông'),
('MUA003', 'Mùa thu'),
('MUA004', 'Mùa xuân');

SELECT *
FROM tblMua;
