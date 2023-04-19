using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IUNGVIEN {
        void dangNhap();
        void dangKy();
        void quenMatKhau();
        void ungTuyen();
        void xemThongTin();
        void timKiemCongViec();
    }
    public class UNGVIEN : PERSON, IUNGVIEN
    {
        private string maUngVien;
        private string trinhDo;
        private string kinhNghiem;
        private string maTK;
        public string MaUngVien { get => maUngVien; set => maUngVien = value; }
        public string TrinhDo { get => trinhDo; set => trinhDo = value; }
        public string KinhNghiem { get => kinhNghiem; set => kinhNghiem = value; }
        public string MaTK { get => maTK; set => maTK = value; }

        public UNGVIEN() { 
        }
        public UNGVIEN(string MaUngVien, string TrinhDo, string KinhNghiem, string MaTK, string hoTen, string ngaySinh, string diaChi, string sdt, string gmail) :base(hoTen, ngaySinh, diaChi, sdt, gmail)
        {
            this.MaUngVien= MaUngVien;
            this.TrinhDo = TrinhDo;
            this.KinhNghiem = KinhNghiem;
            this.MaTK = MaTK;
        }
        public void dangNhap() { 
        
        }
        public void dangKy() {
        
        }
        public void quenMatKhau() {
        
        }
        public void ungTuyen() {
        
        }
        public void xemThongTin() {
        
        }
        public void timKiemCongViec() {
        
        }
    }
}
