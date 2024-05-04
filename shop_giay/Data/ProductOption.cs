using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class ProductOption
{
    public int OptionId { get; set; }

    public int ProductId { get; set; }

    public string? OptionName { get; set; }

    public string? OptionValue { get; set; }

    public int? SoLuong { get; set; }

    public virtual SanPhamGiay Product { get; set; } = null!;
}
