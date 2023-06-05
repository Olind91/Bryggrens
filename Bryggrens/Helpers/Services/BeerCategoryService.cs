using Bryggrens.Helpers.Repositories;
using Bryggrens.Models.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bryggrens.Helpers.Services
{
    public class BeerCategoryService
    {
        private readonly CategoryRepo _categoryRepo;

        public BeerCategoryService(CategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }




        #region Create Category

        #endregion



        #region Get Category

        public async Task<List<SelectListItem>> GetCategorySelectListAsync()
        {
            var categories = await _categoryRepo.GetAllAsync();

            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            }).ToList();
        }

        public async Task<BeerCategory> GetCategoryByNameAsync(string categoryName)
        {
            var result = await _categoryRepo.GetAsync(x => x.CategoryName == categoryName);
            return result;
        }

        #endregion



        #region Get All Categories

        #endregion


    }
}
