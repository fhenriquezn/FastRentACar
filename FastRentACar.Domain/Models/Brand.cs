namespace FastRentACar.Domain.Models
{
    public class Brand : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
