using System;
using System.ComponentModel.DataAnnotations;

namespace FastRentACar.Dto
{
    public class StoreCarRequest
    {
        [Range(1900, 2022, ErrorMessage = "The value for year is not correct")]
        public int Year { get; set; }

        [Required(ErrorMessage = "The number of seats is required")]
        public int? Seats { get; set; }

        [Required(ErrorMessage = "The number of doors is required")]
        public int? Doors { get; set; }

        [Required(ErrorMessage = "The model is required")]
        public int? CarModelId { get; set; }

        [Required(ErrorMessage = "The car type is required")]
        public int? CarTypeId { get; set; }
    }
}
