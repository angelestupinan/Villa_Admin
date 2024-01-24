using Microsoft.EntityFrameworkCore;
using VillaAPI.Models;

namespace VillaAPI.Data

{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                
                new Villa()
                {
                    Id = 1,
                    Nombre = "Casa en la playa/testdbcontent",
                    Habitantes = 15,
                    ImagenUrl = "",
                    Fecha = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Casa en la ciudad/testdbcontent",
                    Habitantes = 25,
                    ImagenUrl = "",
                    Fecha = DateTime.Now
                }
            );
        }

    }
}
