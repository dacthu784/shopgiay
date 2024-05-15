using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface IChiTietOrderRepository
    {
        JsonResult AddChiTietOder(ChiTietOrderVM odr);
        JsonResult AddRatting(Rattings odr,int us);
        JsonResult deletechitietorder(int id, int idsp);
        JsonResult EditChiTietOder(ChiTietOrderEdit odr);
        List<ChiTietOrderMD> GetAll();
        ChiTietchoUser XemSP(int doi);
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
            var b = _context.Orders.Where(u => u.IdOrder == odr.IdOrder).SingleOrDefault();
            var c = _context.SanPhamGiays.SingleOrDefault(u=> u.IdSanPham == odr.IdSanPham);
            b.TongTien = b.TongTien?? 0 + odr.SoLuong * c.Gia;
            var a = new ChiTietOrder()
            {
                IdUser = b.IdUser,
                IdOrder = odr.IdOrder,
                IdSanPham = odr.IdSanPham,
                SoLuong = odr.SoLuong,
                Gia = odr.SoLuong * c.Gia
               
              
            };
            _context.ChiTietOrders.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult AddRatting(Rattings odr,int us)
        {

            var editchitietorder = _context.ChiTietOrders.SingleOrDefault(l => l.IdOrder == odr.IdOrder && l.IdSanPham == odr.IdSanPham && l.IdUser == us);
            if (editchitietorder == null)
            {
                return new JsonResult("Khong tim thay chi tiet order")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
               
                editchitietorder.Ratting = odr.Ratting;
                editchitietorder.Review = odr.Review;
                


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public JsonResult deletechitietorder(int id ,int idsp)
        {
            var a = _context.ChiTietOrders.SingleOrDefault(l => l.IdOrder == id && l.IdSanPham == idsp);
            var b = _context.Orders.Where(u => u.IdOrder == a.IdOrder).SingleOrDefault();
            b.TongTien = b.TongTien ?? 0 - a.Gia;
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

        public JsonResult EditChiTietOder(ChiTietOrderEdit odr)
        {
            var editchitietorder = _context.ChiTietOrders.SingleOrDefault(l => l.IdOrder == odr.IdOrder && l.IdSanPham == odr.IdSanPham);
            var b = _context.Orders.Where(u => u.IdOrder == editchitietorder.IdOrder).SingleOrDefault();
            var c = _context.SanPhamGiays.SingleOrDefault(u => u.IdSanPham == odr.IdSanPham);
            b.TongTien = b.TongTien?? 0 - editchitietorder.Gia + odr.SoLuong * c.Gia;
            if (editchitietorder == null)
            {
                return new JsonResult("Khong tim thay chi tiet order")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editchitietorder.IdOrder = odr.IdOrder;
                editchitietorder.IdSanPham = odr.IdSanPham;
                editchitietorder.SoLuong = odr.SoLuong;
                editchitietorder.Gia = odr.SoLuong * c.Gia;
               editchitietorder.IdUser = odr.IdUser;


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
               IdUser=o.IdUser,
           
            }).ToList();
            return kq;
        }

        public ChiTietchoUser XemSP(int doi)
        {
            var xem = _context.Users.Where(l => l.IdUser == doi).Include(u => u.ChiTietOrders).ThenInclude(t => t.IdSanPhamNavigation).SingleOrDefault();

            var a = new ChiTietchoUser()
            {
                TenSP = xem.ChiTietOrders.Select(o => o.IdSanPhamNavigation.TenSanPham).Distinct().ToList() 
            };

            return a;
        }
    }
}
