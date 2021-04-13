
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

namespace District.Bl.Impl.Services
{
    public class EntranceService : IEntranceService
    {
        private readonly IEntranceRepository _entranceRepository;
        private readonly EntranceMapper _entranceMapper;
        public EntranceService()
        {
            _entranceRepository = new EntranceRepository();
            _entranceMapper = new EntranceMapper();
        }



        public async Task<EntranceModel> CreateEntrance(EntranceModel model)
        {
            return _entranceMapper.Map(await _entranceRepository.AddAsync(_entranceMapper.MapBack(model)));
        }

        public async Task UpdateEntrance(EntranceModel model)
        {
            await _entranceRepository.UpdateAsync(_entranceMapper.MapBack(model));
        }

        public async Task DeleteEntrance(int id)
        {
            await _entranceRepository.DeleteAsync(id);
        }
        public async Task<EntranceModel> GetByIdAsync(int id)
        {
            var item = await _entranceRepository.GetByIdAsync(id);

            return _entranceMapper.Map(item);
        }
        public async Task<List<EntranceModel>> GetAllEntrances()
        {
            return (await _entranceRepository.GetAllAsync()).Select(_entranceMapper.Map).ToList();
        }


    }
}
