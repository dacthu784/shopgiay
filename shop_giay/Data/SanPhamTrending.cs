using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class SanPhamTrending
{
    public int IdSptrending { get; set; }

    public int? IdProduct { get; set; }

    public virtual SanPhamGiay? IdProductNavigation { get; set; }
}
