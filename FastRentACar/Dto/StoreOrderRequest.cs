using System;
using System.ComponentModel.DataAnnotations;

namespace FastRentACar.Dto
{
    public class StoreOrderRequest
    {
        [Range(1, double.MaxValue, ErrorMessage = "The total amount must be greater than {1}USD")]
        public double TotalAmount { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime? EndDate { get; set; }

        public int Days => StartDate.HasValue && EndDate.HasValue ? Math.Abs((StartDate.Value - EndDate.Value).Days) : 0;

        [Required(ErrorMessage = "Branch office is required")]
        public string BranchOffice { get; set; }
    }
}
