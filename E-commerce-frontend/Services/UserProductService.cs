using E_commerce_frontend.Models;
using System.Security.Policy;
using System.Text.Json;

namespace E_commerce_frontend.Services
{

    public class UserProductService : IUserProductService
    {

        private readonly List<UserProduct> _products = new List<UserProduct>();
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        string url = "";
        public UserProductService(HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
            url = _config["apisettings:userproducturl"];
        }
       
           public async Task<IEnumerable<UserProduct>> GetAllUserProducts()
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Throws if the status code is not 2xx

            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response into a list of UserProduct objects
            var userProducts = JsonSerializer.Deserialize<List<UserProduct>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Allows for case-insensitive property matching
            });

            return userProducts; // Return as IEnumerable<UserProduct>
        }
    }
}
