using Bryggrens.Contexts;
using Bryggrens.Models.Entities;

namespace Bryggrens.Helpers.Repositories
{
    public class CategoryRepo : Repo<CategoryEntity>
    {
        public CategoryRepo(DataContext context) : base(context)
        {
        }
    }
}
