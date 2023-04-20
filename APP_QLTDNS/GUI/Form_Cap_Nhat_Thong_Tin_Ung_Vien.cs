using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form_Cap_Nhat_Thong_Tin_Ung_Vien : Form
    {
        private string tenTK;
        public Form_Cap_Nhat_Thong_Tin_Ung_Vien()
        {
            InitializeComponent();
        }
        public Form_Cap_Nhat_Thong_Tin_Ung_Vien(string tenTK)
        {
            InitializeComponent();
            this.tenTK = tenTK;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if(txtHoTen.Text != "" && txtDiaChi.Text != "" && txtEmail.Text != "" && txtSoDienThoai.Text != "" && txtTrinhDo.Text != "" && txtKinhNghiem.Text != "")
            {
                Bus_Ung_Vien ungVien = new Bus_Ung_Vien();
                UNGVIEN ThanhVien1 = new UNGVIEN("", txtTrinhDo.Text, txtKinhNghiem.Text, tenTK, txtHoTen.Text, DateNgaySinh.Value.ToString("dd/MM/yyyy"), txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
                if (ungVien.bus_CapNhatThongTinUngVien(ThanhVien1))
                {
                    MessageBox.Show("Thêm Thông Tin Thành Công");
                    Form_Dang_Nhap dangNhap = new Form_Dang_Nhap();
                    this.Hide();
                    dangNhap.ShowDialog();
                }else
                {
                    MessageBox.Show("Thêm Thông Tin Không Thành Công");
                }
            }else
            {
                MessageBox.Show("Các Thông Tin Không Được Rỗng");
            }
        }
    }
}
