using shop_giay.Data;

namespace shop_giay.ViewModel
{
    public class DonNhapHangHoaVM
    {
        public int? IdNhaCungCap { get; set; }

        public DateTime? NgayTaoDon { get; set; }

        public int? IdTinhTrangDon { get; set; }

        public double? TongTien { get; set; }

    }
<<<<<<< HEAD
    public class DonNhapHangHoaMD:DonNhapHangHoaVM
    {
        public int IdDonNhap { get; set; }
      
=======
    public class DonNhapHangHoaMD : DonNhapHangHoaVM
    {
        public int IdDonNhap { get; set; }

>>>>>>> 777673126970d71958c7b9b02b2f20988a2a3bbd
        public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

        public virtual NhaCungCap? IdNhaCungCapNavigation { get; set; }

        public virtual TinhTrangDon? IdTinhTrangDonNavigation { get; set; }
    }
<<<<<<< HEAD
=======
}

>>>>>>> 777673126970d71958c7b9b02b2f20988a2a3bbd
