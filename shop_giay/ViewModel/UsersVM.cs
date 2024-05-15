using Microsoft.AspNetCore.Mvc.ModelBinding;
using shop_giay.Data;
using System.ComponentModel.DataAnnotations;

namespace shop_giay.ViewModel
{
    
    public class UsersVM

    {
        public string? TenUser { get; set; }
        public string? HoTen { get; set; }

        public string? Password { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public string? DiaChi { get; set; }

        public int IdLoaiUsers { get; set; }
        [BindNever]
        public DateTime? NgayTao { get; set; }
        [BindNever]

        public DateTime? NgaySua { get; set; }
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

        [EmailAddress]
        public string Email { get; set; }


    }
    public class Login
    {
        public string UserOrEmail { get; set; }

        public string Password { get; set; }
    }
    public class DangKy
    {
        [EmailAddress]
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string TenUser { get; set; }
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).{1,3}$", ErrorMessage = "Mật khẩu phải có ít nhất 1 ký tự đặc biệt, ít nhất 1 chữ hoa và có độ dài từ 1 đến 3 ký tự.")]
        //[RegularExpression(@"^(?=(.*[A-Z].*[A-Z]))(?=(.*\W.*\W)).{1,3}$", ErrorMessage = "Mật khẩu phải có ít nhất 2 ký tự đặc biệt, ít nhất 2 chữ hoa và có độ dài từ 1 đến 3 ký tự.")]
        public string Password { get; set; }
       
        public string NhapLaiPassword { get; set; }
    }
    public class ChangePass
    {

        //public string Email { get; set; }
        public string UserOrEmail { get; set; }
        public string Password { get; set; }
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\W).{1,3}$", ErrorMessage = "Mật khẩu phải có ít nhất 1 ký tự đặc biệt, ít nhất 1 chữ hoa và có độ dài từ 1 đến 3 ký tự.")]
        public string DoiPassword { get; set; }
        public string PasswordNhapLai { get; set; }
    }
    public class ResetPass
    {
        public string TenUser { get; set; }

    }
    public class UsersHienAnh

    {
        public int IdUser { get; set; }
        public string? TenUser { get; set; }
        public string? HoTen { get; set; }

        public string? Password { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public string? DiaChi { get; set; }

        public int IdLoaiUsers { get; set; }
        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }
       
        public virtual ICollection<HinhAnhUserLuuAnh> HinhAnhUsers { get; set; } = new List<HinhAnhUserLuuAnh>();

    }
    public class EditForUser

    {
       
        public string? HoTen { get; set; }

        [EmailAddress]

        public string? Email { get; set; }

        public string? DiaChi { get; set; }

       
        

        public DateTime? NgaySua { get; set; }
    }
    
}
