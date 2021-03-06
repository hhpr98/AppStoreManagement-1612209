USE [master]
GO
/****** Object:  Database [StoreManagement]    Script Date: 1/16/2019 9:51:08 PM ******/
CREATE DATABASE [StoreManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StoreManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StoreManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StoreManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StoreManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StoreManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StoreManagement] SET  MULTI_USER 
GO
ALTER DATABASE [StoreManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StoreManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StoreManagement]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaChiTietHoaDon] [nvarchar](10) NOT NULL,
	[MaHoaDon] [nvarchar](10) NULL,
	[MaSanPham] [nvarchar](10) NULL,
	[SoLuong] [int] NULL,
	[GiaBan] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaChiTietPhieuNhap] [nvarchar](10) NOT NULL,
	[MaPhieuNhap] [nvarchar](10) NULL,
	[MaSanPham] [nvarchar](10) NULL,
	[SoLuong] [int] NULL,
	[GiaNhap] [int] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaChiTietPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [nvarchar](10) NOT NULL,
	[MaKhachHang] [nvarchar](10) NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[NgayXuatHoaDon] [date] NULL,
	[TongTien] [int] NULL,
	[DiemThuong] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [nvarchar](10) NOT NULL,
	[TenKhachHang] [ntext] NULL,
	[CMND] [ntext] NULL,
	[SoDienThoai] [ntext] NULL,
	[DiemTichLuy] [int] NULL,
	[isDeleted] [int] NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSanPham] [nvarchar](10) NOT NULL,
	[TenLoaiSanPham] [ntext] NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[TenNhanVien] [ntext] NULL,
	[NgaySinh] [date] NULL,
	[SoDienThoai] [ntext] NULL,
	[DiaChi] [ntext] NULL,
	[isDeleted] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPhieuNhap] [nvarchar](10) NOT NULL,
	[NgayNhap] [date] NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[TongTien] [int] NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [nvarchar](10) NOT NULL,
	[TenSanPham] [ntext] NULL,
	[XuatXu] [ntext] NULL,
	[GiaGoc] [int] NULL,
	[GiaNhap] [int] NULL,
	[GiaBan] [int] NULL,
	[MaLoaiSanPham] [nvarchar](10) NULL,
	[HinhAnh] [ntext] NULL,
	[MoTa] [ntext] NULL,
	[SoLuong] [int] NULL,
	[isDeleted] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 1/16/2019 9:51:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [nvarchar](10) NOT NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[TenDangNhap] [ntext] NULL,
	[MatKhau] [ntext] NULL,
	[LoaiTaiKhoan] [nvarchar](10) NULL,
	[isDeleted] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD001', N'HD001', N'SP002', 1, 14990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD002', N'HD001', N'SP013', 1, 3290000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD003', N'HD002', N'SP004', 1, 4990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD004', N'HD003', N'SP005', 1, 24990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD005', N'HD003', N'SP009', 2, 3490000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD006', N'HD004', N'SP007', 1, 29990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD007', N'HD005', N'SP001', 1, 6990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD008', N'HD006', N'SP008', 1, 21990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD009', N'HD007', N'SP004', 1, 4990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD010', N'HD008', N'SP005', 1, 24990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD011', N'HD009', N'SP001', 2, 6990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD012', N'HD009', N'SP004', 1, 4990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD013', N'HD010', N'SP008', 2, 21990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD014', N'HD011', N'SP008', 1, 21990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD015', N'HD011', N'SP006', 2, 7990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD016', N'HD012', N'SP008', 1, 21990000)
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaSanPham], [SoLuong], [GiaBan]) VALUES (N'CD017', N'HD012', N'SP005', 2, 24990000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP001', N'PN001', N'SP001', 1, 6000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP002', N'PN002', N'SP004', 5, 4000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP003', N'PN002', N'SP005', 1, 24000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP004', N'PN002', N'SP012', 5, 5000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP005', N'PN003', N'SP016', 5, 7000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP006', N'PN003', N'SP001', 10, 6000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP007', N'PN004', N'SP004', 5, 4000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP008', N'PN004', N'SP002', 10, 14000000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP009', N'PN005', N'SP022', 5, 2500000)
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTietPhieuNhap], [MaPhieuNhap], [MaSanPham], [SoLuong], [GiaNhap]) VALUES (N'CP010', N'PN005', N'SP023', 10, 3500000)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD001', N'KH001', N'NV001', CAST(N'2018-03-12' AS Date), 18280000, 182)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD002', N'KH002', N'NV001', CAST(N'2019-01-15' AS Date), 4990000, 49)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD003', N'KH001', N'NV001', CAST(N'2019-01-15' AS Date), 31970000, 319)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD004', N'KH001', N'NV001', CAST(N'2019-01-16' AS Date), 29990000, 299)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD005', N'KH001', N'NV001', CAST(N'2019-01-16' AS Date), 6990000, 69)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD006', N'KH001', N'NV001', CAST(N'2019-01-16' AS Date), 20902000, 219)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD007', N'KH001', N'NV001', CAST(N'2019-01-16' AS Date), 4990000, 49)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD008', N'KH002', N'NV001', CAST(N'2019-01-16' AS Date), 24941000, 249)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD009', N'KH001', N'NV001', CAST(N'2019-01-16' AS Date), 17614000, 189)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD010', N'KH001', N'NV001', CAST(N'2019-01-16' AS Date), 43791000, 439)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD011', N'KH001', N'NV001', CAST(N'2019-01-16' AS Date), 37531000, 379)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayXuatHoaDon], [TongTien], [DiemThuong]) VALUES (N'HD012', N'KH001', N'NV001', CAST(N'2019-01-16' AS Date), 71591000, 719)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy], [isDeleted]) VALUES (N'KH001', N'Lê Tống Minh Hiếu', N'231204505', N'0351134505', 719, 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy], [isDeleted]) VALUES (N'KH002', N'Nguyễn Thành Chung', N'221342134', N'0393928455', 249, 0)
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [CMND], [SoDienThoai], [DiemTichLuy], [isDeleted]) VALUES (N'KH003', N'Cao Minh Đạt', N'242134452', N'0391842742', 10, 0)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LP001', N'Samsung')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LP002', N'OPPO')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LP003', N'iPhone')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LP004', N'Huawei')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LP005', N'iPad')
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham]) VALUES (N'LP006', N'Nokia')
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [SoDienThoai], [DiaChi], [isDeleted]) VALUES (N'NV001', N'Nguyễn Văn An', CAST(N'1997-01-02' AS Date), N'0365311323', N'191 Đồng Đen, Tân Bình, HCM', 0)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [SoDienThoai], [DiaChi], [isDeleted]) VALUES (N'NV002', N'Trần Văn Công', CAST(N'2001-03-12' AS Date), N'0374961234', N'26/35 Tổ dp 2, Phước Long, Q.9, HCM ', 0)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayNhap], [MaNhanVien], [TongTien]) VALUES (N'PN001', CAST(N'2019-01-15' AS Date), N'NV001', 6000000)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayNhap], [MaNhanVien], [TongTien]) VALUES (N'PN002', CAST(N'2019-01-15' AS Date), N'NV002', 79890000)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayNhap], [MaNhanVien], [TongTien]) VALUES (N'PN003', CAST(N'2019-01-16' AS Date), N'NV001', 109850000)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayNhap], [MaNhanVien], [TongTien]) VALUES (N'PN004', CAST(N'2019-01-16' AS Date), N'NV001', 174850000)
INSERT [dbo].[PhieuNhap] ([MaPhieuNhap], [NgayNhap], [MaNhanVien], [TongTien]) VALUES (N'PN005', CAST(N'2019-01-16' AS Date), N'NV001', 62350000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP001', N'Samsung Galaxy A7 (2018)', N'Đài Loan (Taiwan)', 6500000, 6000000, 6990000, N'LP001', N'produce\ss_a7.jpg', N'Samsung Galaxy A7 (2018) là chiếc smartphone đầu tiên của Samsung được trang bị cụm camera với 3 thấu kính có độ phân giải lần lượt là 24 MP, 8 MP và 5 MP.', 16, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP002', N'Samsung Galaxy Note 8', N'Việt Nam', 14500000, 14000000, 14990000, N'LP001', N'produce\ss_note8.jpg', N'Galaxy Note 8 trang bị camera kép xóa phông thời thượng, màn hình vô cực như trên S8 Plus, bút S Pen cùng nhiều tính năng mới và nhiều công nghệ được ưu ái1111', 19, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP003', N'Samsung Galaxy Note 9', N'Việt Nam', 22500000, 22000000, 22990000, N'LP001', N'produce\ss_note9.jpg', N'Mang lại sự cải tiến đặc biệt trong cây bút S-Pen, siêu phẩm Samsung Galaxy Note 9 còn sở hữu dung lượng pin khủng lên tới 4.000 mAh cùng hiệu năng mạnh mẽ vượt bậc.', 10, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP004', N'OPPO A7 32GB', N'Việt Nam', 4500000, 4000000, 4990000, N'LP002', N'produce\op_a7.jpg', N' OPPO A7 đã đem đến cho người dùng những màu sắc mới đáng để lựa chọn với mặt lưng 3D cùng màn hình giọt nước siêu tràn viền.', 21, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP005', N'iPhoneX 64GB (2018)', N'USA - USA', 24500000, 24000000, 24990000, N'LP003', N'produce\ip_X64.jpg', N'iPhone X là cụm từ được rất nhiều người mong chờ muốn biết và tìm kiếm trên Google bởi đây là chiếc điện thoại mà Apple kỉ niệm 10 năm iPhone đầu tiên được bán ra.', 7, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP006', N'Samsung A7 (2018) 128GB', N'Việt Nam', 7500000, 7000000, 7990000, N'LP001', N'produce\ss_a7_128GB.jpg', N'Được nâng cấp cả RAM và bộ nhớ trong, Samsung Galaxy A7 (2018) 128GB đem lại khả năng đa nhiệm, lưu trữ tốt hơn.', 3, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP007', N'iPhoneX 256GB 2018', N'USA', 29500000, 29000000, 29990000, N'LP003', N'produce\ip_X64.jpg', N'iPhone X là cụm từ được rất nhiều người mong chờ muốn biết và tìm kiếm trên Google bởi đây là chiếc điện thoại mà Apple kỉ niệm 10 năm iPhone đầu tiên được bán ra.', 4, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP008', N'Huawei Mate 20 Pro', N'Trung Quốc', 21500000, 21000000, 21990000, N'LP004', N'produce\hw_20p.jpg', N'Thế hệ siêu phẩm mới của Huawei chính thức lộ diện với cái tên Huawei Mate 20 Pro, chiếc điện thoại thu hút trong thiết kế, mạnh mẽ trong hiệu năng cùng một hệ thống camera ấn tượng.', 23, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP009', N'Samsung Galaxy J4', N'Việt Nam', 3000000, 2500000, 3490000, N'LP001', N'produce\ss_j4.jpg', N'Đặc điểm nổi bật của Samsung Galaxy J4
Tìm hiểu thêm

Samsung Galaxy J4 là cái tên tiếp theo thuộc dòng J mà Samsung mới ra mắt với một số tính năng nổi bật nhằm cạnh tranh với các đối thủ trong phân khúc smartphone giá rẻ.', 1, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP010', N'iPad Wifi Cellular 32GB (2018)', N'USA', 11500000, 11000000, 11990000, N'LP005', N'produce\ipad_2018.jpg', N'Máy tính bảng iPad 6th Wifi Cellular 32 GB mang trong mình cấu hình mạnh mẽ cùng giá thành hợp lý.', 20, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP011', N'Samsung Galaxy A8 Star', N'Việt Nam', 8500000, 8000000, 8990000, N'LP001', N'produce\ss_a8star.jpg', N'Samsung Galaxy A8 Star là một biến thể mới của dòng A trong gia đình Samsung với sự nâng cấp vượt trội về camera cũng như thay đổi trong thiết kế.', 20, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP012', N'Samsung Galaxy A6+ (2018)', N'Việt Nam', 5500000, 5000000, 5990000, N'LP001', N'produce\ss_a6plus.jpg', N'Sau nhiều đồn đoán thì cuối cùng Samsung Galaxy A6+ (2018) đã chính thức được Samsung  giới thiệu với một chút đổi mới trong thiết kế cũng như về camera của máy.', 10, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP013', N'OPPO A3s 16GB 2019', N'Trung Quốc', 3000000, 2800000, 3290000, N'LP002', N'produce\op_a3s.jpg', N'OPPO A3s 16GB là một chiếc smartphone giá rẻ hiếm hoi trên thị trường sở hữu những tính năng khá hấp dẫn trong năm 2018 đó là camera kép ở mặt lưng và màn hình tai thỏ ở mặt trước.', 5, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP014', N'OPPO A3s 32GB 2019', N'Trung Quốc', 4500000, 4000000, 4690000, N'LP002', N'produce\op_a3s.jpg', N'OPPO A3s 32GB là một chiếc smartphone mới của OPPO sở hữu giá rẻ hiếm hoi nhưng vẫn được trang bị màn hình tai thỏ và camera kép xu thế của năm 2018.', 10, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP015', N'Huawei Y7 Pro (2019)', N'Trung Quốc', 3500000, 3000000, 3990000, N'LP004', N'produce\hw_y7.jpg', N' Y7 Pro (2019) đã giúp Huawei có thêm điểm cộng trong mắt người dùng nhờ việc đem thiết kế mặt lưng gradient, màn hình giọt nước và pin khủng lên chiếc smartphone giá rẻ của mình.', 20, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP016', N'Nokia 8.1', N'USA', 7500000, 7000000, 7990000, N'LP006', N'produce\nk_81.jpg', N'Nokia 8.1 (là phiên bản quốc tế của Nokia X7), chiếc smartphone trong phân khúc cận cao cấp vừa được trình làng, sở hữu một cấu hình cao cấp kèm theo đó là sự nâng cấp mạnh mẽ về hệ thống camera.', 25, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP017', N'OPPO F9', N'Trung Quốc', 6500000, 6000000, 6990000, N'LP002', N'produce\op_f9.jpg', N'Là chiếc điện thoại OPPO mới nhất sở hữu công nghệ sạc VOOC đột phá, thiết kế mặt lưng chuyển màu độc đáo, màn hình tràn viền giọt nước và camera chụp chân dung tích hợp trí tuệ nhân tạo A.I hoàn hảo.', 20, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP018', N'OPPO A7 64GB', N'Việt Nam', 6500000, 6000000, 6990000, N'LP002', N'produce\op_a7.jpg', N' OPPO A7 đã đem đến cho người dùng những màu sắc mới đáng để lựa chọn với mặt lưng 3D cùng màn hình giọt nước siêu tràn viền.', 20, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP019', N'Samsung Galaxy Note 7', N'Việt Nam', 12500000, 12000000, 12990000, N'LP001', N'produce\ss_note8.jpg', N'Galaxy Note 7 trang bị camera kép xóa phông thời thượng, màn hình vô cực như trên S8 Plus, bút S Pen cùng nhiều tính năng mới và nhiều công nghệ được ưu ái.', 20, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP020', N'OPPO J3', N'Việt Nam', 2500000, 2000000, 2990000, N'LP002', N'produce\default.jpg', N'Không có mô tả', 10, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP021', N'oppo j1', N'Việt Nam', 2000000, 1800000, 2490000, N'LP002', N'produce\default.jpg', N'Điện thoại oppo', 10, 0)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP022', N'OPPO Neo7', N'Việt Nam', 3000000, 2500000, 3490000, N'LP002', N'produce\default.jpg', N'điện thoại OPPO Neo7 thế hệ 2019', 15, 1)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [XuatXu], [GiaGoc], [GiaNhap], [GiaBan], [MaLoaiSanPham], [HinhAnh], [MoTa], [SoLuong], [isDeleted]) VALUES (N'SP023', N'oppo neo5', N'Việt Nam', 4000000, 3500000, 4490000, N'LP002', N'produce\default.jpg', N'Không có mô tả', 20, 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau], [LoaiTaiKhoan], [isDeleted]) VALUES (N'TK001', NULL, N'admin', N'123', N'1', 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau], [LoaiTaiKhoan], [isDeleted]) VALUES (N'TK002', N'NV001', N'nhanvien1', N'nhanvien', N'0', 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau], [LoaiTaiKhoan], [isDeleted]) VALUES (N'Tk003', N'NV002', N'nhanvien2', N'nhanvien', N'0', 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau], [LoaiTaiKhoan], [isDeleted]) VALUES (N'TK004', N'NV001', N'hieu', N'123', N'0', 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau], [LoaiTaiKhoan], [isDeleted]) VALUES (N'TK005', N'NV001', N'an', N'123', N'0', 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau], [LoaiTaiKhoan], [isDeleted]) VALUES (N'TK006', N'NV001', N'anan', N'123', N'0', 0)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [MaNhanVien], [TenDangNhap], [MatKhau], [LoaiTaiKhoan], [isDeleted]) VALUES (N'TK007', N'NV001', N'vanan', N'123', N'0', 0)
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_SanPham]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([MaPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([MaPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_SanPham]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhanVien]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([MaLoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSanPham])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [StoreManagement] SET  READ_WRITE 
GO
