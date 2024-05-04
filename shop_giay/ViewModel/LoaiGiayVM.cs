using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class LoaiGiayVM
    {
        public string? MaLoaiGiay { get; set; }

        public string? TenLoaiGiay { get; set; }

        public int? ThuTuHienThi { get; set; }

       
    }
    public class LoaiGiayMD:LoaiGiayVM
    {
        public int IdLoaiGiay { get; set; }

        

        public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; } = new List<ChiTietOrder>();

        public virtual ICollection<SanPhamGiay> SanPhamGiays { get; set; } = new List<SanPhamGiay>();
    }
}
