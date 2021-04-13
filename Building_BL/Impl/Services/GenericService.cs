using District.Bl.Abstract.IMappers;
using District.Bl.Abstract.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Bl.Impl.Services
{
    public class GenericService<TModel> : IGenericService<TModel> where TModel : class        
    {
        public Task<TModel> CreateInstance(TModel model)
        {
            throw new NotImplementedException();
        }

        //ublic IApartmentRepository _TRepository;
        //public IBackMapper _TMapper;
        //public GenericService()
        //{

        //}
        //public Task<TModel> CreateInstance(TModel model)
        //{
        //    return _TMappper

        //}

        //public async Task<ApartmentModel> CreateApartment(ApartmentModel model)
        //{
        //    return _apartmentMapper.Map(await _apartmentRepository.AddAsync(_apartmentMapper.MapBack(model)));
        //}

        public Task DeleteInstance(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInstance(TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
