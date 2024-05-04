using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface IHinhAnhUserRepository
    {
        JsonResult AddHinhAnhUser(HinhAnhUserVm haus);
        JsonResult DeleteHinhAnhUser(int id);
        JsonResult EditHinhAnhUser(int id, HinhAnhUserVm haus);
        List<HinhAnhUserMD> GetAll();
    }
    public class HinhAnhUserRepository : IHinhAnhUserRepository
    {
        private readonly ShopGiayContext _context;

        public HinhAnhUserRepository(ShopGiayContext context)
        {
            _context = context;
        }

        public JsonResult AddHinhAnhUser(HinhAnhUserVm haus)
        {
            var a = new HinhAnhUser()
            {
                Iduser = haus.Iduser,
                Urlimage = haus.Urlimage,
                Isavarta = haus.Isavarta,
            };
            _context.HinhAnhUsers.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteHinhAnhUser(int id)
        {

            var a = _context.HinhAnhUsers.SingleOrDefault(l => l.IdHinhNguoiDung == id);
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

        public JsonResult EditHinhAnhUser(int id, HinhAnhUserVm haus)
        {
            var editHinhAnhUser = _context.HinhAnhUsers.SingleOrDefault(l => l.IdHinhNguoiDung == id);
            if (editHinhAnhUser == null)
            {
                return new JsonResult("Khong tim thay Hinh anh user")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editHinhAnhUser.Iduser = haus.Iduser;
                editHinhAnhUser.Urlimage = haus.Urlimage;
                editHinhAnhUser.Isavarta = haus.Isavarta;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<HinhAnhUserMD> GetAll()
        {
            var kq = _context.HinhAnhUsers.Select(haus => new HinhAnhUserMD
            {
                IdHinhNguoiDung=haus.IdHinhNguoiDung,
                Iduser=haus.Iduser,
                Urlimage=haus.Urlimage,
                Isavarta=haus.Isavarta,
            }).ToList();
            return kq;
        }
    }
}
