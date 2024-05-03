using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonNhapController : ControllerBase
    {
        private readonly IChiTietDonNhapRepository _chiTietDonNhapRepo;

        public ChiTietDonNhapController(IChiTietDonNhapRepository chiTietDonNhapRepo)
        {
            _chiTietDonNhapRepo = chiTietDonNhapRepo;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_chiTietDonNhapRepo.GetAll());
        }
        [HttpPost("AddChiTietDonNhap")]
        public IActionResult AddChiTietDonNhap(ChiTietDonNhapVM ctdn)
        {
            return Ok(_chiTietDonNhapRepo.AddChiTietDonNhap(ctdn));
        }
        [HttpPut("EditChiTietDonNhap")]
        public IActionResult EditChiTietDonNhap(int id, ChiTietDonNhapVM ctdn)
        {
            return Ok(_chiTietDonNhapRepo.EditChiTietDonNhap(id, ctdn));
        }
        [HttpDelete("DeleteChiTietDonNhap")]
        public IActionResult DeleteChiTietDonNhap(int id)
        {
            return Ok(_chiTietDonNhapRepo.DeleteChiTietDonNhap(id));
        }
    }
}
