using System.ComponentModel.DataAnnotations;

namespace FastRentACar.Dto
{
    public class UpdateCarRequest
    {
        [Range(1900, 2022, ErrorMessage = "The value for year is not correct")]
        public int Year { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public int CarModelId { get; set; }

        public int CarTypeId { get; set; }
    }
}
