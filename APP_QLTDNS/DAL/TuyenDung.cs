using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TuyenDung : TuyenDungVaUngTuyen
    {
        private string maTuyenDung;
        private string noiDungTuyenDung;
        private string phucLoi;
        private float luong;
        private string yeuCau;
        private string thoiGianTuyenDung;
        public string MaTuyenDung { get => maTuyenDung; set => maTuyenDung = value; }
        public string NoiDungTuyenDung { get => noiDungTuyenDung; set => noiDungTuyenDung = value; }
        public string PhucLoi { get => phucLoi; set => phucLoi = value; }
        public float Luong { get => luong; set => luong = value; }
        public string YeuCau { get => yeuCau; set => yeuCau = value; }
        public string ThoiGianTuyenDung { get => thoiGianTuyenDung; set => thoiGianTuyenDung = value; }
        public TuyenDung()
        {

        }
        public TuyenDung(string maTuyenDung, string noiDungTuyenDung, string phucLoi, float luong, string yeuCau, string thoiGianTuyenDung)
        {
            this.MaTuyenDung = maTuyenDung;
            this.NoiDungTuyenDung = noiDungTuyenDung;
            this.PhucLoi = phucLoi;
            this.Luong = luong;
            this.YeuCau = yeuCau;
            this.ThoiGianTuyenDung = thoiGianTuyenDung;
        }
    }
}
