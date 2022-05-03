using FastRentACar.Domain.Models.Contracts;

namespace FastRentACar.DataAccess.Contracts
{
    public interface IGenericRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
    }
}
