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
    public partial class Form_Dang_Nhap : Form
    {
        public Form_Dang_Nhap()
        {
            InitializeComponent();
        }

        private void lblDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Dang_Ky_Tai_Khoan form_Dang_Ky_Tai_Khoan = new Form_Dang_Ky_Tai_Khoan();
            this.Hide();
            form_Dang_Ky_Tai_Khoan.ShowDialog();
        }
        private void CloseAllForms()
        {
            // Lặp qua tất cả các Form mở
            foreach (Form form in Application.OpenForms)
            {
                // Nếu Form hiện tại không phải là Form chính của ứng dụng
                if (form.Name != "Form_Dang_Nhap")
                {
                    // Đóng Form
                    form.Close();
                }
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            CloseAllForms();
        }
    }
}
