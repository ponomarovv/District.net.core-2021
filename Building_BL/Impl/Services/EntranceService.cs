
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
using District.Bl.Abstract.IMappers;
using District.Dal.Abstact;
using District.Dal.Impl;
using District.Entities.Tables;

namespace District.Bl.Impl.Services
{
    public class EntranceService : IEntranceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBackMapper<Entrance, EntranceModel> _entranceMapper;
        

        public EntranceService(IUnitOfWork unitOfWork, IBackMapper<Entrance, EntranceModel> entranceMapper)
        {
            _unitOfWork = unitOfWork;
            _entranceMapper = entranceMapper;
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
