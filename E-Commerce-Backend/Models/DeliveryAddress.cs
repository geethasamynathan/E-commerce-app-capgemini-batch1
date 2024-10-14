namespace E_Commerce_Backend.Models
{
    public class DeliveryAddress
    {
        public int AddressId { get; set; }

        public int UserId { get; set; }

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public string ZipCode { get; set; } = null!;

        public string Country { get; set; } = null!;

        public  User User { get; set; } = null!;
    }
}
