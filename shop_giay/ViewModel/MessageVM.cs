using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class MessageVM
    {
        public int? IdUser { get; set; }

        public string? NoiDungMessage { get; set; }

        public bool? LaTuAdmin { get; set; }

        public DateTime? DauThoiGian { get; set; }
    }
    public class MessageMD : MessageVM
    {
        public int IdMessage { get; set; }

        

        public virtual User? IdUserNavigation { get; set; }
    }
}
