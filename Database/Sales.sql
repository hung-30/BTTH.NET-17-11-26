CREATE DATABASE SalesDB;
GO
USE SalesDB;
GO

CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100) NOT NULL, 
    SoDienThoai VARCHAR(15) UNIQUE,
    ChucVu NVARCHAR(50)
);

CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) UNIQUE,
    DiemTichLuy INT DEFAULT 0
);

CREATE TABLE SanPham (
    MaSP VARCHAR(20) PRIMARY KEY,
    TenSP NVARCHAR(150) NOT NULL,
    GiaBan DECIMAL(18,2) CHECK (GiaBan > 0),
    SoLuongTon INT CHECK (SoLuongTon >= 0)
);

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNV INT FOREIGN KEY REFERENCES NhanVien(MaNV),
    MaKH INT NULL FOREIGN KEY REFERENCES KhachHang(MaKH),
    TongTien DECIMAL(18,2)
);

CREATE TABLE ChiTietHoaDon (
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaSP VARCHAR(20) FOREIGN KEY REFERENCES SanPham(MaSP),
    SoLuong INT CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2),
    PRIMARY KEY (MaHD, MaSP)
);

-- 1. Thêm Nhân viên (Bắt buộc phải có MaNV = 1 vì code đang gán cứng MaNV = 1)
INSERT INTO NhanVien (TenNV, SoDienThoai, ChucVu) 
VALUES (N'Nguyễn Văn Thu Ngân', '0901234567', N'Thu ngân');

-- 2. Thêm Khách hàng mẫu (MaKH sẽ tự tăng là 1)
INSERT INTO KhachHang (TenKH, DienThoai, DiemTichLuy) 
VALUES (N'Trần Thị Khách', '0987654321', 0);

-- 3. Thêm Sản phẩm mẫu (Lưu ý đúng mã SP01, SP02 để nhập trên giao diện)
INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon) VALUES 
('SP01', N'Nước ngọt Coca Cola', 15000, 50),
('SP02', N'Bánh Snack Khoai Tây', 20000, 30),
('SP03', N'Mì gói Hảo Hảo', 5000, 100);

select * from SanPham;
select * from HoaDon;
select * from KhachHang;