using Microsoft.AspNetCore.Mvc;

namespace Bryggrens.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFoundView()
        {
            return View();
        }
    }
}
