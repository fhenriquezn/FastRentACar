using FastRentACar.DataAccess.Maps.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRentACar.DataAccess.Maps
{
    public abstract class MapingConfiguration<T> : IMappingConfiguration<T> where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
    }
}
