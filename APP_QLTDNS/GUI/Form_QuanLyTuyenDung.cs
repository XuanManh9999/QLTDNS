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
    public partial class Form_QuanLyTuyenDung : Form
    {
        public Form_QuanLyTuyenDung()
        {
            InitializeComponent();
        }
        private string maTD = "";
        public void HienThiTT()
        {
            SqlCommand sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandText = "select * from TUYENDUNG ";
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
        private void Form_QuanLyTuyenDung_Load(object sender, EventArgs e)
        {
            HienThiTT();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                TuyenDung tuyenDung = new TuyenDung("", txtNoiDungTuyenDung.Text, txtPhucLoi.Text, float.Parse(txtLuong.Text), txtYeuCau.Text, DateThoiGian.Value.ToString("dd/MM/yyy"));
                if (quanLy.themTD(tuyenDung))
                {
                    HienThiTT();
                    MessageBox.Show("Thêm Thành Công");
                }
                else
                {
                    MessageBox.Show("Thêm Không Thành Công");
                }
            }
            catch
            {
                MessageBox.Show("Thêm không thành công. Có thể thông tin này đã có trong hệ thống");
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                TuyenDung tuyenDung = new TuyenDung(maTD, txtNoiDungTuyenDung.Text, txtPhucLoi.Text, float.Parse(txtLuong.Text), txtYeuCau.Text, DateThoiGian.Value.ToString("dd/MM/yyy"));
                if (quanLy.suaTD(tuyenDung))
                {
                    HienThiTT();
                    MessageBox.Show("Sửa Thành Công");
                }
                else
                {
                    MessageBox.Show("Sửa Không Thành Công");
                }
            }
            catch
            {
                MessageBox.Show("Sửa không thành công. Vui lòng kiểm tra và thử lại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Bus_Quan_Ly quanLy = new Bus_Quan_Ly();
                if (quanLy.xoaTD(maTD))
                {
                    HienThiTT();
                    MessageBox.Show("Xóa Thành Công");
                }
                else
                {
                    MessageBox.Show("Xóa Không Thành Công");
                }
            }
            catch
            {
                MessageBox.Show("Xóa không thành công. Vui lòng kiểm tra và thử lại");
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
                   while(reader.Read())
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
                }else
                {
                    MessageBox.Show("Không Tìm Thấy");
                }
            }
            catch
            {
                MessageBox.Show("Tìm Kiếm Không Thành Công. Hãy Thử Lại Sau.");
            }
        }

        private void lsvHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvHienThi.SelectedItems.Count == 0) return;
            ListViewItem item = lsvHienThi.SelectedItems[0];
            maTD = item.SubItems[0].Text;
            txtNoiDungTuyenDung.Text = item.SubItems[1].Text;
            txtPhucLoi.Text = item.SubItems[2].Text;
            txtLuong.Text = item.SubItems[3].Text;
            txtYeuCau.Text = item.SubItems[4].Text;
        }
    }
}
