using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class NhaCungCap
{
    public int IdNhaCungCap { get; set; }

    public string? TenNhaCungCap { get; set; }

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<DonNhapHangHoa> DonNhapHangHoas { get; set; } = new List<DonNhapHangHoa>();
}
