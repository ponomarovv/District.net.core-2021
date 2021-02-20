using District.Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace District.Dal
{
    public class DistrictDbCondext : DbContext
    {
        public DistrictDbCondext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host = 127.0.0.1; port = 5433; database = districtdb; user id = tdu819; password = 1111");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
    }

}
