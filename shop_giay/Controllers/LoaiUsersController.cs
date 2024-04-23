using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;

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
    }
}
