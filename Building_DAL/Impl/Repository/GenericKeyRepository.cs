using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using District.Dal.Abstract.IRepository;
using District.Dal;

namespace District.Dal.Impl.Repository
{
    public abstract class GenericKeyRepository<TKey, TEntity> : IGenericKeyRepository<TKey, TEntity> where TEntity : class
    {
        public DistrictDbContext Context; //TODO??? context
        public DbSet<TEntity> DbSet => Context.Set<TEntity>();

        public GenericKeyRepository(DistrictDbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> item = await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return item.Entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            TEntity item = await DbSet.FindAsync(id);
             DbSet.Remove(item);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey key)
        {
            TEntity item = await DbSet.FindAsync(key);
            return item;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            List<TEntity> item = await DbSet.ToListAsync();
            return item;
        }

        public virtual async Task<int> GetCountAsync()
        {
            int item = await DbSet.CountAsync();
            return item;
        }

    }
}
