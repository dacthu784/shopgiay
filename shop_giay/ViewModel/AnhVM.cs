using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class AnhVM
    {
        public string? Url { get; set; }

        public int? Idsanpham { get; set; }
    }
    public class AnhMD:AnhVM 
    {
        public int Id { get; set; }

   

        public virtual SanPhamGiay? IdsanphamNavigation { get; set; }
    }
    public class HienAnh
    {
        public string? Url { get; set; }

      
    }
}
