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
    public partial class Form_Trang_Chu_QL : Form
    {
        public Form_Trang_Chu_QL()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Thoát", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            Form_Quan_Ly_Tai_Khoan quan_Ly_Tai_Khoan = new Form_Quan_Ly_Tai_Khoan();
            quan_Ly_Tai_Khoan.ShowDialog();
        }

        private void btnQuanLyTuyenDung_Click(object sender, EventArgs e)
        {
            Form_QuanLyTuyenDung quanLyTuyenDung = new Form_QuanLyTuyenDung();
            quanLyTuyenDung.ShowDialog();
        }
    }
}
