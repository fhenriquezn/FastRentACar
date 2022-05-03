using FastRentACar.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FastRentACar.DataAccess.Seeds
{
    public static class BrandSeed
    {
        public static void BrandSeeds(this EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
            new Brand { Id = 1, Name = "Toyota", CreatedBy = "system", CreatedAt = DateTime.Now },
            new Brand { Id = 2, Name = "Hyundai", CreatedBy = "system", CreatedAt = DateTime.Now },
            new Brand { Id = 3, Name = "Kia", CreatedBy = "system", CreatedAt = DateTime.Now },
            new Brand { Id = 4, Name = "Acura", CreatedBy = "system", CreatedAt = DateTime.Now },
            new Brand { Id = 5, Name = "Alfa-Romeo", CreatedBy = "system", CreatedAt = DateTime.Now },
            new Brand { Id = 6, Name = "BMW", CreatedBy = "system", CreatedAt = DateTime.Now },
            new Brand { Id = 7, Name = "Dodge", CreatedBy = "system", CreatedAt = DateTime.Now },
            new Brand { Id = 8, Name = "Honda", CreatedBy = "system", CreatedAt = DateTime.Now }
            );
        }
    }
}
