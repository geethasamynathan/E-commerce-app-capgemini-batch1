using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.IService
{
    public interface IProductService
    {
        // Add a new product
        void AddProduct(Product product);

        // Edit an existing product
        void EditProduct(Product product);

        // Delete a product by ID
        void DeleteProduct(int productId);

        // Get a list of all products
        IEnumerable<Product> GetAllProducts();

        // Get a product by ID
        Product GetProductById(int productId);
    }

}
