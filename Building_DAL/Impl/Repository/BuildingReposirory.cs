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
    public class BuildingReposirory : GenericKeyRepository<int, Building>, IBuildingRepository
    {
        public BuildingReposirory() : base(DbContextManager.DistrictDbCondext)
        {

        }

        public async Task<Building> GetApartmensByBuildingNumber(int buildingNumber)
        {
            var result = await Context.Buildings.FirstOrDefaultAsync(x => x.BuildingNumber == buildingNumber);
            return result;
        }

    }
}
