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

<<<<<<< Updated upstream
    public class DonNhapHangHoaMD:DonNhapHangHoaVM
=======

    public class DonNhapHangHoaMD : DonNhapHangHoaVM
>>>>>>> Stashed changes
    {
        public int IdDonNhap { get; set; }
      

<<<<<<< Updated upstream
   
=======

>>>>>>> Stashed changes
        public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

        public virtual NhaCungCap? IdNhaCungCapNavigation { get; set; }

        public virtual TinhTrangDon? IdTinhTrangDonNavigation { get; set; }
    }

}


