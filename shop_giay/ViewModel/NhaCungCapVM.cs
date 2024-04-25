using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class NhaCungCapVM
    {
        public string? TenNhaCungCap { get; set; }

        public string? DiaChi { get; set; }

        public string? DienThoai { get; set; }

        public string? Email { get; set; }
    }
    public class NhaCungCapMD:NhaCungCapVM 
    {
        public int IdNhaCungCap { get; set; }

        

        public virtual ICollection<DonNhapHangHoa> DonNhapHangHoas { get; set; } = new List<DonNhapHangHoa>();
    }
}
