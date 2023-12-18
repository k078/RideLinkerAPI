using Microsoft.EntityFrameworkCore;
using Infrastructure.RL;
using Core.DomainService;
using Core.Domain;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<CarService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RideLinkerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
