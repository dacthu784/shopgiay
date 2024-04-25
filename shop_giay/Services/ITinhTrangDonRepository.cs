using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface ITinhTrangDonRepository
    {
        JsonResult AddTinhTrangDon(TinhTrangDonVM ttd);
        JsonResult DeleteTinhTrangdon(int id);
        JsonResult Edit(int id, TinhTrangDonVM ttd);
        List<TinhTrangDonMD> GetAll();
    }
    public class TinhTrangDonRepository : ITinhTrangDonRepository
    {
        private readonly ShopGiayContext _context;

        public TinhTrangDonRepository(ShopGiayContext context)
        {
            _context = context;
        }

        public JsonResult AddTinhTrangDon(TinhTrangDonVM ttd)
        {
            var a = new TinhTrangDon()
            {
              MaTinhTrang=ttd.MaTinhTrang,
              TenTinhTrang=ttd.TenTinhTrang
            };
            _context.TinhTrangDons.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteTinhTrangdon(int id)
        {
            var a = _context.TinhTrangDons.SingleOrDefault(l => l.IdTinhTrangDon == id);
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

        public JsonResult Edit(int id, TinhTrangDonVM ttd)
        {
            var edittinhtrangdon = _context.TinhTrangDons.SingleOrDefault(l => l.IdTinhTrangDon == id);
            if (edittinhtrangdon == null)
            {
                return new JsonResult("Khong tim thay Tinh trang don")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                edittinhtrangdon.MaTinhTrang = ttd.MaTinhTrang;
                edittinhtrangdon.TenTinhTrang = ttd.TenTinhTrang;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<TinhTrangDonMD> GetAll()
        {
            var kq = _context.TinhTrangDons.Select(o => new TinhTrangDonMD
            {
               IdTinhTrangDon=o.IdTinhTrangDon,
               MaTinhTrang=o.MaTinhTrang,
               TenTinhTrang=o.TenTinhTrang
            }).ToList();
            return kq;
        }
    }
}
