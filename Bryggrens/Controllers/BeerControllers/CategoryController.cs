using Bryggrens.Helpers.Repositories;
using Bryggrens.Helpers.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Bryggrens.Controllers.BeerControllers
{
    public class CategoryController : Controller
    {
        
        private readonly BeerRepo _beerRepo;

        public CategoryController(BeerRepo beerRepo)
        {
           
            _beerRepo = beerRepo;
        }

        public async Task<IActionResult> Beers()
        {
            var products = await _beerRepo.GetAllAsync();
            return View(products);
        }

        public async Task<IActionResult> FilterByCategory(int categoryId)
        {
            var products = await _beerRepo.GetProductsByCategoryAsync(categoryId);
            return View("Beers", products);
        }



        public async Task<IActionResult> Neipa()
        {
            var neipaCategoryId = 1;
            var products = await _beerRepo.GetProductsByCategoryAsync(neipaCategoryId);
            return View(products);
        }

        public async Task<IActionResult> Sour()
        {
            var sourCategoryId = 2;
            var products = await _beerRepo.GetProductsByCategoryAsync(sourCategoryId);
            return View(products);
        }



        public async Task<IActionResult> PaleAle()
        {
            var paleAleCategoryId = 3;
            var products = await _beerRepo.GetProductsByCategoryAsync(paleAleCategoryId);
            return View(products);
        }



    }
}
