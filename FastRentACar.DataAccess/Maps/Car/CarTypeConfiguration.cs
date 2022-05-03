using FastRentACar.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRentACar.DataAccess.Maps.Car
{
    public class CarTypeConfiguration : MapingConfiguration<Domain.Models.CarType>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.CarType> builder)
        {
            builder.ToTable(nameof(Domain.Models.CarType)).HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Description).HasColumnType("VARCHAR(250)");

            //Seeders
            builder.CarTypeSeeds();
        }
    }
}
