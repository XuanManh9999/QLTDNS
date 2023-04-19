using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuanLyTuyenDung
    {
        private string maQL;
        private string maTuyenDung;
        public string MaQL { get => maQL; set => maQL = value; }
        public string MaTuyenDung { get => maTuyenDung; set => maTuyenDung = value; }
        public QuanLyTuyenDung()
        {

        }
        public QuanLyTuyenDung(string maQL, string maTuyenDung)
        {
            this.MaQL = maQL;
            this.MaTuyenDung = maTuyenDung;
        }

    }
}
