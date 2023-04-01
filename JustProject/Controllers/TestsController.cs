using Microsoft.AspNetCore.Mvc;

namespace JustProject.Controllers
{
    public class TestsController : Controller
    {
        [HttpGet]
        public IActionResult LoginTest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginTest(string asd)
        {
            return RedirectToAction("TypeTest", "Tests");
        }

        [HttpGet]
        public async Task<IActionResult> TypeTest()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Analyt()
        {
            return View();
        }        

        [HttpGet]
        public async Task<IActionResult> Example()
        {
            return View();
        }
    }
}
