namespace E_commerce_frontend.Models
{
    public class UserProduct
    {
      
        public int UserProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
