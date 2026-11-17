using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RETAILSALESSYSTEM.DAL
{
    public class ThongKeDAL
    {
        private string connectionString = @"Data Source=LAPTOP-O2V1449S\SQLEXPRESS;Initial Catalog=SalesDB;Integrated Security=True;TrustServerCertificate=True";

        // 1. Dùng ExecuteScalar tính tổng doanh thu trong ngày hôm nay
        public decimal TinhDoanhThuHomNay()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }

        // 2. Dùng SqlDataReader lấy Top 5 sản phẩm bán chạy nhất
        public List<string> LayTop5SanPhamBanChay()
        {
            List<string> danhSachTop5 = new List<string>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT TOP 5 sp.MaSP, sp.TenSP, SUM(ct.SoLuong) AS TongBan 
                               FROM ChiTietHoaDon ct 
                               JOIN SanPham sp ON ct.MaSP = sp.MaSP 
                               GROUP BY sp.MaSP, sp.TenSP 
                               ORDER BY TongBan DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    int hang = 1;
                    while (reader.Read())
                    {
                        string tenSP = reader["TenSP"].ToString();
                        string tongBan = reader["TongBan"].ToString();
                        danhSachTop5.Add($"Top {hang}: {tenSP} - Đã bán: {tongBan} cái");
                        hang++;
                    }
                }
            }
            return danhSachTop5;
        }
    }
}