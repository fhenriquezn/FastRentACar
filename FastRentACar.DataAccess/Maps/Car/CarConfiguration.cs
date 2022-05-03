using FastRentACar.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRentACar.DataAccess.Maps.Car
{
    public class CarConfiguration : MapingConfiguration<Domain.Models.Car>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.Car> builder)
        {
            builder.ToTable(nameof(Domain.Models.Car)).HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Year).IsRequired().HasMaxLength(4);
            builder.Property(p => p.Price).IsRequired().HasColumnType("DECIMAL(18,2)").HasDefaultValue(0);
            builder.Property(p => p.Seats).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Doors).IsRequired().HasDefaultValue(0);
            builder.HasOne(p => p.CarModel).WithMany().HasForeignKey(p => p.CarModelId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.CarType).WithMany().HasForeignKey(p => p.CarTypeId).OnDelete(DeleteBehavior.NoAction);

            //Seeders
            builder.CarSeeds();
        }
    }
}
