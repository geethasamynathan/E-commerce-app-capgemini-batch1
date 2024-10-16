using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace E_commerce_frontend.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

       // public string? Description { get; set; }

        public decimal Price { get; set; }

       public string? Category { get; set; }

      //  public int? StockQuantity { get; set; }

        //public string? ImageUrl { get; set; }

        //public decimal? Rating { get; set; }

        //public string? Reviews { get; set; }
       
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
    }
}
