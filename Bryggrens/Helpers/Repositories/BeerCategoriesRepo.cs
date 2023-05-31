using Bryggrens.Contexts;
using Bryggrens.Models.Entities;

namespace Bryggrens.Helpers.Repositories
{
    public class BeerCategoriesRepo : Repo<BeerCategoriesEntity>
    {
        public BeerCategoriesRepo(DataContext context) : base(context)
        {
        }
    }
}
