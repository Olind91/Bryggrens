using Bryggrens.Contexts;
using Bryggrens.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bryggrens.Helpers.Repositories
{
    public class BeerRepo : Repo<BeerEntity>
    {
        private readonly DataContext _context;

        public BeerRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BeerEntity>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Beer
                .Where(b => b.BeerCategoriesList.Any(bc => bc.CategoryId == categoryId))
                .ToListAsync();
        }









    }
}
