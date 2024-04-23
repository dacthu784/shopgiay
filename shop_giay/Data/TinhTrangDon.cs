using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class TinhTrangDon
{
    public int IdTinhTrangDon { get; set; }

    public string? TenTinhTrang { get; set; }

    public string? MaTinhTrang { get; set; }

    public virtual ICollection<DonNhapHangHoa> DonNhapHangHoas { get; set; } = new List<DonNhapHangHoa>();
}
