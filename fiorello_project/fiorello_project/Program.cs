#region Builder

using fiorello_project.DAL;
using fiorello_project.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IFileService, FileService>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

#endregion

#region App


var app = builder.Build();
app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}"
    );

app.UseStaticFiles();
app.Run();

#endregion