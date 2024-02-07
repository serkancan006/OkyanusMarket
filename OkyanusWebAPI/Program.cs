using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Container;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);
//app settings
var configuration = builder.Configuration;
// Context
builder.Services.AddDbContext<Context>(options => options.UseOracle(configuration.GetConnectionString("DefaultConnection")));
//identitiy
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddDefaultTokenProviders()
.AddEntityFrameworkStores<Context>();
// Add services to the container.
builder.Services.ContainerDependencies();
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));


//builder.Services.AddControllers().AddFluentValidation(); //fluent validation için baþka iþlemler de yapýlabilir...
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
