using District.Dal.Abstract.IRepository;
using District.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Dal.Abstact.IRepository
{
    public interface IPersonRepository : IGenericKeyRepository<int, Person>
    {
        Task<Person> FindPersonByName(string name);

    }
}
