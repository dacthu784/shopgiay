using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class ProductSizeQuantity
{
    public int IdSizeQuanltity { get; set; }

    public int? IdSanPhamGiay { get; set; }

    public int? IdSize { get; set; }

    public virtual SanPhamGiay? IdSanPhamGiayNavigation { get; set; }

    public virtual Size? IdSizeNavigation { get; set; }

    public virtual ICollection<SanPhamYeuThich> SanPhamYeuThiches { get; set; } = new List<SanPhamYeuThich>();
}
