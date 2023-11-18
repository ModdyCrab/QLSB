create table Account(
	Username varchar(20) primary key,
	PassWord varchar(20),
	DisplayName nvarchar(20),
	UserType nvarchar(20)
)
INSERT INTO Account
(
Username ,
	PassWord ,
	DisplayName ,
	UserType 
)
VALUES (N'DucDat',
N'1',
N'Kiều Đức Đạt',
N'Khách Hàng'
)
INSERT INTO Account
(
Username ,
	PassWord ,
	DisplayName ,
	UserType 
)
VALUES (N'NamCuong',
N'1',
N'Trần Nam Cương',
N'Khách Hàng'
)
create table KhachHang(
	ID_KH INT primary key,
	HoTen nvarchar(50),
	SDT varchar(10),
	FB nvarchar(100),
	SoLanDat int,
	Loai_KH nvarchar(20),
	Username varchar(20)references Account(Username)
)
INSERT INTO KhachHang
(
ID_KH ,
	HoTen ,
	SDT ,
	FB,
	SoLanDat,
	Loai_KH,
	Username
)
VALUES (1,
N'Trương Công Đạt',
0345678912,
N'Đạt Vip',
10,
N'Vip',
'CongDat'
)
INSERT INTO KhachHang
(
ID_KH ,
	HoTen ,
	SDT ,
	FB,
	SoLanDat,
	Loai_KH,
	Username
)
VALUES (2,
N'Kiều Đức Đạt',
0345678913,
N'Đạt Kiều',
0,
N'Mới',
'DucDat'
)
INSERT INTO KhachHang
(
ID_KH ,
	HoTen ,
	SDT ,
	FB,
	SoLanDat,
	Loai_KH,
	Username
)
VALUES (3,
N'Trần Nam Cương',
0345678914,
N'Cương Pro',
2,
N'Cũ',
'NamCuong'
)
INSERT INTO KhachHang
(
ID_KH ,
	HoTen ,
	SDT ,
	FB,
	SoLanDat,
	Loai_KH,
	Username
)
VALUES (4,
N'Nguyễn Phương Thanh',
0345678915,
N'Thanh Nguyen',
1,
N'Cũ',
'PhuongThanh'
)
create table NhanVien(
	ID_NV INT primary key,
	HoTen nvarchar(50),
	SDT varchar(10),
	QueQuan nvarchar(100),
	Username varchar(20)references Account(Username)
)
INSERT INTO NhanVien
(
ID_NV ,
	HoTen ,
	SDT ,
	QueQuan,
	Username
)
VALUES (1,
N'Đỗ Quỳnh Trang',
0345678917,
N'Yên Bái',
'DoTrang'
)
INSERT INTO NhanVien
(
ID_NV ,
	HoTen ,
	SDT ,
	QueQuan,
	Username
)
VALUES (2,
N'Nguyễn Hương Giang',
0345678918,
N'Lào Cai',
'HuongGiang'
)
INSERT INTO KhachHang
(
ID_KH ,
	HoTen ,
	SDT ,
	FB,
	SoLanDat,
	Loai_KH,
	Username
)
VALUES (4,
N'Nguyễn Phương Thanh',
0345678915,
N'Thanh Nguyen',
1,
N'Cũ',
'PhuongThanh'
)
create table KhuVuc_SanBong(
	ID_KVSB int primary key,
	Ten nvarchar(20),
	GiaTien int,
	TrangThai nvarchar(20)
)

create table LichDat_SanBong(
	ID_LDSB int primary key,
	ID_KH int references KhachHang(ID_KH),
	NgayDat date,

)
INSERT INTO LichDat_SanBong
(
ID_LDSB,
	ID_KH ,
NgayDat
)
VALUES (8,
1,
'4-8-2023'
)
INSERT INTO LichDat_SanBong
(
ID_LDSB,
	ID_KH ,
NgayDat
)
VALUES (9,
1,
'3-8-2023'
)

create table ChiTietLichDat_SanBong(
	ID_CTLDSB int primary key,
	ID_LDSB int references LichDat_SanBong(ID_LDSB),
	ID_KVSB int references KhuVuc_SanBong(ID_KVSB),
	KhungGio_Nhan time,
	KhungGio_Tra time,
	GhiChu nvarchar(100),
	TrangThai nvarchar(100)
)

create table HoaDon(
	ID_HoaDon int primary key,
	ID_CTLDSB int references ChiTietLichDat_SanBong(ID_CTLDSB),
	ID_KH int references KhachHang(ID_KH),
	NgayLapBill date,
	NgayXuatBill date,
	GiamGia int,
	TrangThai nvarchar(100),
	ID_NV int
)


create table ChiTietHoaDon(
	ID_ChiTietHoaDon int primary key,
	ID_HoaDon int references HoaDon(ID_HoaDon),
	ID_DV int references DV(ID_DV),
	SoLuong int
)

create table LoaiDV(
	ID_LDV int primary key,
	TenLoaiDV nvarchar(50)
)

create table DV(
	ID_DV int primary key,
	ID_LDV int references LoaiDV(ID_LDV),
	TenDV nvarchar(20),
	GiaTien int,
)
SELECT * FROM Account
SELECT * FROM Account WHERE Username = N'admin'AND PassWord = N'admin'

CREATE PROC USP_GetAccountByUserName
@Username nvarchar (20)
AS
BEGIN
SELECT * FROM Account WHERE Username=@Username 
END 
GO

exec USP_GetAccountByUserName @Username = N'admin'

CREATE PROC USP_Login2
@Username nvarchar (20), @PassWord varchar (20)
AS
BEGIN
SELECT * FROM Account WHERE Username=@UserName AND PassWord=@PassWord
END 
GO

create proc hiendskh
as
begin
    select * from KhachHang
end
GO

create proc themkh
@ID_KH int,
@HoTen nvarchar(50),
@SDT varchar(10),
@FB nvarchar(100),
@SoLanDat int,
@Loai_KH nvarchar(20)
@Username varchar(20)
as
begin
    Insert into KhachHang values(@ID_KH,@HoTen,@SDT,@FB,@SoLanDat,@Loai_KH,@Username)
end
go

create proc suakh
@ID_KH nvarchar(10),
@HoTen nvarchar(50),
@SDT varchar(10),
@FB nvarchar(100),
@SoLanDat int,
@Loai_KH nvarchar(20)
as
begin
    update KhachHang 
    set ID_KH =@ID_KH,
        HoTen = @HoTen,
        SDT=@SDT,
		FB=@FB,
		Loai_KH=@Loai_KH 
    where ID_KH = @ID_KH
end
go

create proc xoakh
@ID_KH nvarchar(10)
as
begin
    delete KhachHang where ID_KH = @ID_KH
end
go

SELECT * FROM dbo.KhuVuc_SanBong
INSERT INTO dbo.KhuVuc_SanBong
    (ID_KVSB, Ten,GiaTien)
VALUES
    (7, 'Sân 7', '7000000');
INSERT INTO dbo.KhuVuc_SanBong
    (ID_KVSB, Ten,GiaTien)
VALUES
    (5, 'Sân 5', '200000');
INSERT INTO dbo.KhuVuc_SanBong
    (ID_KVSB, Ten,GiaTien)
VALUES
    (6, 'Sân 6', '5000000');

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.KhuVuc_SanBong
go
EXEC dbo.USP_GetTableList

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.KhuVuc_SanBong



DROP PROCEDURE dbo.USP_GetTableList;

ALTER TABLE dbo.KhuVuc_SanBong
  ADD TrangThai nvarchar(10);



INSERT INTO dbo.LoaiDV
    (ID_LDV, TenLoaiDV)
VALUES
    ('1', N'Thuê quần áo');
INSERT INTO dbo.LoaiDV
    (ID_LDV, TenLoaiDV)
VALUES
    ('2', N'Thuê vật dụng');
INSERT INTO dbo.DV
    (ID_DV, ID_LDV,TenDV,GiaTien)
VALUES
    ('1', '1',N'Thuê áo','50000');
INSERT INTO dbo.DV
    (ID_DV, ID_LDV,TenDV,GiaTien)
VALUES
    ('2', '1',N'Thuê quần','70000');
INSERT INTO dbo.DV
    (ID_DV, ID_LDV,TenDV,GiaTien)
VALUES
    ('3', '2',N'Thuê bóng','200000');
INSERT INTO dbo.DV
    (ID_DV, ID_LDV,TenDV,GiaTien)
VALUES
    ('4', '2',N'Găng tay','100000');

INSERT INTO dbo.LichDat_SanBong
    (ID_LDSB,ID_KH,NgayDat)
VALUES
    ('11', '3','11-11-2023')
	INSERT INTO dbo.LichDat_SanBong
    (ID_LDSB,ID_KH,NgayDat)
VALUES
    ('12', '3','11-12-2023')
		INSERT INTO dbo.LichDat_SanBong
    (ID_LDSB,ID_KH,NgayDat)
VALUES
    ('13', '4','11-14-2023')

INSERT INTO dbo.HoaDon
    (ID_HoaDon, ID_CTLDSB,ID_KH,NgayLapBill,NgayXuatBill,GiamGia,TrangThai,ID_NV)
VALUES
    ('4', '4','1','11-4-2023','11-4-2023',0,0,2)
INSERT INTO dbo.HoaDon
    (ID_HoaDon, ID_CTLDSB,ID_KH,NgayLapBill,NgayXuatBill,GiamGia,TrangThai,ID_NV)
VALUES
    ('2', '2','1','11-2-2023','11-2-2023',20,1,1)
INSERT INTO dbo.HoaDon
    (ID_HoaDon, ID_CTLDSB,ID_KH,NgayLapBill,NgayXuatBill,GiamGia,TrangThai,ID_NV)
VALUES
    ('4', '4','1','11-4-2023','11-4-2023',20,0,2)
	INSERT INTO dbo.HoaDon
    (ID_HoaDon, ID_CTLDSB,ID_KH,NgayLapBill,NgayXuatBill,GiamGia,TrangThai,ID_NV)
VALUES
    ('3', '3','1',GETDATE(),GETDATE(),20,1,2)

INSERT INTO dbo.ChiTietHoaDon
    (ID_ChiTietHoaDon, ID_HoaDon,ID_DV,SoLuong)
VALUES
    ('4', '4','2',5)

INSERT INTO dbo.ChiTietLichDat_SanBong
    (ID_CTLDSB, ID_LDSB,ID_KVSB,KhungGio_Nhan,KhungGio_Tra,GhiChu,TrangThai)
VALUES
    ('7', '7','8','08:00:00','09:00:00','',1)
	INSERT INTO dbo.ChiTietLichDat_SanBong
    (ID_CTLDSB, ID_LDSB,ID_KVSB,KhungGio_Nhan,KhungGio_Tra,GhiChu,TrangThai)
VALUES
    ('8', '8','6','08:00:00','09:00:00','',1)
	INSERT INTO dbo.ChiTietLichDat_SanBong
    (ID_CTLDSB, ID_LDSB,ID_KVSB,KhungGio_Nhan,KhungGio_Tra,GhiChu,TrangThai)
VALUES
    ('9', '9','5','08:00:00','09:00:00','',1)
	INSERT INTO dbo.ChiTietLichDat_SanBong
    (ID_CTLDSB, ID_LDSB,ID_KVSB,KhungGio_Nhan,KhungGio_Tra,GhiChu,TrangThai)
VALUES
    ('10', '10','8','08:00:00','09:00:00','',1)
		INSERT INTO dbo.ChiTietLichDat_SanBong
    (ID_CTLDSB, ID_LDSB,ID_KVSB,KhungGio_Nhan,KhungGio_Tra,GhiChu,TrangThai)
VALUES
    ('11', '11','8','11:00:00','12:00:00','',1)

ALTER TABLE dbo.HoaDon
ALTER COLUMN TrangThai int;

SELECT * FROM dbo.HoaDon WHERE ID_HoaDon = 3 AND TrangThai = 1
SELECT * FROM dbo.ChiTietHoaDon WHERE ID_HoaDon = 3 

EXEC sp_rename 'dbo.DV.GiaTien', 'GiaTienDV', 'COLUMN';
UPDATE dbo.KhuVuc_SanBong
SET TrangThai = N'Đang Thuê'
WHERE ID_KVSB = 8;

SELECT a.ID_HoaDon,e.ID_KVSB,e.Ten,e.GiaTien,c.TenDV,c.GiaTienDV,c.GiaTienDV*b.SoLuong+e.GiaTien AS TongTien FROM dbo.HoaDon AS a,dbo.ChiTietHoaDon AS b,dbo.DV AS c,dbo.ChiTietLichDat_SanBong AS d, dbo.KhuVuc_SanBong AS e WHERE a.ID_HoaDon=b.ID_HoaDon AND b.ID_DV=c.ID_DV AND a.ID_CTLDSB=d.ID_CTLDSB AND d.ID_KVSB=e.ID_KVSB AND a.TrangThai=1 AND a.ID_HoaDon=1
SELECT a.ID_HoaDon,e.ID_KVSB,e.Ten,e.GiaTien,c.TenDV,c.GiaTienDV FROM dbo.HoaDon AS a,dbo.ChiTietHoaDon AS b,dbo.DV AS c,dbo.ChiTietLichDat_SanBong AS d, dbo.KhuVuc_SanBong AS e WHERE a.ID_HoaDon=b.ID_HoaDon AND b.ID_DV=c.ID_DV AND a.ID_CTLDSB=d.ID_CTLDSB AND d.ID_KVSB=e.ID_KVSB AND a.TrangThai=1 AND a.ID_HoaDon=2
SELECT a.ID_HoaDon,e.ID_KVSB,e.Ten,e.GiaTien,c.TenDV,c.GiaTienDV FROM dbo.HoaDon AS a,dbo.ChiTietHoaDon AS b,dbo.DV AS c,dbo.ChiTietLichDat_SanBong AS d, dbo.KhuVuc_SanBong AS e WHERE a.ID_HoaDon=b.ID_HoaDon AND b.ID_DV=c.ID_DV AND a.ID_CTLDSB=d.ID_CTLDSB AND d.ID_KVSB=e.ID_KVSB AND a.TrangThai=1 AND a.ID_HoaDon=3

ALTER TABLE dbo.DV

ADD SoLuong int;

ALTER TABLE dbo.DV
DROP COLUMN SoLuong;
select * from DV where ID_LoaiDV =1

Create proc USP_InsertBill
@ID_HoaDon int
AS
Begin
Insert dbo.HoaDon
(NgayLapBill,
NgayXuatBill,
ID_HoaDon,
TrangThai)
Values (GETDATE() ,
Null ,
@ID_HoaDon,
0 )
end
go

Create proc USP_InsertBillInfo
@ID_ChiTietHoaD int, @ID_HoaDon int, @ID_DV int, @SoLuong int
AS
Begin
Insert dbo.ChiTietHoaDon
(ID_ChiTietHoaDon,
ID_HoaDon,
ID_DV,
SoLuong)
Values (@ID_ChiTietHoaD,
@ID_HoaDon,
@ID_DV,
@SoLuong)
end
go

SELECT MAX(ID_HoaDon) FROM dbo.HoaDon
UPDATE dbo.HoaDon SET TrangThai = 1 WHERE ID_HoaDon =1

UPDATE HoaDon
SET TrangThai = 1
FROM HoaDon hd
JOIN ChiTietLichDat_SanBong ctl ON hd.ID_CTLDSB = ctl.ID_CTLDSB
WHERE ctl.ID_KVSB = 3

SELECT * FROM dbo.HoaDon WHERE ID_HoaDon = 1 AND TrangThai = 1

ALTER TABLE dbo.Account
ALTER COLUMN UserType int;

Select * from Account where UserName =N'HuongGiang'



SELECT * From dbo.HoaDon
SELECT * From dbo.ChiTietHoaDon
SELECT * From dbo.DV
SELECT * From dbo.LichDat_SanBong
SELECT * From dbo.KhuVuc_SanBong
SELECT * From dbo.ChiTietLichDat_SanBong
SELECT * From dbo.LoaiDV
SELECT * From dbo.KhachHang
SELECT * From dbo.Account
SELECT * From dbo.NhanVien


