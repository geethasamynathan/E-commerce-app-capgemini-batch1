using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.IService
{
    public interface IUserProductService
    {

        // Add a new product
       void AddProduct(UserProduct product);

        // Edit an existing product
        void EditProduct(UserProduct product);

        // Delete a product by ID
        void DeleteProduct(int productId);

        // Get a list of all products
        IEnumerable<UserProduct> GetAllProducts();

        // Get a product by ID
        UserProduct GetProductById(int productId);

    }
}
