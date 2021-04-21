using District.Dal.Abstact.IRepository;
using District.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Dal.Impl.Repository
{
    public class EntranceRepository : GenericKeyRepository<int, Entrance>, IEntranceRepository
    {
        public EntranceRepository(DistrictDbContext dbContext) : base(dbContext)
        {

        }
    }
}
