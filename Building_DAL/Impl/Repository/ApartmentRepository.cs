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
        public ApartmentRepository() : base(DbContextManager.DistrictDbContext)
        { 

        }

        public async Task<List<Apartment>> GetApartmentsByBuildingId(int buildingid)
        {
            var result = await  Context.Apartments.Where(x => x.BuildingId == buildingid).ToListAsync();
            return  result;
        }

        public async Task<List<Apartment>> GetApartmentsByPersonId(int personId)
        {
            var result = await Context.Apartments.Where(x => x.PersonId == personId).ToListAsync();
            return result;
        }

        //public async Task<List<Apartment>> GetBuildingIdByApartmentId(int apartmentId)
        //{
        //    var result = await Context.Buildings.Where(x => x.id == apartmentId).ToListAsync();
        //    return result;
        //}

    }
}
