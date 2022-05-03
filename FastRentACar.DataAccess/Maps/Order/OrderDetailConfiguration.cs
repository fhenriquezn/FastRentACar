using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRentACar.DataAccess.Maps.Order
{
    public class OrderDetailConfiguration : MapingConfiguration<Domain.Models.OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.OrderDetail> builder)
        {
            builder.ToTable(nameof(Domain.Models.OrderDetail)).HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Price).IsRequired().HasColumnType("DECIMAL(18,2)").HasDefaultValue(0);
            builder.Property(p=> p.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Car).WithMany().HasForeignKey(x => x.CarId);
        }
    }
}
