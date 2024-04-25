using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface ISanPhamGiayRepository
    {
        JsonResult AddSanPham(SanPhamGiayVM spg);
        JsonResult DeleteSanPhamGiay(int id);
        JsonResult EditSanPhamGiay(int id, SanPhamGiayVM spg);
        List<SanPhamGiayMD> GetAll();
        public Task<SanPhamGiayMD> GetById(int id);
    }
    public class SanPhamGiayRepository : ISanPhamGiayRepository
    {
        private readonly ShopGiayContext _context;

        public SanPhamGiayRepository(ShopGiayContext context)
        {
            _context = context;
        }

        public JsonResult AddSanPham(SanPhamGiayVM spg)
        {
            var a = new SanPhamGiay()
            {
                IdLoaiGiay = spg.IdLoaiGiay,
                MoTa = spg.MoTa,
                SoLuong = spg.SoLuong,
                Gia = spg.Gia,
                GiamGia = spg.GiamGia,

            };
            _context.SanPhamGiays.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteSanPhamGiay(int id)
        {
            var a = _context.SanPhamGiays.SingleOrDefault(l => l.IdSanPham == id);
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

        public JsonResult EditSanPhamGiay(int id, SanPhamGiayVM spg)
        {
            var editsanphamgiay = _context.SanPhamGiays.SingleOrDefault(l => l.IdSanPham == id);
            if (editsanphamgiay == null)
            {
                return new JsonResult("Khong tim thay San pham giay")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editsanphamgiay.IdLoaiGiay = spg.IdLoaiGiay;
                editsanphamgiay.MoTa = spg.MoTa;
                editsanphamgiay.SoLuong = spg.SoLuong;
                editsanphamgiay.Gia = spg.Gia;
                editsanphamgiay.GiamGia = spg.GiamGia;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<SanPhamGiayMD> GetAll()
        {
            var kq = _context.SanPhamGiays.Select(o => new SanPhamGiayMD
            {
               IdSanPham=o.IdSanPham,
               IdLoaiGiay=o.IdLoaiGiay,
               MoTa=o.MoTa,
               SoLuong=o.SoLuong,
               Gia=o.Gia,
               GiamGia=o.GiamGia,
              
            }).ToList();
            return kq;
        }

        public async Task<SanPhamGiayMD> GetById(int id)
        {
            var spg = await _context.SanPhamGiays.FirstOrDefaultAsync(l => l.IdSanPham == id);
            if (spg == null)
                return null!;
            return new SanPhamGiayMD
            {

                IdLoaiGiay = spg.IdLoaiGiay,
                MoTa = spg.MoTa,
                SoLuong = spg.SoLuong,
                Gia = spg.Gia,
                GiamGia = spg.GiamGia,
            };
        }
    }
 

}
