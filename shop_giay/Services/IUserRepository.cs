using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;
using System.Runtime.CompilerServices;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace shop_giay.Services
{
    public interface IUserRepository
    {
        JsonResult AddData(UsersViewModel us);
        Task<JsonResult> AdddUser(UsersVM usersVM, List<IFormFile> files);
        JsonResult EditData(int id, UsersViewModel us);
        List<UsersViewModel> GetAll();
    }
    public class UserRepository : IUserRepository
    {
        private readonly ShopGiayContext _context;
        private readonly IWriteFileRepository _WriteFileRepo;
        private readonly ISendEmailServices _SendEmailServices;
        public UserRepository(ShopGiayContext context, IWriteFileRepository WriteFileRepo,ISendEmailServices sendEmailServices)
        { 
            _context = context;
            _WriteFileRepo = WriteFileRepo;
            _SendEmailServices = sendEmailServices;
        }

        public JsonResult AddData(UsersViewModel us)
        {
            var a = new User()
            {
                TenUser = us.TenUser,
                Email = us.Email,
                Password=us.Password,
                DiaChi = us.DiaChi,
                IdLoaiUsers = us.IdLoaiUsers,
            };
            _context.Users.Add(a);
            _context.SaveChanges();
            return new JsonResult("add thanh cong")
            {

            };
        }

        public async Task<JsonResult> AdddUser(UsersVM usersVM, List<IFormFile> files)
        {
            int IdUser = usersVM.IdUser;
            string folder = "Users";
            List<string> images = await _WriteFileRepo.WriteFileAsync(files, folder);
            if (images.Count != 0)
            {
                foreach (string image in images)
                {
                    var item = new HinhAnhUser()
                    {
                        Iduser = IdUser,
                        Urlimage = image

                    };
                    _context.HinhAnhUsers.Add(item);
                }
                _context.SaveChanges();
            }

            var email = new EmailModel
            {
                ToEmail = usersVM.Email,
                Subject = "Tài khoản của bạn bla bla bla",
                Body = " Thông tin đăng nhâp Username:  pass:123",
            };

          _SendEmailServices.Send(email);
            return new JsonResult("thanh cong")
            {

            };
            
            
        }

        public JsonResult EditData(int id, UsersViewModel us)
        {
            var editUser = _context.Users.SingleOrDefault(l => l.IdUser == id);
            if(editUser == null)
            {
                return new JsonResult("Khong tim thay user")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                editUser.TenUser = us.TenUser;
                editUser.Email = us.Email;
                editUser.DiaChi = us.DiaChi;

                _context.SaveChanges();
                new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<UsersViewModel> GetAll()
        {
            var users = _context.Users.Select(l => new UsersViewModel
            {
                
                TenUser = l.TenUser,
                Email = l.Email,
                Password = l.Password,
                DiaChi = l.DiaChi,
                IdLoaiUsers = l.IdLoaiUsers,
            }).ToList();
            return users;
        }
    }
}
