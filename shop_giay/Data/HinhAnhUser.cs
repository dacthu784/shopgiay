using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class HinhAnhUser
{
    public int IdHinhNguoiDung { get; set; }

    public int? Iduser { get; set; }

    public string? Urlimage { get; set; }

    public bool? Isavarta { get; set; }

    public virtual User? IduserNavigation { get; set; }
}
