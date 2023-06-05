using Bryggrens.Models.Dto;
using Bryggrens.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Bryggrens.Models.ViewModels
{
    public class BeerVM
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Alcohol { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? ImageUrl { get; set; }
        public List<string>? BeerCategories { get; set; }

        public string? SelectedCategory { get; set; }



        public static implicit operator BeerEntity(BeerVM viewModel)
        {
            var entity = new BeerEntity
            {
                ArticleNumber = viewModel.ArticleNumber,
                BeerName = viewModel.Name,
                BeerDescription = viewModel.Description,
                AlcoholPercent = viewModel.Alcohol,
                BeerPrice = viewModel.Price

            };

           

            if (!string.IsNullOrEmpty(viewModel.SelectedCategory))
            {
                entity.BeerCategoriesList.Add(new BeerCategoriesEntity
                {
                    CategoryId = int.Parse(viewModel.SelectedCategory)
                });
            }

            if (viewModel.ImageUrl != null)

                entity.ImageUrl = $"{Guid.NewGuid}_{viewModel.ImageUrl?.FileName}";

            return entity;
        }
    }
}
