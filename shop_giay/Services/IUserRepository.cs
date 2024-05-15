using Microsoft.AspNetCore.Mvc;
using shop_giay.Data;
using shop_giay.ViewModel;
using System.Runtime.CompilerServices;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Drawing;
using shop_giay.OtherServices;
using shop_giay.Helper;
using Microsoft.EntityFrameworkCore;
using Emgu.CV.Features2D;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace shop_giay.Services
{
    public interface IUserRepository
    {
        JsonResult ActionLogin(Login login);
        JsonResult AddData(UsersVM us);
        JsonResult AdddUser(int doi, List<IFormFile> files);
        JsonResult ChangePass(ChangePass changePass);
        JsonResult DangKy(DangKy dangKy);
        JsonResult DeleteData(int id);
        JsonResult EditData(int id, UsersVM us);
       JsonResult EditForUser(int id,EditForUser us);
        List<UsersHienAnh> GetAll(QueryObject queryObjec);
        UsersMD GetByInfo(Info info);
        JsonResult ResetPass(int id);
       
    }
    public class UserRepository : IUserRepository
    {
        private readonly ShopGiayContext _context;
        private readonly IWriteFileRepository _WriteFileRepo;
        private readonly ISendEmailServices _SendEmailServices;
        private readonly ITokenServices tokenServices;
        public UserRepository(ShopGiayContext context, IWriteFileRepository WriteFileRepo, ISendEmailServices sendEmailServices, ITokenServices tokenServices)
        {
            _context = context;
            _WriteFileRepo = WriteFileRepo;
            _SendEmailServices = sendEmailServices;
            this.tokenServices = tokenServices;
        }

        public JsonResult ActionLogin(Login login)
        {
            var data =_context.Users.SingleOrDefault(u => u.TenUser == login.UserOrEmail || u.Email == login.UserOrEmail);
            if(data != null)
            {
                string token = tokenServices.CreateToken(data);
                bool check = PasswordHasherServices.verifyPassword(login.Password, data.Password);
                if (check)
                {
                    return new JsonResult(token)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                else
                {
                    return new JsonResult("sai mat khau")
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
            }
            else
            {
                return new JsonResult("ten user or mail  khong ton tai")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
           
        }

        public JsonResult AddData(UsersVM us)
        {
            var data = _context.Users.SingleOrDefault(u => u.TenUser == us.TenUser);
            if (data == null)
            {
                var a = new User()
                {
                    TenUser = us.TenUser,
                    Email = us.Email,
                    Password = PasswordHasherServices.HashPassword(us.Password),
                    DiaChi = us.DiaChi,
                    NgayTao = DateTime.Now,
                    IdLoaiUsers = us.IdLoaiUsers,
                };
                _context.Users.Add(a);
                _context.SaveChanges();
                return new JsonResult("add thanh cong")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
            else
            {
                return new JsonResult("user da ton tai")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

        }

        public JsonResult AdddUser(int doi, List<IFormFile> files)
        {
            var editUser = _context.Users.SingleOrDefault(l => l.IdUser == doi);
            string folder = "Users";
            List<string> images =  _WriteFileRepo.WriteFile(files, folder);
            if (images.Count != 0)
            {
                foreach (string image in images)
                {
                    var item = new HinhAnhUser()
                    {
                        Iduser = editUser.IdUser,
                        Urlimage = image

                    };
                    _context.HinhAnhUsers.Add(item);
                }
                _context.SaveChanges();
            }

            var email = new EmailModel
            {
                ToEmail = editUser.Email,
                Subject = "Tài khoản của bạn bla bla bla",
                Body = " Thông tin đăng nhâp Username:  pass:123",
            };

            _SendEmailServices.Send(email);
            return new JsonResult("thanh cong")
            {
                StatusCode = StatusCodes.Status200OK
            };


        }

        public JsonResult ChangePass(ChangePass changePass)
        {

            var data =_context.Users.SingleOrDefault(u => u.TenUser == changePass.UserOrEmail || u.Email == changePass.UserOrEmail );
            if (data != null)
            {
               bool check = PasswordHasherServices.verifyPassword(changePass.Password, data.Password);
                if (check)
                {
                    if (changePass.DoiPassword == changePass.PasswordNhapLai)
                    {
                        var save = changePass.PasswordNhapLai;
                        data.Password = PasswordHasherServices.HashPassword(changePass.PasswordNhapLai);
                         data.NgaySua = DateTime.Now;
                        _context.SaveChanges();
                        var sendmail = new EmailModel
                        {
                            ToEmail = data.Email,
                            Subject = " gui mat khau dang ky",
                            Body = " mat khau la " + save
                        };
                        _SendEmailServices.Send(sendmail);
                        return new JsonResult("da doi tai khoan thanh cong")
                        {
                            StatusCode = StatusCodes.Status200OK
                        };
                    }
                    else
                    {
                        return new JsonResult("mat khau nhap lai khong khop")
                        {
                            StatusCode = StatusCodes.Status400BadRequest
                        };
                    }
                }
                else
                {
                    return new JsonResult("sai mat khau")
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

            }
            else
            {
                return new JsonResult("sai ten user")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
        public JsonResult ResetPass(int id)
        {
            var data = _context.Users.SingleOrDefault(u => u.IdUser == id);
            var save = PasswordHasherServices.GetRandomPassword();
            var hashpass = PasswordHasherServices.HashPassword(save);
            data.Password = hashpass;
            data.NgaySua = DateTime.Now;
            _context.SaveChanges();
            var sendmail = new EmailModel
            {
                ToEmail = data.Email,
                Subject = " gui mat khau reset",
                Body = " mat khau  moi la " + save
            };
            _SendEmailServices.Send(sendmail);
            return new JsonResult("da reset mat khau thanh cong")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult DangKy(DangKy dangKy)
        {
            var data = _context.Users.SingleOrDefault(u => u.TenUser == dangKy.TenUser);
            if (data == null)
            {
                
                
                if (dangKy.Password == dangKy.NhapLaiPassword)
                {
                    var a = new User()
                    {
                        TenUser = dangKy.TenUser,
                        HoTen=dangKy.HoTen,
                        Email = dangKy.Email,
                        Password = PasswordHasherServices.HashPassword(dangKy.NhapLaiPassword),
                        NgayTao = DateTime.Now,
                        IdLoaiUsers = 2,
                    };
                    string token = tokenServices.CreateToken(a);
                    _context.Users.Add(a);
                     _context.SaveChanges();
                    var sendmail = new EmailModel
                    {
                        ToEmail = dangKy.Email,
                        Subject = " gui mat khau dang ky",
                        Body = " mat khau la " + dangKy.Password
                    };
                    _SendEmailServices.Send(sendmail);
                    return new JsonResult(token)
                    {
                        StatusCode = StatusCodes.Status201Created
                    };
                }
                else
                {
                    return new JsonResult("mat khau nhap lai khong dung")
                    {
                        StatusCode = StatusCodes.Status201Created
                    };
                }
                   
               
            }
            else
            {
                return new JsonResult("ten user da ton tai")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
           
           
           
        }

        public JsonResult DeleteData(int id)
        {
            var a = _context.Users.SingleOrDefault(l => l.IdUser == id);
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

        public JsonResult EditData(int id, UsersVM us)
        {
            var editUser = _context.Users.SingleOrDefault(l => l.IdUser == id);
            if (editUser == null)
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
                editUser.NgaySua = DateTime.Now;

                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<UsersHienAnh> GetAll(QueryObject queryObjec)
        {
            var users = _context.Users.Include(u => u.HinhAnhUsers).Select(l => new UsersHienAnh
            {
                IdUser = l.IdUser,
                TenUser = l.TenUser,
                Email = l.Email,
                Password = l.Password,
                DiaChi = l.DiaChi,
                IdLoaiUsers = l.IdLoaiUsers,
                HinhAnhUsers = l.HinhAnhUsers.Select(u => new HinhAnhUserLuuAnh()
                {
                    Urlimage = u.Urlimage,
                    Isavarta = u.Isavarta
                }).ToList()
            });;
            
            if (queryObjec.IsDecsending == true)
            {
                users = users.OrderByDescending(c => c.TenUser);
            }
            
            var skipNumber = (queryObjec.PageNumber - 1) * queryObjec.PageSize;

            return users.Skip(skipNumber).Take(queryObjec.PageSize).ToList();

        }

        public UsersMD GetByInfo(Info? info)
        {
           

            if (!(info.Id == null))
            {
                 var l = _context.Users.SingleOrDefault(u => u.IdUser == info.Id);
                if (l != null)
                {
                    var users = new UsersMD
                    {
                        IdUser = l.IdUser,
                        TenUser = l.TenUser,
                        Email = l.Email,
                        Password = l.Password,
                        DiaChi = l.DiaChi,
                        IdLoaiUsers = l.IdLoaiUsers,

                    };
                    return users;
                }

            }
             if (!string.IsNullOrWhiteSpace(info.Name) )
            {
                 var l = _context.Users.SingleOrDefault(u => u.TenUser == info.Name);
                if (l != null)
                {
                    var users = new UsersMD
                    {
                        IdUser = l.IdUser,
                        TenUser = l.TenUser,
                        Email = l.Email,
                        Password = l.Password,
                        DiaChi = l.DiaChi,
                        IdLoaiUsers = l.IdLoaiUsers,

                    };
                    return users;
                }


            }
             if (!string.IsNullOrWhiteSpace(info.Email) ) 
            {
                var  l = _context.Users.SingleOrDefault(u => u.Email == info.Email);
                if (l != null)
                {
                    var users = new UsersMD
                    {
                        IdUser = l.IdUser,
                        TenUser = l.TenUser,
                        Email = l.Email,
                        Password = l.Password,
                        DiaChi = l.DiaChi,
                        IdLoaiUsers = l.IdLoaiUsers,

                    };
                    return users;
                }


            }
            return null;

            



        }

        public JsonResult EditForUser(int id,EditForUser  us)
        {
            var editUser = _context.Users.SingleOrDefault(l => l.IdUser == id);
           
            
                editUser.HoTen = us.HoTen;
                editUser.Email = us.Email;
                editUser.DiaChi = us.DiaChi;
                editUser.NgaySua = DateTime.Now;

                _context.SaveChanges();
                return new JsonResult("Edit thanh cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            
        }

       
    }
}
