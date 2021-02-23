using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace District.Bl.Abstract.IServices
{
    public interface IGenericService<TModel>
    {
        Task<TModel> CreateInstance(TModel model);
        Task<TModel> GetByIdAsync(int id);
        Task UpdateInstance(TModel model);
        Task DeleteInstance(int id);
    }
}
