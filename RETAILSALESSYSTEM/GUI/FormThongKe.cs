using System;
using System.Windows.Forms;
using RETAILSALESSYSTEM.BUS; // Nhớ using BUS

namespace RETAILSALESSYSTEM.GUI
{
    public partial class FormThongKe : Form
    {
        private ThongKeBUS thongKeBUS = new ThongKeBUS();

        public FormThongKe()
        {
            InitializeComponent();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi ExecuteScalar tính tổng doanh thu
                decimal doanhThu = thongKeBUS.LayDoanhThuHomNay();
                lblDoanhThu.Text = "Doanh thu hôm nay: " + doanhThu.ToString("N0") + " VNĐ";

                // Gọi SqlDataReader lấy danh sách Top 5
                lstTop5.DataSource = thongKeBUS.LayTop5BanChay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy báo cáo: " + ex.Message);
            }
        }
    }
}