using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class HinhAnhUserVm
    {

        public int? Iduser { get; set; }

        public string? Urlimage { get; set; }

        public bool? Isavarta { get; set; }
    }
    public class HinhAnhUserMD:HinhAnhUserVm 
    {
        public int IdHinhNguoiDung { get; set; }


        public virtual User? IduserNavigation { get; set; }
    }
}
