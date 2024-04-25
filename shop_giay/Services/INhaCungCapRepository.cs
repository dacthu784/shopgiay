using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface INhaCungCapRepository
    {
        JsonResult AddNhaCungCap(NhaCungCapVM ncc);
        JsonResult Deletenhacungcap(int id);
        JsonResult EditNhaCungCap(int id, NhaCungCapVM ncc);
        List<NhaCungCapMD> GetAll();
    }
    public class NhaCungCapRepository : INhaCungCapRepository
    {
        private readonly ShopGiayContext _context;

        public NhaCungCapRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        public JsonResult AddNhaCungCap(NhaCungCapVM ncc)
        {
            var a = new NhaCungCap()
            {
                TenNhaCungCap = ncc.TenNhaCungCap,
                DiaChi = ncc.DiaChi,
                DienThoai = ncc.DienThoai,
                Email = ncc.Email,
            };
            _context.NhaCungCaps.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult Deletenhacungcap(int id)
        {
            var a = _context.NhaCungCaps.SingleOrDefault(l => l.IdNhaCungCap == id);
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

        public JsonResult EditNhaCungCap(int id, NhaCungCapVM ncc)
        {
            var editnhacungcap = _context.NhaCungCaps.SingleOrDefault(l => l.IdNhaCungCap == id);
            if (editnhacungcap == null)
            {
                return new JsonResult("Khong tim thay Nha Cung Cap")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editnhacungcap.TenNhaCungCap = ncc.TenNhaCungCap;
                editnhacungcap.DiaChi = ncc.DiaChi;
                editnhacungcap.DienThoai = ncc.DienThoai;
                editnhacungcap.Email = ncc.Email;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<NhaCungCapMD> GetAll()
        {
            var kq = _context.NhaCungCaps.Select(o => new NhaCungCapMD
            {
                IdNhaCungCap=o.IdNhaCungCap,
                TenNhaCungCap = o.TenNhaCungCap,
                DiaChi=o.DiaChi,
                DienThoai=o.DienThoai,
                Email=o.Email,
            }).ToList();
            return kq;
        }
    }
}
