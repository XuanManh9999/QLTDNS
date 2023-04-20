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
        public Form_Cap_Nhat_Thong_Tin_Ung_Vien()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            Form_Dang_Nhap dangNhap = new Form_Dang_Nhap();
            this.Hide();
            dangNhap.ShowDialog();
        }
    }
}
