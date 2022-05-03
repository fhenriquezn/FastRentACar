namespace FastRentACar.Domain.Models
{
    public class CarModel : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        //Navigation
        public Brand Brand { get; set; }
    }
}
