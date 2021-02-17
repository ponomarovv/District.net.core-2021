using District.Bl.Abstract.IMappers;
using District.Entities.Tables;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Bl.Impl.Mappers
{
    public class BuildingMapper : IMapper<Building, BuildingModel>
    {
        public BuildingModel Map(Building entity)
        {
            return new BuildingModel
            {
                BuildingNumber = entity.BuildingNumber,
                Id = entity.Id,
                Street = entity.Street,
            };
        }
    }
}
