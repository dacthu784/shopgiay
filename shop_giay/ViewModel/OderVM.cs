using Microsoft.AspNetCore.Mvc.ModelBinding;
using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class OrderVM
    {
        public int IdOrder { get; set; }
        public int? IdUser { get; set; }

        [BindNever]
        public DateTime? NgayOrder { get; set; }
        [BindNever]
        public decimal? TongTien { get; set; }
    }
    public class OrderMD:OrderVM 
    {
        

        public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; } = new List<ChiTietOrder>();

        public virtual User? IdUserNavigation { get; set; }
    }

}
