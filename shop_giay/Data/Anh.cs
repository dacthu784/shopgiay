using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class Anh
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public int? Idsanpham { get; set; }

    public virtual SanPhamGiay? IdsanphamNavigation { get; set; }
}
