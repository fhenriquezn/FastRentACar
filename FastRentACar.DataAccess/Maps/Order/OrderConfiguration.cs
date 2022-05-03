using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRentACar.DataAccess.Maps.Order
{
    public class OrderConfiguration : MapingConfiguration<Domain.Models.Order>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.Order> builder)
        {
            builder.ToTable(nameof(Domain.Models.Order)).HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.TotalAmount).IsRequired().HasColumnType("DECIMAL(18,2)").HasDefaultValue(0.00);
            builder.Property(p => p.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.EndDate).IsRequired();
            builder.Property(p => p.Days).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.BranchOffice).IsRequired();
            builder.HasMany(p => p.OrderDetails).WithOne(p => p.Order);
        }
    }
}
