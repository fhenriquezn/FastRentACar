using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FastRentACar.Domain.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }

        public string SecondName { get; set; }
        public string Surname { get; set; }

        public string SecondSurname { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }

        public bool Is2FAEnabled { get; set; }
    }
}
