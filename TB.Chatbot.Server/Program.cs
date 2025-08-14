using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TB.Chatbot.Infratructure.DBContexts;

var builder = WebApplication.CreateBuilder(args);

// อ่าน environment จาก environment variable
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

// โหลด configuration จาก appsettings.json ตาม environment
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()

    .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddDbContext<WebTBrokerDBContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

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
