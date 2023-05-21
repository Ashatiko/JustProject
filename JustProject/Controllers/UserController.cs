using JustProject.Domain.ViewModels;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectAspMvc.Service.Interfaces;

namespace JustProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserTestsService _userTests;
        private readonly ILogger<UserController> _logger;        

        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;

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
                string token = await _userService.Login(model);
                if (token == null)
                    return View(model);

                //Request.Headers.Add("Authorization", $"Bearer {token}");

                return RedirectToAction("Account", "User");
            }
            return View(model);
        }
        
        public async Task<IActionResult> Account()
        {            
            var user = await _userService.GetUser();
            
            return View(user.Data);
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
            //var user = new IdentityUser { UserName = "None", Email = model.Email };

            //var result = await _userManager.CreateAsync(user, model.Password);

            //if (result.Succeeded)
            //{
            //    await _signInManager.SignInAsync(user, isPersistent: false);

            //    List<Claim> claims = new List<Claim>()
            //    {
            //        new Claim(ClaimTypes.Email, model.Email),
            //        new Claim(ClaimTypes.Name, "None")
            //    };

            //    await _userManager.AddClaimsAsync(user, claims);
            //}

            //return View(model);

            if (ModelState.IsValid)
            {
                await _userService.Register(model);
                return RedirectToAction("Login", "User");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> LoginTest()
        {
            var user = await _userService.GetUser();
            return View(user.Data);
        }

        [HttpGet]
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

        [HttpGet]
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
            return View(user.Data);
        }        
    }
}

//Last login            

//if (ModelState.IsValid)
//{
//    var claimsPrincipal = await _userService.Login(model);
//    if (claimsPrincipal == null)
//    {
//        return View(model);
//    }
//    //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: true);
//    //await _signInManager.SignInAsync(user, isPersistent: false);
//    //HttpContext.SignInAsync(userbool);

//    await HttpContext.SignInAsync(claimsPrincipal);



//    return RedirectToAction("Account", "User");
//}
//return View(model);

////var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

////// Если вход выполнен успешно, перенаправляем на нужную страницу
////if (result.Succeeded)
////{
////    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
////    {
////        //return Redirect(returnUrl);
////        return RedirectToAction("Account", "User");
////    }
////    else
////    {
////        return RedirectToAction("Account", "User");
////        //return RedirectToAction("Index", "Home");
////    }
////}