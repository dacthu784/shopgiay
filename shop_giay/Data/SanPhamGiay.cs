using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class SanPhamGiay
{
    public int IdSanPham { get; set; }

    public string? TenSanPham { get; set; }

    public decimal? Gia { get; set; }

    public int? IdLoaiGiay { get; set; }

    public string? MoTa { get; set; }

    public decimal? GiamGia { get; set; }

    public int SoLuong { get; set; }

    public virtual ICollection<Anh> Anhs { get; set; } = new List<Anh>();

    public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

    public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; } = new List<ChiTietOrder>();

    public virtual LoaiGiay? IdLoaiGiayNavigation { get; set; }
}
