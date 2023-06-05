using Bryggrens.Models.Dto;

namespace Bryggrens.Models.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
        public ICollection<BeerCategoriesEntity> BeersCategories { get; set; } = new HashSet<BeerCategoriesEntity>();



        public static implicit operator BeerCategory(CategoryEntity? entity)
        {
            if (entity == null)
            {
                return null!;
            }

            return new BeerCategory
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
            };
        }

    }
}
