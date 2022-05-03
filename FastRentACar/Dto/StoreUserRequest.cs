using System.ComponentModel.DataAnnotations;

namespace FastRentACar.Dto
{
    public class StoreUserRequest : UserRequest
    {
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
