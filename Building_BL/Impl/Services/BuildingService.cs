
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Mappers;
using District.Bl.Impl.Services;
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
    public class BuildingService : IBuildingService
    {
        public IBuildingRepository _buildingRepository;
        public BuildingMapper _buildingMapper;
        public BuildingService()
        {
            _buildingRepository = new BuildingReposirory();
            _buildingMapper = new BuildingMapper();
        }



        public async Task<BuildingModel> CreateBuilding(BuildingModel model)
        {
            return _buildingMapper.Map(await _buildingRepository.AddAsync(_buildingMapper.MapBack(model)));
        }

        public async Task<List<BuildingModel>> GetAllApartments()
        {
            return (await _buildingRepository.GetAllAsync()).Select(_buildingMapper.Map).ToList();
        }

    }

}
