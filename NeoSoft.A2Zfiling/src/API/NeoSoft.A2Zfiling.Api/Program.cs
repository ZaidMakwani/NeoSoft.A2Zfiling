//--
using Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using NeoSoft.A2Zfiling.Api.Middleware;
using NeoSoft.A2Zfiling.Application;
using NeoSoft.A2Zfiling.Application.Contracts;
using NeoSoft.A2Zfiling.Infrastructure;
using NeoSoft.A2Zfiling.Persistence;
using NeoSoft.A2Zfiling.Api.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using NeoSoft.A2Zfiling.Api.SwaggerHelper;
using Microsoft.AspNetCore.DataProtection;
using NeoSoft.A2Zfiling.Auth;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Persistence.Repositories;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Persistence.Repositories;
using NeoSoft.A2Zfiling.Auth.Models;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

//SERILOG IMPLEMENTATION

builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
IConfiguration configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
        optional: true)
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configurationBuilder)
    .CreateBootstrapLogger().Freeze();

new LoggerConfiguration()
    .ReadFrom.Configuration(configurationBuilder)
    .CreateLogger();

builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));


// Add services to the container.

//readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


IConfiguration Configuration = builder.Configuration;
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var services = builder.Services;

string Urls = Configuration.GetSection("URLWhiteListings").GetSection("URLs").Value;
services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins(Urls).AllowAnyHeader().AllowAnyMethod();
        });
});
services.AddApplicationServices();

//services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnectionString")));

services.AddInfrastructureServices(Configuration);

services.AddAuthServices(Configuration);
services.AddPersistenceServices(Configuration);
services.AddSwaggerExtension();
services.AddSwaggerVersionedApiExplorer();
services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
services.AddControllers();
services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"bin\debug\configuration"));
services.AddHealthcheckExtensionService(Configuration);


builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddIdentity<AppUser, IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireLowercase = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    try
    {
        Log.Information("Application Starting");
    }
    catch (Exception ex)
    {
        Log.Warning(ex, "An error occured while starting the application");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),  
// specifying the Swagger JSON endpoint.  
IApiVersionDescriptionProvider provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwaggerUI(
options =>
{
// build a swagger endpoint for each discovered API version  
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
    }
});

app.UseCustomExceptionHandler();

app.UseCors("Open");

//app.UseAuthorization();
//if (app.Environment.EnvironmentName != "Test")
//{
//    app.UseWhen(context => context.Request.Path.StartsWithSegments("/api"), appBuilder =>
//    {
//        appBuilder.UsePermissionMiddleware();
//    });
//}
app.MapControllers();

//adding endpoint of health check for the health check ui in UI format
app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

//map healthcheck ui endpoing - default is /healthchecks-ui/
app.MapHealthChecksUI();

app.Run();

//For Integration test
public partial class Program { }
