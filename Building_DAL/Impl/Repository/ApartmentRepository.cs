using District.Dal.Abstact.IRepository;
using District.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace District.Dal.Impl.Repository
{
    public class ApartmentRepository : GenericKeyRepository<int, Apartment>, IApartmentRepository
    {
        public ApartmentRepository() : base(DbContextManager.DistrictDbCondext)
        { 

        }

        public async Task<List<Apartment>> GetApartmenеsByBuildingId(int buildingid)
        {
            var result = await  Context.Apartments.Where(x => x.BuildingId == buildingid).ToListAsync();
            return  result;
        }

        public async Task<List<Apartment>> GetApartmentsByPersonId(int personId)
        {
            var result = await Context.Apartments.Where(x => x.PersonId == personId).ToListAsync();
            return result;
        }

    }
}
