using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class SanPhamGiayVM
    {
        public string? TenSanPham { get; set; }

        public decimal? Gia { get; set; }

        public int? IdLoaiGiay { get; set; }

        public string? MoTa { get; set; }

        public decimal? GiamGia { get; set; }

        public int SoLuong { get; set; }
    }
    public class SanPhamGiayMD:SanPhamGiayVM 
    {
        public int IdSanPham { get; set; }

       

        public virtual ICollection<Anh> Anhs { get; set; } = new List<Anh>();

        public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

        public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; } = new List<ChiTietOrder>();

        public virtual LoaiGiay? IdLoaiGiayNavigation { get; set; }
    }
}
