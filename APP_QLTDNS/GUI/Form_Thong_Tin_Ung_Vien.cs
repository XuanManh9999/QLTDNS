using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_Thong_Tin_Ung_Vien : Form
    {
        private string maUV = "";
        public Form_Thong_Tin_Ung_Vien()
        {
            InitializeComponent();
        }
        public Form_Thong_Tin_Ung_Vien(string maUV)
        {
            InitializeComponent();
            this.maUV = maUV;
        }
        public void HienThiTHongTin()
        {
            Bus_Ung_Vien ungVien = new Bus_Ung_Vien();
            SqlDataReader reader = ungVien.hienThiThongTinUngVien(maUV);
            while(reader.Read())
            {
                txtHoTen.Text = reader.GetString(1);
                txtDiaChi.Text = reader.GetString(2);
                txtNgaySinh.Text = reader.GetString(3);
                txtSdt.Text = reader.GetString(4);
                txtEmail.Text = reader.GetString(5);
                txtTrinhDo.Text = reader.GetString(6);
                txtKinhNghiem.Text = reader.GetString(7);
            }
            reader.Close();

        }
        private void Form_Thong_Tin_Ung_Vien_Load(object sender, EventArgs e)
        {
            HienThiTHongTin();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhatThongTinUngVien_Click(object sender, EventArgs e)
        {
            UNGVIEN ungVien = new UNGVIEN("", txtTrinhDo.Text, txtKinhNghiem.Text, "", txtHoTen.Text, txtNgaySinh.Text, txtDiaChi.Text, txtSdt.Text, txtEmail.Text);
            Bus_Ung_Vien uv = new Bus_Ung_Vien();
            if (uv.capNhatTTUngVien(maUV, ungVien))
            {
                HienThiTHongTin();
                MessageBox.Show("Cập Nhật Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Cập Nhật Không Thành Công!. Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
