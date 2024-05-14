using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class ProductSizeQuantityVM
    {
       

        public int? IdSanPhamGiay { get; set; }

        public int? IdSize { get; set; }

        public int? SoLuong { get; set; }

      

    }
    public class ProductSizeQuantityMD: ProductSizeQuantityVM
    {
        public int IdSizeQuanltity { get; set; }
        public virtual SanPhamGiay? IdSanPhamGiayNavigation { get; set; }

        public virtual Size? IdSizeNavigation { get; set; }

        public virtual ICollection<SanPhamYeuThich> SanPhamYeuThiches { get; set; } = new List<SanPhamYeuThich>();
    }
  }
