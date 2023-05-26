using Bryggrens.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bryggrens.Models.Entities
{
    //Slår ihop till en primär nyckel.
    [PrimaryKey(nameof(UserId), nameof(AddressId))]
    public class UserAddressEntity
    {
        //Kopplar till respektive sida
        public string UserId { get; set; } = null!;
        public AppUser User { get; set; } = null!;




        public int AddressId { get; set; }
        public AddressEntity Address { get; set; } = null!;
    }
}
/*
Entity Relationships: The relationship between AppUser, AddressEntity, and UserAddressEntity seems appropriate for managing user addresses.
You have a many-to-many relationship between users and addresses, with the UserAddressEntity acting as a join table.
This setup allows users to have multiple addresses, and an address can be associated with multiple users.
Ensure that your database schema reflects this relationship.
*/