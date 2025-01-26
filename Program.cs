using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

using Wq_Surveillance;
using Wq_Surveillance.Models;
using Wq_Surveillance.NwashModels;
using Wq_Surveillance.Models.Mapping;
using Wq_Surveillance.Service.WQS;
using Wq_Surveillance.Service.Users;
using Wq_Surveillance.Service.WaterQualityData;
using Wq_Surveillance.Service.WashSanitaryInspections;
using Wq_Surveillance.Service.Other;
using Wq_Surveillance.Service.Project;

var builder = WebApplication.CreateBuilder(args);

AppConfiguration.LoadConfig(builder);

// Add services to the container.
var services = builder.Services;

services.AddControllersWithViews();
builder.Services.AddControllersWithViews();

services.AddDbContext<WqsContext>();
services.AddDbContext<NwashContext>();

builder.Services.AddTransient<IOtherService, OtherService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IWashSanitaryInspection, WashSanitaryInspection>();
builder.Services.AddTransient<IWaterQualityData, WaterQualityData>();
builder.Services.AddTransient<IWQSservices, WQSservices>();
builder.Services.AddAutoMapper(typeof(MapModels));

builder.Services.AddEndpointsApiExplorer();
// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP-only
    options.Cookie.IsEssential = true; // Mark the session cookie as essential
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(
    new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wqs_images")),
        RequestPath = "/wqs_images"
    }
);
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};

app.UseCookiePolicy(cookiePolicyOptions);

app.MapControllerRoute(name: "default", pattern: "{controller=WqsDashboard}/{action=Index}/{id?}");

app.Run();