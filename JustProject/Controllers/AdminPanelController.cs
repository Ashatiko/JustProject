using Microsoft.AspNetCore.Mvc;

namespace JustProject.Controllers
{
    public class AdminPanelController : Controller
    {
        [HttpGet]
        public IActionResult ManegerCMS()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProffessionAdd()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserAdd()
        {
            return View();
        }
    }
}
