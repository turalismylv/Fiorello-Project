#region Builder

using fiorello_project.DAL;
using fiorello_project.Helpers;
using fiorello_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IFileService, FileService>();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddIdentity<User, IdentityRole>(options =>

{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 0;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.User.RequireUniqueEmail = true;

    options.Lockout.MaxFailedAccessAttempts=3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
}
).AddEntityFrameworkStores<AppDbContext>();

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

app.UseAuthentication();
app.UseAuthorization();
app.Run();

#endregion