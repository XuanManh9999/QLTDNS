CREATE DATABASE QLTDNS
USE QLTDNS 
CREATE TABLE QUANLY (
	MaQL varchar(10) primary key,
	TenQL nvarchar (50),
	DiaChi nvarchar(50),
	NgaySinh varchar (12),
	Sdt varchar (20),
	Email varchar(20)
)
CREATE TABLE QUANLYTUYENDUNG(
	MaTD varchar(10) foreign key references TUYENDUNG(MaTD),
	MaQL varchar(10) foreign key references QUANLY(MaQL)
	primary key(MaTD, MaQL)
)
CREATE TABLE QUANLYUNGVIEN(
	MaQL varchar(10) foreign key references QUANLY(MaQL),
	MaUV varchar(10) foreign key references UNGVIEN (MaUngVien)
	primary key (MaQL, MaUV)
)
CREATE TABLE UNGVIEN(
	MaUngVien VARCHAR(10) primary key,
	TenUngVien Nvarchar(50),
	DiaChi nvarchar(50),
	NgaySinh varchar(12),
	Sdt varchar(20),
	Gmail varchar(50),
	TrinhDo nvarchar(200),
	KinhNghiem nvarchar(200),
	TenTK nvarchar(50) foreign key references TAIKHOAN(TenTK)
)
CREATE TABLE UNGTUYEN(
	MaUV varchar(10) foreign key references UNGVIEN(MaUngVien),
	MaTD varchar(10) foreign key references TUYENDUNG(MaTD)
	primary key (MaUV, MaTD)
)
CREATE TABLE TUYENDUNG (
	MaTD varchar(10) primary key,
	NoiDungTuyenDung nvarchar(2000),
	PhucLoi Nvarchar(100),
	Luong float,
	YeuCau Nvarchar(2000),
	ThoiGianTuyenDung varchar (100)	
)
CREATE TABLE QUANLYTAIKHOAN(
	MaQL varchar(10) foreign key references QUANLY(MaQL),
	TenTK nvarchar(50) foreign key references TAIKHOAN(TenTK)
	primary key (MaQL, TenTK)
)
CREATE TABLE TAIKHOAN(
	TenTK nvarchar(50) primary key,
	MatKhau nvarchar(50)
)
-- Dựng DaTaBase
-----------------------------------------------Các truy vấn----------------------
select MatKhau from TAIKHOAN
select * from TAIKHOAN
select MatKhau from TAIKHOAN where TenTK = N'Xuân Mạnh';
insert into TAIKHOAN values (N'Xuân Mạnh', N'123')
insert into TAIKHOAN values (N'1', N'123')
update TAIKHOAN set TenTK = N'', MatKhau = N'123' where TenTK = N''
select * from TAIKHOAN
delete from TAIKHOAN where TenTK = N''
select * from TAIKHOAN where TenTK like N'%N%' or MatKhau like N'%A%'
select * from TUYENDUNG 
select MaTD from TUYENDUNG
update TUYENDUNG set NoiDungTuyenDung = N'', PhucLoi = N'', Luong = '', YeuCau = N'', ThoiGianTuyenDung = ''   where MaTD = 'MTD001'
delete from TUYENDUNG where MaTD = 'MTD001'
select * from TUYENDUNG where NoiDungTuyenDung like N'%Áo%' or YeuCau like N'%Kẹo%' or Luong like '%12%'
insert into TUYENDUNG values ('MTD001', N'Bán Hàng Quần Áo', N'Đóng BHXH', '999', N'Tốt Nghiệp Cấp 3', N'20h')
select * from TUYENDUNG where NoiDungTuyenDung like N'%NET%' or YeuCau like N'%NET%' or Luong like '%NET%'
select * from UNGVIEN
insert into UNGTUYEN values('UV001', 'MTD001');
select UNGVIEN.TenUngVien, UNGVIEN.DiaChi, TUYENDUNG.NoiDungTuyenDung from UNGVIEN, TUYENDUNG, UNGTUYEN where TUYENDUNG.MaTD = UNGTUYEN.MaTD and UNGVIEN.MaUngVien = UNGTUYEN.MaUV
select * from TUYENDUNG
select * from UNGVIEN
select * from UNGTUYEN
select MaUngVien from TAIKHOAN, UNGVIEN where TAIKHOAN.TenTK = N'Xuân Mạnh' and UNGVIEN.TenTK = TAIKHOAN.TenTK