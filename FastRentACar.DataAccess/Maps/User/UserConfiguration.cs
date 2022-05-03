using FastRentACar.DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastRentACar.DataAccess.Maps.User
{
    public class UserConfiguration : MapingConfiguration<Domain.Models.User>
    {
        public override void Configure(EntityTypeBuilder<Domain.Models.User> builder)
        {
            builder.ToTable(nameof(Domain.Models.User)).HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.Property(p => p.FirstName).HasMaxLength(25);
            builder.Property(p => p.SecondName).HasMaxLength(25);
            builder.Property(p => p.Surname).HasMaxLength(25);
            builder.Property(p => p.SecondSurname).HasMaxLength(25);
            builder.Property(p => p.Username).IsRequired().HasMaxLength(25);
            builder.Property(p => p.ModifiedAt).ValueGeneratedOnUpdate();
            builder.Property(p => p.Password).IsRequired().HasColumnType("VARCHAR(255)");
            builder.Property(p => p.CreatedAt).IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.Is2FAEnabled).IsRequired().HasDefaultValue(0).HasColumnType("BIT");
            
            //Index
            builder.HasIndex(p=> p.Email);
            builder.HasIndex(p => p.Username).IsUnique();

            //Seeders
            builder.UserSeeds();
        }
    }
}
