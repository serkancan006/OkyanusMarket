using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OkyanusWebUI.Service;
using OkyanusWebUI.Validations;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromSeconds(10);
    //options.Cookie.Name = "UserCookie";
    //options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<CustomHttpClient>();
builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<FileOperationService>();

builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddRazorRuntimeCompilation();

builder.Services.AddFluentValidation(configuration =>
{
    configuration.RegisterValidatorsFromAssemblyContaining<Program>();
    //configuration.RegisterValidatorsFromAssemblyContaining<CartItemValidator>();
    //configuration.RegisterValidatorsFromAssemblyContaining<CreateContactMessageVMValidator>();
    //configuration.RegisterValidatorsFromAssemblyContaining<CreateOrderValidator>();
});


// Add Jwt Bearer Token
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
        ValidateLifetime = true,  //geçerlilik süresini dogrulamasý için false olursa süre dogrulama yapmaz.
        ClockSkew = TimeSpan.Zero   //zaman farký hesaplama 
    };
});

//Notfy Service
builder.Services.AddNotyf(config => { config.DurationInSeconds = 3; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Index", "?code={0}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Session aþaðýdaki middlewareden önce gelmek zorunda çünkü aþaðýdaki middlewaredeki TokenService Session ile ilgili iþlemler yapýyor
app.UseSession();
//Middleware -> Authenticate iþlemlerinden önce gelmeleri çünkü authenticate ile ilgili iþlemi ekliyor sonra authenticatein çalýþmasý gerek.
app.Use(async (context, next) =>
{
    var tokenService = context.RequestServices.GetRequiredService<TokenService>();
    var jwt = tokenService.GetToken();

    if (jwt != null)
        context.Request.Headers.Append("Authorization", "Bearer " + jwt);

    await next();
});

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseNotyf();
app.Run();
