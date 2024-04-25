using Microsoft.AspNetCore.Mvc;

using shop_giay.Data;


//using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface ILoaiUsersRepository
    {
        JsonResult AddLoaiUser(LoaiUsersVM lus);
        JsonResult DeleteLoaiUser(int id);
        JsonResult EditLoaiUser(int id, LoaiUsersVM us);
        List<LoaiUsersMD> GetAll();
    }
    public class LoaiUsersRepo : ILoaiUsersRepository
    {
        private readonly ShopGiayContext _context;

        public LoaiUsersRepo(ShopGiayContext context)
        {
            _context = context;
        }

        public JsonResult AddLoaiUser(LoaiUsersVM lus)
        {
            var a = new LoaiUser()
            {
              TenLoai=lus.TenLoai,
              MaLoai=lus.MaLoai,
            };
            _context.LoaiUsers.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteLoaiUser(int id)
        {
            var a = _context.LoaiUsers.SingleOrDefault(l => l.IdLoaiUser == id);
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

        public JsonResult EditLoaiUser(int id, LoaiUsersVM us)
        {
            var editLoaiUser = _context.LoaiUsers.SingleOrDefault(l => l.IdLoaiUser == id);
            if (editLoaiUser == null)
            {
                return new JsonResult("Khong tim thay Loaiuser")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editLoaiUser.TenLoai=us.TenLoai;
                editLoaiUser.MaLoai=us.MaLoai;
            

                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<LoaiUsersMD> GetAll()
        {
            var kq = _context.LoaiUsers.Select(o => new LoaiUsersMD
            {
                IdLoaiUser = o.IdLoaiUser,
                MaLoai = o.MaLoai,
                TenLoai = o.TenLoai,
            }).ToList();
            return kq;
        }

    }
}
