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
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ApartmentMapper _apartmentMapper;
        public ApartmentService()
        {
            _apartmentRepository = new ApartmentRepository();
            _apartmentMapper = new ApartmentMapper();
        }

        public async Task<ApartmentModel> CreateApartment(ApartmentModel model)
        {
            return  _apartmentMapper.Map(await _apartmentRepository.AddAsync(_apartmentMapper.MapBack(model)));
        }
        public async Task<ApartmentModel> GetByIdAsync(int id)
        {
            var item = await _apartmentRepository.GetByIdAsync(id);

            return _apartmentMapper.Map(item);
        }
        public async Task UpdateApartment(ApartmentModel model)
        {
            await _apartmentRepository.UpdateAsync(_apartmentMapper.MapBack(model));
        }

        public async Task DeleteApartment(int id)
        {
            await _apartmentRepository.DeleteAsync(id);
        }


        public async Task<List<ApartmentModel>> GetAllApartments()
        {
            List<ApartmentModel> apartments =  (await _apartmentRepository.GetAllAsync()).Select(_apartmentMapper.Map).ToList();

            //var result = await _apartmentRepository.GetAllAsync();
            //List<ApartmentModel> apartmentModels = new List<ApartmentModel>();
            //foreach (var entity in result)
            //{
            //    apartmentModels.Add(_apartmentMapper.Map(entity));
            //}
            //return apartmentModels;
            return apartments;
        }

        public async Task<List<ApartmentModel>> GetApartmentsByBuildingId(int buildingId)
        {
            return ((await _apartmentRepository.GetApartmentsByBuildingId(buildingId)).Select(_apartmentMapper.Map)).ToList();
        }

        public async Task<List<ApartmentModel>> GetApartmentsByPersonId(int personId)
        {
            return ((await _apartmentRepository.GetApartmentsByPersonId(personId)).Select(_apartmentMapper.Map)).ToList();
        }
    }
}
