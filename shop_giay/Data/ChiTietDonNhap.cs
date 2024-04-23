using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class ChiTietDonNhap
{
    public int IdChiTietDonNhap { get; set; }

    public int? IdDonNhapHangHoa { get; set; }

    public int? IdSanPham { get; set; }

    public int? SoLuong { get; set; }

    public double? DonGia { get; set; }

    public int? Vat { get; set; }

    public double? ThanhTien { get; set; }

    public virtual DonNhapHangHoa? IdDonNhapHangHoaNavigation { get; set; }

    public virtual SanPhamGiay? IdSanPhamNavigation { get; set; }
}
