using Web.Interfaces.Configurations;
using Web.Interfaces.Services;
using Web.Interfaces.Services.Configurations;
using Web.Models.Configurations;
using Web.Models.Configurations.Auth;
using Web.Models.Configurations.Coupons;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureConfigurations(builder.Services);
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();

    //confiure http client services
    services.AddHttpContextAccessor();
    services.AddHttpClient();

    //configure coupon service to have access on http client
    services.AddHttpClient<ICouponService, CouponService>();

    services.AddScoped<IBaseService, BaseService>();
    services.AddScoped<ICouponService, CouponService>();
    services.AddScoped<ICouponUrlConfigs, CouponUrlConfigs>(); 
    services.AddScoped<IAuthUrlConfigs, AuthUrlConfigs>();
}

void ConfigureConfigurations(IServiceCollection services)
{
    var couponsUrlsSection = builder.Configuration.GetSection("ServiceUrls:CouponsUrl");
    services.Configure<CouponUrlDto>(couponsUrlsSection);

    var authUrlsSection = builder.Configuration.GetSection("ServiceUrls:AuthUrl");
    services.Configure<AuthUrlDto>(authUrlsSection);
}