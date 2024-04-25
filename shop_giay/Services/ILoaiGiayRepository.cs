using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface ILoaiGiayRepository
    {
        JsonResult AddLoaigiay(LoaiGiayVM loaigiay);
        JsonResult DeleteLoaiGiay(int id);
        JsonResult EditLoaiGiay(int id, LoaiGiayVM lg);
        List<LoaiGiayMD> GetAll();
    }

    public class LoaiGiayRepo : ILoaiGiayRepository
    {
        private readonly ShopGiayContext _context;

        public LoaiGiayRepo(ShopGiayContext context)
    {
            _context = context;
    }

        public JsonResult AddLoaigiay(LoaiGiayVM loaigiay)
        {
            var a = new LoaiGiay()
            {
                MaLoaiGiay = loaigiay.MaLoaiGiay,
                TenLoaiGiay = loaigiay.TenLoaiGiay,
                ThuTuHienThi = loaigiay.ThuTuHienThi,
                DanhSachCha = loaigiay.DanhSachCha,
                DanhSachCon = loaigiay.DanhSachCon,

            };
            _context.LoaiGiays.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteLoaiGiay(int id)
        {
            var a = _context.LoaiGiays.SingleOrDefault(l => l.IdLoaiGiay == id);
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

        public JsonResult EditLoaiGiay(int id, LoaiGiayVM lg)
        {
            var editLoaiGiay = _context.LoaiGiays.SingleOrDefault(l => l.IdLoaiGiay == id);
            if (editLoaiGiay == null)
            {
                return new JsonResult("Khong tim thay Loai giay")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editLoaiGiay.MaLoaiGiay = lg.MaLoaiGiay;
                editLoaiGiay.TenLoaiGiay = lg.TenLoaiGiay;
                editLoaiGiay.ThuTuHienThi = lg.ThuTuHienThi;
                editLoaiGiay.DanhSachCha = lg.DanhSachCha;
                editLoaiGiay.DanhSachCon = lg.DanhSachCon;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<LoaiGiayMD> GetAll()
        {
            var kq = _context.LoaiGiays.Select(o => new LoaiGiayMD
            {
                IdLoaiGiay=o.IdLoaiGiay,
                MaLoaiGiay = o.MaLoaiGiay,
                TenLoaiGiay= o.TenLoaiGiay,
                ThuTuHienThi=o.ThuTuHienThi,
                DanhSachCha=o.DanhSachCha,
                DanhSachCon=o.DanhSachCon,
             
            }).ToList();
            return kq;
        }
    }
}
