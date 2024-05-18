using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class SanPhamSoLanNhap
{
    public int IdSpNhap { get; set; }

    public int? Idsanpham { get; set; }

    public int? SoLanNhap { get; set; }

    public virtual SanPhamGiay? IdsanphamNavigation { get; set; }
}
