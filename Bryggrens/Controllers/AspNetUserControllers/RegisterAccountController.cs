﻿using Bryggrens.Helpers.Services;

using Bryggrens.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Bryggrens.Controllers.AspNetUserControllers
{
    public class RegisterAccountController : Controller
    {
        private readonly AuthService _authService;

        public RegisterAccountController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM viewModel)
        {
            if (!viewModel.TermsAndAgreement)
            {
                ModelState.AddModelError("TermsAndAgreement", "You must agree with the terms and conditions");
            }

            if (ModelState.IsValid)
            {
                //Kollar om user finns, true/false
                if (await _authService.UserAlreadyExistsAsync(x => x.Email == viewModel.Email))
                    ModelState.AddModelError("", "A user with the same email already exists");

                //registrerar och omdirigerar
                if (await _authService.RegisterUserAsync(viewModel))
                    return RedirectToAction("index", "login");

            }
            return View(viewModel);
        }



    }


}
