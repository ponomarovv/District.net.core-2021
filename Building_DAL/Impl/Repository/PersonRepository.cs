using District.Dal.Abstact.IRepository;
using District.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Dal.Impl.Repository
{
    public class PersonRepository : GenericKeyRepository<int, Person>, IPersonRepository
    {
        public PersonRepository() : base(DbContextManager.DistrictDbCondext)
        {

        }
    }
}
