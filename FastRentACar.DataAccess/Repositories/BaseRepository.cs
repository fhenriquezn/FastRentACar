using FastRentACar.DataAccess.Contracts;
using FastRentACar.Domain.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FastRentACar.DataAccess.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly DbContext context;

        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public DbSet<TEntity> GetDbSet()
        => context.Set<TEntity>();

        public IQueryable<TEntity> GetAll()
        => GetDbSet();

        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        => await GetDbSet().AnyAsync(predicate);

        public IQueryable<TEntity> Include(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = GetAll();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.Where(filter);
        }

        public async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        => await GetDbSet().FirstOrDefaultAsync(predicate);

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        => GetDbSet().Where(predicate);

        public async Task<TEntity> FindAsync(params object[] keys)
        => await GetDbSet().FindAsync(keys);

        public async Task<TEntity> FindByKey(params object[] keyValues)
        => await GetDbSet().FindAsync(keyValues);

        public virtual TEntity Add(TEntity entity)
        {
            GetDbSet().Add(entity);
            return entity;
        }

        public virtual async Task AddRange(IEnumerable<TEntity> entites)
        => await GetDbSet().AddRangeAsync(entites);

        public virtual void Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void SetValues(TEntity entity, TEntity newValuesEntity)
        => context.Entry(entity).CurrentValues.SetValues(newValuesEntity);

        public void SetValues(TEntity entity, object newValuesEntity)
        => context.Entry(entity).CurrentValues.SetValues(newValuesEntity);

        public virtual TEntity Patch(TEntity entity, IEnumerable<string> properties)
        {
            GetDbSet().Attach(entity);
            var entry = context.Entry(entity);
            foreach (var property in properties)
            {
                entry.Property(property).IsModified = true;
            }
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            GetDbSet().Attach(entity);
            GetDbSet().Remove(entity);
        }

        public async Task<TEntity> Delete(params object[] keyValues)
        {
            var entity = await FindByKey(keyValues);
            if (entity == null) return null;
            Delete(entity);
            return entity;
        }

        public void DeleteBy(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = FindBy(predicate);
            DeleteRange(entities.AsEnumerable());
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        => GetDbSet().RemoveRange(entities);

        public virtual async Task Save()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

            }

        }
    }
}
