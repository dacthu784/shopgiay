using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Helper;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1,3")]
    public class NhaCungCapController : ControllerBase
    {
        private readonly INhaCungCapRepository _nhaCungCapRepo;

        public NhaCungCapController(INhaCungCapRepository nhaCungCapRepo)
        {
            _nhaCungCapRepo = nhaCungCapRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] QueryObject queryObject)
        {
            return Ok(_nhaCungCapRepo.GetAll(queryObject));
        }
        [HttpPost("AddNhaCungCap")]
        public IActionResult AddNhaCungCap(NhaCungCapVM ncc)
        {
            return Ok(_nhaCungCapRepo.AddNhaCungCap(ncc));
        }
        [HttpPut("EditNhaCungCap")]
        public IActionResult EditNhaCungCap(int id, NhaCungCapVM ncc)
        {
            return Ok(_nhaCungCapRepo.EditNhaCungCap(id, ncc));
        }
        [HttpDelete("Deletenhacungcap")]
        public IActionResult Deletenhacungcap(int id)
        {
            return Ok(_nhaCungCapRepo.Deletenhacungcap(id));
        }


    }
}
