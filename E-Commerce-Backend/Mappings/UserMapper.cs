using E_Commerce_Backend.DTO;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Mappings
{
    public static class UserMapper
    {
        public static UserProductDTO ToUserProductDTO(UserProduct product)
        {
            return new UserProductDTO
            {
                UserProductId = product.UserProductId,
                ProductName = product.ProductName,
               // Description = product.Description,
                Price = product.Price,
                Category = product.Category,
               // StockQuantity = product.StockQuantity,
                ImageUrl = product.ImageUrl,
                //Rating = product.Rating,
                //Reviews = product.Reviews
            };
        }

        public static UserProduct ToUserProduct(UserProductDTO productDTO)
        {
            return new UserProduct
            {
                UserProductId = productDTO.UserProductId,
                ProductName = productDTO.ProductName,
                // = productDTO.Description,
                Price = productDTO.Price,
                Category = productDTO.Category,
               // StockQuantity = productDTO.StockQuantity,
                ImageUrl = productDTO.ImageUrl,
               // Rating = productDTO.Rating,
                //Reviews = productDTO.Reviews
            };
        }
    }

}

