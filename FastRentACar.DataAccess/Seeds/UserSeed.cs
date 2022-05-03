using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FastRentACar.DataAccess.Seeds
{
    public static class UserSeed
    {
        public static void UserSeeds(this EntityTypeBuilder<Domain.Models.User> builder)
        {
            builder.HasData(
                new Domain.Models.User { 
                    Id = 1, Username = "admin", 
                    FirstName = "Admin", 
                    Email = "admin@admin.com",
                    Password = "VPHsJPhGwlWKj/JjQl2nez/UAgRknL/X0Fo1E5Ba5GuU+PKu/H4h19ZXRpygNm9vIOvgNQVhqTdMxwoC2aVva9ot1SJTaV1qbl9F3nRne23NzLDjnYCNVuB7iZ3Q2qvMmEDskXDmmmV0tLlX+y8Xy/aEEhBJa1ZNbYrfKZ2b2TI=",
                    Is2FAEnabled = true,
                    CreatedBy = "system",
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}
