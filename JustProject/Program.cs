using Microsoft.AspNetCore.Authentication.Cookies;
using JustProject.Service.Implementations;
using JustProject.Domain.Entity;
using JustProject.DAL.Interfaces;
using JustProject.DAL.Repositories;
using JustProject.DAL;
using Microsoft.EntityFrameworkCore;
using ProjectAspMvc.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBaseRepository<User>, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Index";
    option.AccessDeniedPath = "/Index";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
