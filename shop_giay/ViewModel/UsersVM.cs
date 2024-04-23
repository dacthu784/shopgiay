using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class UsersVM
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        

    }
    

    public class UsersViewModel

    {
        public string? TenUser { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? DiaChi { get; set; }

        public int IdLoaiUsers { get; set; }
    }
}
