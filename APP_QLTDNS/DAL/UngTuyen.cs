using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UngTuyen : TuyenDungVaUngTuyen
    {
        private string maUngVien;
        private string tenUngVien;
        public string MaUngVien { get => maUngVien; set => maUngVien = value; }
        public string TenUngVien { get => tenUngVien; set => tenUngVien = value; }
        public UngTuyen() { }
        public UngTuyen(string maUngVien, string tenUngVien)
        {
            this.MaUngVien = maUngVien;
            this.TenUngVien = tenUngVien;
        }
    }
}
