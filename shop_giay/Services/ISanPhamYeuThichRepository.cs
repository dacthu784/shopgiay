using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;
using System.Security.Claims;
using shop_giay.Extension;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.EntityFrameworkCore;
using shop_giay.Helper;
using shop_giay.OtherServices;
namespace shop_giay.Services
{
    public interface ISanPhamYeuThichRepository
    {
        JsonResult AddSanPhamYeuThich(SanPhamYeuThichVM sanPhamYeuThich);
        JsonResult DeleteSanPhamYeuThich(int id,int doi);
        JsonResult EditSanPhamYeuThich(int id, SanPhamYeuThichVM sanPhamYeuThich);
        List<SanPhamYeuThichVMNoUserName> GetAll(int doi);
        JsonResult SendEmail();
    }
    public class SanPhamYeuThichRepository : ISanPhamYeuThichRepository
    {
        private readonly ShopGiayContext _context;
        public readonly ISendEmailServices sendEmailServices;

        public SanPhamYeuThichRepository(ShopGiayContext context, ISendEmailServices sendEmailServices)
        {
            _context = context;
            this.sendEmailServices = sendEmailServices; 
        }
        public JsonResult AddSanPhamYeuThich(SanPhamYeuThichVM sanPhamYeuThich)
        {
            
            var a = new SanPhamYeuThich()
            {
                IdUser = sanPhamYeuThich.IdUser,
               IdSanPham = sanPhamYeuThich.IdsanPham,

               AddedDate = DateTime.Now,

              ChoPhepGuiEmail = sanPhamYeuThich.ChoPhepGuiEmail


            };
            _context.SanPhamYeuThiches.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteSanPhamYeuThich(int id,int doi)
        {
            var a = _context.SanPhamYeuThiches.Where(u => u.IdUser == doi);
            var b = a.SingleOrDefault(u=>u.IdSanPhamYeuThich == id);
            if (a != null)
            {
                _context.Remove(b);
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
            var a = _context.SanPhamYeuThiches.Where(u => u.IdUser == sanPhamYeuThich.IdUser);
            var EditSanPhamYeuThich = a.SingleOrDefault(u => u.IdSanPhamYeuThich == id);
            if (EditSanPhamYeuThich == null)
            {
                return new JsonResult("Khong tim thay san pham yeu thich")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
               
                EditSanPhamYeuThich.IdSanPham = sanPhamYeuThich.IdsanPham;
                EditSanPhamYeuThich.ChoPhepGuiEmail = sanPhamYeuThich.ChoPhepGuiEmail;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<SanPhamYeuThichVMNoUserName> GetAll(int doi)
        {
            var a = _context.SanPhamYeuThiches.Where(u => u.IdUser == doi).Include(a => a.IdSanPhamNavigation).ToList(); ;
            var kq = a.Select(u => new SanPhamYeuThichVMNoUserName()
            {
                IdSanPhamYeuThich = u.IdSanPhamYeuThich,
                IdsanPham = u.IdSanPham,
                AddedDate = u.AddedDate,
                sanPhamGiayVM = new ProductSizeQuantityVM
                {
                    IdSize = u.IdSanPhamNavigation.IdSize,
                    IdSanPhamGiay = u.IdSanPhamNavigation.IdSanPhamGiay
                }

            }).ToList();
            return kq;
        }

        public JsonResult SendEmail()
        {
            var userIds = _context.SanPhamYeuThiches
                .Where(u => u.ChoPhepGuiEmail == true)
                .Include(a => a.IdSanPhamNavigation)
                .Where(k => k.IdSanPhamNavigation.SoLuong > 0)
                .Select(s => s.IdUser)
                .ToList();

            var users = _context.Users.Where(w => userIds.Contains(w.IdUser)).ToList();

            foreach (var user in users)
            {
                var sanPhamYeuThiches = _context.SanPhamYeuThiches
                    .Where(u => u.IdUser == user.IdUser)
                    .Include(a => a.IdSanPhamNavigation)
                    .ThenInclude(b => b.IdSanPhamGiayNavigation)
                    .Include(a => a.IdSanPhamNavigation).ThenInclude(u=>u.IdSizeNavigation)
                    .ToList();

                foreach (var sanPhamYeuThich in sanPhamYeuThiches)
                {
                    var sanPham = sanPhamYeuThich.IdSanPhamNavigation;
                    var sanPhamGiay = sanPham.IdSanPhamGiayNavigation;
                    var size = sanPham.IdSizeNavigation;

                    var email = new EmailModel
                    {
                        ToEmail = user.Email,
                        Subject = "San pham cua ban da co",
                        Body = $"Da co san pham {sanPhamGiay?.TenSanPham ?? string.Empty} Size: {size?.Size1 ?? 0} Gia: {sanPhamGiay?.Gia ?? 0}"
                    };

                    sendEmailServices.Send(email);
                }
            }

            return new JsonResult("da send email thong bao cho khach hang")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
