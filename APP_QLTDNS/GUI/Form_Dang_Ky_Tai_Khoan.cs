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
    public partial class Form_Dang_Ky_Tai_Khoan : Form
    {
        public Form_Dang_Ky_Tai_Khoan()
        {
            InitializeComponent();
        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangKyTaiKhoan_Click(object sender, EventArgs e)
        {
            Bus_Ung_Vien ungVien = new Bus_Ung_Vien();
            TaiKhoan taiKhoan = new TaiKhoan(txtTenTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim());
            if(ungVien.DangKy(taiKhoan))
            {
                Form_Cap_Nhat_Thong_Tin_Ung_Vien cap_Nhat_Thong_Tin_Ung_Vien = new Form_Cap_Nhat_Thong_Tin_Ung_Vien(txtTenTaiKhoan.Text);
                this.Hide();
                MessageBox.Show("Đăng Ký Thành Công, Vui Lòng Cập Nhật Thêm Thông Tin Để Tương Tác Với Hệ Thống");
                cap_Nhat_Thong_Tin_Ung_Vien.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng Ký Không Thành Công, Vui Lòng Kiểm Tra Lại");
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
