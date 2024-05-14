using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeQuantityController : ControllerBase
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;

        public ProductSizeQuantityController(IProductSizeQuantityRepository productSizeQuantityRepository)
        {
            _productSizeQuantityRepository = productSizeQuantityRepository;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_productSizeQuantityRepository.GetAll());
        }
        [HttpPost("AddProDuctSizeQuantity")]
        public IActionResult AddProDuctSizeQuantity(ProductSizeQuantityVM pds)
        {
            return Ok(_productSizeQuantityRepository.AddProDuctSizeQuantity(pds));
        }
        [HttpPut("EditProDuctSizeQuantity")]
        public IActionResult EditProDuctSizeQuantity(int id, ProductSizeQuantityVM pds)
        {
            return Ok(_productSizeQuantityRepository.EditProDuctSizeQuantity(id, pds));
        }
        [HttpDelete("DeleteProDuctSizeQuantity")]
        public IActionResult DeleteProDuctSizeQuantity(int id)
        {
            return Ok(_productSizeQuantityRepository.DeleteProDuctSizeQuantity(id));
        }

    }
}
