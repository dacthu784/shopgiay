using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="1,3")]
    public class AnhController : ControllerBase
    {
        private IAnhRepository _anhRepoy;

        public AnhController(IAnhRepository anhRepoy)
        {
            _anhRepoy = anhRepoy;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_anhRepoy.GetAll());
        }
        [HttpPost("AddAnh")]
        public IActionResult AddAnh(AnhVM anh)
        {
            return Ok(_anhRepoy.AddAnh(anh));
        }
        [HttpPut("EditAnh")]
        public IActionResult EditAnh(int id, AnhVM anh)
        {
            return Ok(_anhRepoy.EditAnh(id, anh));
        }
        [HttpDelete("DeleteAnh")]
        public IActionResult DeleteAnh(int id)
        {
            return Ok(_anhRepoy.DeleteAnh(id));
        }
    }
}
