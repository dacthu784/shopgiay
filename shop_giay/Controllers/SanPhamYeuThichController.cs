using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.Extension;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SanPhamYeuThichController : ControllerBase
    {
        private readonly ISanPhamYeuThichRepository _sanPhamYeuThichrepository;
        private readonly ShopGiayContext _context;

        public SanPhamYeuThichController(ISanPhamYeuThichRepository sanPhamYeuThichrepository,ShopGiayContext context)
        {
            _sanPhamYeuThichrepository = sanPhamYeuThichrepository;
            _context = context;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "2")]

        public IActionResult GetAll()
        {
            var id = User.GetId();
            var doi = int.Parse(id);
            return Ok(_sanPhamYeuThichrepository.GetAll(doi));
        }
        [HttpPost("AddSanPhamYeuThich")]
        [Authorize(Roles = "2")]

        public IActionResult AddSanPhamYeuThich([FromQuery]SanPhamYeuThichVM sanPhamYeuThich)
        {

            var id = User.GetId();
            var doi = int.Parse(id);
            sanPhamYeuThich.IdUser = doi;
            return Ok(_sanPhamYeuThichrepository.AddSanPhamYeuThich(sanPhamYeuThich));
        }
        [HttpPut("EditSanPhamYeuThich")]
        [Authorize(Roles = "2")]

        public IActionResult EditSanPhamYeuThich(int id, SanPhamYeuThichVM sanPhamYeuThich)
        {
            var iduser = User.GetId();
            var doi = int.Parse(iduser);
            sanPhamYeuThich.IdUser = doi;
            return Ok(_sanPhamYeuThichrepository.EditSanPhamYeuThich(id, sanPhamYeuThich));
        }
        [HttpDelete("DeleteSanPhamYeuThich")]
        [Authorize(Roles = "2")]

        public IActionResult DeleteSanPhamYeuThich(int id)
        {
           
            var iduser = User.GetId();
            var doi = int.Parse(iduser);
            
            return Ok(_sanPhamYeuThichrepository.DeleteSanPhamYeuThich(id,doi));
        }
        [HttpPost("Sendemail")]
        [Authorize(Roles = "1,3")]
        public IActionResult SendEmail()
        {

            
            return Ok(_sanPhamYeuThichrepository.SendEmail());
        }
    }
}
