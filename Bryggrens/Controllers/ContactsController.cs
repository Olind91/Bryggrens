using Microsoft.AspNetCore.Mvc;

namespace Bryggrens.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult ThankYouView()
        {
            return View();
        }
    }
}
