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
        public override async Task<IEnumerable<BeerEntity>> GetAllAsync()
        {
            try
            {
                var items = await _context.Set<BeerEntity>()
                    .Include(e => e.BeerCategoriesList)
                    .ToListAsync();
                return items!;
            }
            catch
            {
                return null!;
            }
        }


    }
}
