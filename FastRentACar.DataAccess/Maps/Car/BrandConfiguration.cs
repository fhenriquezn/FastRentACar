using Microsoft.EntityFrameworkCore;
using FastRentACar.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRentACar.DataAccess.Maps.Car
{
    public class BrandConfiguration : MapingConfiguration<Domain.Models.Brand>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.Brand> builder)
        {
            builder.ToTable(nameof(Domain.Models.Brand)).HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Description).HasColumnType("VARCHAR(250)");

            //Seeders
            builder.BrandSeeds();
        }
    }
}
