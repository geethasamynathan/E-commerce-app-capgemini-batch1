using E_Commerce_Backend.Models;
using E_Commerce_Backend.Profiles;
using E_Commerce_Backend.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(OrderProfile));
builder.Services.AddLogging();
builder.Services.AddDbContext<EcommerceContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnection"))
.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                      .EnableSensitiveDataLogging()
                      .EnableDetailedErrors()

);
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
