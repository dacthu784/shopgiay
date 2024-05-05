using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;
using System;

namespace shop_giay.Services
{
    public interface IAnhRepository
    {
        JsonResult AddAnh(AnhVM anh);
        JsonResult DeleteAnh(int id);
        JsonResult EditAnh(int id, AnhVM anh);
        List<AnhMD> GetAll();
    }
    public class AnhRepository : IAnhRepository
    {
        private readonly ShopGiayContext _context;

<<<<<<< Updated upstream
        public AnhRepository(ShopGiayContext context) 
=======
        AnhRepository(ShopGiayContext context) 
>>>>>>> Stashed changes
        {
            _context = context;
        
        }

        public JsonResult AddAnh(AnhVM anh)
        {

            var a = new Anh()
            {
                Url = anh.Url,
                Idsanpham = anh.Idsanpham,
            };
            _context.Anhs.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteAnh(int id)
        {
            var a = _context.Anhs.SingleOrDefault(l => l.Id == id);
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

        public JsonResult EditAnh(int id, AnhVM anh)
        {
            var editanh = _context.Anhs.SingleOrDefault(l => l.Id == id);
            if (editanh == null)
            {
                return new JsonResult("Khong tim thay Anh")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editanh.Url = anh.Url;
                editanh.Idsanpham = anh.Idsanpham;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<AnhMD> GetAll()
        {
            var kq = _context.Anhs.Select(anh => new AnhMD
            {
               Id=anh.Id,
               Url=anh.Url,
               Idsanpham=anh.Idsanpham,
            }).ToList();
            return kq;
        }
    }

}
