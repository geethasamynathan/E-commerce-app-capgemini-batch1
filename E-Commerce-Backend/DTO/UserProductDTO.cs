namespace E_Commerce_Backend.DTO
{
    public class UserProductDTO
    {
        public int UserProductId { get; set; }
        public string ProductName { get; set; } = null!;

       // public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Category { get; set; }
        public string? ImageUrl { get; set; }

        //public decimal? Rating { get; set; }

        //public string? Reviews { get; set; }
        //public int? StockQuantity { get; set; }

    }
}
