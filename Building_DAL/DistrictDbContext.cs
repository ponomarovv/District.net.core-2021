using District.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace District.Dal
{
    public class DistrictDbContext : DbContext
    {
        public DistrictDbContext()
        {
            
        }

        public DistrictDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host = 127.0.0.1; port = 5433; database = districtdb; user id = tdu819; password = 1111");
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //todo config connection string
        //{
        //    optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //}

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
    }
}
