using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class ChiTietOrderVM
    {
        public int IdSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? Gia { get; set; }

        public string? Ratting { get; set; }

        public string? Review { get; set; }

        public int? Idloai { get; set; }

        public int? IdUser { get; set; }
    }
    public class ChiTietOrderMD:ChiTietOrderVM 
    {

        public int IdOrder { get; set; }

        

        public virtual Order IdOrderNavigation { get; set; } = null!;

        public virtual SanPhamGiay IdSanPhamNavigation { get; set; } = null!;

        public virtual User? IdUserNavigation { get; set; }

        public virtual LoaiGiay? IdloaiNavigation { get; set; }
    }
}
