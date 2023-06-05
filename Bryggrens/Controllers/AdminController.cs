﻿using Bryggrens.Helpers.Services;
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
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Something Went Wrong.");
            }
            ViewBag.CategorySelectList = await _beerCategoryService.GetCategorySelectListAsync();
            return View(viewModel);
        }


        public async Task<IActionResult> Category(string categoryName)
        {
            var category = await _beerCategoryService.GetCategoryByNameAsync(categoryName);
            if (category == null)
            {
                return NotFound();
            }

            var products = await _beerService.GetProductsByCategoryAsync(category.Id);
            ViewBag.CategoryName = category.Name;
            ViewBag.Products = products;

            return View();
        }

    }
}