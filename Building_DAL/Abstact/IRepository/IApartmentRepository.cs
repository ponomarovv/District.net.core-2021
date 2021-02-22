using District.Dal.Abstract.IRepository;
using District.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Dal.Abstact.IRepository
{
    public interface IApartmentRepository : IGenericKeyRepository<int, Apartment>
    {
        Task<List<Apartment>> GetApartmenеsByBuildingId(int id);
        Task<List<Apartment>> GetApartmentsByPersonId(int personId);
    }
}
