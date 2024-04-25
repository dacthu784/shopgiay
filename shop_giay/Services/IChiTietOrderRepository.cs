using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface IChiTietOrderRepository
    {
        JsonResult AddChiTietOder(ChiTietOrderVM odr);
        JsonResult deletechitietorder(int id);
        JsonResult EditChiTietOder(int id, ChiTietOrderVM odr);
        List<ChiTietOrderMD> GetAll();
    }
    public class ChiTietOrderRepository : IChiTietOrderRepository
    {
        private readonly ShopGiayContext _context;

        public ChiTietOrderRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        public JsonResult AddChiTietOder(ChiTietOrderVM odr)
        {

            var a = new ChiTietOrder()
            {
                IdSanPham = odr.IdSanPham,
                SoLuong = odr.SoLuong,
                Gia = odr.Gia,
                Ratting = odr.Ratting,
                Review = odr.Review,
                Idloai = odr.Idloai,
            };
            _context.ChiTietOrders.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult deletechitietorder(int id)
        {
            var a = _context.ChiTietOrders.SingleOrDefault(l => l.IdOrder == id);
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

        public JsonResult EditChiTietOder(int id, ChiTietOrderVM odr)
        {
            var editchitietorder = _context.ChiTietOrders.SingleOrDefault(l => l.IdOrder == id);
            if (editchitietorder == null)
            {
                return new JsonResult("Khong tim thay chi tiet order")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editchitietorder.IdSanPham = odr.IdSanPham;
                editchitietorder.SoLuong = odr.SoLuong;
                editchitietorder.Gia = odr.Gia;
                editchitietorder.Ratting = odr.Ratting;
                editchitietorder.Review = odr.Review;
                editchitietorder.Idloai = odr.Idloai;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<ChiTietOrderMD> GetAll()
        {
            var kq = _context.ChiTietOrders.Select(o => new ChiTietOrderMD
            {
               IdOrder=o.IdOrder,
               IdSanPham=o.IdSanPham,
               SoLuong=o.SoLuong,
               Gia=o.Gia,
               Ratting=o.Ratting,
               Review=o.Review,
               Idloai=o.Idloai,
           
            }).ToList();
            return kq;
        }
    }
}
