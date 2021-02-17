using District.Bl.Abstract.IMappers;
using District.Entities.Tables;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Bl.Impl.Mappers
{
    public class PersonMapper : IMapper<Person, PersonModel>
    {
        public PersonModel Map(Person entity)
        {
            return new PersonModel
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}
