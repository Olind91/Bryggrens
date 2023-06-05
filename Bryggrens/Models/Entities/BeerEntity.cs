using Bryggrens.Models.Dto;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bryggrens.Models.Entities
{
    public class BeerEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = null!;
        public string BeerName { get; set; } = null!;


        public string? BeerDescription { get; set;}

        [Column(TypeName = "money")]
        public decimal? BeerPrice { get; set; }
        public int? AlcoholPercent { get; set; }
        public string? ImageUrl { get; set; }

               
        public ICollection<BeerCategoriesEntity> BeerCategoriesList { get; set; } = new HashSet<BeerCategoriesEntity>();


        public static implicit operator Beer(BeerEntity entity)
        {
            
            return new Beer
            {
                ArticleNumber = entity.ArticleNumber,
                Name = entity.BeerName,
                Description = entity.BeerDescription,
                Price = entity.BeerPrice,
                Alcohol = entity.AlcoholPercent,
                ImageUrl = entity.ImageUrl,

            };
           
        }

    }
}


/* 
Skapa en tabell för kategorier: Skapa en annan tabell med namnet "Categories" som innehåller information om kategorierna för öl.
Detta kan inkludera kolumnen "Id" (unik identifierare för varje kategori) och "Namn" (namnet på kategorin). 

Skapa en kopplingstabell: Eftersom varje öl kan kopplas till en eller 
flera kategorier behöver du en kopplingstabell för att skapa en många-till-många-relation mellan öl och kategorier.

Du kan skapa en tabell med namnet "BeerCategories" som har kolumnerna "BeerId" och "CategoryId". 
Dessa kolumner kommer att fungera som främmande nycklar som refererar till de relevanta id-kolumnerna i "Beers"- och "Categories"-tabellerna.
*/