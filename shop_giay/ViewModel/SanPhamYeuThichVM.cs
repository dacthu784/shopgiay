using Microsoft.AspNetCore.Mvc.ModelBinding;
using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class SanPhamYeuThichVM
    {
        [BindNever]
        public int IdUser { get; set; }

        public int? IdsanPham { get; set; }

        [BindNever]
        public DateTime? AddedDate { get; set; }

        public bool? ChoPhepGuiEmail { get; set; }
    }
    public class SanPhamYeuThichMD : SanPhamYeuThichVM
    {
        public int IdSanPhamYeuThich { get; set; }
        public virtual ProductSizeQuantity? IdSanPhamNavigation { get; set; }

        public virtual User? IdUserNavigation { get; set; }
    }
    public class SanPhamYeuThichVMNoUserName
    {
        public int IdSanPhamYeuThich { get; set; }
        public int? IdsanPham { get; set; }

        [BindNever]
        public DateTime? AddedDate { get; set; }

        public bool? ChoPhepGuiEmail { get; set; }

        public ProductSizeQuantityVM sanPhamGiayVM { get; set; }
        //    public int? IdSanPhamGiay { get; set; }

        //    public int? IdSize { get; set; }
        //}


    }
}
