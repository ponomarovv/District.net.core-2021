
using District.Bl.Abstract.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace District.Bl.Impl.Services
{
    public class EntranceService : IEntranceService
    {
        public int EntranceNumer { get; set; }
        public BuildingService Building { get; private set; }
    }
}
