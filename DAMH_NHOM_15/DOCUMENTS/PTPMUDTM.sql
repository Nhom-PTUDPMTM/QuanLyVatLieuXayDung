CREATE DATABASE QLVLXD

USE QLVLXD
GO

CREATE TABLE [LoaiHang] (
  [MaLoai] char(10) PRIMARY KEY,
  [TenLoai] nvarchar(20),
  [TinhTrang] nvarchar(30)
)
GO

CREATE TABLE [HangHoa] (
  [MaHH] char(10) PRIMARY KEY,
  [TenHH] nvarchar(30),
  [MaLoai] char(10),
  [DonVi] nvarchar(10),
  [DonGia] float,
  [SoLuongTon] int
)
GO

CREATE TABLE [KhachHang] (
  [MaKH] char(10) PRIMARY KEY,
  [TenKH] nvarchar(30),
  [MatKhau] nvarchar(30),
  [GioiTinh] nvarchar(10),
  [NgaySinh] date,
  [DiaChi] nvarchar(30),
  [SDT] varchar(20),
  [LoaiKH] varchar(10)
)
GO

CREATE TABLE [NhanVien] (
  [MaNV] char(10) PRIMARY KEY,
  [TenNV] nvarchar(30),
  [MatKhau] nvarchar(30),
  [GioiTinh] nvarchar(10),
  [NgaySinh] date,
  [DiaChi] nvarchar(30),
  [SDT] varchar(20),
  [ChucVu] nvarchar(20)
)
GO

CREATE TABLE [PhieuXuat] (
  [MaHDXuat] char(10) PRIMARY KEY,
  [MaKH] char(10),
  [MaNV] char(10),
  [NgayXuat] date,
  [TinhTrang] nvarchar(30),
  [ThanhTien] float
)
GO

CREATE TABLE [ChiTietPhieuXuat] (
  [MaHH] char(10),
  [MaHDXuat] char(10),
  [SLXuat] int,
  [DonGiaXuat] float,
  [ThanhTien] float,
  PRIMARY KEY ([MaHH], [MaHDXuat])
)
GO

CREATE TABLE [NhaCC] (
  [MaNCC] char(10) PRIMARY KEY,
  [TenNCC] nvarchar(30),
  [DiaChi] nvarchar(20),
  [SDT] varchar(20)
)
GO

CREATE TABLE [CungUng] (
  [MaNCC] char(10),
  [MaHH] char(10),
  [TrangThai] nvarchar(50),
  PRIMARY KEY ([MaNCC], [MaHH])
)
GO

CREATE TABLE [PhieuNhap] (
  [MaHDNhap] char(10) PRIMARY KEY,
  [MaNCC] char(10),
  [MaNV] char(10),
  [NgayNhap] date,
  [TinhTrang] nvarchar(30),
  [ThanhTien] float
)
GO

CREATE TABLE [ChiTietPhieuNhap] (
  [MaHH] char(10),
  [MaHDNhap] char(10),
  [SLNhap] int,
  [DonGiaNhap] float,
  [ThanhTien] float,
  PRIMARY KEY ([MaHH], [MaHDNhap])
)
GO

CREATE TABLE [DonHang] (
  [MaTK] char(10),
  [MaPX] char(10),
  [ThanhTien] float,
  [TinhTrang] nvarchar(30),
  [GhiChu] nvarchar(100),
  [NgayDat] date,
  [NgayGiao] date,
  [ViTri] nvarchar(100),
  PRIMARY KEY ([MaTK], [MaPX])
)
GO

CREATE TABLE [GiaoHang] (
  [MaGH] char(10) PRIMARY KEY,
  [MaPX] char(10),
  [ViTri] nvarchar(100)
)
GO

CREATE TABLE [ChiTietGiaoHang] (
  [MaGH] char(10),
  [MaSP] char(10),
  [MaNV] char(10),
  [NgayGiao] date,
  [SoLuongGiao] int,
  [SoLuongCon] int,
  PRIMARY KEY ([MaGH], [MaSP], [NgayGiao])
)
GO

ALTER TABLE [HangHoa] ADD CONSTRAINT [fk_HangHoa_LoaiHang] FOREIGN KEY ([MaLoai]) REFERENCES [LoaiHang] ([MaLoai])
GO

ALTER TABLE [PhieuXuat] ADD CONSTRAINT [fk_PhieuXuat_KhachHang] FOREIGN KEY ([MaKH]) REFERENCES [KhachHang] ([MaKH])
GO

ALTER TABLE [PhieuXuat] ADD CONSTRAINT [fk_PhieuXuat_NhanVien] FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO

ALTER TABLE [ChiTietPhieuXuat] ADD CONSTRAINT [fk_CT_PhieuXuat_PX] FOREIGN KEY ([MaHDXuat]) REFERENCES [PhieuXuat] ([MaHDXuat])
GO

ALTER TABLE [ChiTietPhieuXuat] ADD CONSTRAINT [fk_CT_PhieuXuat_HangHoa] FOREIGN KEY ([MaHH]) REFERENCES [HangHoa] ([MaHH])
GO

ALTER TABLE [CungUng] ADD CONSTRAINT [fk_CungUng_NhaCC] FOREIGN KEY ([MaNCC]) REFERENCES [NhaCC] ([MaNCC])
GO

ALTER TABLE [CungUng] ADD CONSTRAINT [fk_CungUng_HangHoa] FOREIGN KEY ([MaHH]) REFERENCES [HangHoa] ([MaHH])
GO

ALTER TABLE [PhieuNhap] ADD CONSTRAINT [fk_PhieuNhap_NhaCC] FOREIGN KEY ([MaNCC]) REFERENCES [NhaCC] ([MaNCC])
GO

ALTER TABLE [PhieuNhap] ADD CONSTRAINT [fk_PhieuNhap_NhanVien] FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO

ALTER TABLE [ChiTietPhieuNhap] ADD CONSTRAINT [fk_CT_PhieuNhap_PN] FOREIGN KEY ([MaHDNhap]) REFERENCES [PhieuNhap] ([MaHDNhap])
GO

ALTER TABLE [ChiTietPhieuNhap] ADD CONSTRAINT [fk_CT_PhieuNhap_HangHoa] FOREIGN KEY ([MaHH]) REFERENCES [HangHoa] ([MaHH])
GO

ALTER TABLE [DonHang] ADD CONSTRAINT [fk_DonHang_KhachHang] FOREIGN KEY ([MaTK]) REFERENCES [KhachHang] ([MaKH])
GO

ALTER TABLE [DonHang] ADD CONSTRAINT [fk_DonHang_PhieuXuat] FOREIGN KEY ([MaPX]) REFERENCES [PhieuXuat] ([MaHDXuat])
GO

ALTER TABLE [GiaoHang] ADD CONSTRAINT [fk_GiaoHang_PhieuXuat] FOREIGN KEY ([MaPX]) REFERENCES [PhieuXuat] ([MaHDXuat])
GO

ALTER TABLE [ChiTietGiaoHang] ADD CONSTRAINT [fk_ChiTietGiaoHang_GiaoHang] FOREIGN KEY ([MaGH]) REFERENCES [GiaoHang] ([MaGH])
GO

ALTER TABLE [ChiTietGiaoHang] ADD CONSTRAINT [fk_ChiTietGiaoHang_SanPham] FOREIGN KEY ([MaSP]) REFERENCES [HangHoa] ([MaHH])
GO

ALTER TABLE [ChiTietGiaoHang] ADD CONSTRAINT [fk_ChiTietGiaoHang_NhanVien] FOREIGN KEY ([MaNV]) REFERENCES [NhanVien] ([MaNV])
GO


INSERT INTO LoaiHang (MaLoai, TenLoai, TinhTrang) 
VALUES 
('LH001', 'Cement', 'Available'),
('LH002', 'Steel', 'Available'),
('LH003', 'Bricks', 'Out of stock'),
('LH004', 'Tiles', 'Available'),
('LH005', 'Glass', 'Limited');

INSERT INTO HangHoa (MaHH, TenHH, MaLoai, DonVi, DonGia, SoLuongTon) 
VALUES 
('HH001', 'Cement Bag', 'LH001', 'Bag', 50.0, 100),
('HH002', 'Steel Rod', 'LH002', 'Piece', 100.0, 50),
('HH003', 'Red Brick', 'LH003', 'Piece', 1.0, 0),
('HH004', 'Floor Tile', 'LH004', 'Box', 30.0, 200),
('HH005', 'Glass Panel', 'LH005', 'Piece', 150.0, 10);

INSERT INTO KhachHang (MaKH, TenKH, MatKhau, GioiTinh, NgaySinh, DiaChi, SDT, LoaiKH) 
VALUES 
('KH001', 'John Doe', 'password1', 'Male', '1985-06-15', '123 Main St', '0912345678', 'Retail'),
('KH002', 'Jane Smith', 'password2', 'Female', '1990-09-25', '456 Elm St', '0912345679', 'Wholesale'),
('KH003', 'Alice Johnson', 'password3', 'Female', '1982-12-30', '789 Oak St', '0912345680', 'Retail'),
('KH004', 'Bob Brown', 'password4', 'Male', '1975-03-10', '321 Pine St', '0912345681', 'Wholesale'),
('KH005', 'Charlie Green', 'password5', 'Male', '1995-08-12', '654 Cedar St', '0912345682', 'Retail');

INSERT INTO NhanVien (MaNV, TenNV, MatKhau, GioiTinh, NgaySinh, DiaChi, SDT, ChucVu) 
VALUES 
('NV001', 'David Lee', 'nvpassword1', 'Male', '1980-01-01', '987 Maple St', '0912345683', 'Manager'),
('NV002', 'Emily Davis', 'nvpassword2', 'Female', '1987-02-02', '654 Birch St', '0912345684', 'Staff'),
('NV003', 'Frank Wilson', 'nvpassword3', 'Male', '1992-03-03', '321 Spruce St', '0912345685', 'Staff'),
('NV004', 'Grace Young', 'nvpassword4', 'Female', '1994-04-04', '789 Fir St', '0912345686', 'Supervisor'),
('NV005', 'Henry Walker', 'nvpassword5', 'Male', '1985-05-05', '123 Willow St', '0912345687', 'Staff');

INSERT INTO PhieuXuat (MaHDXuat, MaKH, MaNV, NgayXuat, TinhTrang, ThanhTien) 
VALUES 
('PX001', 'KH001', 'NV001', '2024-10-10', 'Completed', 500.0),
('PX002', 'KH002', 'NV002', '2024-10-11', 'Pending', 1000.0),
('PX003', 'KH003', 'NV003', '2024-10-12', 'Completed', 300.0),
('PX004', 'KH004', 'NV004', '2024-10-13', 'Pending', 200.0),
('PX005', 'KH005', 'NV005', '2024-10-14', 'Completed', 700.0);

INSERT INTO ChiTietPhieuXuat (MaHH, MaHDXuat, SLXuat, DonGiaXuat, ThanhTien) 
VALUES 
('HH001', 'PX001', 10, 50.0, 500.0),
('HH002', 'PX002', 5, 100.0, 500.0),
('HH003', 'PX003', 300, 1.0, 300.0),
('HH004', 'PX004', 6, 30.0, 180.0),
('HH005', 'PX005', 2, 150.0, 300.0);

INSERT INTO NhaCC (MaNCC, TenNCC, DiaChi, SDT) 
VALUES 
('NCC001', 'ABC Supplies', '123 Industry Rd', '0987654321'),
('NCC002', 'DEF Materials', '456 Commerce St', '0987654322'),
('NCC003', 'GHI Distributors', '789 Trade Ave', '0987654323'),
('NCC004', 'JKL Builders', '321 Construction Dr', '0987654324'),
('NCC005', 'MNO Traders', '654 Supply Blvd', '0987654325');


INSERT INTO CungUng (MaNCC, MaHH, TrangThai) 
VALUES 
('NCC001', 'HH001', 'Delivered'),
('NCC002', 'HH002', 'Pending'),
('NCC003', 'HH003', 'Delivered'),
('NCC004', 'HH004', 'Pending'),
('NCC005', 'HH005', 'Delivered');

INSERT INTO PhieuNhap (MaHDNhap, MaNCC, MaNV, NgayNhap, TinhTrang, ThanhTien) 
VALUES 
('PN001', 'NCC001', 'NV001', '2024-10-01', 'Completed', 1000.0),
('PN002', 'NCC002', 'NV002', '2024-10-02', 'Completed', 1500.0),
('PN003', 'NCC003', 'NV003', '2024-10-03', 'Completed', 500.0),
('PN004', 'NCC004', 'NV004', '2024-10-04', 'Pending', 200.0),
('PN005', 'NCC005', 'NV005', '2024-10-05', 'Completed', 750.0);

INSERT INTO ChiTietPhieuNhap (MaHH, MaHDNhap, SLNhap, DonGiaNhap, ThanhTien) 
VALUES 
('HH001', 'PN001', 20, 50.0, 1000.0),
('HH002', 'PN002', 15, 100.0, 1500.0),
('HH003', 'PN003', 500, 1.0, 500.0),
('HH004', 'PN004', 7, 30.0, 210.0),
('HH005', 'PN005', 5, 150.0, 750.0);

INSERT INTO DonHang (MaTK, MaPX, ThanhTien, TinhTrang, GhiChu, NgayDat, NgayGiao, ViTri) 
VALUES 
('KH001', 'PX001', 500.0, 'Delivered', 'Urgent order', '2024-10-10', '2024-10-12', '123 Main St'),
('KH002', 'PX002', 1000.0, 'Pending', 'Large order', '2024-10-11', '2024-10-13', '456 Elm St'),
('KH003', 'PX003', 300.0, 'Delivered', 'Fast delivery', '2024-10-12', '2024-10-14', '789 Oak St'),
('KH004', 'PX004', 200.0, 'Pending', 'Scheduled delivery', '2024-10-13', '2024-10-15', '321 Pine St'),
('KH005', 'PX005', 700.0, 'Delivered', 'Fragile items', '2024-10-14', '2024-10-16', '654 Cedar St');

INSERT INTO GiaoHang (MaGH, MaPX, ViTri) 
VALUES 
('GH001', 'PX001', '123 Main St'),
('GH002', 'PX002', '456 Elm St'),
('GH003', 'PX003', '789 Oak St'),
('GH004', 'PX004', '321 Pine St'),
('GH005', 'PX005', '654 Cedar St');

INSERT INTO ChiTietGiaoHang (MaGH, MaSP, MaNV, NgayGiao, SoLuongGiao, SoLuongCon) 
VALUES 
('GH001', 'HH001', 'NV001', '2024-10-12', 10, 0),
('GH002', 'HH002', 'NV002', '2024-10-13', 5, 0),
('GH003', 'HH003', 'NV003', '2024-10-14', 300, 0),
('GH004', 'HH004', 'NV004', '2024-10-15', 6, 0),
('GH005', 'HH005', 'NV005', '2024-10-16', 2, 0);
