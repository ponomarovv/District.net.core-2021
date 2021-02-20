
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Mappers;
using District.Dal.Abstact.IRepository;
using District.Dal.Impl.Repository;
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
        public IPersonRepository _personRepository;
        public PersonMapper _personMapper;

        public PersonService()
        {
            _personRepository = new PersonRepository();
            _personMapper = new PersonMapper();
        }

        public async Task<PersonModel> CreatePerson(PersonModel model)
        {
            return  _personMapper.Map(await _personRepository.AddAsync(_personMapper.MapBack(model)));
        }

        public async Task<List<PersonModel>> GetAllPersons()
        {
            return (await _personRepository.GetAllAsync()).Select(_personMapper.Map).ToList();
        }
    }
}
