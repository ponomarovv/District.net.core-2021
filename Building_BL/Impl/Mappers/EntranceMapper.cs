﻿using District.Bl.Abstract.IMappers;
using District.Entities.Tables;
using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Bl.Impl.Mappers
{
    public class EntranceMapper : IBackMapper<Entrance, EntranceModel>
    {
        public EntranceModel Map(Entrance entity)
        {
            return new EntranceModel
            {
                Id = entity.Id,
                EntranceNumber = entity.EntranceNumer,
                BuildingId = entity.BuildingId,
            };
        }
        public Entrance MapBack(EntranceModel model)
        {
            return new Entrance
            {
                Id = model.Id,
                BuildingId = model.BuildingId,
                EntranceNumer = model.EntranceNumber,
            };
        }
    }
}
