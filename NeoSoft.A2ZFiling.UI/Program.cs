using DNTCaptcha.Core;
using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;

using NeoSoft.A2ZFiling.UI.Services;

using DNTCaptcha.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IApiClient<>), typeof(ApiClient<>));
builder.Services.AddScoped<IZoneService, ZoneService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IPermissionService,PermissionService>();
builder.Services.AddScoped<IUserPermission,UserPermissionService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IIndustryService, IndustryService>();


builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped(typeof(IApiClient<>), typeof(ApiClient<>));
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<IMunicipalService,MunicipalService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ILoginService, LoginService>();


builder.Services.AddDNTCaptcha(option =>
{
    option.UseCookieStorageProvider().ShowThousandsSeparators(false);
    option.WithEncryptionKey("Asdfqwe123sdfsdfdfdf1234");
});

builder.Services.AddControllersWithViews();

builder.Services.AddDNTCaptcha(options =>
{
    options.UseCookieStorageProvider()
           .ShowThousandsSeparators(false)
           .WithEncryptionKey("AvbwgwgASDMSSSgg") // Replace with your encryption key
           .InputNames(new DNTCaptchaComponent
           {
               CaptchaHiddenInputName = "DNTCaptchaText",
               CaptchaHiddenTokenName = "DNTCaptchaToken",
               CaptchaInputName = "DNTCaptchaInputText"
           });
});



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
