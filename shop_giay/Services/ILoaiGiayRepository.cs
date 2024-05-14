using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface ILoaiGiayRepository
    {
        JsonResult AddLoaigiay(LoaiGiayVM loaigiay);
        JsonResult DeleteLoaiGiay(int id);
        JsonResult EditLoaiGiay(int id, LoaiGiayVM lg);
        List<LoaiGiayMD> GetAll();
        List<HienCaSanPham> GetAllSP();
        List<Tinhtong> TinhTong();
    }

    public class LoaiGiayRepo : ILoaiGiayRepository
    {
        private readonly ShopGiayContext _context;

        public LoaiGiayRepo(ShopGiayContext context)
        {
            _context = context;
        }

        public JsonResult AddLoaigiay(LoaiGiayVM loaigiay)
        {
            var a = new LoaiGiay()
            {
                MaLoaiGiay = loaigiay.MaLoaiGiay,
                TenLoaiGiay = loaigiay.TenLoaiGiay,
                ThuTuHienThi = loaigiay.ThuTuHienThi,
                

            };
            _context.LoaiGiays.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult DeleteLoaiGiay(int id)
        {
            var a = _context.LoaiGiays.SingleOrDefault(l => l.IdLoaiGiay == id);
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

        public JsonResult EditLoaiGiay(int id, LoaiGiayVM lg)
        {
            var editLoaiGiay = _context.LoaiGiays.SingleOrDefault(l => l.IdLoaiGiay == id);
            if (editLoaiGiay == null)
            {
                return new JsonResult("Khong tim thay Loai giay")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editLoaiGiay.MaLoaiGiay = lg.MaLoaiGiay;
                editLoaiGiay.TenLoaiGiay = lg.TenLoaiGiay;
                editLoaiGiay.ThuTuHienThi = lg.ThuTuHienThi;
               


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<LoaiGiayMD> GetAll()
        {
            var kq = _context.LoaiGiays.Include(u=>u.SanPhamGiays).Select(o => new LoaiGiayMD
            {
                IdLoaiGiay=o.IdLoaiGiay,
                MaLoaiGiay = o.MaLoaiGiay,
                TenLoaiGiay= o.TenLoaiGiay,
                ThuTuHienThi=o.ThuTuHienThi,
                SanPhamGiaysHienAdmin  = o.SanPhamGiays.Select( s=> new SanPhamHienTrongLoaiChoAdmin
                {
                    IdSanPham = s.IdSanPham,
                    TenSanPham = s.TenSanPham,
                    Gia = s.Gia,
                    MoTa = s.MoTa,
                    GiamGia = s.GiamGia,
                    SoLuong = s.SoLuong,
                }).ToList()
               
            }).ToList();
            return kq;
        }

        public List<HienCaSanPham> GetAllSP()
        {
            var kq = _context.LoaiGiays.Include(u => u.SanPhamGiays).Select(o => new HienCaSanPham
            {
                
                MaLoaiGiay = o.MaLoaiGiay,
                TenLoaiGiay = o.TenLoaiGiay,
                ThuTuHienThi = o.ThuTuHienThi,
                SanPhamGiaysHien = o.SanPhamGiays.Select(s => new SanPhamHienTrongLoai
                {
                   
                    TenSanPham = s.TenSanPham,
                    Gia = s.Gia,
                    MoTa = s.MoTa,
                    GiamGia = s.GiamGia,
                    SoLuong = s.SoLuong,
                }).ToList()

            }).ToList();
            return kq;
        }

        public List<Tinhtong> TinhTong()
        {

            var kq = _context.LoaiGiays.Include(u => u.ChiTietDonNhaps).Include(a => a.ChiTietOrders).Select(o => new Tinhtong
            {
                IdLoaiGiay = o.IdLoaiGiay,
                MaLoaiGiay = o.MaLoaiGiay,
                TenLoaiGiay = o.TenLoaiGiay,
                TinhThuChi =  (double)o.ChiTietOrders.Sum(t=> t.Gia) - o.ChiTietDonNhaps.Sum(t => t.ThanhTien)

            }).ToList();
            return kq;
        }
    }
}
