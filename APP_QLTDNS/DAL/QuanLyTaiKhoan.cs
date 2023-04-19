using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyTaiKhoan
    {
        private string maQL;
        private string maTK;

        public string MaQL { get => maQL; set => maQL = value; }
        public string MaTK { get => maTK; set => maTK = value; }
        public QuanLyTaiKhoan() { }
        public QuanLyTaiKhoan(string maQL, string MaTK)
        {
            this.MaQL = maQL;
            this.MaTK = MaTK;
        }
    }
}
