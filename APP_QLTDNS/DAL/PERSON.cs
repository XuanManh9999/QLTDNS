using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PERSON
    {
        protected string hoTen { get; set; }
        protected string ngaySinh { get; set; }
        protected string diaChi { get; set; }
        protected string sdt { get; set; }
        protected string gmail { get; set; }
        public PERSON()
        {

        }
        public PERSON(string hoTen, string ngaySinh, string diaChi, string sdt, string gmail)
        {
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.gmail = gmail;
        }
    }
}
