using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhTrangDonController : ControllerBase
    {
        private readonly ITinhTrangDonRepository _tinhTrangDonRepo;

        public TinhTrangDonController(ITinhTrangDonRepository tinhTrangDonRepo)
        {
            _tinhTrangDonRepo = tinhTrangDonRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_tinhTrangDonRepo.GetAll());
        }
        [HttpPost("AddTinhTrangDon")]
        public IActionResult AddTinhTrangDon(TinhTrangDonVM ttd)
        {
            return Ok(_tinhTrangDonRepo.AddTinhTrangDon(ttd));
        }
        [HttpPut("EditTinhTrangDon")]
        public IActionResult EditTinhTrangDon(int id, TinhTrangDonVM ttd)
        {
            return Ok(_tinhTrangDonRepo.Edit(id, ttd));
        }
        [HttpDelete("DeleteTinhTrangDon")]
        public IActionResult DeleteTinhTrangdon(int id)
        {
            return Ok(_tinhTrangDonRepo.DeleteTinhTrangdon(id));
        }
    }
}
