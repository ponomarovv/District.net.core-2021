
using District.Bl.Abstract.IServices;
using District.Bl.Impl.Mappers;
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
    public class EntranceService : IEntranceService
    {
        
        private readonly EntranceMapper _entranceMapper;
        private readonly UnitOfWork _unitOfWork;

        public EntranceService()
        {
            _unitOfWork = new UnitOfWork();
            _entranceMapper = new EntranceMapper();
        }



        public async Task<EntranceModel> CreateEntrance(EntranceModel model)
        {
            return _entranceMapper.Map(await _unitOfWork.EntranceRepository.AddAsync(_entranceMapper.MapBack(model)));
        }

        public async Task UpdateEntrance(EntranceModel model)
        {
            await _unitOfWork.EntranceRepository.UpdateAsync(_entranceMapper.MapBack(model));
        }

        public async Task DeleteEntrance(int id)
        {
            await _unitOfWork.EntranceRepository.DeleteAsync(id);
        }
        public async Task<EntranceModel> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.EntranceRepository.GetByIdAsync(id);

            return _entranceMapper.Map(item);
        }
        public async Task<List<EntranceModel>> GetAllEntrances()
        {
            return (await _unitOfWork.EntranceRepository.GetAllAsync()).Select(_entranceMapper.Map).ToList();
        }


    }
}
