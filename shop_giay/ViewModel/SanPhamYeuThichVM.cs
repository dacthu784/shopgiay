using Microsoft.AspNetCore.Mvc.ModelBinding;
using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class SanPhamYeuThichVM
    {
        [BindNever]
        public int IdUser { get; set; }

        public int IdsanPham { get; set; }

        public DateTime? AddedDate { get; set; }

        public bool? ChoPhepGuiEmail { get; set; }
    }
    public class SanPhamYeuThichMD : SanPhamGiayVM
    {
        public int IdSanPhamYeuThich { get; set; }
        public virtual User? IdUserNavigation { get; set; } = null!;

        public virtual ProductSizeQuantity? IdSanPhamNavigation { get; set; }
    }
}
