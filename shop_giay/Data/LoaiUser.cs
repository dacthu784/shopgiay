using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class LoaiUser
{
    public int IdLoaiUser { get; set; }

    public string? MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
