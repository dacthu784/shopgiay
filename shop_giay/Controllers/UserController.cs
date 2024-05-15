using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Serilog;
using shop_giay.Extension;
using shop_giay.Helper;
using shop_giay.OtherServices;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
   
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UsersRepo;
       
        public UserController(IUserRepository UsersRepo)
        {
            _UsersRepo = UsersRepo;
        }
        [HttpPost("AddUser")]
        [Authorize(Roles = "1,2,3")]
        public IActionResult AdddUser( List<IFormFile> files)
        {
            var id = User.GetId();
            var doi = int.Parse(id);
            return Ok(_UsersRepo.AdddUser(doi, files));
        }
        [HttpGet("GetAll")]
        [Authorize(Roles = "1")]
        public IActionResult GetAll([FromQuery] QueryObject queryObjec)
        {
            return Ok(_UsersRepo.GetAll(queryObjec));
        }
        [HttpPost("AddData")]
        [Authorize(Roles = "1")]

        public IActionResult AddData(UsersVM us)
        {
            return Ok(_UsersRepo.AddData(us));
        }
        [HttpPut("EditData")] //,{id:int}
        [Authorize(Roles = "1")]

        public IActionResult EditData(int id, UsersVM us)
        {
            return Ok(_UsersRepo.EditData(id,us));
        }
        [HttpDelete("DeleteData")]
        [Authorize(Roles = "1")]

        public IActionResult DeleteData(int id)
        {
            return Ok(_UsersRepo.DeleteData(id));
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> ActionLogin([FromQuery] Login login)
        {
            return Ok(_UsersRepo.ActionLogin(login));
           
        }
        [HttpPost("DangKy")]
        [AllowAnonymous]
        public async Task<IActionResult> DangKy([FromQuery] DangKy dangKy)
        {
            return Ok(_UsersRepo.DangKy(dangKy));


            
        }
        [HttpPut("ChangePass")]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePass(ChangePass changePass)
        {
            return Ok(_UsersRepo.ChangePass(changePass));
        }

        [HttpPut("ResetPass")]
        [Authorize(Roles = "1")]
        public IActionResult ResetPass(int id)
        {
            return Ok(_UsersRepo.ResetPass(id));
            
        }
        [HttpGet("GetByInfo")]
        [Authorize(Roles = "1")]
        public IActionResult GetByInfo([FromQuery] Info? info)
        {
            return Ok(_UsersRepo.GetByInfo(info));

        }
        [HttpPut(" EditForUser")] //,{id:int}
        [Authorize(Roles ="1,2,3")]
        public IActionResult EditForUser( EditForUser us)
        {
            var id = User.GetId();
            var doi = int.Parse(id);
            return Ok(_UsersRepo.EditForUser( doi,us));
        }
       
    }
}
