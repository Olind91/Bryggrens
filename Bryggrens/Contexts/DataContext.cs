using Bryggrens.Models.Entities;
using Bryggrens.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bryggrens.Contexts
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }



        //Users
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<UserAddressEntity> UserAddress { get; set; }

        //Contact
        public DbSet<ContactFormEntity> ContactForm { get; set; }

    }

}
