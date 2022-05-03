using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FastRentACar.DataAccess.Contracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entites);

        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        Task<TEntity> Delete(params object[] keyValues);

        void DeleteBy(Expression<Func<TEntity, bool>> predicate);

        void DeleteRange(IEnumerable<TEntity> entities);

        void Edit(TEntity entity);

        IQueryable<TEntity> Include(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FindByKey(params object[] keyValues);

        Task<TEntity> FindAsync(params object[] keyValues);

        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        DbSet<TEntity> GetDbSet();

        TEntity Patch(TEntity entity, IEnumerable<string> properties);

        Task Save();

        void SetValues(TEntity entity, TEntity newValuesEntity);

        void SetValues(TEntity entity, object newValuesEntity);

    }
}
