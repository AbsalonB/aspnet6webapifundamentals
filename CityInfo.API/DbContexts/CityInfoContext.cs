using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterst> PointsOfInterest { get; set; } = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("Managua") { Id = 1, Description = "Managua" },
                new City("Tipitapa") { Id = 2, Description = "Tipitapa" });
            modelBuilder.Entity<PointOfInterst>().HasData(
                new PointOfInterst("Ninguno") { Id = 1, CityId = 1, Description = "Ninguno" },
                new PointOfInterst("Ninguno2") { Id = 2, CityId = 2, Description = "Ninguno2" }
                );
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
