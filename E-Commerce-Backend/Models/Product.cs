using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace E_Commerce_Backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Category { get; set; }

        public int? StockQuantity { get; set; }

        public string? ImageUrl { get; set; }

        public decimal? Rating { get; set; }

        public string? Reviews { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Review> ReviewsNavigation { get; set; } = new List<Review>();

        public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
    }

}
