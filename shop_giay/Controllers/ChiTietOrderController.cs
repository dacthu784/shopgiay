using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Extension;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietOrderController : ControllerBase
    {
        private readonly IChiTietOrderRepository _chiTietOrderRepo;

        public ChiTietOrderController(IChiTietOrderRepository chiTietOrderRepo) 
        {
            _chiTietOrderRepo = chiTietOrderRepo;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_chiTietOrderRepo.GetAll());
        }
        [HttpPost("AddChiTietOder")]
        public IActionResult AddChiTietOder([FromQuery] ChiTietOrderVM odr)
        {
            return Ok(_chiTietOrderRepo.AddChiTietOder(odr));
        }
        [HttpPut("EditChiTietOder")]
        public IActionResult EditChiTietOder([FromQuery] ChiTietOrderEdit odr)
        {
            return Ok(_chiTietOrderRepo.EditChiTietOder( odr));
        }
        [HttpDelete("deletechitietorder")]
        public IActionResult deletechitietorder(int id,int idsp)
        {
            return Ok(_chiTietOrderRepo.deletechitietorder(id,idsp));
        }

        [HttpGet("XemSP")]
        [Authorize(Roles = "2")]
        public async Task<IActionResult> XemSP()
        {
            var id = User.GetId();
            var doi = int.Parse(id);
            return Ok(_chiTietOrderRepo.XemSP(doi));



        }
        [HttpPut("AddRatting")]
        [Authorize(Roles ="2")]
        public IActionResult AddRatting([FromQuery]Rattings odr)
        {
            var id = User.GetId();
            var doi = int.Parse(id);
            return Ok(_chiTietOrderRepo.AddRatting(odr,doi));
        }
    }
}
