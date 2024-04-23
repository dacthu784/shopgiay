using Microsoft.AspNetCore.Mvc;

using shop_giay.Data;


//using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface ILoaiUsersRepository
    {
        List<LoaiUsersMD> GetAll();
    }
    public class LoaiUsersRepo : ILoaiUsersRepository
    {
        private readonly ShopGiayContext _context;

        public LoaiUsersRepo(ShopGiayContext context)
        {
            _context = context;
        }
        public List<LoaiUsersMD> GetAll()
        {
            var kq = _context.LoaiUsers.Select(o => new LoaiUsersMD
            {
                MaLoai = o.MaLoai,
                TenLoai = o.TenLoai,
                IdLoaiUser = o.IdLoaiUser,
            }).ToList();
            return kq;
        }

    }
}
