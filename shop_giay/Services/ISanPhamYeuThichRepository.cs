using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;
using System.Security.Claims;
using shop_giay.Extension;
using Microsoft.AspNetCore.Mvc.Core;
namespace shop_giay.Services
{
    public interface ISanPhamYeuThichRepository
    {
        JsonResult AddSanPhamYeuThich(SanPhamYeuThichVM sanPhamYeuThich);
        JsonResult DeleteSanPhamYeuThich(int id);
        JsonResult EditSanPhamYeuThich(int id, SanPhamYeuThichVM sanPhamYeuThich);
        List<SanPhamYeuThichMD> GetAll();
    }
    public class SanPhamYeuThichRepository : ISanPhamYeuThichRepository
    {
        private readonly ShopGiayContext _context;

        public SanPhamYeuThichRepository(ShopGiayContext context)
        {
            _context = context;
        }
        public JsonResult AddSanPhamYeuThich(SanPhamYeuThichVM sanPhamYeuThich)
        {
            
            var a = new SanPhamYeuThich()
            {
                IdUser = sanPhamYeuThich.IdUser,
                //IdsanPham = sanPhamYeuThich.IdsanPham,

               //AddedDate = sanPhamYeuThich.AddedDate,

              ChoPhepGuiEmail = sanPhamYeuThich.ChoPhepGuiEmail


            };
            _context.SanPhamYeuThiches.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteSanPhamYeuThich(int id)
        {
            var a = _context.SanPhamYeuThiches.SingleOrDefault(l => l.IdSanPhamYeuThich == id);
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

        public JsonResult EditSanPhamYeuThich(int id, SanPhamYeuThichVM sanPhamYeuThich)
        {
            throw new NotImplementedException();
        }

        public List<SanPhamYeuThichMD> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
