using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Helper;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamGiayController : ControllerBase
    {
        private readonly ISanPhamGiayRepository _SanPhamGiayRepo;

        public SanPhamGiayController(ISanPhamGiayRepository SanPhamGiayRepo)
        {
            _SanPhamGiayRepo = SanPhamGiayRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery]QueryObject queryObject, string? option)
        {
            return Ok(_SanPhamGiayRepo.GetAll(queryObject,option));
        }
        [HttpPost("AddSanPhamGiay")]
        public IActionResult AddSanPhamGiay(SanPhamGiayVM spg)
        {
            return Ok(_SanPhamGiayRepo.AddSanPham(spg));
        }
        [HttpPut("EditSanPhamGiay")]
        public IActionResult EditSanPhamGiay(int id, SanPhamGiayVM spg)
        {
            return Ok(_SanPhamGiayRepo.EditSanPhamGiay(id, spg));
        }
        [HttpDelete("DeleteSanPhamGiay")]
        public IActionResult DeleteSanPhamGiay(int id)
        {
            return Ok(_SanPhamGiayRepo.DeleteSanPhamGiay(id));
        }

        [HttpGet("getbyid")]
        public ActionResult<SanPhamGiayMD> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID không hợp lệ");
            }
            var spg = _SanPhamGiayRepo.GetById(id);
            if (spg is null) { return NotFound("không tìm thấy"); }
            return Ok(spg);
        }
        [HttpPost("AddAnhSanPhamGiay")]
        public IActionResult AddAnhSanPhamGiay(List<IFormFile> files,int id)
        {
            return Ok(_SanPhamGiayRepo.AddAnhSanPhamGiay(files,id));
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName( string name)
        {
            return Ok(_SanPhamGiayRepo.GetByName( name));
        }
    }
}
