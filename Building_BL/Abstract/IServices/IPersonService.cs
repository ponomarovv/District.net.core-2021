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
        //List<ApartmentModel> FindAppartments()
        //{
        //    return 
        //}
        Task<List<PersonModel>> GetAllPersons();
        Task<PersonModel> CreatePerson(PersonModel personModel);
    }
}
