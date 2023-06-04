using Microsoft.AspNetCore.Mvc;

namespace Bryggrens.Controllers.BeerControllers
{
    public class CategoryController : Controller
    {
        


        public IActionResult Neipa()
        {
            return View();
        }
        public IActionResult Sour()
        {
            return View();
        }

        public IActionResult PaleAle()
        {
            return View();
        }
    }
}
