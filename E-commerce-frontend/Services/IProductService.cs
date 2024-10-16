using E_commerce_frontend.Models;

namespace E_commerce_frontend.Services
{
    public interface IProductService
    {
        // Add a new product
         Task AddNewProduct(Product product);

        // Edit an existing product
        Task EditProduct(Product product);

        // Delete a product by ID
        Task DeleteProduct(int productId);

        // Get a list of all products
        Task<List<Product>> GetAllProducts();

        // Get a product by ID
        Task<Product> GetProductById(int productId);
    }
}
