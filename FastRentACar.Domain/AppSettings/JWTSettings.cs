namespace FastRentACar.Domain.AppSettings
{
    public class JWTSettings
    {
        public string Secret { get; set; }

        public double ExpiryMinutes { get; set; }
    }
}
