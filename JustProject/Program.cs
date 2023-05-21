using JustProject.Service.Implementations;
using JustProject.Domain.Entity;
using JustProject.DAL.Interfaces;
using JustProject.DAL.Repositories;
using JustProject.DAL;
using Microsoft.EntityFrameworkCore;
using ProjectAspMvc.Service.Interfaces;
using JustProject.Service.Interfaces;
using JustProject.Models.Tests;
using JustProject.Models.Tests.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWTSettings"));

//var secretKey = builder.Configuration.GetSection("JWTSettings:SecretKey").Value;
//var issuer = builder.Configuration.GetSection("JWTSettings:Issuer").Value;
//var audience = builder.Configuration.GetSection("JWTSettings:Audience").Value;
//var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ITestResultService, TestResultService>();
builder.Services.AddTransient<IUserTestsService, UserTestsService>();
builder.Services.AddTransient<ITestsService, TestsService>();
builder.Services.AddTransient<IUserAllowTestService, UserAllowTestService>();

builder.Services.AddTransient<IBaseRepository<User>, UserRepository>();
builder.Services.AddTransient<IBaseRepository<UserTests>, UserTestsRepository >();
builder.Services.AddTransient<IBaseRepository<UserAllowTest>, UserAllowTestRepository>();
builder.Services.AddTransient<IBaseRepository<TestResult>, TestResultRepository>();

builder.Services.AddScoped<IBaseRepository<UserAllowTest>, UserAllowTestRepository>();


builder.Services.AddTransient<UserTestsRepository>();

builder.Services.AddScoped<JWTSettings>();
builder.Services.AddScoped<ReviewsRepositoy>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITestCalculation, TestCalculation>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TestResultRepository>();
builder.Services.AddScoped<TestsRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/User/Account";
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
});

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidIssuer = issuer,
//        ValidateAudience = true,
//        ValidAudience = audience,
//        ValidateLifetime = true,
//        IssuerSigningKey = signingKey,
//        ValidateIssuerSigningKey = true,
//    };
//});

builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie(options =>
{

    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/User/Login";
    options.SlidingExpiration = true;
});

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{string?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();