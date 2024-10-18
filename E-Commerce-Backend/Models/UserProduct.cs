using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Backend.Models
{
    public class UserProduct
    {
        [Key]
        public int UserProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        //public string? Description { get; set; } // Ensure this property exists
        //public decimal Rating { get; set; } // Ensure this property exists
        //public int Reviews { get; set; } // Ensure this property exists
        //public int StockQuantity { get; set; } // Ensure this property exists
                                               
    }
    }
