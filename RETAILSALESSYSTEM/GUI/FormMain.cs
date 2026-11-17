using System;
using System.Windows.Forms;

namespace RETAILSALESSYSTEM.GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // Gắn sự kiện click cho các nút bằng code (nếu chưa gán trong designer)
            btnSanPham.Click += BtnSanPham_Click;
            btnBanHang.Click += BtnBanHang_Click;
            btnThongKe.Click += BtnThongKe_Click;
        }

        private void BtnSanPham_Click(object sender, EventArgs e)
        {
            FormSanPham frm = new FormSanPham();
            frm.ShowDialog(); // Mở Form Sản phẩm lên, dùng ShowDialog để bắt buộc phải đóng form này mới quay lại Form Main được
        }

        private void BtnBanHang_Click(object sender, EventArgs e)
        {
            FormBanHang frm = new FormBanHang();
            frm.ShowDialog();
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            FormThongKe frm = new FormThongKe();
            frm.ShowDialog();
        }
    }
}