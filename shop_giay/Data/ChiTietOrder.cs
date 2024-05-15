using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class ChiTietOrder
{
    public int IdOrder { get; set; }

    public int IdSanPham { get; set; }

    public int? SoLuong { get; set; }

    public decimal? Gia { get; set; }

    public int? Ratting { get; set; }

    public string? Review { get; set; }

    public int? Idloai { get; set; }

    public int? IdUser { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual SanPhamGiay IdSanPhamNavigation { get; set; } = null!;

    public virtual User? IdUserNavigation { get; set; }

    public virtual LoaiGiay? IdloaiNavigation { get; set; }
}
