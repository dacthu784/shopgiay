using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class User
{
    public int IdUser { get; set; }

    public string? TenUser { get; set; }

    public string? HoTen { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public int IdLoaiUsers { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgaySua { get; set; }

    public virtual ICollection<ChiTietOrder> ChiTietOrders { get; set; } = new List<ChiTietOrder>();

    public virtual ICollection<HinhAnhUser> HinhAnhUsers { get; set; } = new List<HinhAnhUser>();

    public virtual LoaiUser IdLoaiUsersNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<SanPhamYeuThich> SanPhamYeuThiches { get; set; } = new List<SanPhamYeuThich>();
}
