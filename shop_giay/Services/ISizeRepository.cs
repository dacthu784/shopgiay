using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface ISizeRepository
    {
        JsonResult? AddSize(SizeVM size);
        JsonResult? DeleteSize(int id);
        JsonResult? EditSize(int id, SizeVM size);
        List<SizeMD> GetAll();
    }
    public class SizeRepository : ISizeRepository
    {
        private readonly ShopGiayContext _context;

        public SizeRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        public JsonResult? AddSize(SizeVM size)
        {
            var a = new Size()
            {
                Size1 = size.Size1,
            };
            _context.Sizes.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult? DeleteSize(int id)
        {
            var a = _context.Sizes.SingleOrDefault(l => l.IdSize == id);
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

        public JsonResult? EditSize(int id, SizeVM size)
        {
            var Editsize = _context.Sizes.SingleOrDefault(l => l.IdSize == id);
            if (Editsize == null)
            {
                return new JsonResult("Khong tim thay Size")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                Editsize.Size1 = size.Size1;



                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<SizeMD> GetAll()
        {
            var kq = _context.Sizes.Select(size => new SizeMD
            {
            IdSize = size.IdSize,
            Size1= size.Size1,
            }).ToList();
            return kq;
        }
    }
}
