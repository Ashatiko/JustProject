using JustProject.Domain.ViewModels;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAspMvc.Service.Interfaces;
using JustProject.Domain.Entity;
using Microsoft.AspNetCore.Authentication.Google;
using AspNet.Security.OAuth.Vkontakte;

namespace JustProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserTestsService _userTests;
        private readonly ILogger<UserController> _logger;
        
        public UserController(IUserService userService, IUserTestsService userTests, ILogger<UserController> logger)
        {
            _userService = userService;
            _userTests = userTests;
            _logger = logger;            
        }

        [AllowAnonymous]
        public ActionResult Login()
        {            
            return View();
        }

        [HttpGet]        
        public async Task<ActionResult> LogOut()
        {
            var auther = await _userService.LogOut();
            if (auther == true) return RedirectToAction("Login", "User");
            return RedirectToAction("Account", "User");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool user = await _userService.Login(model);
                if (user == false)
                {
                    ViewData["Request"] = "Email или пароль введены неверно";
                    return View(model);
                }                
                return RedirectToAction("Account", "User");
            }
            
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult LoginGoogle(string returnUrl = null)
        {
            var redirectUrl = Url.Action("GoogleCallback", "User", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleCallback(string returnUrl = null)
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            if (authenticateResult.Succeeded)
            {                
                //var user = authenticateResult.Principal;                
                if (await _userService.GetUser() == null)
                    await _userService.SetGoogleAuth();
                return RedirectToAction("Account", "User");
            }
            else
            {                
                return RedirectToAction("Login");
            }
        }

        [AllowAnonymous]
        public IActionResult LoginVK(string returnUrl = null)
        {            
            var redirectUrl = Url.Action("ExternalLoginCallback", "User", new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties {
                RedirectUri = redirectUrl,
                Items =
                {
                    {"scope", "Email" }
                }
                };
            return Challenge(properties, VkontakteAuthenticationDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(VkontakteAuthenticationDefaults.AuthenticationScheme);
            if (authenticateResult.Succeeded)
            {
                var user = authenticateResult.Principal;
                await _userService.SetVKAuth(user);      
                
                return RedirectToAction("Account", "User");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public async Task<IActionResult> Account()
        {            
            User user = await _userService.GetUser();

            var authenticateResult = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Account(AccountViewModel model)
        {
            var user = await _userService.GetEditUser(model);
            return View(user.Data);
        }

        [AllowAnonymous]        
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                await _userService.Register(model);
                return RedirectToAction("Login", "User");
            }
            return View(model);
        }
        
        public async Task<ActionResult> LoginTest()
        {
            var user = await _userService.GetUser();
            return View(user);
        }
        
        public async Task<IActionResult> HistoryTests(int id)
        {            
            id = Convert.ToInt32(TempData["TestIdBuy"]);            
            if (id == 0)
            {
                var tests = await _userService.GetHistoryTest();                

                return View(tests);
            }
            var testsAdd = await _userService.GetHistoryTestAdd(id);

            

            return View(testsAdd);
        }
       
        public async Task<IActionResult> Delete(int id)
        {
            var tests = await _userService.GetHistoryTestDelete(id);
            if (tests == true)
            {
                return RedirectToAction("HistoryTests");
            }
            return RedirectToAction("HistoryTests");
        }

        
        public async Task<IActionResult> Results()
        {          

            return View();
        }


        public async Task<IActionResult> Consultation()
        {            
            var user = await _userService.GetUser();
            return View(user);
        }        
    }
}