using District.Dal.Abstract.IRepository;
using District.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Dal.Abstact.IRepository
{
    public interface IPersonRepository : IGenericKeyRepository<int, Person>
    {

    }
}
