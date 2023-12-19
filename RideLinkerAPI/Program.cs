using Microsoft.EntityFrameworkCore;
using Infrastructure.RL;
using Core.DomainService;
using Core.Domain;
using Core.DomainService.Interfaces;
using Core.DomainService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ITripRepository, TripRepository>();  
builder.Services.AddScoped<ITripService, TripService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RideLinkerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
