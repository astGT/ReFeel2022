
using Microsoft.EntityFrameworkCore;
using ReFeelCourtesy.Logging;
using ReFeelRepository.iRepository;
using ReFeelRepository.Models;
using ReFeelRepository.Repository;
//using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//global debug log
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("log/ReFeelAPILogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();
//builder.Host.UseSerilog();

builder.Services.AddDbContext<RefeelContext>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers( option =>
{
    option.ReturnHttpNotAcceptable=true;    
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<iLoggin, Logging>();


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
