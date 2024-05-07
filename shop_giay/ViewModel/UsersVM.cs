using shop_giay.Data;

namespace shop_giay.ViewModel
{
    
    public class UsersVM

    {
        public string? TenUser { get; set; }
        public string? HoTen { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }

        public string? DiaChi { get; set; }

        public int IdLoaiUsers { get; set; }
    }
    public class UsersMD : UsersVM
    {
        public int IdUser { get; set; }
        public virtual ICollection<HinhAnhUser> HinhAnhUsers { get; set; } = new List<HinhAnhUser>();

        public virtual LoaiUser IdLoaiUsersNavigation { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<SanPhamYeuThichVM> SanPhamYeuThiches { get; set; } = new List<SanPhamYeuThichVM>();
    }
    public class UsersSendMail
    {
        public int IdUser { get; set; }

        public string Email { get; set; }


    }
    public class Login
    {
        public string UserOrEmail { get; set; }

        public string Password { get; set; }
    }
    public class DangKy
    {
       
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string TenUser { get; set; }

        public string Password { get; set; }
       
        public string NhapLaiPassword { get; set; }
    }
    public class ChangePass
    {

        //public string Email { get; set; }
        public string UserOrEmail { get; set; }
        public string Password { get; set; }
        public string DoiPassword { get; set; }
        public string PasswordNhapLai { get; set; }
    }
    public class ResetPass
    {
        public string TenUser { get; set; }

    }
}
