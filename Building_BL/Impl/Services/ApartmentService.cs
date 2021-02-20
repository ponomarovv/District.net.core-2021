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
        public IApartmentRepository _apartmentRepository;
        public ApartmentMapper _apartmentMapper;
        public ApartmentService()
        {
            _apartmentRepository = new ApartmentRepository();
            _apartmentMapper = new ApartmentMapper();
        }

        public async Task<ApartmentModel> CreateApartment(ApartmentModel model)
        {
            return  _apartmentMapper.Map(await _apartmentRepository.AddAsync(_apartmentMapper.MapBack(model)));
        }

        public async Task<List<ApartmentModel>> GetAllApartments()
        {
            //return (await _apartmentRepository.GetAllAsync()).Select(_apartmentMapper.Map).ToList();
            var result = await _apartmentRepository.GetAllAsync();
            List<ApartmentModel> apartmentModels = new List<ApartmentModel>();
            foreach (var entity in result)
            {
                apartmentModels.Add(_apartmentMapper.Map(entity));
            }
            return apartmentModels;
        }

        public async Task<List<ApartmentModel>> GetApartmentsByBuildingId(int buildId)
        {
            return ((await _apartmentRepository.GetApartmensByBuildingId(buildId)).Select(_apartmentMapper.Map)).ToList();
        }
    }
}
