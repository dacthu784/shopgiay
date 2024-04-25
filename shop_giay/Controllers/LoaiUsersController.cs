using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiUsersController : ControllerBase
    {
        private readonly ILoaiUsersRepository _loaiUsersRepo;
        public LoaiUsersController(ILoaiUsersRepository loaiUsersRepo)
        {
            _loaiUsersRepo = loaiUsersRepo;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_loaiUsersRepo.GetAll());
        }
        [HttpPost("AddLoaiUser")]
        public IActionResult AddLoaiUser(LoaiUsersVM lus)
        {
            return Ok(_loaiUsersRepo.AddLoaiUser(lus));
        }
        [HttpPut("EditLoaiUser")]
        public IActionResult EditLoaiUser(int id, LoaiUsersVM us)
        {
            return Ok(_loaiUsersRepo.EditLoaiUser(id, us));
        }
        [HttpDelete("DeleteLoaiUser")]
        public IActionResult DeleteLoaiUser(int id)
        {
            return Ok(_loaiUsersRepo.DeleteLoaiUser(id));
        }
    }
}
