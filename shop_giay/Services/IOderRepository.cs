using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_giay.Data;
using shop_giay.ViewModel;
using System.Security.Cryptography.Xml;

namespace shop_giay.Services
{
    public interface IOderRepository
    {
        JsonResult AddOrder(OrderVM odr);
        JsonResult DeleteLoaiUser(int id);
        JsonResult EditOrder(int id, OrderVM odr);
        List<OrderMD> GetAll();
        List<XemChiTietOrder> XemChiTietOrders(int doi);
    }

    public class OderRepository : IOderRepository
    {
        private readonly ShopGiayContext _context;

        public OderRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        public JsonResult AddOrder(OrderVM odr)
        {
           
             var a = new Order()
            {
              IdUser=odr.IdUser,
              NgayOrder=DateTime.Now,
             
            };
            _context.Orders.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteLoaiUser(int id)
        {
            var a = _context.Orders.SingleOrDefault(l => l.IdOrder == id);
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

        public JsonResult EditOrder(int id, OrderVM odr)
        {
            var editorder = _context.Orders.SingleOrDefault(l => l.IdOrder == id);
            if (editorder == null)
            {
                return new JsonResult("Khong tim thay Order")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editorder.IdUser = odr.IdUser;
                editorder.NgayOrder = odr.NgayOrder;
                editorder.TongTien = odr.TongTien;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<OrderMD> GetAll()
        {
            var kq = _context.Orders.Select(o => new OrderMD
            {
                IdOrder=o.IdOrder,
                IdUser=o.IdUser,
                NgayOrder=o.NgayOrder,
                TongTien=o.TongTien,
               
            }).ToList();
            return kq;
        }
        
        public List<XemChiTietOrder> XemChiTietOrders(int doi)
        {
            var xem = _context.Users.Where(l => l.IdUser == doi).Include(u => u.Orders).ThenInclude(a => a.ChiTietOrders).ThenInclude(g => g.IdSanPhamNavigation).SingleOrDefault();

            var hien = xem.Orders.Select(u => new XemChiTietOrder()
            {
                XemChiTietOrders = u.ChiTietOrders.Select(u => new ChiTietchoOrder()
                {
                    TenSanPham = u.IdSanPhamNavigation.TenSanPham,
                    SoLuong = u.SoLuong,
                    Gia=u.Gia,
                    Ratting = u.Ratting,
                    Review = u.Review
                }).ToList(),
                NgayOrder = u.NgayOrder,
                TongTien = u.TongTien,
            });

            return hien.ToList();
        }
    }
}
