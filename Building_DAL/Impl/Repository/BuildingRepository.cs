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
    public class BuildingRepository : GenericKeyRepository<int, Building>, IBuildingRepository
    {
        public BuildingRepository(DistrictDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Building> GetApartmensByBuildingNumber(int buildingNumber)
        {
            var result = await Context.Buildings.FirstOrDefaultAsync(x => x.BuildingNumber == buildingNumber);
            return result;
        }

    }
}
