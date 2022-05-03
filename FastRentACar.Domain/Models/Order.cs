using System;
using System.Collections.Generic;

namespace FastRentACar.Domain.Models
{
    public class Order : BaseModel
    {
        public int Id { get; set; }

        public double TotalAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Days { get; set; }

        public string BranchOffice { get; set; }

        //Navigation
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
