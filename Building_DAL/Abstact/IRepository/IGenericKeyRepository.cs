using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace District.Dal.Abstract.IRepository
{
    public interface IGenericKeyRepository <Tkey,TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Tkey entity);
        Task<TEntity> GetByIdAsync(Tkey key);
        Task<List<TEntity>> GetAllAsync();
        //Task<int> GetCountAsync();
    }
}
