//using District.Entities.Tables;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Bl.Abstract.IServices
{
    public interface IPersonService
    {                
        Task<PersonModel> CreatePerson(PersonModel personModel);
        Task<PersonModel> GetByIdAsync(int id);
        Task UpdatePerson(PersonModel model);
        Task DeletePerson(int id);

        Task<List<PersonModel>> GetAllPersons();
        Task BuyAppartment(int personId, int apartmentId);

        Task<PersonModel> FindPersonByName(string name);

    }
}
