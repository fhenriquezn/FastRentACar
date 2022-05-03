using FastRentACar.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FastRentACar.DataAccess.Seeds
{
    public static class CarTypeSeed
    {
        public static void CarTypeSeeds(this EntityTypeBuilder<CarType> builder)
        {
            builder.HasData(
            new CarType { Id = 1, Name = "Sedan", CreatedBy = "system", CreatedAt = DateTime.Now },
            new CarType { Id = 2, Name = "Hatchback", CreatedBy = "system", CreatedAt = DateTime.Now }
            );
        }
    }
}
