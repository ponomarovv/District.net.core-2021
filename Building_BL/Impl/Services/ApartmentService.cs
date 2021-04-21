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
    public class ApartmentService : IApartmentService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ApartmentMapper _apartmentMapper;
        public ApartmentService()
        {
            _unitOfWork = new UnitOfWork();
            _apartmentMapper = new ApartmentMapper(); // TODO сюда IMapper, и IUnitofwork
        }

        public async Task<ApartmentModel> CreateApartment(ApartmentModel model)
        {
            return _apartmentMapper.Map(await _unitOfWork.ApartmentRepository.AddAsync(_apartmentMapper.MapBack(model)));
        }
        public async Task<ApartmentModel> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.ApartmentRepository.GetByIdAsync(id);

            return _apartmentMapper.Map(item);
        }
        public async Task UpdateApartment(ApartmentModel model)
        {
            await _unitOfWork.ApartmentRepository.UpdateAsync(_apartmentMapper.MapBack(model));
        }

        public async Task DeleteApartment(int id)
        {
            await _unitOfWork.ApartmentRepository.DeleteAsync(id);
        }


        public async Task<List<ApartmentModel>> GetAllApartments()
        {
            List<ApartmentModel> apartments = (await _unitOfWork.ApartmentRepository.GetAllAsync()).Select(_apartmentMapper.Map).ToList();

            int apartmentsLength = apartments.Count;

            ApartmentModel tempApartmentModelModel = new ApartmentModel();

            for (int i = 0; i < apartmentsLength - 1; i++)
            {
                for (int j = i + 1; j < apartmentsLength; j++)
                {
                    if (apartments[i].Id > apartments[j].Id)
                    {
                        tempApartmentModelModel = apartments[i];
                        apartments[i] = apartments[j];
                        apartments[j] = tempApartmentModelModel;
                    }

                }
            }

            //ApartmentModel minApartmentModel = new ApartmentModel();

            //for (int i = 0; i < apartmentsLength - 1; i++)
            //{
            //    minApartmentModel = apartments[i];
            //    for (int j = i + 1; j < apartmentsLength; j++)
            //    {
            //        if (minApartmentModel.Id > apartments[j].Id)
            //        {
            //            minApartmentModel = apartments[j];

            //        }

            //    }

            //    apartments[i] = minApartmentModel;
            //int dummy = list[i];
            //list[i] = list[min];
            //list[min] = dummy;
            //}


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
            return ((await _unitOfWork.ApartmentRepository.GetApartmentsByBuildingId(buildingId)).Select(_apartmentMapper.Map)).ToList();
        }

        public async Task<List<ApartmentModel>> GetApartmentsByPersonId(int personId)
        {
            return ((await _unitOfWork.ApartmentRepository.GetApartmentsByPersonId(personId)).Select(_apartmentMapper.Map)).ToList();
        }
    }
}
