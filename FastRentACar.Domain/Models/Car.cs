namespace FastRentACar.Domain.Models
{
    public class Car : BaseModel
    {
        public int Id { get; set; }

        public string Year { get; set; }

        public double Price { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public int CarModelId { get; set; }

        public int CarTypeId { get; set; }

        //Navigation
        public CarModel CarModel { get; set; }

        public CarType CarType { get; set; }
    }
}
