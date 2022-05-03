using FastRentACar.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRentACar.DataAccess.Maps.Car
{
    public class CarModelConfiguration : MapingConfiguration<Domain.Models.CarModel>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.CarModel> builder)
        {
            builder.ToTable(nameof(Domain.Models.CarModel)).HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property(p => p.Description).HasColumnType("VARCHAR(250)");
            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.BrandId).OnDelete(DeleteBehavior.NoAction);

            //Seeders
            builder.CarModelSeeds();
        }
    }
}
