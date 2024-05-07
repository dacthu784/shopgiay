using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeController(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_sizeRepository.GetAll());
        }
        [HttpPost("AddSize")]
        public IActionResult AddSize(SizeVM size)
        {
            return Ok(_sizeRepository.AddSize(size));
        }
        [HttpPut("EditSize")]
        public IActionResult EditSize(int id, SizeVM size)
        {
            return Ok(_sizeRepository.EditSize(id, size));
        }
        [HttpDelete("DeleteSize")]
        public IActionResult DeleteSize(int id)
        {
            return Ok(_sizeRepository.DeleteSize(id));
        }
    }
}
