using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class Size
{
    public int IdSize { get; set; }

    public int? Size { get; set; }

    public virtual ICollection<ProductSizeQuantity> ProductSizeQuantities { get; set; } = new List<ProductSizeQuantity>();
}
