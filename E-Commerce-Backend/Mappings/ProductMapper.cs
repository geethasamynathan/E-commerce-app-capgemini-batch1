using E_Commerce_Backend.DTO;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Mappings
{
    public static class ProductMapper
    {
        public static ProductDTO ToProductDTO(Product product)
        {
            return new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
               // Description = product.Description,
                Price = product.Price,
                Category = product.Category,
               // StockQuantity = product.StockQuantity,
                //ImageUrl = product.ImageUrl,
                //Rating = product.Rating,
                //Reviews = product.Reviews
            };
        }

        public static Product ToProduct(ProductDTO productDTO)
        {
            return new Product
            {
                ProductId = productDTO.ProductId,
                ProductName = productDTO.ProductName,
                //Description = productDTO.Description,
                //Price = productDTO.Price,
                Category = productDTO.Category,
                //StockQuantity = productDTO.StockQuantity,
                //ImageUrl = productDTO.ImageUrl,
                //Rating = productDTO.Rating,
                //Reviews = productDTO.Reviews
            };
        }
    }

}
