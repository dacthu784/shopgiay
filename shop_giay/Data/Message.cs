using System;
using System.Collections.Generic;

namespace shop_giay.Data;

public partial class Message
{
    public int IdMessage { get; set; }

    public int? IdUser { get; set; }

    public string? NoiDungMessage { get; set; }

    public bool? LaTuAdmin { get; set; }

    public DateTime? DauThoiGian { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
