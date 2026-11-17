using System;
using System.Collections.Generic;
using System.Windows.Forms;
// Nhớ using thư mục DTO và BUS của bạn, ví dụ:
// using QuanLyBanHang.DTO;
// using QuanLyBanHang.BUS;

namespace RETAILSALESSYSTEM.GUI
{
    public partial class FormBanHang : Form
    {
        private decimal tongTienHoaDon = 0;
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();

        public FormBanHang()
        {
            InitializeComponent();
        }

        // 1. Xử lý nút "Thêm vào giỏ"
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim().ToUpper(); // Tự động viết hoa mã nhập vào
            int soLuong = (int)nudSoLuong.Value;

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm!");
                return;
            }

            try
            {
                // Lấy giá thật từ SQL Server
                decimal donGia = hoaDonBUS.LayGiaSanPham(maSP);
                decimal thanhTien = donGia * soLuong;

                dgvGioHang.Rows.Add(maSP, soLuong, donGia, thanhTien);

                tongTienHoaDon += thanhTien;
                lblTongTien.Text = tongTienHoaDon.ToString("N0") + " VNĐ";

                txtMaSP.Clear();
                txtMaSP.Focus();
                nudSoLuong.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi nhập hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 2. Xử lý nút "Thanh toán"
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0 || (dgvGioHang.Rows.Count == 1 && dgvGioHang.Rows[0].IsNewRow))
            {
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }

            try
            {
                // Đóng gói dữ liệu Hóa Đơn (DTO)
                HoaDonDTO hd = new HoaDonDTO();
                hd.MaNV = 1; // Giả sử nhân viên ID = 1 đang đăng nhập
                hd.TongTien = tongTienHoaDon;

                if (!string.IsNullOrEmpty(txtMaKH.Text))
                    hd.MaKH = int.Parse(txtMaKH.Text); // Có mã KH
                else
                    hd.MaKH = null; // Khách lẻ

                // Đóng gói danh sách Chi tiết hóa đơn (DTO)
                List<ChiTietHoaDonDTO> listChiTiet = new List<ChiTietHoaDonDTO>();
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua dòng trống mặc định ở cuối

                    ChiTietHoaDonDTO ct = new ChiTietHoaDonDTO();
                    ct.MaSP = row.Cells["MaSP"].Value.ToString();
                    ct.SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    ct.DonGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                    listChiTiet.Add(ct);
                }

                // Gọi tầng BUS để thực thi Transaction
                bool ketQua = hoaDonBUS.ThanhToan(hd, listChiTiet);

                if (ketQua)
                {
                    MessageBox.Show("Thanh toán thành công!\nHóa đơn đã được lưu và điểm đã được cộng.", "Thông báo");
                    // Làm mới giao diện sau khi bán xong
                    dgvGioHang.Rows.Clear();
                    tongTienHoaDon = 0;
                    lblTongTien.Text = "0 VNĐ";
                    txtMaKH.Clear();
                }
            }
            catch (Exception ex)
            {
                // Nếu lỗi thiếu tồn kho, SqlTransaction sẽ Rollback và quăng lỗi ra đây
                MessageBox.Show("LỖI GIAO DỊCH (Đã Rollback):\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}