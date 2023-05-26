using Bryggrens.Contexts;
using Bryggrens.Models.Entities;

namespace Bryggrens.Helpers.Repositories
{
    public class UserAddressRepository : Repo<UserAddressEntity>
    {
        public UserAddressRepository(DataContext context) : base(context)
        {
        }
    }
}
