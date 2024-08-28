using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Okyanus.BusinessLayer.Container;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.OptionsPattern;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Hangfire.Jobs;
using OkyanusWebAPI.Hubs;
using OkyanusWebAPI.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//appsettings.json
var configuration = builder.Configuration;
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IConfiguration>(configuration);
// Context
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
//identitiy
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+";
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
// MVC
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
        policy.WithOrigins(configuration["WebSiteHosts:Https"], configuration["WebSiteHosts:Http"]).AllowAnyHeader().AllowAnyHeader().AllowCredentials();
    });
});
//Hangfire
builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"));
});
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
    SeedDatabase.Seed(app.Services);
    // MVC
    app.UseDeveloperExceptionPage();
}else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();
//CORS 
app.UseCors();
app.UseHttpsRedirection();
//MVC
app.UseRouting();
//Authentication ve Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//signalR
app.MapHub<SignalRHub>("/signalRHub");
// Hangfire dashboard'ýný yapýlandýrýn
//app.Use(async (context, next) =>
//{
//    var tokenService = context.RequestServices.GetRequiredService<TokenService>();
//    var jwt = tokenService.GetToken();

//    if (jwt != null)
//        context.Request.Headers.Append("Authorization", "Bearer " + jwt);

//    await next();
//});
app.UseHangfireDashboard("/hangfire");
// Hangfire Server
app.UseHangfireServer();
// hangire görevleri
RecurringJob.AddOrUpdate<MyJobs>("email-job", job => job.SendEmail("example@example.com"), "0 0 * * *");
RecurringJob.AddOrUpdate<MyJobs>("products-add-job", job => job.GetProducts(), "0 0 * * *");

//MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Optionally map Razor Pages
//app.MapRazorPages();

app.Run();
