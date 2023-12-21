using Microsoft.EntityFrameworkCore;
using Infrastructure.RL;
using Core.DomainService;
using Core.Domain;
using Core.DomainService.Interfaces;
using Core.DomainService.Services;
using RideLinkerAPI.Controllers;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
//builder.Services.AddScoped<AccountController, AccountController>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITripRepository, TripRepository>();  
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var identityConnectionString = builder.Configuration.GetConnectionString("identityDbConnection");

builder.Services.AddDbContext<RideLinkerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(identityConnectionString);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();


var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
