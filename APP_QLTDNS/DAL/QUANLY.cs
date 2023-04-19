using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IQUANLY
    {
        void dangNhap();
        void themTaiKhoan();
        void suaTaiKhoan();
        void xoaTaiKhoan();
        void timKiemTaiKhoan();
        void themUngVien();
        void suaUngVien();
        void xoaUngVien();
        void timKiemUngVien();
        void thongKeUngVien();
    }
    public class QUANLY : PERSON, IQUANLY
    {
        private string _maQL;

        public string MaQL { get => _maQL; set => _maQL = value; }
        public QUANLY() { }
        public QUANLY(string maQL, string hoTen, string ngaySinh, string diaChi, string sdt, string gmail) : base(hoTen, ngaySinh, diaChi, sdt, gmail)
        {
            this.MaQL = maQL;
        }
        public void dangNhap() { 
        
        }
        public void themTaiKhoan() {
        
        }
        public void suaTaiKhoan() {
        
        }
        public void xoaTaiKhoan() {
        
        }
        public void timKiemTaiKhoan() {
        
        }
        public void themUngVien() {
        
        }
        public void suaUngVien() {
        
        }
        public void xoaUngVien() {
        
        }
        public void timKiemUngVien() {
        
        }
        public void thongKeUngVien() {
        
        }
    }
}
