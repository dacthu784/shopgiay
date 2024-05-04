using Emgu.CV;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface IChiTietDonNhapRepository
    {
        JsonResult AddChiTietDonNhap(ChiTietDonNhapVM ctdn);
        JsonResult DeleteChiTietDonNhap(int id);
        JsonResult EditChiTietDonNhap(int id, ChiTietDonNhapVM ctdn);
        List<ChiTietDonNhapMD> GetAll();
    }

    public class ChiTietDonNhapRepository : IChiTietDonNhapRepository
    {
        private readonly ShopGiayContext _context;

        public ChiTietDonNhapRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        public JsonResult AddChiTietDonNhap(ChiTietDonNhapVM ctdn)
        {
            var a = new ChiTietDonNhap()
            {
                IdSanPham = ctdn.IdSanPham,
                SoLuong = ctdn.SoLuong,
                DonGia = ctdn.DonGia,
                Vat = ctdn.Vat,
                ThanhTien = ctdn.ThanhTien,
            };
            _context.ChiTietDonNhaps.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteChiTietDonNhap(int id)
        {
            var a = _context.ChiTietDonNhaps.SingleOrDefault(l => l.IdChiTietDonNhap == id);
            if (a != null)
            {
                _context.Remove(a);
                _context.SaveChanges();
                return new JsonResult("da xoa thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new JsonResult("khong tim thay")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }

        public JsonResult EditChiTietDonNhap(int id, ChiTietDonNhapVM ctdn)
        {
            var EditChiTietDonNhap = _context.ChiTietDonNhaps.SingleOrDefault(l => l.IdChiTietDonNhap == id);
            if (EditChiTietDonNhap == null)
            {
                return new JsonResult("Khong tim thay Chi Tiet Don Nhap")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                EditChiTietDonNhap.IdSanPham = ctdn.IdSanPham;
                EditChiTietDonNhap.SoLuong = ctdn.SoLuong;
                EditChiTietDonNhap.DonGia = ctdn.DonGia;
                EditChiTietDonNhap.Vat = ctdn.Vat;
                EditChiTietDonNhap.ThanhTien = ctdn.ThanhTien;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }


        public List<ChiTietDonNhapMD> GetAll()
        {
            var kq = _context.ChiTietDonNhaps.Select(o => new ChiTietDonNhapMD
            {
                IdChiTietDonNhap = o.IdChiTietDonNhap,
              IdDonNhapHangHoa=o.IdDonNhapHangHoa,
              IdSanPham=o.IdSanPham,
              SoLuong=o.SoLuong,
              DonGia=o.DonGia,
              Vat=o.Vat,
              ThanhTien=o.ThanhTien,
            }).ToList();
            return kq;
        }
    }
}
