using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    interface IUNGVIEN {
        bool dangNhap(TaiKhoan taiKhoan);
        bool dangKy(TaiKhoan taiKhoan);
        string quenMatKhau(string tenTK);
        bool capNhatThongTinUngVien(UNGVIEN ungVien);
        bool ungTuyen(string maTD, string maUV);
        SqlDataReader xemThongTin(string maUV);
        bool capNhatThongTin(string maUV, UNGVIEN ungVien);
    }
    public class UNGVIEN : PERSON, IUNGVIEN
    {
        public List<string> tenTK = new List<string>();
        public List<string> matKhau = new List<string>();
        public List<char> layALLMaUV = new List<char>();
        private string maUngVien;
        private string trinhDo;
        private string kinhNghiem;
        private string tenTK_;
        public string MaUngVien { get => maUngVien; set => maUngVien = value; }
        public string TrinhDo { get => trinhDo; set => trinhDo = value; }
        public string KinhNghiem { get => kinhNghiem; set => kinhNghiem = value; }
        public string TenTK_ { get => tenTK_; set => tenTK_ = value; }

        public UNGVIEN() { 
        }
        public UNGVIEN(string MaUngVien, string TrinhDo, string KinhNghiem, string TenTK_, string hoTen, string ngaySinh, string diaChi, string sdt, string gmail) :base(hoTen, ngaySinh, diaChi, sdt, gmail)
        {
            this.MaUngVien= MaUngVien;
            this.TrinhDo = TrinhDo;
            this.KinhNghiem = KinhNghiem;
            this.TenTK_ = TenTK_;
        }
        public void layTenTK()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select TenTK from TAIKHOAN";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            while(reader.Read())
            {
                tenTK.Add(reader.GetString(0).Trim());
            }
            reader.Close();
        }
        public void layMatKhau()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select MatKhau from TAIKHOAN";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            while (reader.Read())
            {
                matKhau.Add(reader.GetString(0).Trim());
            }
            reader.Close();
        }
        public bool dangNhap(TaiKhoan taiKhoan) {
            layTenTK();
            layMatKhau();
            int cnt = 0;
            foreach (string i in tenTK)
            {
                if (i == taiKhoan.TenTaiKhoan.Trim())
                {
                    cnt++;
                    break;
                }
            }
            foreach (string i in matKhau)
            {
                if (i == taiKhoan.MatKhau)
                {
                    cnt++;
                    break;
                }
            }
            if (cnt == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            int cnt = 0;
        public bool dangKy(TaiKhoan taiKhoan) {
            layTenTK();
            layMatKhau();
            cnt = 0;
            foreach (string i in tenTK)
            {
                if (i == taiKhoan.TenTaiKhoan.Trim())
                {
                    cnt++;
                    break;
                }
            }
            if (cnt == 0)
            {
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = $"insert into TAIKHOAN values (N'{taiKhoan.TenTaiKhoan}', N'{taiKhoan.MatKhau}')";
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
            else
            {
                return false;
            }
        }
        public string quenMatKhau(string tenTKK) {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"select MatKhau from TAIKHOAN where TenTK = N'{tenTKK}';";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            if(reader.Read())
            {
                return reader.GetString(0).Trim();
            }
            return "err";
        }
        public void layMUV()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = "select MaUngVien from UNGVIEN";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            while (reader.Read())
            {
                layALLMaUV.Add((reader.GetString(0)[reader.GetString(0).Length - 1]));
            }
            reader.Close();
        }
        public bool capNhatThongTinUngVien(UNGVIEN ungVien)
        {
            try
            {
                layMUV();
                back:
                Random random = new Random();
                int x = random.Next(100) + 1;
                foreach (char c in layALLMaUV)
                {
                    if (int.Parse(c.ToString()) == x)
                    {
                        goto back;
                    }
                }
                SqlCommand sqlCMD = new SqlCommand();
                sqlCMD.CommandType = System.Data.CommandType.Text;
                sqlCMD.CommandText = $"insert into UNGVIEN values ('UV00{x}', N'{ungVien.hoTen}', N'{ungVien.diaChi}', '{ungVien.ngaySinh}', '{ungVien.sdt}', '{ungVien.gmail}', N'{ungVien.trinhDo}', N'{ungVien.kinhNghiem}', N'{ungVien.tenTK_}')";
                sqlCMD.Connection = CONECT.chuoiKetNoi();
                if (sqlCMD.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch
            {
                return false;
            }
        }
        public bool ungTuyen(string maTD, string maUV)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"insert into UNGTUYEN values('{maTD}', '{maUV}');";
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
        public string getMaUV(string tenTK)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"select MaUngVien from TAIKHOAN, UNGVIEN where TAIKHOAN.TenTK = N'{tenTK}' and UNGVIEN.TenTK = TAIKHOAN.TenTK";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            return "";
        }
        public SqlDataReader xemThongTin(string maUV)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"select * from UNGVIEN where MaUngVien = '{maUV}'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            return reader;
        }
        public bool capNhatThongTin(string maUV, UNGVIEN ungVien)
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = System.Data.CommandType.Text;
            sqlCMD.CommandText = $"update UNGVIEN set  TenUngVien = N'{ungVien.hoTen}', DiaChi = N'{ungVien.diaChi}', NgaySinh = '{ungVien.ngaySinh}', Sdt = '{ungVien.sdt}', Gmail = '{ungVien.gmail}', TrinhDo = N'{ungVien.trinhDo}', KinhNghiem = N'{ungVien.kinhNghiem}' where MaUngVien = '{maUV}'";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            if (sqlCMD.ExecuteNonQuery() > 0) {
                return true;
            }
            return false;
        }
    }
}
