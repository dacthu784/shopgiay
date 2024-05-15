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
using shop_giay.Services;
using shop_giay.OtherServices;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Nhập Token vào ",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddAuthentication(opt =>
{
    //object JwtBearerDefaults = null;
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, 
        ValidateAudience = false, 
        ValidateIssuer = false, 

        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]))
    };
});


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
builder.Services.AddScoped<ISanPhamYeuThichRepository, SanPhamYeuThichRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<IProductSizeQuantityRepository, ProductSizeQuantityRepository>();





builder.Services.AddScoped<IAnhRepository, AnhRepository>();
builder.Services.AddScoped<IHinhAnhUserRepository, HinhAnhUserRepository>();
builder.Services.AddScoped<ITokenServices,TokenService >();
builder.Services.AddScoped<PasswordHasherServices>();


builder.Services.AddScoped<IAnhRepository, AnhRepository>();
builder.Services.AddScoped<IHinhAnhUserRepository, HinhAnhUserRepository>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


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
