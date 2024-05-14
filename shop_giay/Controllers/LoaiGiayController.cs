using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiGiayController : ControllerBase
    {
        private readonly ILoaiGiayRepository _loaiGiayRepo;

        public LoaiGiayController(ILoaiGiayRepository loaiGiayRepo)
        {
            _loaiGiayRepo = loaiGiayRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_loaiGiayRepo.GetAll());
        }
        [HttpGet("GetAllSP")]
        public IActionResult GetAllSP()
        {
            return Ok(_loaiGiayRepo.GetAllSP());
        }
        [HttpPost("AddLoaiGiay")]
        public IActionResult AddLoaiGiay(LoaiGiayVM loaigiay)
        {
            return Ok(_loaiGiayRepo.AddLoaigiay(loaigiay));
        }
        [HttpPut("EditLoaiGiay")]
        public IActionResult EditLoaiGiay(int id, LoaiGiayVM lg)
        {
            return Ok(_loaiGiayRepo.EditLoaiGiay(id, lg));
        }
        [HttpDelete("DeleteLoaiGiay")]
        public IActionResult DeleteLoaiGiay(int id)
        {
            return Ok(_loaiGiayRepo.DeleteLoaiGiay(id));
        }
        [HttpGet(" TinhTong")]
        public IActionResult TinhTong()
        {
            return Ok(_loaiGiayRepo.TinhTong());
        }
    }
}
