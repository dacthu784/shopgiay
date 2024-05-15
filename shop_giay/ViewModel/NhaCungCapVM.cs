using shop_giay.Data;
using System.ComponentModel.DataAnnotations;

namespace shop_giay.ViewModel
{
    public class NhaCungCapVM
    {
        public string? TenNhaCungCap { get; set; }

        public string? DiaChi { get; set; }
        [RegularExpression("^[0-9]{10,11}$", ErrorMessage = "Nhap sai SDT")]
        public string? DienThoai { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
    public class NhaCungCapMD:NhaCungCapVM 
    {
        public int IdNhaCungCap { get; set; }

        

        public virtual ICollection<DonNhapHangHoa> DonNhapHangHoas { get; set; } = new List<DonNhapHangHoa>();
    }
}
