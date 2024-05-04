﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UsersRepo;
       
        public UserController(IUserRepository UsersRepo)
        {
            _UsersRepo = UsersRepo;
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AdddUser([FromForm] UsersSendMail users , List<IFormFile> files)
        {
            return Ok(await _UsersRepo.AdddUser(users, files));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_UsersRepo.GetAll());
        }
        [HttpPost("AddData")]
        public IActionResult AddData(UsersVM us)
        {
            return Ok(_UsersRepo.AddData(us));
        }
        [HttpPut("EditData,{id:int}")]
        public IActionResult EditData(int id, UsersVM us)
        {
            return Ok(_UsersRepo.EditData(id,us));
        }
        [HttpDelete("DeleteData")]
        public IActionResult DeleteData(int id)
        {
            return Ok(_UsersRepo.DeleteData(id));
        }
    }
}
