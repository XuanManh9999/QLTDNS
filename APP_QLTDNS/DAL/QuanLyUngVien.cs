using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyUngVien
    {
        private string mqQL;
        private string maUngVien;
        public string MaQL { get => mqQL; set => mqQL = value; }
        public string MaUngVien { get => maUngVien; set => maUngVien = value; }
        public QuanLyUngVien() { }
        public QuanLyUngVien(string maQL, string maUngVien)
        {
            this.MaQL = maQL;
            this.MaUngVien= maUngVien;
        }
    }
}
