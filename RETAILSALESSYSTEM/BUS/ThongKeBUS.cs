using System.Collections.Generic;
using RETAILSALESSYSTEM.DAL;

namespace RETAILSALESSYSTEM.BUS
{
    public class ThongKeBUS
    {
        private ThongKeDAL dal = new ThongKeDAL();
        public decimal LayDoanhThuHomNay() => dal.TinhDoanhThuHomNay();
        public List<string> LayTop5BanChay() => dal.LayTop5SanPhamBanChay();
    }
}