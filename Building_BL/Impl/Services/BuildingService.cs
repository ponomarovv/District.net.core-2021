
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
        private readonly IBuildingRepository _buildingRepository;
        private readonly BuildingMapper _buildingMapper;
        public BuildingService()
        {
            _buildingRepository = new BuildingReposirory();
            _buildingMapper = new BuildingMapper();
        }



        public async Task<BuildingModel> CreateBuilding(BuildingModel model)
        {
            return _buildingMapper.Map(await _buildingRepository.AddAsync(_buildingMapper.MapBack(model)));
        }

        public async Task UpdateBuilding(BuildingModel model)
        {
            await _buildingRepository.UpdateAsync(_buildingMapper.MapBack(model));
        }

        public async Task DeleteBuilding(int id)
        {
            await _buildingRepository.DeleteAsync(id);
        }

        public async Task<BuildingModel> GetByIdAsync(int id)
        {
            var item = await _buildingRepository.GetByIdAsync(id);

            return _buildingMapper.Map(item);
        }



        public async Task<List<BuildingModel>> GetAllBuildings()
        {
            return (await _buildingRepository.GetAllAsync()).Select(_buildingMapper.Map).ToList();
        }

    }

}
