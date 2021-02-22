using District.Dal.Abstact.IRepository;
using District.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
//using System.Linq;

namespace District.Dal.Impl.Repository
{
    public class PersonRepository : GenericKeyRepository<int, Person>, IPersonRepository
    {
        public PersonRepository() : base(DbContextManager.DistrictDbCondext)
        {
            
        }


        public async Task<Person> FindPersonByName(string name)
        {
            return await Context.Persons.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
