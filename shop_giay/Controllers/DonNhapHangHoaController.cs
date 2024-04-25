using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonNhapHangHoaController : ControllerBase
    {
        private readonly IDonNhapHangHoaRepository _donNhapHangHoaRepo;

        public DonNhapHangHoaController(IDonNhapHangHoaRepository donNhapHangHoaRepo)
        {
            _donNhapHangHoaRepo = donNhapHangHoaRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_donNhapHangHoaRepo.GetAll());
        }
        [HttpPost("AddDonNhapHangHoa")]
        public IActionResult AddDonNhapHangHoa(DonNhapHangHoaVM dnhh)
        {
            return Ok(_donNhapHangHoaRepo.AddDonNhapHangHoa(dnhh));
        }
        [HttpPut("EditDonNhapHangHoa")]
        public IActionResult EditDonNhapHangHoa(int id, DonNhapHangHoaVM dnhh)
        {
            return Ok(_donNhapHangHoaRepo.EditDonNhapHangHoa(id, dnhh));
        }
        [HttpDelete("DeleteDonNhapHangHoa")]
        public IActionResult DeleteDonNhapHangHoa(int id)
        {
            return Ok(_donNhapHangHoaRepo.DeleteDonNhapHangHoa(id));
        }
    }
}
