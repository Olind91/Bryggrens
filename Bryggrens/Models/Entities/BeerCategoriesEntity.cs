using Microsoft.EntityFrameworkCore;

namespace Bryggrens.Models.Entities
{
    //Kopplingstabell
    [PrimaryKey(nameof(ArticleNumber), nameof(CategoryId))]
    public class BeerCategoriesEntity
    {
        public string ArticleNumber { get; set; } = null!;
        public BeerEntity Beer { get; set; } = null!;



        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;
    }
}
