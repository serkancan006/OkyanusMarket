using Hangfire;
using Hangfire.MySql;
using Microsoft.AspNetCore.HttpLogging;
using OkyanusHangfire.Context;
using OkyanusHangfire.Hangfire.auth;
using OkyanusHangfire.Hangfire.jobs;
using OkyanusHangfire.Repositories.ProductRepository;
using OkyanusHangfire.Services.OlimposSoapService;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddSession(); // Session kullanýmý
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddSingleton<HangfireAuthorization>();

#region ContainerDependencies
// Mssql context - repository
builder.Services.AddSingleton<DapperMsSqlContext>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOlimposSoapService, OlimposSoapManager>();
#endregion

#region Logging
//Logging Mysql Hangfire
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
    .WriteTo.Console()
    .WriteTo.Async(a => a.MySQL(
        connectionString: builder.Configuration.GetConnectionString("HangfireConnection"),
        tableName: "logs",
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information))
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Host.UseSerilog();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    //logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});
#endregion

#region Hangfire
//Hangfire - Mysql
builder.Services.AddHangfire(configuration =>
{
    configuration.UseStorage(new MySqlStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new MySqlStorageOptions()
    {
        TablesPrefix = "hangfire_", // Tablo isimlerinde ön ek kullanýmý
        //QueuePollInterval = TimeSpan.FromSeconds(15), // Kuyrukta iþ bekleme süresi
        //JobExpirationCheckInterval = TimeSpan.FromHours(1), // Süresi dolmuþ iþlerin kontrol süresi
        //CountersAggregateInterval = TimeSpan.FromMinutes(5), // Sayaçlarýn toplanma süresi
        //PrepareSchemaIfNecessary = true, // Gerekirse tablo þemasýný oluþtur
        //DashboardJobListLimit = 5000, // Gösterilecek maksimum iþ sayýsý
        //TransactionTimeout = TimeSpan.FromMinutes(1), // Ýþlem zaman aþýmý
        //InvisibilityTimeout = TimeSpan.FromMinutes(5), // Ýþ görünmezlik zaman aþýmý
    }));
});
builder.Services.AddHangfireServer();
#endregion

// Default
builder.Services.AddControllersWithViews();
// Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(builder.Configuration["WebSiteHosts:Https"], builder.Configuration["WebSiteHosts:Http"]).AllowAnyHeader().AllowAnyHeader().AllowCredentials();
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();
//logging
app.UseSerilogRequestLogging();
app.UseHttpLogging();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

//hangfire
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorization(app.Services.GetRequiredService<IHttpContextAccessor>()) },
    //Authorization = new[] { app.Services.GetRequiredService<HangfireAuthorization>() },
    AppPath = "https://adlokyanus.com/", // Dashboard'dan çýkýþ yapýldýðýnda gidilecek yol
    //StatsPollingInterval = 2000 // Ýstatistiklerin güncellenme süresi (ms)
});
RecurringJob.AddOrUpdate<MyJobs>("update-products-job", job => job.UpdateProductsBySoapApi(), "30 0 * * *");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

//app.MapHangfireDashboard("/hangfire", new DashboardOptions
//{
//    Authorization = new[] { new HangfireAuthorization() },
//});

app.Run();
