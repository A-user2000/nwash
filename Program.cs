using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Wq_Surveillance.Service;
using Wq_Surveillance.Models;
using Wq_Surveillance.Service.OtherService;
using Wq_Surveillance.Models.Mapping;
using Microsoft.Extensions.FileProviders;
using wq.Service.OtherService;
using Wq_Surveillance.NwashModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();
// Add DbContext
builder.Services.AddDbContext<WqsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<NwashContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NwashConnection")));


builder.Services.AddTransient<IOtherService, OtherService>();
builder.Services.AddTransient<IWQSservices, WQSservices>();
builder.Services.AddAutoMapper(typeof(MapModels));

builder.Services.AddEndpointsApiExplorer();



// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Set session timeout as needed
    options.Cookie.HttpOnly = true;
});

// Configure HTTPS redirection port (if needed, optional)
//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenAnyIP(44310, listenOptions =>
//    {
//        listenOptions.UseHttps();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Wqs/Error");
    app.UseHsts(); // Use HSTS for security in production scenarios
 
}
else
{
    app.UseDeveloperExceptionPage();
}

// HTTPS redirection
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wqs_images")),
    RequestPath = "/wqs_images"
});


app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=WqsDashboard}/{action=Index}/{id?}");

app.Run();
