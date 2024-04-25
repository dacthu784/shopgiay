using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class OrderVM
    {
        public int? IdUser { get; set; }

        public DateTime? NgayOrder { get; set; }

        public decimal? TongTien { get; set; }
    }
    public class OrderMD:OrderVM 
    {
        public int IdOrder { get; set; }

        public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; } = new List<ChiTietOrder>();

        public virtual User? IdUserNavigation { get; set; }
    }
}
