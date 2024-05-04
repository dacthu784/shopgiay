using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Services;
using shop_giay.ViewModel;

namespace shop_giay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepo;

        public MessageController(IMessageRepository messageRepo) 
        {
            _messageRepo = messageRepo;

        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_messageRepo.GetAll());
        }
        [HttpPost("AddMessage")]
        //public IActionResult AddMessage(MessageVM mes)
        //{
        //    return Ok(_messageRepo.AddMessage(mes));
        //}
        [HttpPut("EditMessage")]
        public IActionResult EditMessage(int id, MessageVM mes)
        {
            return Ok(_messageRepo.EditMessage(id, mes));
        }
        [HttpDelete("DeleteMessage")]
        public IActionResult DeleteMessage(int id)
        {
            return Ok(_messageRepo.DeleteMessage(id));
        }
    }
}
