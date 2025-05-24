public class SanPhamGioHang
{
    public int MaSanPham { get; set; }
    public string? TenSanPham { get; set; }
    public double GiaBan { get; set; }
    public double SoLuong { get; set; }
    public string? HinhAnh { get; set; }

    public string tinhTongTien()
    {
        return (SoLuong * GiaBan).ToString("N0"); //10,000,000.00
    }
}


