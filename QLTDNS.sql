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
	MaTk varchar(10)foreign key references TAIKHOAN(MaTk)
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
	MaTK varchar(10) foreign key references TAIKHOAN(MaTK)
	primary key (MaQL, MaTK)
)
CREATE TABLE TAIKHOAN(
	MaTK VARCHAR(10) primary key ,
	TenTK nvarchar(50),
	MatKhau nvarchar(50)
)
-- Dựng DaTaBase