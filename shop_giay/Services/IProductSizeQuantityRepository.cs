using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface IProductSizeQuantityRepository
    {
        JsonResult? AddProDuctSizeQuantity(ProductSizeQuantityMD pds);
        JsonResult? DeleteProDuctSizeQuantity(int id);
        JsonResult? EditProDuctSizeQuantity(ProductSizeQuantityVM pds);
        List<ProductSizeQuantityMD> GetAll();
    }
    public class ProductSizeQuantityRepository : IProductSizeQuantityRepository
    {
        private readonly ShopGiayContext _context;

        public ProductSizeQuantityRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        public JsonResult? AddProDuctSizeQuantity(ProductSizeQuantityMD pds)
        {
            var a = new ProductSizeQuantity()
            {
                IdSanPhamGiay = pds.IdSanPhamGiay,
                IdSize = pds.IdSize,
            };
            _context.ProductSizeQuantities.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult? DeleteProDuctSizeQuantity(int id)
        {
            var a = _context.ProductSizeQuantities.SingleOrDefault(l => l.IdSizeQuanltity == id);
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

        public JsonResult? EditProDuctSizeQuantity(ProductSizeQuantityVM pds)
        {
            var Editpds = _context.ProductSizeQuantities.SingleOrDefault(l => l.IdSizeQuanltity == id);
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
            }).ToList();
            return kq;
        }
    }
}
