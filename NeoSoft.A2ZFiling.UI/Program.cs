using DNTCaptcha.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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
           .WithEncryptionKey("YourEncryptionKey") // Replace with your encryption key
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
