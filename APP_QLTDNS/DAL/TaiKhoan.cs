using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TaiKhoan
    {
        private string tenTaiKhoan;
        private string matKhau;
        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public TaiKhoan()
        {

        }
        public TaiKhoan(string tenTaiKhoan, string matKhau)
        {
            this.TenTaiKhoan= tenTaiKhoan;
            this.MatKhau= matKhau;
        }
    }
}
