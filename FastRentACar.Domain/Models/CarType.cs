namespace FastRentACar.Domain.Models
{
    public class CarType : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
