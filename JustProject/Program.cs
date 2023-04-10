using Microsoft.AspNetCore.Authentication.Cookies;
using JustProject.Service.Implementations;
using JustProject.Domain.Entity;
using JustProject.DAL.Interfaces;
using JustProject.DAL.Repositories;
using JustProject.DAL;
using Microsoft.EntityFrameworkCore;
using ProjectAspMvc.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using JustProject.Models;
using Microsoft.AspNetCore.Antiforgery;
using JustProject.Service.Interfaces;
using JustProject.Domain.ViewModels;
using JustProject.Models.Tests;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITestResultService, TestResultService>();
builder.Services.AddTransient<IUserTestsService, UserTestsService>();
builder.Services.AddTransient<IUserAllowTestService, UserAllowTestService>();
builder.Services.AddTransient<IBaseRepository<User>, UserRepository>();
builder.Services.AddTransient<IBaseRepository<UserTests>, UserTestsRepository>();
builder.Services.AddTransient<IBaseRepository<UserAllowTest>, UserAllowTestRepository>();
builder.Services.AddTransient<IBaseRepository<TestResult>, TestResultRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITestResultService, TestResultService>();
builder.Services.AddScoped<ITestCalculation, TestCalculation>();
builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IBaseRepository<UserAllowTest>, UserAllowTestRepository>();
builder.Services.AddScoped<IBaseRepository<TestResult>, TestResultRepository>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Home/Index";
    option.AccessDeniedPath = "/Home/Index";
});

//builder.Services.AddSingleton<IAntiforgeryAdditionalDataProvider, MyAntiforgeryAdditionalDataProvider>();

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
