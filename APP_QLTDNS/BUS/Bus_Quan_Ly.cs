using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class Bus_Quan_Ly
    {
        QUANLY quanLY = new QUANLY();
        public bool dangNhap(TaiKhoan taiKhoan)
        {
            return quanLY.dangNhap(taiKhoan);
        }
        public SqlDataReader loadingTK()
        {
            return quanLY.loadingTK();
        }
        public bool ThemTK(TaiKhoan khoan)
        {
            return quanLY.themTaiKhoan(khoan);
        }
        public bool suaTK(TaiKhoan khoan)
        {
            return quanLY.suaTaiKhoan(khoan);
        }
        public bool xoaTK(string s)
        {
            return quanLY.xoaTaiKhoan(s);
        }
        public SqlDataReader timKiemTK(string data)
        {
            return quanLY.timKiemTaiKhoan(data);
        }
        // Quản Lý Tuyển Dụng
        public bool themTD(TuyenDung tuyenDung)
        {
            return quanLY.themNoiDungTuyenDung(tuyenDung);
        }
        public bool suaTD(TuyenDung tuyenDung)
        {
            return quanLY.suaNoiDungTuyenDung(tuyenDung);
        }
        public bool xoaTD(string maTD)
        {
            return quanLY.xoaNoiDungTuyenDung(maTD);
        }
        public SqlDataReader timKiemTD(string data)
        {
            return quanLY.timNoiDungTuyenDung(data);
        }
    }
}
