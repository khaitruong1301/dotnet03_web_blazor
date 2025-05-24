public static class DbSanPham
{
    public static List<SanPhamVM> lst = new List<SanPhamVM>();
    static DbSanPham()
    {
        for (int i = 1; i <= 3; i++)
        {
            SanPhamVM sp = new SanPhamVM()
            {
                MaSanPham = i,
                TenSanPham = $"Sản phẩm {i}",
                HinhAnh = $"https://dummyimage.com/200x200?text=sản phẩm {i}",
                GiaBan = 1000 * i
            };
            lst.Add(sp);
        }
    }
}