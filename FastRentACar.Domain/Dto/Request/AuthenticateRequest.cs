using System.ComponentModel.DataAnnotations;

namespace FastRentACar.Domain.Dto.Request
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
