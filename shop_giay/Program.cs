using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using shop_giay;
using shop_giay.Data;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;




//using shop_giay.Data;
using shop_giay.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddAuthentication();
builder.Services.AddDbContext<ShopGiayContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Dbcontext")));
builder.Services.AddScoped<ILoaiUsersRepository, LoaiUsersRepo>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWriteFileRepository, WriteFileRepository>();
builder.Services.AddScoped<ISendEmailServices, SendEmailServices>();
builder.Services.AddScoped<ISanPhamGiayRepository, SanPhamGiayRepository>();
builder.Services.AddScoped<ILoaiGiayRepository,LoaiGiayRepo>();
builder.Services.AddScoped<ITinhTrangDonRepository, TinhTrangDonRepository>();
builder.Services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
builder.Services.AddScoped<IOderRepository, OderRepository>();
builder.Services.AddScoped<IDonNhapHangHoaRepository, DonNhapHangHoaRepository>();
builder.Services.AddScoped<IChiTietOrderRepository, ChiTietOrderRepository>();
builder.Services.AddScoped<IChiTietDonNhapRepository, ChiTietDonNhapRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IAnhRepository, AnhRepository>();
builder.Services.AddScoped<IHinhAnhUserRepository, HinhAnhUserRepository>();












//builder.Services.AddScoped<ColorRecognition>;

//ColorRecognition.Color();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapPost("broadcast", async (string message, IHubContext<ChatHub, IChatClient> context) =>
{
    await context.Clients.All.ReceiveMessage(message);

    return Results.NoContent();
});
app.MapHub<ChatHub>("chat-hub");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//void DeleteDatabse()
//{
//    var dbcontext = new ShopGiayContext();
//    dbcontext.Database.EnsureDeleted();
//}

//void CreateDatabse()
//{
//    var dbcontext = new ShopGiayContext();
//    dbcontext.Database.EnsureCreated();
//}
