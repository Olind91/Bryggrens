using Microsoft.AspNetCore.Mvc;

namespace Bryggrens.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
