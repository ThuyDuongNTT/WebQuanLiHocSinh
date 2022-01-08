
/****** Object:  database  QLDiem   Script Date: 12/31/2022 7:25:52 AM ******/
create  database DB_QuanLiDiem
go
use [DB_QuanLiDiem] 
go
GO

/****** Object:  Table [dbo].[THocSinh] ******/
CREATE TABLE [dbo].[HocSinh](
	[MaHS] [bigint] IDENTITY(1,1) NOT NULL,
	[TenHS] [nvarchar](25) NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh][nchar](5) NULL,
	[DiaChi] [nvarchar](35) NULL,
	[Email] [nvarchar](20) NULL,
	[MaLop] [bigint] NULL,
 CONSTRAINT [HocSinh1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TLop] ******/
CREATE TABLE [dbo].[Lop](
	[MaLop] [bigint] IDENTITY(1,1) NOT NULL,
	[TenLop] [nvarchar](10) NULL,
	[SiSo] [int] NULL,
	[MaGVCN] [bigint] NULL,
 CONSTRAINT [Lop1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TMonHoc] ******/
CREATE TABLE [dbo].[MonHoc](
	[MaMH] [bigint] IDENTITY(1,1) NOT NULL,
	[TenMH] [nvarchar](20) NULL,
	[Khoi] [int] NULL,
 CONSTRAINT [MonHoc1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Quyen] ******/
CREATE TABLE [dbo].[Quyen](
	[MaQuyen] [bigint] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](20) NULL,
	[TrangThai] [bit] NULL,
	[HocSinh] [nvarchar] (5) NULL,
	[LopHoc] [nvarchar] (5) NULL,
	[MonHoc] [nvarchar] (5) NULL,
	[BangDiem] [nvarchar] (5) NULL,
	[BaoCao] [nvarchar] (5) NULL,
	[NguoiDung] [nvarchar] (5) NULL,
 CONSTRAINT [Quyen1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[GiangVien] ******/
CREATE TABLE [dbo].[GiangVien](
	[MaGV] [bigint] IDENTITY(1,1) NOT NULL,
	[TenGV] [nvarchar](25) NULL,
	[SDT] [int] NULL,
	[DiaChi] [nvarchar](35) NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh][nchar](5) NULL,
	[MatKhau] [nvarchar](10) NULL,
	[TrangThai] [bit] NULL,
	[MaQuyen] [int] NULL,
	[Email] [nvarchar](20) NULL,
	
 CONSTRAINT [GiangVien1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[PhanCong] ******/
CREATE TABLE [dbo].[PhanCong](
	[MaLop] [bigint] NOT NULL,
	[MaMH] [bigint] NOT NULL,
	[MaGV] [bigint] NOT NULL,
 CONSTRAINT [PhanCong1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaLop] ASC,
	[MaMH] ASC,
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Diem] ******/

CREATE TABLE [dbo].[Diem](
	[MaHS] [bigint] NOT NULL,
	[MaMon] [bigint] NOT NULL,
	[HocKy] [int] NOT NULL,
	[NienKhoa] [nvarchar](9) NULL,
	[Diem15p] [float] NULL,
	[Diem1Tiet] [float] NULL,
	[DiemCuoiKy] [float] NULL,

 CONSTRAINT [Diem1_PK] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC,
	[MaMon] ASC,
	[HocKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[BaoCaoTK] ******/
CREATE TABLE [dbo].[BaoCaoTK](
	[MaBC] [bigint] NOT NULL,
	[LoaiBC] [int] NULL,
	[MaMH] [bigint]  NULL,
	[MaLop] [bigint] NULL,
	[SoLuongDat] [int]  NULL,
	[HocKy] [int] NULL,


 CONSTRAINT [BaoCao1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaBC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO