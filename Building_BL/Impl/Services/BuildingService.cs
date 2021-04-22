
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
using District.Bl.Abstract.IMappers;
using District.Dal.Impl;
using District.Entities.Tables;
using District.Dal.Abstact;

namespace District.Bl.Impl.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackMapper<Building, BuildingModel> _buildingMapper;


        public BuildingService(IUnitOfWork unitOfWork, IBackMapper<Building, BuildingModel> buildingMapper)
        {
            _unitOfWork = unitOfWork;
            _buildingMapper = buildingMapper;
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
