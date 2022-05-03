using FastRentACar.Domain.Models.Contracts;
using System;

namespace FastRentACar.Domain.Models
{
    public class BaseModel : IEntity
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime CreatedAt { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? ModifiedAt { get; set; }
       
        [System.Text.Json.Serialization.JsonIgnore]
        public string CreatedBy { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public string ModifiedBy { get; set; }
    }
}
