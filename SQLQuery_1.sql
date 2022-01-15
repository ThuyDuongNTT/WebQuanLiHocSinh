-- Drop the database 'DatabaseName'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Uncomment the ALTER DATABASE statement below to set the database to SINGLE_USER mode if the drop database command fails because the database is in use.
ALTER DATABASE DB_QuanLiDiem SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
-- Drop the database if it exists
IF EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'DB_QuanLiDiem'
)
DROP DATABASE DB_QuanLiDiem
GO

/****** Object:  database  QLDiem   Script Date: 12/31/2022 7:25:52 AM ******/
create  database DB_QuanLiDiem
go
use [DB_QuanLiDiem] 
go
GO

/****** Object:  Table [dbo].[THocSinh] ******/
CREATE TABLE [dbo].[HocSinh](
	[MaHS] [int] IDENTITY(1,1) NOT NULL,
	[TenHS] [nvarchar](25) NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh][nchar](5) NULL,
	[DiaChi] [nvarchar](35) NULL,
	[Email] [nvarchar](50) NULL,
	[MaLop] [int] NULL,
 CONSTRAINT [HocSinh1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaHS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[TLop] ******/
CREATE TABLE [dbo].[Lop](
	[MaLop] [int] IDENTITY(1,1) NOT NULL,
	[TenLop] [nvarchar](10) NULL,
	[SiSo] [int] NULL,
	[MaGVCN] [int] NULL,
 CONSTRAINT [Lop1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TMonHoc] ******/
CREATE TABLE [dbo].[MonHoc](
	[MaMH] [int] IDENTITY(1,1) NOT NULL,
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
	[MaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](20) NULL,
	[TrangThai] [bit] NULL,

 CONSTRAINT [Quyen1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[GiangVien] ******/
CREATE TABLE [dbo].[GiangVien](
	[MaGV] [int] IDENTITY(1,1) NOT NULL,
	[TenGV] [nvarchar](25) NULL,
	[SDT] [int] NULL,
	[DiaChi] [nvarchar](35) NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh][nchar](5) NULL,
	[MatKhau] [nvarchar](10) NULL,
	[TrangThai] [bit] NULL,
	[MaQuyen] [int] NULL,
	[Email] [nvarchar](50) NULL,
	
 CONSTRAINT [GiangVien1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[PhanCong] ******/
CREATE TABLE [dbo].[PhanCong](
	[MaLop] [int] NOT NULL,
	[MaMH] [int] NOT NULL,
	[MaGV] [int] NOT NULL,
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
	[MaHS] [int] NOT NULL,
	[MaMH] [int] NOT NULL,
	[HocKy] [int] NOT NULL,
	[NienKhoa] [nvarchar](9) NULL,
	[Diem15p] [float] NULL,
	[Diem1Tiet] [float] NULL,
	[DiemCuoiKy] [float] NULL,

 CONSTRAINT [Diem1_PK] PRIMARY KEY CLUSTERED 
(
	[MaHS] ASC,
	[MaMH] ASC,
	[HocKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[BaoCaoTK] ******/
CREATE TABLE [dbo].[BaoCaoTK](
	[MaBC] [int] NOT NULL,
	[LoaiBC] [int] NULL,
	[MaMH] [int]  NULL,
	[MaLop] [int] NULL,
	[SoLuongDat] [int]  NULL,
	[HocKy] [int] NULL,

 CONSTRAINT [BaoCao1_PK] PRIMARY KEY NONCLUSTERED 
(
	[MaBC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/***** Foreign Key Constraints ******/
ALTER TABLE [dbo].[HocSinh]  WITH CHECK ADD FOREIGN KEY([MaLop])  
REFERENCES [dbo].[Lop] ([MaLop])  
GO  

ALTER TABLE [dbo].[Lop]  WITH CHECK ADD FOREIGN KEY([MaGVCN])  
REFERENCES [dbo].[GiangVien] ([MaGV])
GO  

ALTER TABLE [dbo].[GiangVien]  WITH CHECK ADD FOREIGN KEY([MaQuyen])  
REFERENCES [dbo].[Quyen] ([MaQuyen])  
GO  

ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaLop])  
REFERENCES [dbo].[Lop] ([MaLop])  
GO  

ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaMH])  
REFERENCES [dbo].[MonHoc] ([MaMH])  
GO  

ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaGV])  
REFERENCES [dbo].[GiangVien] ([MaGV])  
GO  

ALTER TABLE [dbo].[Diem]  WITH CHECK ADD FOREIGN KEY([MaMH])  
REFERENCES [dbo].[MonHoc] ([MaMH])  
GO  

ALTER TABLE [dbo].[Diem]  WITH CHECK ADD FOREIGN KEY([MaHS])  
REFERENCES [dbo].[HocSinh] ([MaHS])  
GO  

ALTER TABLE [dbo].[BaoCaoTK]  WITH CHECK ADD FOREIGN KEY([MaMH])  
REFERENCES [dbo].[MonHoc] ([MaMH])  
GO  

ALTER TABLE [dbo].[BaoCaoTK]  WITH CHECK ADD FOREIGN KEY([MaLop])  
REFERENCES [dbo].[Lop] ([MaLop])  
GO  


SET IDENTITY_INSERT [dbo].[Quyen] ON;
GO
INSERT INTO [dbo].[Quyen] ([MaQuyen], [TenQuyen], [TrangThai]) VALUES (1, 'superadmin', 1);
GO
SET IDENTITY_INSERT [dbo].[Quyen] OFF;
GO

SET IDENTITY_INSERT [dbo].[GiangVien] ON;
GO
INSERT INTO [dbo].[GiangVien] ([MaGV], [TenGV], [MatKhau], [TrangThai], [MaQuyen], [Email]) VALUES (1,'admin', 'admin', 1, 1, 'admin')
GO
SET IDENTITY_INSERT [dbo].[GiangVien] OFF;
GO

