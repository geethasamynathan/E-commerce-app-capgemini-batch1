namespace E_Commerce_Backend.Models
{
    public class ShoppingCart
    {
        public int CartId { get; set; }

        public int UserId { get; set; }

        public int? ProductId { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime? CreatedDate { get; set; }

        public  Product? Product { get; set; }

        public  User User { get; set; } = null!;
    }
}
