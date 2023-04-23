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
    public partial class Form_Xem_Viec_Lam : Form
    {
        private string maTD = "";
        private string maUV = "";
        public Form_Xem_Viec_Lam()
        {
            InitializeComponent();
        }
        public Form_Xem_Viec_Lam(string maUV) 
        {
            InitializeComponent();
            this.maUV = maUV;
        }
        public void HienThiTT()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = "select * from TUYENDUNG";
            sqlCMD.Connection = CONECT.chuoiKetNoi();
            SqlDataReader reader = sqlCMD.ExecuteReader();
            lsvHienThi.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader.GetString(0));
                item.SubItems.Add(reader.GetString(1));
                item.SubItems.Add(reader.GetString(2));
                item.SubItems.Add(reader.GetDouble(3).ToString());
                item.SubItems.Add(reader.GetString(4));
                item.SubItems.Add(reader.GetString(5));
                lsvHienThi.Items.Add(item);
            }
            reader.Close();
        }
        private void Form_Xem_Viec_Lam_Load(object sender, EventArgs e)
        {
            HienThiTT();
        }

        private void lsvHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHienThi.SelectedItems.Count == 0) return;
            ListViewItem item = lsvHienThi.SelectedItems[0];
            maTD = item.SubItems[0].Text;
        }

        private void btnUngTuyen_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Ung_Vien ungVien = new Bus_Ung_Vien();
                if(ungVien.ungTuyen(maUV, maTD))
                {
                    MessageBox.Show("Ứng Tuyển Thành Công, bạn vui lòng đợi xét duyệt. Nếu được xét duyệt chúng tôi sẽ gọi điện cho bạn.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    MessageBox.Show("Ứng Tuyển Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ứng Tuyển Không Thành Công, có thể bạn ứng tuyển công việc này trước đó. Vui lòng đợi xét duyệt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                SqlDataReader reader = quanLy.timKiemTD(txtTiemKiem.Text);
                lsvHienThi.Items.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        item.SubItems.Add(reader.GetDouble(3).ToString());
                        item.SubItems.Add(reader.GetString(4));
                        item.SubItems.Add(reader.GetString(5));
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
    }
}
