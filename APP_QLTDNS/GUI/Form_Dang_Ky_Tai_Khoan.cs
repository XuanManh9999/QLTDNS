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
            Form_Cap_Nhat_Thong_Tin_Ung_Vien cap_Nhat_Thong_Tin_Ung_Vien = new Form_Cap_Nhat_Thong_Tin_Ung_Vien();
            this.Hide();
            cap_Nhat_Thong_Tin_Ung_Vien.ShowDialog();
        }
    }
}
