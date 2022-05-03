using FastRentACar.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FastRentACar.DataAccess.Seeds
{
    public static class CarModelSeed
    {
        public static void CarModelSeeds(this EntityTypeBuilder<CarModel> builder)
        {
            builder.HasData(
            new CarModel { Id = 1, Name = "Fortuner", CreatedBy = "system", BrandId = 1, CreatedAt = DateTime.Now },
            new CarModel { Id = 2, Name = "Corolla", CreatedBy = "system", BrandId = 1, CreatedAt = DateTime.Now },
            new CarModel { Id = 3, Name = "Yaris", CreatedBy = "system", BrandId = 1, CreatedAt = DateTime.Now },
            new CarModel { Id = 4, Name = "Camry", CreatedBy = "system", BrandId = 1, CreatedAt = DateTime.Now },

            new CarModel { Id = 5, Name = "I20", CreatedBy = "system", BrandId = 2, CreatedAt = DateTime.Now },
            new CarModel { Id = 6, Name = "Creta", CreatedBy = "system", BrandId = 2, CreatedAt = DateTime.Now },
            new CarModel { Id = 7, Name = "Grand i10", CreatedBy = "system", BrandId = 2, CreatedAt = DateTime.Now },
            new CarModel { Id = 8, Name = "Verna", CreatedBy = "system", BrandId = 2, CreatedAt = DateTime.Now },

            new CarModel { Id = 9, Name = "Forte", CreatedBy = "system", BrandId = 3, CreatedAt = DateTime.Now },
            new CarModel { Id = 10, Name = "Optima", CreatedBy = "system", BrandId = 3, CreatedAt = DateTime.Now },
            new CarModel { Id = 11, Name = "Rio", CreatedBy = "system", BrandId = 3, CreatedAt = DateTime.Now },
            new CarModel { Id = 12, Name = "Sedona", CreatedBy = "system", BrandId = 3, CreatedAt = DateTime.Now },

            new CarModel { Id = 13, Name = "RL", CreatedBy = "system", BrandId = 4, CreatedAt = DateTime.Now },
            new CarModel { Id = 14, Name = "TL", CreatedBy = "system", BrandId = 4, CreatedAt = DateTime.Now },
            new CarModel { Id = 15, Name = "Vigor", CreatedBy = "system", BrandId = 4, CreatedAt = DateTime.Now },
            new CarModel { Id = 16, Name = "Integra", CreatedBy = "system", BrandId = 4, CreatedAt = DateTime.Now },

            new CarModel { Id = 17, Name = "Giulia", CreatedBy = "system", BrandId = 5, CreatedAt = DateTime.Now },
            new CarModel { Id = 18, Name = "Spider", CreatedBy = "system", BrandId = 5, CreatedAt = DateTime.Now },
            new CarModel { Id = 19, Name = "Stelvio", CreatedBy = "system", BrandId = 5, CreatedAt = DateTime.Now },
            new CarModel { Id = 20, Name = "Giuliva Quadrifoglio", CreatedBy = "system", BrandId = 5, CreatedAt = DateTime.Now },

            new CarModel { Id = 21, Name = "X4", CreatedBy = "system", BrandId = 6, CreatedAt = DateTime.Now },
            new CarModel { Id = 22, Name = "X1", CreatedBy = "system", BrandId = 6, CreatedAt = DateTime.Now },
            new CarModel { Id = 23, Name = "X6", CreatedBy = "system", BrandId = 6, CreatedAt = DateTime.Now },
            new CarModel { Id = 24, Name = "X7", CreatedBy = "system", BrandId = 6, CreatedAt = DateTime.Now },

            new CarModel { Id = 25, Name = "Daytona", CreatedBy = "system", BrandId = 7, CreatedAt = DateTime.Now },
            new CarModel { Id = 26, Name = "Deluxe", CreatedBy = "system", BrandId = 7, CreatedAt = DateTime.Now },
            new CarModel { Id = 27, Name = "Viper", CreatedBy = "system", BrandId = 7, CreatedAt = DateTime.Now },
            new CarModel { Id = 28, Name = "Raider", CreatedBy = "system", BrandId = 7, CreatedAt = DateTime.Now },

            new CarModel { Id = 29, Name = "Amaze", CreatedBy = "system", BrandId = 8, CreatedAt = DateTime.Now },
            new CarModel { Id = 30, Name = "civic", CreatedBy = "system", BrandId = 8, CreatedAt = DateTime.Now },
            new CarModel { Id = 31, Name = "CR-V", CreatedBy = "system", BrandId = 8, CreatedAt = DateTime.Now },
            new CarModel { Id = 32, Name = "Jazz", CreatedBy = "system", BrandId = 8, CreatedAt = DateTime.Now }
            );
        }
    }
}
