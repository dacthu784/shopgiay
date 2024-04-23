using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class DonNhapHangHoa
{
    public int IdDonNhap { get; set; }

    public int? IdNhaCungCap { get; set; }

    public DateTime? NgayTaoDon { get; set; }

    public int? IdTinhTrangDon { get; set; }

    public double? TongTien { get; set; }

    public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

    public virtual NhaCungCap? IdNhaCungCapNavigation { get; set; }

    public virtual TinhTrangDon? IdTinhTrangDonNavigation { get; set; }
}
