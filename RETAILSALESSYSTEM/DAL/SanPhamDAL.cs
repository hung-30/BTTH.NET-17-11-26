using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RETAILSALESSYSTEM.DTO;

namespace RETAILSALESSYSTEM.DAL
{
    public class SanPhamDAL
    {
        private string connectionString = @"Data Source=LAPTOP-O2V1449S\SQLEXPRESS;Initial Catalog=SalesDB;Integrated Security=True;TrustServerCertificate=True";

        // 1. Lấy toàn bộ danh sách Sản phẩm
        public DataTable LayDanhSachSanPham()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM SanPham";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Tìm kiếm theo Tên hoặc Mã SP dùng SqlParameter với %
        public DataTable TimKiemSanPham(string tuKhoa)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM SanPham WHERE MaSP LIKE @TuKhoa OR TenSP LIKE @TuKhoa";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 3. Thêm Sản phẩm
        public bool ThemSanPham(SanPhamDTO sp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon) VALUES (@MaSP, @TenSP, @GiaBan, @SoLuongTon)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 4. Sửa Sản phẩm
        public bool SuaSanPham(SanPhamDTO sp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE SanPham SET TenSP = @TenSP, GiaBan = @GiaBan, SoLuongTon = @SoLuongTon WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 5. Xóa Sản phẩm
        public bool XoaSanPham(string maSP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}