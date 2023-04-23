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
    public partial class Form_Quan_Ly_Tai_Khoan : Form
    {
        public Form_Quan_Ly_Tai_Khoan()
        {
            InitializeComponent();
        }

        private void lsvHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHienThi.SelectedItems.Count == 0) return;
            ListViewItem item = lsvHienThi.SelectedItems[0];
            tenTK = item.SubItems[1].Text;
            txtTaiKhoan.Text = item.SubItems[1].Text;
            txtMatKhau.Text = item.SubItems[2].Text;
        }
        string tenTK = "";
        public void HienThiTT()
        {
            Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
            SqlDataReader reader = quanLy.loadingTK();
            lsvHienThi.Items.Clear();
            while (reader.Read())
            {
                ListViewItem listViewItem = new ListViewItem("");
                listViewItem.SubItems.Add(reader.GetString(0));
                listViewItem.SubItems.Add(reader.GetString(1));
                lsvHienThi.Items.Add(listViewItem);
            }
            reader.Close();
        }
        private void Form_Quan_Ly_Tai_Khoan_Load(object sender, EventArgs e)
        {
            HienThiTT();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                TaiKhoan taiKhoan = new TaiKhoan(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim());
                if (quanLy.ThemTK(taiKhoan))
                {
                    HienThiTT();
                    MessageBox.Show("Thêm Thành Công");
                }
                else
                {
                    MessageBox.Show("Thêm Không Thành Công");
                }
            }catch
            {
                MessageBox.Show("Thêm không thành công. Có thể tên này đã có trong hệ thống");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                TaiKhoan taiKhoan = new TaiKhoan(txtTaiKhoan.Text.Trim(), txtMatKhau.Text.Trim());
                if (quanLy.suaTK(taiKhoan))
                {
                    HienThiTT();
                    MessageBox.Show("Sửa Tài Khoản Thành Công");
                }
                else
                {
                    MessageBox.Show("Sửa Không Thành Công");
                }
            }
            catch
            {
                MessageBox.Show("Sửa Không Thành Công. Lưu Ý Chỉ Có Thể Sửa Mật Khẩu");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                if (quanLy.xoaTK(tenTK))
                {
                    HienThiTT();
                    MessageBox.Show("Xóa Tài Khoản Thành Công!");
                }
                else
                {
                    MessageBox.Show("Xóa Tài Khoản Không Thành Công!");
                }
            }
            catch
            {
                MessageBox.Show("Xóa Tài Khoản Không Thành Công!. Vui lòng thử lại sau.");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                SqlDataReader reader = quanLy.timKiemTK(txtTiemKiem.Text);
                if (reader.HasRows)
                {
                    lsvHienThi.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem listViewItem = new ListViewItem("");
                        tenTK = reader.GetString(0);
                        listViewItem.SubItems.Add(reader.GetString(0));
                        listViewItem.SubItems.Add(reader.GetString(1));
                        lsvHienThi.Items.Add(listViewItem);
                    }
                    reader.Close();
                }else
                {
                    MessageBox.Show("Không Tìm Thấy");
                }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtTiemKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
