using BUS;
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
    public partial class FormQuenMatKhau : Form
    {
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnTroLaiTrangChu_Click(object sender, EventArgs e)
        {
           if (txtTenTaiKhoan.Text != "")
            {
                Bus_Ung_Vien ungVien = new Bus_Ung_Vien();
                if (ungVien.QuenMatKhau(txtTenTaiKhoan.Text) != "err")
                {
                    txtMatKhauQuen.Text = ungVien.QuenMatKhau(txtTenTaiKhoan.Text);
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng nhập tên tài khoản để lấy lại mật khẩu.");
            }
        }

        private void txtMatKhauQuen_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
