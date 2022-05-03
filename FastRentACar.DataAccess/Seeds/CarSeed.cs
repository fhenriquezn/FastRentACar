using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FastRentACar.DataAccess.Seeds
{
    public static class CarSeed
    {
        public static void CarSeeds(this EntityTypeBuilder<Domain.Models.Car> builder)
        {
            builder.HasData(
                new Domain.Models.Car { Id = 1, CarModelId = 2, CarTypeId = 1, Doors = 4, Seats = 5, Price = 15000.00, Year = "2019", CreatedAt = DateTime.Now }
            );
        }
    }
}
