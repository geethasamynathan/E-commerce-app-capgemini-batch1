using E_commerce_frontend.Models;
using System.Text;
using System.Text.Json;

namespace E_commerce_frontend.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        string url = "";
        public ProductService(HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
            url = _config["apisettings:productUrl"];
        }
        //public async Task AddProduct(Product product)
        //{
        //    var json = JsonSerializer.Serialize(product);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await _httpClient.PostAsync("https://localhost:7168/api/Products", content);
        //    response.EnsureSuccessStatusCode();
        //    _products.Add(product);
        //}
        public async Task AddNewProduct(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content); // Using the correct URL here
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var addedProduct = JsonSerializer.Deserialize<Product>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Adding product to the list after successful API call
            _products.Add(addedProduct);
        }



        public async Task EditProduct(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{url}/{product.ProductId}", content);
            response.EnsureSuccessStatusCode();

            var existingProduct = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
            }
        }


        public async Task DeleteProduct(int productId)
        {
            var response = await _httpClient.DeleteAsync($"{url}/{productId}");
            response.EnsureSuccessStatusCode();

            var product = _products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var response =await  _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<Product>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
           
            return products;
        }

        public async Task<Product> GetProductById(int productId)
        {
            var response = await _httpClient.GetAsync($"{url}/{productId}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var product = JsonSerializer.Deserialize<Product>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return product;
        }

    }

}
