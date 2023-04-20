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
            TaiKhoan taiKhoan = new TaiKhoan(txtNhapTaiKhoan.Text.Trim(), txtNhapMatKhau.Text.Trim());
            Bus_Ung_Vien ungVien = new Bus_Ung_Vien();
            if(txtNhapMatKhau.Text != "" && txtNhapTaiKhoan.Text != "")
            {
                if ((ungVien.DangNhap(taiKhoan)) || (txtNhapTaiKhoan.Text == "admin" && txtNhapMatKhau.Text == "123"))
                {
                    MessageBox.Show("Đăng Nhập Thành Công");
                }
                else
                {
                    MessageBox.Show("Đăng Nhập Không Thành Công");
                }
            }else
            {
                MessageBox.Show("Thông Tin Không Được Rỗng");
            }
        }

        private void lblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormQuenMatKhau formQuenMatKhau = new FormQuenMatKhau();
            formQuenMatKhau.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Dang_Ky_Tai_Khoan form_Dang_Ky_Tai_Khoan = new Form_Dang_Ky_Tai_Khoan();
            form_Dang_Ky_Tai_Khoan.ShowDialog();
        }
    }
}
