using Microsoft.EntityFrameworkCore;

namespace FastRentACar.DataAccess.Maps.Contracts
{
    public interface IMappingConfiguration<T> : IEntityTypeConfiguration<T> where T : class { }
}
