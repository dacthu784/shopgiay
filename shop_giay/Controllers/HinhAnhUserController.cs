using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "1,3")]
    public class HinhAnhUserController : ControllerBase
    {
        private readonly IHinhAnhUserRepository _hinhAnhUserRepo;

        public HinhAnhUserController(IHinhAnhUserRepository hinhAnhUserRepo)
        {
            _hinhAnhUserRepo = hinhAnhUserRepo;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_hinhAnhUserRepo.GetAll());
        }
        [HttpPost("AddHinhAnhUser")]
        public IActionResult AddHinhAnhUser(HinhAnhUserVm haus)
        {
            return Ok(_hinhAnhUserRepo.AddHinhAnhUser(haus));
        }
        [HttpPut("EditHinhAnhUser")]
        public IActionResult EditHinhAnhUser(int id, HinhAnhUserVm haus)
        {
            return Ok(_hinhAnhUserRepo.EditHinhAnhUser(id, haus));
        }
        [HttpDelete("DeleteHinhAnhUser")]
        public IActionResult DeleteHinhAnhUser(int id)
        {
            return Ok(_hinhAnhUserRepo.DeleteHinhAnhUser(id));
        }
    }
}
