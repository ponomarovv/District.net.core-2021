
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
using District.Entities.Enums;

namespace District.Bl.Impl.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IBackMapper<Person, PersonModel> _personMapper;



        public PersonService(IUnitOfWork unitOfWork, IBackMapper<Person, PersonModel> personMapper)
        {
            _unitOfWork = unitOfWork;
            _personMapper = personMapper;


        }

        public async Task<PersonModel> CreatePerson(PersonModel model)
        {
            var person = _personMapper.Map(await _unitOfWork.PersonRepository.AddAsync(_personMapper.MapBack(model)));
            _unitOfWork.Save();

            return person;
        }

        public async Task UpdatePerson(PersonModel model)
        {
            await _unitOfWork.PersonRepository.UpdateAsync(_personMapper.MapBack(model));
            //_unitOfWork.Save();
        }

        public async Task DeletePerson(int id)
        {
            await _unitOfWork.PersonRepository.DeleteAsync(id);
            //_unitOfWork.Save();
        }

        public async Task BuyApartment(int personId, int apartmentId)
        {
            Apartment apartment = await _unitOfWork.ApartmentRepository.GetByIdAsync(apartmentId);
            Person person = await _unitOfWork.PersonRepository.GetByIdAsync(personId);
            apartment.PersonId = personId;
            apartment.OrderDate = DateTime.Now;

            switch (person.PersonType)
            {
                case PersonType.Builder:
                    apartment.IsOwn = false;
                    break;
                case PersonType.Client:
                    apartment.IsOwn = true;
                    break;
                default:
                    break;
            }

            await _unitOfWork.ApartmentRepository.UpdateAsync(apartment);
            //_unitOfWork.Save();
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
            List<PersonModel> allpersons = (await _unitOfWork.PersonRepository.GetAllAsync()).Select(_personMapper.Map).ToList();

            int personsLength = allpersons.Count;

            PersonModel tempPersonModel = new PersonModel();

            for (int i = 0; i < personsLength - 1; i++)
            {
                for (int j = i + 1; j < personsLength; j++)
                {
                    if (allpersons[i].Id > allpersons[j].Id)
                    {
                        tempPersonModel = allpersons[i];
                        allpersons[i] = allpersons[j];
                        allpersons[j] = tempPersonModel;
                    }

                }
            }

            return allpersons;
        }
    }
}
