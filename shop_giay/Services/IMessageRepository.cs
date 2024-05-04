using Google.Apis.Gmail.v1.Data;
using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;

namespace shop_giay.Services
{
    public interface IMessageRepository
    {
        //JsonResult AddMessage(MessageVM mes);
        JsonResult DeleteMessage(int id);
        JsonResult EditMessage(int id, MessageVM mes);
        List<MessageMD> GetAll();
    }
    public class MessageRepository : IMessageRepository
    {
        private readonly ShopGiayContext _context;

        public MessageRepository(ShopGiayContext context) 
        {
            _context = context;
        }

        //public JsonResult AddMessage(MessageVM mes)
        //{
        //    var a = new MessageMD()
        //    {
        //        IdUser = mes.IdUser,
        //        NoiDungMessage = mes.NoiDungMessage,
        //        LaTuAdmin = mes.LaTuAdmin,
        //        DauThoiGian = mes.DauThoiGian,
        //    };
        //    _context.Messages.Add(a);
        //    _context.SaveChanges();
        //    return new JsonResult("add thanh cong")
        //    {
        //        StatusCode = StatusCodes.Status201Created
        //    };
        //}

        public JsonResult DeleteMessage(int id)
        {
            var a = _context.Messages.SingleOrDefault(l => l.IdMessage == id);
            if (a != null)
            {
                _context.Remove(a);
                _context.SaveChanges();
                return new JsonResult("da xoa thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new JsonResult("khong tim thay")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }

        public JsonResult EditMessage(int id, MessageVM mes)
        {
            var editMess = _context.Messages.SingleOrDefault(l => l.IdMessage == id);
            if (editMess == null)
            {
                return new JsonResult("Khong tim thay Message")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editMess.IdUser = mes.IdUser;
                editMess.NoiDungMessage = mes.NoiDungMessage;
                editMess.LaTuAdmin = mes.LaTuAdmin;
                editMess.DauThoiGian = mes.DauThoiGian;


                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<MessageMD> GetAll()
        {
            var kq = _context.Messages.Select(mes => new MessageMD
            {
               IdMessage=mes.IdMessage,
               IdUser=mes.IdUser,
               NoiDungMessage=mes.NoiDungMessage,
               LaTuAdmin=mes.LaTuAdmin,
               DauThoiGian=mes.DauThoiGian,
            }).ToList();
            return kq;
        }
    }
}
