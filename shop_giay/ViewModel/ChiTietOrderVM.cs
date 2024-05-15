using Microsoft.AspNetCore.Mvc.ModelBinding;
using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class ChiTietOrderVM
    {
        public int IdOrder { get; set; }
        public int IdSanPham { get; set; }

        public int? SoLuong { get; set; }
        [BindNever]
        public decimal? Gia { get; set; }

        //public int? Ratting { get; set; }

        //public string? Review { get; set; }

        //public int? Idloai { get; set; }
        [BindNever]
        public int? IdUser { get; set; }
    }
    public class ChiTietOrderMD:ChiTietOrderVM 
    {



        public int? Ratting { get; set; }

        public string? Review { get; set; }

        public int? Idloai { get; set; }

        public int? IdUser { get; set; }

        public virtual Order IdOrderNavigation { get; set; } = null!;

        public virtual SanPhamGiay IdSanPhamNavigation { get; set; } = null!;

        public virtual User? IdUserNavigation { get; set; }

        public virtual LoaiGiay? IdloaiNavigation { get; set; }
    }
    public class Danhgia
    {
       

       

        public int? Ratting { get; set; }

        public string? Review { get; set; }

      

        public int? IdUser { get; set; }
    }
    public class ChiTietchoUser
    {
        public List<string?> TenSP { get; set; }
       
    }
    public class ChiTietchoOrder
    {
        public string? TenSanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? Gia { get; set; }

        public int? Ratting { get; set; }

        public string? Review { get; set; }

     
    }
    public class Rattings
    {
        public int IdOrder { get; set; }
        public int IdSanPham { get; set; }



        public int? Ratting { get; set; }

        public string? Review { get; set; }

       

    }
    public class ChiTietOrderEdit
    {
        public int IdOrder { get; set; }
        public int IdSanPham { get; set; }

        public int? SoLuong { get; set; }
        [BindNever]
        public decimal? Gia { get; set; }

        //public int? Ratting { get; set; }

        //public string? Review { get; set; }

        //public int? Idloai { get; set; }
       
        public int? IdUser { get; set; }
    }
}
