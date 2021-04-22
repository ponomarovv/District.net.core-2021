
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
using District.Bl.Abstract.IMappers;
using District.Dal.Abstact;
using District.Dal.Impl;

namespace District.Bl.Impl.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IBackMapper<Person, PersonModel> _personMapper;

       

        public PersonService()
        {
            _unitOfWork = new UnitOfWork();
            _personMapper = new PersonMapper();
            
        }

        public async Task<PersonModel> CreatePerson(PersonModel model)
        {
            return  _personMapper.Map(await _unitOfWork.PersonRepository.AddAsync(_personMapper.MapBack(model)));
        }

        public async Task UpdatePerson(PersonModel model)
        {
            await _unitOfWork.PersonRepository.UpdateAsync(_personMapper.MapBack(model));
        }

        public async Task DeletePerson(int id)
        {
            await _unitOfWork.PersonRepository.DeleteAsync(id);
        }

        public async Task BuyApartment(int personId, int apartmentId)
        {
            Apartment item = await _unitOfWork.ApartmentRepository.GetByIdAsync(apartmentId);
            item.PersonId = personId;
            if (personId != 1) // 1 is id of building creator // todo переделать. -1
            {
                item.IsOwn = true;
            }
            else
            {
                item.IsOwn = false;
            }
            item.OrderDate = DateTime.Now;
            await _unitOfWork.ApartmentRepository.UpdateAsync(item);
        }
        public async Task<PersonModel> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.PersonRepository.GetByIdAsync(id);
            //if (item == null)
            //{
            //    return new PersonModel() { };
            //}

            return _personMapper.Map(item);
        }


        public async Task<PersonModel> FindPersonByName(string name)
        {


            PersonModel result =  
                _personMapper.Map(await _unitOfWork.PersonRepository.FindPersonByName(name));

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
            return (await _unitOfWork.PersonRepository.GetAllAsync()).Select(_personMapper.Map).ToList();
        }
    }
}
