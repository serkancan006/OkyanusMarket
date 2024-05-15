using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Okyanus.BusinessLayer.Container;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.OptionsPattern;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Hubs;
using OkyanusWebAPI.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
//appsettings.json
var configuration = builder.Configuration;
//builder.Services.AddSingleton<IConfiguration>(configuration);
// Context
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
//identitiy
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddDefaultTokenProviders()
.AddEntityFrameworkStores<Context>();
// Add Jwt Bearer Token Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = true; //https olmak zorunludur.
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = configuration["JwtTokenOptions:ValidIssuer"],
        ValidAudience = configuration["JwtTokenOptions:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtTokenOptions:IssuerSigningKey"])),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = false,  //geçerlilik süresini dogrulamasý için false olursa süre dogrulama yapmaz.
        ClockSkew = TimeSpan.Zero   //zaman farký hesaplama 
    };
});
// Add services to the container.
builder.Services.ContainerDependencies();
//Options Pattern
builder.Services.Configure<MailOptions>(configuration.GetSection("MailOptions"));
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));


//builder.Services.AddControllers().AddFluentValidation(); //fluent validation için baþka iþlemler de yapýlabilir...
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });

    // Define the BearerAuth scheme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                        Enter 'Bearer' [space] and then your token in the text input below.  
                        \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
//signalR
builder.Services.AddSignalR();
//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7077", "http://localhost:7077").AllowAnyHeader().AllowAnyHeader().AllowCredentials();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
    SeedDatabase.Seed(app.Services);
}
app.UseStaticFiles();
//CORS 
app.UseCors();
app.UseHttpsRedirection();
//Authentication ve Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//signalR
app.MapHub<SignalRHub>("/signalRHub");


app.Run();
