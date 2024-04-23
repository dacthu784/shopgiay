using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class LoaiGiay
{
    public int IdLoaiGiay { get; set; }

    public string? MaLoaiGiay { get; set; }

    public string? TenLoaiGiay { get; set; }

    public int? ThuTuHienThi { get; set; }

    public int? DanhSachCha { get; set; }

    public int? DanhSachCon { get; set; }

    public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; } = new List<ChiTietOrder>();

    public virtual ICollection<SanPhamGiay> SanPhamGiays { get; set; } = new List<SanPhamGiay>();
}
