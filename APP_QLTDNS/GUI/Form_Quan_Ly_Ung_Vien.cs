using BUS;
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
    public partial class Form_Quan_Ly_Ung_Vien : Form
    {
        private string maUV, maTD = "";
        public Form_Quan_Ly_Ung_Vien()
        {
            InitializeComponent();
        }
        public void hienThiTT()
        {
            Bus_Quan_Ly bus_Quan_Ly = new Bus_Quan_Ly();
            SqlDataReader reader = bus_Quan_Ly.hienThiUngVienUngTuyen();
            lsvHienThi.Items.Clear();
            while(reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetString(3));
                item.SubItems.Add(reader.GetString(4));
                item.SubItems.Add(reader.GetString(5));
                item.SubItems.Add(reader.GetString(6));
                item.SubItems.Add(reader.GetString(7));
                lsvHienThi.Items.Add(item);
            }
            reader.Close();
        }
        private void lsvHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHienThi.SelectedItems.Count == 0) return;
            ListViewItem item = lsvHienThi.SelectedItems[0];
            maUV = item.SubItems[6].Text;
            maTD = item.SubItems[7].Text;
        }

        private void Form_Quan_Ly_Ung_Vien_Load(object sender, EventArgs e)
        {
            hienThiTT();
        }

        private void txtTiemKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                SqlDataReader reader = quanLy.timKiemUngVien(txtTiemKiem.Text);
                lsvHienThi.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        item.SubItems.Add(reader.GetString(3));
                        item.SubItems.Add(reader.GetString(4));
                        item.SubItems.Add(reader.GetString(5));
                        item.SubItems.Add(reader.GetString(6));
                        item.SubItems.Add(reader.GetString(7));
                        lsvHienThi.Items.Add(item);
                    }
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Không Tìm Thấy");
                }
            }
            catch
            {
                MessageBox.Show("Tìm Kiếm Không Thành Công. Hãy Thử Lại Sau.");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly(); 
                if (quanLy.LoaiUngVien(maTD, maUV))
                {
                    hienThiTT();
                    MessageBox.Show("Loại Ứng Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch
            {
                MessageBox.Show("Loại Ứng Viên Không Thành Công, vui lòng thử lại sau!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
