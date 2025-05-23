using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.IdentityModel.Tokens;
using OkyanusWebUI.Service;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
//Localization Culture ayarlar�
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var suppoertedcultures = new[]
    {
        //new CultureInfo("tr-TR"),
        new CultureInfo("en-Us"),
    };
    CultureInfo.CurrentCulture = new CultureInfo("en-Us");
    options.DefaultRequestCulture = new RequestCulture("en-Us");
    options.SupportedCultures = suppoertedcultures;
    options.SupportedUICultures = suppoertedcultures;
});
//Local Services
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
//Custom Services
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<CustomHttpClient>();
builder.Services.AddScoped<BasketService>();
builder.Services.AddScoped<FileOperationService>();
builder.Services.AddScoped<UserAdresService>();
builder.Services.AddScoped<DeliveryTimeService>();
builder.Services.AddScoped<CityService>();
builder.Services.AddScoped<ProductTypeService>();
builder.Services.AddScoped<MarkaService>();
//Controller Views
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddRazorRuntimeCompilation();
//Razor page mimarisini entegre ediyoruz.
builder.Services.AddRazorPages();
//Fluent Validation
builder.Services.AddFluentValidation(configuration =>
{
    configuration.RegisterValidatorsFromAssemblyContaining<Program>();
    //configuration.RegisterValidatorsFromAssemblyContaining<CartItemValidator>();
});
//Jwt Bearer Token
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
        ValidateLifetime = true,  //ge�erlilik s�resini dogrulamas� i�in false olursa s�re dogrulama yapmaz.
        ClockSkew = TimeSpan.Zero   //zaman fark� hesaplama 
    };
});
//Notfy Service
builder.Services.AddNotyf(config => { config.DurationInSeconds = 3; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

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

//Localization and Culture
app.UseRequestLocalization();

app.UseRouting();

//Session a�a��daki middlewareden �nce gelmek zorunda ��nk� a�a��daki middlewaredeki TokenService Session ile ilgili i�lemler yap�yor
app.UseSession();
//Authenticate i�lemlerinden �nce gelmeleri ��nk� authenticate ile ilgili i�lemi ekliyor sonra authenticatein �al��mas� gerek.
app.Use(async (context, next) =>
{
    var tokenService = context.RequestServices.GetRequiredService<TokenService>();
    var jwt = tokenService.GetToken();

    if (jwt != null)
        context.Request.Headers.Append("Authorization", "Bearer " + jwt);

    await next();
});
//Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Orders}/{action=InstantOrder}/{id?}"
    );

    //Razor page i�in middle ware i da ekliyoruz.
    endpoints.MapRazorPages();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Notf Middleware
app.UseNotyf();
app.Run();
