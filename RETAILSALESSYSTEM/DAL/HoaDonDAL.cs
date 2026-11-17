using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class HoaDonDAL
{
    // Thay đổi Data Source theo máy của bạn
    private string connectionString = @"Data Source=LAPTOP-O2V1449S\SQLEXPRESS;Initial Catalog=SalesDB;Integrated Security=True;TrustServerCertificate=True";

    public bool ThanhToanGiaoDich(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> dsChiTiet)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            // BẮT ĐẦU TRANSACTION ĐẢM BẢO ACID
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    // 1. Chèn Hóa Đơn (Lấy ID vừa tạo)
                    string sqlHD = "INSERT INTO HoaDon (MaNV, MaKH, TongTien) VALUES (@MaNV, @MaKH, @TongTien); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans);
                    cmdHD.Parameters.AddWithValue("@MaNV", hoaDon.MaNV);
                    cmdHD.Parameters.AddWithValue("@MaKH", hoaDon.MaKH.HasValue ? (object)hoaDon.MaKH.Value : DBNull.Value);
                    cmdHD.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);

                    int maHD = Convert.ToInt32(cmdHD.ExecuteScalar());

                    // 2. Xử lý Giỏ hàng (ChiTietHoaDon + Trừ Tồn Kho)
                    foreach (var ct in dsChiTiet)
                    {
                        // Trừ tồn kho (Kèm điều kiện Check > 0)
                        string sqlUpdateSP = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuong WHERE MaSP = @MaSP AND SoLuongTon >= @SoLuong";
                        SqlCommand cmdSP = new SqlCommand(sqlUpdateSP, conn, trans);
                        cmdSP.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                        cmdSP.Parameters.AddWithValue("@MaSP", ct.MaSP);

                        int rows = cmdSP.ExecuteNonQuery();
                        if (rows == 0) throw new Exception($"Sản phẩm {ct.MaSP} không đủ số lượng tồn kho!");

                        // Chèn Chi Tiết
                        string sqlCT = "INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES (@MaHD, @MaSP, @SoLuong, @DonGia)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                        cmdCT.Parameters.AddWithValue("@MaSP", ct.MaSP);
                        cmdCT.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                        cmdCT.Parameters.AddWithValue("@DonGia", ct.DonGia);
                        cmdCT.ExecuteNonQuery();
                    }

                    // 3. Cộng điểm tích lũy khách hàng (Nếu có)
                    if (hoaDon.MaKH.HasValue)
                    {
                        int diem = (int)(hoaDon.TongTien / 100000);
                        string sqlKH = "UPDATE KhachHang SET DiemTichLuy = DiemTichLuy + @Diem WHERE MaKH = @MaKH";
                        SqlCommand cmdKH = new SqlCommand(sqlKH, conn, trans);
                        cmdKH.Parameters.AddWithValue("@Diem", diem);
                        cmdKH.Parameters.AddWithValue("@MaKH", hoaDon.MaKH.Value);
                        cmdKH.ExecuteNonQuery();
                    }

                    // HOÀN TẤT TRANSACTION
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // LỖI -> HOÀN TÁC TOÀN BỘ
                    trans.Rollback();
                    throw new Exception("Thanh toán thất bại, đã Rollback: " + ex.Message);

                }
            }
        }
    }
    public decimal LayGiaSanPham(string maSP)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "SELECT GiaBan FROM SanPham WHERE MaSP = @MaSP";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaSP", maSP);

            object result = cmd.ExecuteScalar();
            if (result == null)
                throw new Exception("Không tìm thấy mã sản phẩm này trong kho!");

            return Convert.ToDecimal(result);
        }
    }
}
