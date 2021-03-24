
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Mappers;
using District.Dal.Abstact.IRepository;
using District.Dal.Impl.Repository;
using District.Entities.Tables;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace District.Bl.Impl.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonMapper _personMapper;

        private readonly IApartmentRepository _apartmentRepository;

        public PersonService()
        {
            _personRepository = new PersonRepository();
            _personMapper = new PersonMapper();
            _apartmentRepository = new ApartmentRepository();
        }

        public async Task<PersonModel> CreatePerson(PersonModel model)
        {
            return  _personMapper.Map(await _personRepository.AddAsync(_personMapper.MapBack(model)));
        }

        public async Task UpdatePerson(PersonModel model)
        {
            await _personRepository.UpdateAsync(_personMapper.MapBack(model));
        }

        public async Task DeletePerson(int id)
        {
            await _personRepository.DeleteAsync(id);
        }

        public async Task BuyAppartment(int personId, int apartmentId)
        {
            Apartment item = await _apartmentRepository.GetByIdAsync(apartmentId);
            item.PersonId = personId;
            if (personId != 1) // 1 is id of building creator
            {
                item.IsOwn = true;
            }
            item.OrderDate = DateTime.Now;
            await _apartmentRepository.UpdateAsync(item);
        }
        public async Task<PersonModel> GetByIdAsync(int id)
        {
            var item = await _personRepository.GetByIdAsync(id);

            return _personMapper.Map(item);
        }


        public async Task<PersonModel> FindPersonByName(string name)
        {


            PersonModel result =  _personMapper.Map(await _personRepository.FindPersonByName(name));

            //if (result == null)
            //{
            //    PersonModel noneModel2 = new PersonModel() { };
            //    return noneModel2;
            //}
            
            //if (result == null)
            //{
            //    Console.WriteLine("Nothing found");
            //}
            return result;
        }
        //return (await _apartmentRepository.GetAllAsync()).Select(_apartmentMapper.Map).ToList();
        //await _apartmentRepository.UpdateAsync(_apartmentMapper.MapBack(model));



        public async Task<List<PersonModel>> GetAllPersons()
        {
            return (await _personRepository.GetAllAsync()).Select(_personMapper.Map).ToList();
        }
    }
}
