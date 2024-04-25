using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddChiTietOder(ChiTietOrderVM odr)
        {
            return Ok(_chiTietOrderRepo.AddChiTietOder(odr));
        }
        [HttpPut("EditChiTietOder")]
        public IActionResult EditChiTietOder(int id, ChiTietOrderVM odr)
        {
            return Ok(_chiTietOrderRepo.EditChiTietOder(id, odr));
        }
        [HttpDelete("deletechitietorder")]
        public IActionResult deletechitietorder(int id)
        {
            return Ok(_chiTietOrderRepo.deletechitietorder(id));
        }
    }
}
