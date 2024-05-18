using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class SanPhamYeuThich
{
    public int IdSanPhamYeuThich { get; set; }

    public int? IdUser { get; set; }

    public int? IdSanPham { get; set; }

    public DateTime? AddedDate { get; set; }

    public virtual ProductSizeQuantity? IdSanPhamNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
