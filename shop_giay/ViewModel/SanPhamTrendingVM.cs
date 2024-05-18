namespace shop_giay.ViewModel
{
    public class SanPhamTrendingVM
    {
        public int? IsSanPham { get; set; }

    }
    public class HienTrendingAndYeuThich
    {
        public List<SanPhamTrendingVM> SPTD { get; set; }
        public List<SanPhamYeuThichVMNoUserName> SPYT { get; set; }
       
    }
}
