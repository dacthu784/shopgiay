using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface IProductSizeQuantityRepository
    {
        JsonResult AddProDuctSizeQuantity(ProductSizeQuantityVM pds);
        JsonResult DeleteProDuctSizeQuantity(int id);
        JsonResult EditProDuctSizeQuantity(int id, ProductSizeQuantityVM pds);
        List<ProductSizeQuantityMD> GetAll();
    }
    public class ProductSizeQuantityRepository : IProductSizeQuantityRepository
    {
        private readonly ShopGiayContext _context;

        public ProductSizeQuantityRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        public JsonResult AddProDuctSizeQuantity(ProductSizeQuantityVM pds)
        {
            var sanPhamGiaySum = _context.SanPhamGiays.SingleOrDefault(sp => sp.IdSanPham == pds.IdSanPhamGiay);
            sanPhamGiaySum.SoLuong = sanPhamGiaySum?.SoLuong ?? 0 + pds.SoLuong;
            var a = new ProductSizeQuantity()
            {
                IdSanPhamGiay = pds.IdSanPhamGiay,
                IdSize = pds.IdSize,
                SoLuong = pds.SoLuong,
                
                IdSanPhamGiayNavigation = new SanPhamGiay{
                    SoLuong =   sanPhamGiaySum.SoLuong
                }
                
            };
            _context.ProductSizeQuantities.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteProDuctSizeQuantity(int id)
        {
           
           
            var a = _context.ProductSizeQuantities.SingleOrDefault(l => l.IdSizeQuanltity == id);
            var sanPhamGiayTru = _context.SanPhamGiays.SingleOrDefault(sp => sp.IdSanPham == a.IdSanPhamGiay);
            sanPhamGiayTru.SoLuong = sanPhamGiayTru?.SoLuong ?? 0 - a.SoLuong;
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

        public JsonResult EditProDuctSizeQuantity(int id, ProductSizeQuantityVM pds)
        {
            var Editpds = _context.ProductSizeQuantities.SingleOrDefault(l => l.IdSizeQuanltity == id);
            var sanPhamGiayTru = _context.SanPhamGiays.SingleOrDefault(sp => sp.IdSanPham == pds.IdSanPhamGiay);
            
            if (Editpds == null)
            {
                return new JsonResult("Khong tim thay ProductSizeQuantity")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                Editpds.IdSanPhamGiay = pds.IdSanPhamGiay;
                Editpds.IdSize = pds.IdSize;
                Editpds.SoLuong = pds.SoLuong;
                sanPhamGiayTru.SoLuong = sanPhamGiayTru?.SoLuong ?? 0 - (Editpds.SoLuong - pds.SoLuong);

                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<ProductSizeQuantityMD> GetAll()
        {
            var kq = _context.ProductSizeQuantities.Select(pds => new ProductSizeQuantityMD
            {
             IdSizeQuanltity=pds.IdSizeQuanltity,
             IdSanPhamGiay=pds.IdSanPhamGiay,
             IdSize=pds.IdSize,
             SoLuong=pds.SoLuong,
            }).ToList();
            return kq;
        }
    }
}
