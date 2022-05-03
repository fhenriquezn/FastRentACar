using System;
using System.ComponentModel.DataAnnotations;

namespace FastRentACar.Dto
{
    public class StoreOrderDetailRequest
    {
        [Range(1, double.MaxValue, ErrorMessage = "The price must be greater than {1}USD")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The item id is required")]
        public int? CarId { get; set; }
    }
}
