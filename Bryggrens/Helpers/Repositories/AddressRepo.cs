using Bryggrens.Contexts;
using Bryggrens.Models.Entities;

namespace Bryggrens.Helpers.Repositories
{
    public class AddressRepository : Repo<AddressEntity>
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}
