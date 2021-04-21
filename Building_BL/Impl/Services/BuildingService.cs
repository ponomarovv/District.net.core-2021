
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
using District.Dal.Impl;

namespace District.Bl.Impl.Services
{
    public class BuildingService : IBuildingService
    {
        
        private readonly BuildingMapper _buildingMapper;
        private readonly UnitOfWork _unitOfWork;

        public BuildingService()
        {
            _unitOfWork = new UnitOfWork();
            _buildingMapper = new BuildingMapper(); //TODO
        }



        public async Task<BuildingModel> CreateBuilding(BuildingModel model)
        {
            return _buildingMapper.Map(await _unitOfWork.BuildingRepository.AddAsync(_buildingMapper.MapBack(model)));
        }

        public async Task UpdateBuilding(BuildingModel model)
        {
            await _unitOfWork.BuildingRepository.UpdateAsync(_buildingMapper.MapBack(model));
        }

        public async Task DeleteBuilding(int id)
        {
            await _unitOfWork.BuildingRepository.DeleteAsync(id);
        }

        public async Task<BuildingModel> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.BuildingRepository.GetByIdAsync(id);

            return _buildingMapper.Map(item);
        }



        public async Task<List<BuildingModel>> GetAllBuildings()
        {
            return (await _unitOfWork.BuildingRepository.GetAllAsync()).Select(_buildingMapper.Map).ToList();
        }

    }

}
