
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Building_BL
{
    public class BuildingService : IBuildingService
    {
        
        public List<ApartmentService> Apartments { get; set; }

        public string Street { get; set; }
        public int BuildingNumber { get; set; }
    }
}
