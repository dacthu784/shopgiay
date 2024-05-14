using Emgu.CV.Features2D;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_giay.Data;
using shop_giay.Helper;
using shop_giay.OtherServices;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface ISanPhamGiayRepository
    {
        JsonResult AddAnhSanPhamGiay(List<IFormFile> files, int id);
        JsonResult AddSanPham(SanPhamGiayVM spg);
        
        JsonResult DeleteSanPhamGiay(int id);
       
        JsonResult EditSanPhamGiay(int id, SanPhamGiayVM spg);
        
        List<SanPhamHienAnh> GetAll(QueryObject queryObject, string option);
        SanPhamGiayVM GetById(int id);
        SanPhamGiayVM GetByName(string name);
    }
    public class SanPhamGiayRepository : ISanPhamGiayRepository
    {
        private readonly ShopGiayContext _context;
        private readonly IWriteFileRepository _writeFileRepository;

        public SanPhamGiayRepository(ShopGiayContext context, IWriteFileRepository writeFileRepository)
        {
            _context = context;
            _writeFileRepository = writeFileRepository;
        }

        public JsonResult AddAnhSanPhamGiay(List<IFormFile> files, int id)
        {
            
            string folder = "Products";
            List<string> images = _writeFileRepository.WriteFile(files, folder);
            if (images.Count != 0)
            {
                foreach (string image in images)
                {
                    var item = new Anh()
                    {
                        Idsanpham = id,
                        Url = image

                    };
                    _context.Anhs.Add(item);
                }
                _context.SaveChanges();
            }
            return new JsonResult("thanh cong")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult AddSanPham(SanPhamGiayVM spg)
        {
            var a = new SanPhamGiay()
            {
                IdLoaiGiay = spg.IdLoaiGiay,
                MoTa = spg.MoTa,
                SoLuong = spg.SoLuong,
                Gia = spg.Gia,
                GiamGia = spg.GiamGia,

            };
            _context.SanPhamGiays.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteSanPhamGiay(int id)
        {
            var a = _context.SanPhamGiays.SingleOrDefault(l => l.IdSanPham == id);
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

        public JsonResult EditSanPhamGiay(int id, SanPhamGiayVM spg)
        {
            var editsanphamgiay = _context.SanPhamGiays.SingleOrDefault(l => l.IdSanPham == id);
            if (editsanphamgiay == null)
            {
                return new JsonResult("Khong tim thay San pham giay")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editsanphamgiay.IdLoaiGiay = spg.IdLoaiGiay;
                editsanphamgiay.MoTa = spg.MoTa;
                editsanphamgiay.SoLuong = spg.SoLuong;
                editsanphamgiay.Gia = spg.Gia;
                editsanphamgiay.GiamGia = spg.GiamGia;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<SanPhamHienAnh> GetAll(QueryObject queryObject, string option)
        {

            //queryObject.PageSize = 4;
            var kq = _context.SanPhamGiays.Include(u => u.Anhs).Include(c => c.ChiTietOrders).Select(o => new SanPhamHienAnh
            {
                IdSanPham = o.IdSanPham,
                IdLoaiGiay = o.IdLoaiGiay,
                MoTa = o.MoTa,
                SoLuong = o.SoLuong,
                Gia = o.Gia,
                GiamGia = o.GiamGia,
                AnhHien = o.Anhs.Select(a => new HienAnh
                {
                    Url = a.Url,
                }).ToList(),
                Danhgias = o.ChiTietOrders.Select(b => new Danhgia
                {
                    IdUser = b.IdUser,
                    Ratting = b.Ratting,
                    Review = b.Review,
                }).ToList(),

                Rattings = o.ChiTietOrders.Count() > 0 ? o.ChiTietOrders.Sum(t => t.Ratting) / o.ChiTietOrders.Count() : 0

            }); ;
           
            if (queryObject.IsDecsending == true)
            {
                if(option == "Giatang")
                {
                    kq = kq.OrderByDescending(c => c.Gia);
                }

                else if(option == "name")
                {
                    kq = kq.OrderByDescending(c => c.TenSanPham);
                }
                else if(option == "ratting")
                {
                   
                    kq = kq.OrderByDescending(c => c.Rattings);
                }
                
            }
            else
            {
                if (option == "Giatang")
                {
                    kq = kq.OrderBy(c => c.Gia);
                }

                else if (option == "name")
                {
                    kq = kq.OrderBy(c => c.TenSanPham);
                }
                else if (option == "ratting")
                {

                    kq = kq.OrderBy(c => c.Rattings);
                }
            }
            var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

            return kq.Skip(skipNumber).Take(queryObject.PageSize).ToList();
           
        }

        public  SanPhamGiayVM GetById(int id)
        {
            var spg =  _context.SanPhamGiays.FirstOrDefault(l => l.IdSanPham == id);
            if (spg == null)
                return null!;
            return new SanPhamGiayVM
            {
               
                TenSanPham = spg.TenSanPham,
                IdLoaiGiay = spg.IdLoaiGiay,
                MoTa = spg.MoTa,
                SoLuong = spg.SoLuong,
                Gia = spg.Gia,
                GiamGia = spg.GiamGia,
            };
        }

        public SanPhamGiayVM GetByName(string name)
        {
            var spg = _context.SanPhamGiays.FirstOrDefault(l => l.TenSanPham == name);
            if (spg == null)
                return null!;
            return new SanPhamGiayVM
            {

                IdLoaiGiay = spg.IdLoaiGiay,
                TenSanPham = spg.TenSanPham,
                MoTa = spg.MoTa,
                SoLuong = spg.SoLuong,
                Gia = spg.Gia,
                GiamGia = spg.GiamGia,
            };
        }
    }
 

}
