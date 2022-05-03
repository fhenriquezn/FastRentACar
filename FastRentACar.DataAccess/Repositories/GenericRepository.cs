using FastRentACar.DataAccess.Contracts;
using FastRentACar.DataAccess.Core;
using FastRentACar.Domain.Models.Contracts;

namespace FastRentACar.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : BaseRepository<TEntity, ApplicationDbContext>, IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        public GenericRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
