using Bryggrens.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;

namespace Bryggrens.Controllers
{
    public class AboutController : Controller
    {     



        public IActionResult Index()
        {
            var model = new AboutVM
            {
                Name = "Andreas Rydas Rydgren",                
                ProfilePictureUrl = "/images/rydasabout.jpg" 
            };
            return View(model);
        }
    }
}
