using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class ChiTietDonNhapVM
    {
        public int? IdDonNhapHangHoa { get; set; }

        public int? IdSanPham { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public int? Vat { get; set; }

        public double? ThanhTien { get; set; }

        public int? IdLoaiGiay { get; set; }
    }
    public class ChiTietDonNhapMD:ChiTietDonNhapVM 
    {
        public int IdChiTietDonNhap { get; set; }


        public virtual LoaiGiay? IdLoaiGiayNavigation { get; set; }
        public virtual DonNhapHangHoa? IdDonNhapHangHoaNavigation { get; set; }

        public virtual SanPhamGiay? IdSanPhamNavigation { get; set; }

    }
}
