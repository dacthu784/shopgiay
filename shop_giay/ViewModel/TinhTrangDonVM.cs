using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class TinhTrangDonVM
    {
        public string? TenTinhTrang { get; set; }

        public string? MaTinhTrang { get; set; }

    }
    public class TinhTrangDonMD:TinhTrangDonVM 
    {
        public int IdTinhTrangDon { get; set; }


        public virtual ICollection<DonNhapHangHoa> DonNhapHangHoas { get; set; } = new List<DonNhapHangHoa>();
    }
}
