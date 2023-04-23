using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IQUANLY
    {
        bool dangNhap(TaiKhoan taiKhoan);
        bool themTaiKhoan(TaiKhoan taiKhoan);
        bool suaTaiKhoan(TaiKhoan taiKhoan);
        bool xoaTaiKhoan(string tenTK);
        SqlDataReader timKiemTaiKhoan(string data);
        void themUngVien();
        void suaUngVien();
        void xoaUngVien();
        void timKiemUngVien();
        SqlDataReader thongKeUngVien();
        bool themNoiDungTuyenDung(TuyenDung tuyenDung);
        bool suaNoiDungTuyenDung(TuyenDung tuyenDung);
        bool xoaNoiDungTuyenDung(string matd);
        SqlDataReader timNoiDungTuyenDung(string data);
        SqlDataReader hienThiUngVienUngTuyen();
        bool loaiUngVien(string maTD, string maUV);
        SqlDataReader timKiemUngVIenUngTuyen(string data);
    }
    public class QUANLY : PERSON, IQUANLY
    {
        private string _maQL;
        private List<char> layMaTD = new List<char>();
        public string MaQL { get => _maQL; set => _maQL = value; }
        public QUANLY() { }
        public QUANLY(string maQL, string hoTen, string ngaySinh, string diaChi, string sdt, string gmail) : base(hoTen, ngaySinh, diaChi, sdt, gmail)
        {
            this.MaQL = maQL;
        }
        public bool dangNhap(TaiKhoan taiKhoan) { 
            if (taiKhoan.TenTaiKhoan == "admin" && taiKhoan.MatKhau == "123")
            {
                return true;
            }else
            {
                return false;
            }
        }
        public SqlDataReader loadingTK()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select * from TAIKHOAN";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            return reader;
        }
        public bool themTaiKhoan(TaiKhoan  taiKhoan) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"insert into TAIKHOAN values (N'{taiKhoan.TenTaiKhoan}', N'{taiKhoan.MatKhau}')";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool suaTaiKhoan(TaiKhoan taiKhoan) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"update TAIKHOAN set TenTK = N'{taiKhoan.TenTaiKhoan}', MatKhau = N'{taiKhoan.MatKhau}' where TenTK = N'{taiKhoan.TenTaiKhoan}'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool xoaTaiKhoan(string tenTK) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"delete from TAIKHOAN where TenTK = N'{tenTK}'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public SqlDataReader timKiemTaiKhoan(string data) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"select * from TAIKHOAN where TenTK like N'%{data}%' or MatKhau like N'%{data}%'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            return reader;
        }
        public void themUngVien() {
        
        }
        public void suaUngVien() {
        
        }
        public void xoaUngVien() {
        
        }
        public void timKiemUngVien() {
        
        }
        public SqlDataReader thongKeUngVien() {
            // kết xuất nguồn dữ liệu cho report
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = "select  UNGVIEN.TenUngVien, UNGVIEN.DiaChi, UNGVIEN.TrinhDo, UNGVIEN.KinhNghiem, TUYENDUNG.NoiDungTuyenDung, UNGVIEN.Sdt from UNGVIEN, TUYENDUNG, UNGTUYEN where TUYENDUNG.MaTD = UNGTUYEN.MaTD and UNGVIEN.MaUngVien = UNGTUYEN.MaUV";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            return reader;
        }
        public void layMaTuyenDung()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select MaTD from TUYENDUNG";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            while(reader.Read())
            {
                layMaTD.Add(reader.GetString(0)[reader.GetString(0).Length - 1]);
            }
            reader.Close();
        }
        public bool themNoiDungTuyenDung(TuyenDung tuyenDung) {
            layMaTuyenDung();
            AsyncCallback:
            Random random = new Random();
            int x = random.Next(1000);
            foreach (char k in layMaTD)
            {
                if(x == int.Parse(k.ToString()))
                {
                    goto AsyncCallback;
                }
            }
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"insert into TUYENDUNG values ('MTD0{x}', N'{tuyenDung.NoiDungTuyenDung}', N'{tuyenDung.PhucLoi}', '{tuyenDung.Luong}', N'{tuyenDung.YeuCau}', N'{tuyenDung.ThoiGianTuyenDung}')";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool suaNoiDungTuyenDung(TuyenDung tuyenDung) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"update TUYENDUNG set NoiDungTuyenDung = N'{tuyenDung.NoiDungTuyenDung}', PhucLoi = N'{tuyenDung.PhucLoi}', Luong = '{tuyenDung.Luong}', YeuCau = N'{tuyenDung.YeuCau}', ThoiGianTuyenDung = '{tuyenDung.ThoiGianTuyenDung}'   where MaTD = '{tuyenDung.MaTuyenDung}'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public bool xoaNoiDungTuyenDung(string matd) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"delete from TUYENDUNG where MaTD = '{matd}'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public SqlDataReader timNoiDungTuyenDung(string data) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"select * from TUYENDUNG where NoiDungTuyenDung like N'%{data}%' or YeuCau like N'%{data}%' or Luong like '%{data}%'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            return reader;
        }
        public SqlDataReader hienThiUngVienUngTuyen()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select UNGVIEN.TenUngVien, UNGVIEN.DiaChi, UNGVIEN.TrinhDo, UNGVIEN.KinhNghiem, TUYENDUNG.NoiDungTuyenDung, UNGVIEN.Sdt, UNGVIEN.MaUngVien, TUYENDUNG.MaTD from UNGVIEN, TUYENDUNG, UNGTUYEN where TUYENDUNG.MaTD = UNGTUYEN.MaTD and UNGVIEN.MaUngVien = UNGTUYEN.MaUV";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            return reader;
        }
        public bool loaiUngVien(string maTD, string maUV)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"delete from UNGTUYEN where MaUV = '{maUV}' and MaTD = '{maTD}'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0) { return true; }
            return false;
        }
        public SqlDataReader timKiemUngVIenUngTuyen(string data)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"select UNGVIEN.TenUngVien, UNGVIEN.DiaChi, UNGVIEN.TrinhDo, UNGVIEN.KinhNghiem, TUYENDUNG.NoiDungTuyenDung, UNGVIEN.Sdt, UNGVIEN.MaUngVien, TUYENDUNG.MaTD from UNGVIEN, TUYENDUNG, UNGTUYEN where TUYENDUNG.MaTD = UNGTUYEN.MaTD and UNGVIEN.MaUngVien = UNGTUYEN.MaUV and TenUngVien like N'%{data}%' ";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            return reader;
        }
    }
}
