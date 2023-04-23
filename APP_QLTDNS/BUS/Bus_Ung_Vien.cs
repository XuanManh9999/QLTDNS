using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class Bus_Ung_Vien
    {
        UNGVIEN ungVien = new UNGVIEN();
        // Đăng nhập
        public bool DangNhap(TaiKhoan taiKhoan)
        {
            if(ungVien.dangNhap(taiKhoan))
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool DangKy(TaiKhoan taiKhoan)
        {
            if (ungVien.dangKy(taiKhoan))
            {
                return true;
            }else
            {
                return false;
            }
        }
        public string QuenMatKhau(string tenTK)
        {
            if (ungVien.quenMatKhau(tenTK) != "err")
            {
                return ungVien.quenMatKhau(tenTK);
            }else
            {
                return "err";
            }
        }
        public bool bus_CapNhatThongTinUngVien(UNGVIEN ungVien)
        {
            if(ungVien.capNhatThongTinUngVien(ungVien))
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool ungTuyen(string maUV, string maTD)
        {
            return ungVien.ungTuyen(maUV, maTD);
        }
        public string getMaUV(string tenUV)
        {
            return ungVien.getMaUV(tenUV);
        }
        // Hiển thị thông tin
        public SqlDataReader hienThiThongTinUngVien(string maUV)
        {
            return ungVien.xemThongTin(maUV);
        }
        // cập nhật thông tin
        public bool capNhatTTUngVien(string maUV, UNGVIEN ungVien)
        {
            return ungVien.capNhatThongTin(maUV, ungVien);
        }
    }
}
