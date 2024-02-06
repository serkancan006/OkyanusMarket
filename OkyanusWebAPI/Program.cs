using Microsoft.EntityFrameworkCore;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.EntityLayer.Entities.identitiy;

var builder = WebApplication.CreateBuilder(args);
// appsettings.json dosyas�ndan yap�land�rmay� al�n
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<Context>(options => options.UseOracle(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<Context>()
.AddEntityFrameworkStores<Context>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
