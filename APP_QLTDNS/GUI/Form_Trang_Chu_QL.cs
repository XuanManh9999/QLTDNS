using BUS;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
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

        private void CloseAllFormsExceptOne(Form formToKeep)
        {
            // Lặp qua tất cả các form đang mở
            foreach (Form form in Application.OpenForms)
            {
                // Nếu form hiện tại không phải là form cần giữ lại
                if (form != formToKeep)
                {
                    // Đóng form hiện tại
                    form.Close();
                }
            }
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có Chắc Chắn Muốn Thoát", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Form_Dang_Nhap form_Dang_Nhap = new Form_Dang_Nhap;
                CloseAllFormsExceptOne(form_Dang_Nhap);
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

        private void btnQuanLyUngVien_Click(object sender, EventArgs e)
        {
            Form_Quan_Ly_Ung_Vien quanLyUngVien = new Form_Quan_Ly_Ung_Vien();
            quanLyUngVien.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // kết xuất nguồn dữ liệu cho report
            Bus_Quan_Ly bus_Quan_Ly = new Bus_Quan_Ly();
            SqlDataReader reader = bus_Quan_Ly.UngVienDuocTuyenDung();
            DataTable data = new DataTable("Hiển Thị TT");
            data.Load(reader);
            rptUngVienUngTuyen baoCao = new rptUngVienUngTuyen();
            baoCao.SetDataSource(data);
            // hiển thị báo cáo
            FormInBao_Cao f = new FormInBao_Cao();
            f.crystalReportViewer1.ReportSource = baoCao;
            f.ShowDialog();
        }

        private void Form_Trang_Chu_QL_Load(object sender, EventArgs e)
        {

        }
    }
}
