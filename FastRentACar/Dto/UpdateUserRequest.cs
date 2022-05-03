using System.ComponentModel.DataAnnotations;

namespace FastRentACar.Dto
{
    public class UpdateUserRequest
    {
        [MaxLength(25, ErrorMessage = "The first name must be a maximum of {1} characters")]
        public string FirstName { get; set; }

        [MaxLength(25, ErrorMessage = "The second name must be a maximum of {1} characters")]
        public string SecondName { get; set; }

        [MaxLength(25, ErrorMessage = "The surname must be a maximum of {1} characters")]
        public string Surname { get; set; }

        [MaxLength(25, ErrorMessage = "The second surname must be a maximum of {1} characters")]
        public string SecondSurname { get; set; }

        [MaxLength(255, ErrorMessage = "The email must be a maximum of {1} characters")]
        [EmailAddress(ErrorMessage = "The email format is invalid")]
        public string Email { get; set; }

        public bool? Is2FAEnabled { get; set; }
    }
}
