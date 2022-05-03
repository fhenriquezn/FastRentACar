namespace FastRentACar.Domain.Models
{
    public class OrderDetail : BaseModel
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int CarId { get; set; }

        public int OrderId { get; set; }

        //Navigation
        public Car Car { get; set; }

        public Order Order { get; set; }
    }
}
