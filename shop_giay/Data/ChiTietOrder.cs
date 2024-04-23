﻿using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class ChiTietOrder
{
    public int IdOrder { get; set; }

    public int IdSanPham { get; set; }

    public int? SoLuong { get; set; }

    public decimal? Gia { get; set; }

    public string? Ratting { get; set; }

    public string? Review { get; set; }

    public int? Idloai { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual SanPhamGiay IdSanPhamNavigation { get; set; } = null!;

    public virtual LoaiGiay? IdloaiNavigation { get; set; }
}
