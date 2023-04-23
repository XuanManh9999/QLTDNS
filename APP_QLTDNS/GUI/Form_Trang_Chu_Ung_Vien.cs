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
    public partial class Form_Trang_Chu_Ung_Vien : Form
    {
        private string MaUV = "";
        public Form_Trang_Chu_Ung_Vien()
        {
            InitializeComponent();
        }
        public Form_Trang_Chu_Ung_Vien(string maUV)
        {
            InitializeComponent();
            this.MaUV = maUV;
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
            if (result == DialogResult.Yes) {
                Form_Dang_Nhap form_Dang_Nhap = new Form_Dang_Nhap();
                CloseAllFormsExceptOne(form_Dang_Nhap);
            }
        }

        private void Form_Trang_Chu_Ung_Vien_Load(object sender, EventArgs e)
        {

        }

        private void btnXemViecLam_Click(object sender, EventArgs e)
        {
            Form_Xem_Viec_Lam form_Xem_Viec_Lam = new Form_Xem_Viec_Lam(MaUV);
            form_Xem_Viec_Lam.ShowDialog();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            Form_Thong_Tin_Ung_Vien form_Thong_Tin_Ung_Vien = new Form_Thong_Tin_Ung_Vien(MaUV);
            form_Thong_Tin_Ung_Vien.ShowDialog();
        }
    }
}
