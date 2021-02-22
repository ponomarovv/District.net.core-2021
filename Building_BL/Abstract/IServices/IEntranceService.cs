using District.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Bl.Abstract.IServices
{
    public interface IEntranceService 
    {
        public Task<EntranceModel> CreateEntrance(EntranceModel model);

    }
}
