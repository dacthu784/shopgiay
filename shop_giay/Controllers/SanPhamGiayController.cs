using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            return Ok(_SanPhamGiayRepo.GetAll());
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
        public async Task<ActionResult<SanPhamGiayMD>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID không hợp lệ");
            }
            var spg = await _SanPhamGiayRepo.GetById(id);
            if (spg is null) { return NotFound("không tìm thấy"); }
            return Ok(spg);
        }
    }
}
