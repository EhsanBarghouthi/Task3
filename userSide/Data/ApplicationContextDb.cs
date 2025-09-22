
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using userSide.Models;

namespace userSide.Data
{
    public class ApplicationContextDb : DbContext

    {
        public DbSet<category> categories { get; set; }
        public DbSet<product> products  { get; set; }

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=ASP11_MVC2;Trusted_Connection=True;TrustServerCertificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<category>()
            .HasData(new category
            {
                categoryId = 1,
                categoryName = "Electronics",
                categoryType ="Laptops"

            }, 
            new category
            {
                categoryId = 2,
                categoryName = "Electronics",
                categoryType = "Computers"

            } ,
            new category
            {
                categoryId = 3,
                categoryName = "Electronics",
                categoryType = "Televisions"

            },
            new category
            {
                categoryId = 4,
                categoryName = "Electronics",
                categoryType = "AirConditions"

            },
            new category
            {
                categoryId = 5,
                categoryName = "Electronics",
                categoryType = "Microwaves"

            }

            
            );
        }
    }
}



