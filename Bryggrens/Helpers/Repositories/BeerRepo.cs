using Bryggrens.Contexts;
using Bryggrens.Models.Entities;

namespace Bryggrens.Helpers.Repositories
{
    public class BeerRepo : Repo<BeerEntity>
    {
        public BeerRepo(DataContext context) : base(context)
        {
        }
    }
}
