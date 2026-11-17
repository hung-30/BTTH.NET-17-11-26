using System;
using System.Data;
using RETAILSALESSYSTEM.DAL;
using RETAILSALESSYSTEM.DTO;

namespace RETAILSALESSYSTEM.BUS
{
    public class SanPhamBUS
    {
        private SanPhamDAL dal = new SanPhamDAL();

        public DataTable LayDanhSach() => dal.LayDanhSachSanPham();
        public DataTable TimKiem(string tuKhoa) => dal.TimKiemSanPham(tuKhoa);

        public bool Them(SanPhamDTO sp)
        {
            if (string.IsNullOrWhiteSpace(sp.MaSP) || string.IsNullOrWhiteSpace(sp.TenSP))
                throw new Exception("Mã SP và Tên SP không được để trống!");
            if (sp.GiaBan <= 0 || sp.SoLuongTon < 0)
                throw new Exception("Giá bán phải > 0 và Tồn kho phải >= 0!");
            return dal.ThemSanPham(sp);
        }

        public bool Sua(SanPhamDTO sp)
        {
            if (sp.GiaBan <= 0 || sp.SoLuongTon < 0)
                throw new Exception("Giá bán phải > 0 và Tồn kho phải >= 0!");
            return dal.SuaSanPham(sp);
        }

        public bool Xoa(string maSP) => dal.XoaSanPham(maSP);
    }
}