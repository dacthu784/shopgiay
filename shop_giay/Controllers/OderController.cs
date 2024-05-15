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
   
    public class OderController : ControllerBase
    {
        private readonly IOderRepository _oderRepo;

        public OderController(IOderRepository oderRepo) 
        {
            _oderRepo = oderRepo;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "1,3")]

        public IActionResult GetAll()
        {
            return Ok(_oderRepo.GetAll());
        }
        [HttpPost("AddOrder")]
        [Authorize(Roles = "1,3")]
        public IActionResult AddOrder([FromQuery ]OrderVM odr)
        {
            return Ok(_oderRepo.AddOrder(odr));
        }
        [HttpPut("EditOrder")]
        [Authorize(Roles = "1,3")]
        public IActionResult EditOrder(int id, OrderVM odr)
        {
            return Ok(_oderRepo.EditOrder(id, odr));
        }
        [HttpDelete("DeleteOrder")]
        [Authorize(Roles = "1,3")]
        public IActionResult DeleteOrder(int id)
        {
            return Ok(_oderRepo.DeleteLoaiUser(id));
        }
        [HttpGet("XemChiTietOrders")]
        [Authorize(Roles = "2")]
        public async Task<IActionResult> XemChiTietOrders()
        {
            var id = User.GetId();
            var doi = int.Parse(id);
            return Ok(_oderRepo.XemChiTietOrders(doi));



        }
    }
}
