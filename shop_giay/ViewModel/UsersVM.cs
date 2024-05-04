using shop_giay.Data;

namespace shop_giay.ViewModel
{
    
    public class UsersVM

    {
        public string? TenUser { get; set; }

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

        public virtual ICollection<SanPhamYeuThich> SanPhamYeuThiches { get; set; } = new List<SanPhamYeuThich>();
    }
    public class UsersSendMail
    {
        public int IdUser { get; set; }

        public string Email { get; set; }


    }
}
