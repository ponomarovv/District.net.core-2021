using District.Bl.Abstract.IMappers;
using District.Entities.Tables;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Bl.Impl.Mappers
{
    public class EntranceMapper : IMapper<Entrance, EntranceModel>
    {
        public EntranceModel Map(Entrance entity)
        {
            return new EntranceModel
            {
                Id = entity.Id,
                EntranceNumer = entity.EntranceNumer,                   
            };
        }
    }
}
