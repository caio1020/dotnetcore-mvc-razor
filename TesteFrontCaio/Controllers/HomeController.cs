using Microsoft.AspNetCore.Mvc;

namespace TesteFrontCaio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
