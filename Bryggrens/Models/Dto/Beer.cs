namespace Bryggrens.Models.Dto
{
    public class Beer
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Alcohol {get; set; }
        public string? ImageUrl { get; set; }


        public IEnumerable<BeerCategory> Categories { get; set; } = new List<BeerCategory>();
    }
}
