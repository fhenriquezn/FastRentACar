using FastRentACar.Domain.Models;
using System.Text.Json.Serialization;

namespace FastRentACar.Domain.Dto.Response
{
    public class AuthenticateResponse
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Surname { get; set; }

        public string SecondSurname { get; set; }

        public string Email { get; set; }

        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public AuthenticateResponse(User user, string jwtToken, string refreshToken)
        {
            Id = user.Id;
            Username = user.Username;
            FirstName = user.FirstName;
            SecondSurname = user.SecondName;
            Surname = user.Surname;
            SecondSurname = user.SecondSurname;
            Email = user.Email;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
