using Bryggrens.Helpers.Repositories;
using Bryggrens.Models.Dto;
using Bryggrens.Models.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Bryggrens.Helpers.Services
{
    public class BeerService
    {

        private readonly BeerRepo _beerRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BeerService(BeerRepo beerRepo, IWebHostEnvironment webHostEnvironment)
        {
            _beerRepo = beerRepo;
            _webHostEnvironment = webHostEnvironment;
        }


        #region Create

        public async Task<Beer> CreateAsync(BeerEntity entity)
        {
            var _entity = await _beerRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            if (_entity == null)
            {
                _entity = await _beerRepo.AddAsync(entity);
                if (_entity != null)
                    return _entity;
            }
            return null!;
        }


        #endregion



        #region Get By ArticleNumber

        public async Task<Beer> GetByArticleNumberAsync(string articleNumber)
        {
            return await _beerRepo.GetAsync(x => x.ArticleNumber == articleNumber);
        }

        #endregion



        #region Get All

        public async Task<IEnumerable<BeerEntity>> GetAllAsync()
        {
            return await _beerRepo.GetAllAsync();
        }

        #endregion



        #region Upload Image
        public async Task<bool> UploadImageAsync(Beer product, IFormFile image)
        {
            try
            {
                string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";
                await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
                
                return true;
            }
            catch { return false; }
        }
        #endregion



        #region Get By Category ID

        public async Task<IEnumerable<BeerEntity>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _beerRepo.GetProductsByCategoryAsync(categoryId);
        }





        #endregion



        #region Add Category To Product

        #endregion


    }
}
