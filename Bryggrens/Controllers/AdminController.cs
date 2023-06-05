using Bryggrens.Helpers.Services;
using Bryggrens.Models.Dto;
using Bryggrens.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Bryggrens.Controllers
{
    public class AdminController : Controller
    {

        private readonly BeerService _beerService;
        private readonly BeerCategoryService _beerCategoryService;

        public AdminController(BeerService beerService, BeerCategoryService beerCategoryService)
        {
            _beerService = beerService;
            _beerCategoryService = beerCategoryService;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.CategorySelectList = await _beerCategoryService.GetCategorySelectListAsync();
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateProduct(BeerVM viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _beerService.CreateAsync(viewModel);
                if (product != null)
                {
                    if(viewModel.ImageUrl != null)
                        await _beerService.UploadImageAsync(product, viewModel.ImageUrl); //Verkar inte funka....
                    
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Something Went Wrong.");
            }
            ViewBag.CategorySelectList = await _beerCategoryService.GetCategorySelectListAsync();
            return View(viewModel);
        }


        
    }
}
