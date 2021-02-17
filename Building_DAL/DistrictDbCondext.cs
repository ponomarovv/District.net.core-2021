using District.Entities.Tables;
using Microsoft.EntityFrameworkCore;

namespace District.Dal
{
    public class DistrictDbCondext : DbContext
    {
        public DistrictDbCondext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
    }

}
