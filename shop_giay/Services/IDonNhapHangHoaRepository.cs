using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface IDonNhapHangHoaRepository
    {
        JsonResult AddDonNhapHangHoa(DonNhapHangHoaVM dnhh);
        JsonResult DeleteDonNhapHangHoa(int id);
        JsonResult EditDonNhapHangHoa(int id, DonNhapHangHoaVM dnhh);
        List<DonNhapHangHoaMD> GetAll();
    }
    public class DonNhapHangHoaRepository : IDonNhapHangHoaRepository
    {
        private readonly ShopGiayContext _context;

        public DonNhapHangHoaRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        public JsonResult AddDonNhapHangHoa(DonNhapHangHoaVM dnhh)
        {
            var a = new DonNhapHangHoa()
            {
                IdNhaCungCap = dnhh.IdNhaCungCap,
                NgayTaoDon = dnhh.NgayTaoDon,
                IdTinhTrangDon = dnhh.IdTinhTrangDon,
                TongTien = dnhh.TongTien
            };
            _context.DonNhapHangHoas.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteDonNhapHangHoa(int id)
        {
            var a = _context.DonNhapHangHoas.SingleOrDefault(l => l.IdDonNhap == id);
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

        public JsonResult EditDonNhapHangHoa(int id, DonNhapHangHoaVM dnhh)
        {
            var editdonnhaphanghoa = _context.DonNhapHangHoas.SingleOrDefault(l => l.IdDonNhap == id);
            if (editdonnhaphanghoa == null)
            {
                return new JsonResult("Khong tim thay Don nhap hang hoa")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editdonnhaphanghoa.IdNhaCungCap = dnhh.IdNhaCungCap;
                editdonnhaphanghoa.NgayTaoDon = dnhh.NgayTaoDon;
                editdonnhaphanghoa.IdTinhTrangDon = dnhh.IdTinhTrangDon;
                editdonnhaphanghoa.TongTien = dnhh.TongTien;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<DonNhapHangHoaMD> GetAll()
        {
            var kq = _context.DonNhapHangHoas.Select(o => new DonNhapHangHoaMD
            {
              IdDonNhap=o.IdDonNhap,
              IdNhaCungCap=o.IdNhaCungCap,
              NgayTaoDon=o.NgayTaoDon,
              IdTinhTrangDon=o.IdTinhTrangDon,
              TongTien=o.TongTien
            }).ToList();
            return kq;
        }
    }
}
