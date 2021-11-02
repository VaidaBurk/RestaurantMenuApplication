using Microsoft.EntityFrameworkCore;
using Restaurants.Models;

namespace Restaurants.Data
{
    public class DataContext : DbContext
    {
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<DishModel> Menu { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishModel>()
                .HasMany(d => d.Restaurants)
                .WithOne()
                .HasForeignKey(r => r.DishId);


            modelBuilder.Entity<DishModel>()
                .Property(d => d.Price)
                .HasPrecision(5, 2);
        }
    }
}
