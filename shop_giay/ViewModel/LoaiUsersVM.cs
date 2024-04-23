//using shop_giay.Data;


using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class LoaiUsersVM
    {
        

        public string? MaLoai { get; set; }

        public string TenLoai { get; set; }

       
    }
    public class LoaiUsersMD : LoaiUsersVM
    {
        public int IdLoaiUser { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }

}
