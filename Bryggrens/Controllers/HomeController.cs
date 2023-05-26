using Microsoft.AspNetCore.Mvc;

namespace Bryggrens.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
