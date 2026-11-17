public class HoaDonBUS
{
    private HoaDonDAL dal = new HoaDonDAL();

    public bool ThanhToan(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> dsChiTiet)
    {
        if (dsChiTiet.Count == 0)
            throw new Exception("Giỏ hàng đang trống!");

        return dal.ThanhToanGiaoDich(hoaDon, dsChiTiet);
    }
    public decimal LayGiaSanPham(string maSP)
    {
        return dal.LayGiaSanPham(maSP);
    }
}