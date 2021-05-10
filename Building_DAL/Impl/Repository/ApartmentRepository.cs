using District.Dal.Abstact.IRepository;
using District.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace District.Dal.Impl.Repository
{
    public class ApartmentRepository : GenericKeyRepository<int, Apartment>, IApartmentRepository
    {
        public ApartmentRepository(DistrictDbContext dbContext) : base(dbContext)
        { 

        }

        public async Task<List<Apartment>> GetApartmentsByBuildingId(int buildingId)
        {
            var result =
                from apartment in Context.Apartments
                where apartment.BuildingId == buildingId
                orderby apartment.Id
                select apartment;

            //var result = await  Context.Apartments.Where(x => x.BuildingId == buildingId).ToListAsync();
            return await result.ToListAsync();
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
