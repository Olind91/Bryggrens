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

        //Beer
        public DbSet<BeerEntity> Beer { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<BeerCategoriesEntity> BeerCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { Id = 1, CategoryName = "Neipa" },
                new CategoryEntity { Id = 2, CategoryName = "Sour Beer" },
                new CategoryEntity { Id = 3, CategoryName = "Pale Ale" }

             );
        }

    }

}
