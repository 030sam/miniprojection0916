using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using YourApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Reacter DbContext
builder.Services.AddDbContext<ReacterDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Reacter DbContext
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

string fileFolder = @"D:\VisualStudio\WebApplication2\FilePath";


//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

// Folder where your files are stored
//var fileFolder = @"D:\VisualStudio\WebApplication2\FilePath";

//// Map root URL to serve files
app.Map("/{filename}", async (HttpContext context) =>
{
    var filename = context.Request.RouteValues["filename"]?.ToString();

    if (string.IsNullOrEmpty(filename))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("File name is required");
        return;
    }

    var filePath = Path.Combine(fileFolder, filename);

    if (!System.IO.File.Exists(filePath))
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("File not found");
        return;
    }

    var contentType = "application/octet-stream";
    new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider()
        .TryGetContentType(filePath, out contentType);

    await context.Response.SendFileAsync(filePath);
});

app.Run();
