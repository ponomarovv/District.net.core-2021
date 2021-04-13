using District.Bl.Abstract.IMappers;
using District.Entities.Tables;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Bl.Impl.Mappers
{
    public class PersonMapper : IBackMapper<Person, PersonModel>
    {
        public PersonModel Map(Person entity)
        {
            if (entity == null)
            {
                return new PersonModel() { };
            }

            return new PersonModel
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
            };
        }

        public Person MapBack(PersonModel model)
        {
            return new Person
            {
                Id = model.Id,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
            };
        }
    }
}
