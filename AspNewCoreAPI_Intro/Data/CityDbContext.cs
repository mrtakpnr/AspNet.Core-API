using AspNewCoreAPI_Intro.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNewCoreAPI_Intro.Data
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options) : base(options)
        { }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "İstanbul", Region = "Marmara", Code = "34" },
                new City { Id = 2, Name = "İzmir", Region = "Ege", Code = "35" },
                new City { Id = 3, Name = "Ankara", Region = "İç Anadolu", Code = "06" },
                new City { Id = 4, Name = "Antalya", Region = "Akdeniz", Code = "07" },
                new City { Id = 5, Name = "Bursa", Region = "Marmara", Code = "16" },
                new City { Id = 6, Name = "Ordu", Region = "Karadeniz", Code = "52" }

            );
            base.OnModelCreating(modelBuilder);
        }
}
}
