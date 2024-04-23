using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdUser { get; set; }

    public DateTime? NgayOrder { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; } = new List<ChiTietOrder>();

    public virtual User? IdUserNavigation { get; set; }
}
