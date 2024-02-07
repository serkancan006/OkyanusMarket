using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Container;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.identitiy;

var builder = WebApplication.CreateBuilder(args);
//app settings
var configuration = builder.Configuration;
// Context
builder.Services.AddDbContext<Context>(options => options.UseOracle(configuration.GetConnectionString("DefaultConnection")));
//identitiy
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>()
.AddEntityFrameworkStores<Context>();
// Add services to the container.
builder.Services.ContainerDependencies();
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));


//builder.Services.AddControllers().AddFluentValidation(); //fluent validation için baþka iþlemler de yapýlabilir...
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
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
