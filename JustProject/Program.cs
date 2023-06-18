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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using JustProject.Domain.Entity.Test;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddSession();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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

builder.Services.AddTransient<IAnswersService, AnswersService>();
builder.Services.AddScoped<AnswersRepository>();

builder.Services.AddTransient<ITestGroupsService, TestGroupsService>();
builder.Services.AddScoped<TestGroupsRepository>();

builder.Services.AddTransient<IQuestionsService, QuestionsService>();
builder.Services.AddScoped<QuestionsRepository>();

builder.Services.AddTransient<IGroupsResultService, GroupsResultService>();
builder.Services.AddScoped<GroupsResultRepository>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/User/Account";
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
}).AddGoogle(options =>
{
    IConfigurationSection googleAuthNSection =
    config.GetSection("Authentication:Google");
    options.ClientId = "78627099217-s286j3trgnrvklltc1ijaj233bp0dufe.apps.googleusercontent.com";
    options.ClientSecret = "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";
}).AddVkontakte(options =>
{
    options.ClientId = "51680143";
    options.ClientSecret = "8jXbvB0aUHYTAQkbKRgU";
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}/{string?}"
    );

app.Run();