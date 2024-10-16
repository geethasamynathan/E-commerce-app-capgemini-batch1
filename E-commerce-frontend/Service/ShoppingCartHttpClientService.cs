using E_commerce_frontend.DTO;
using E_commerce_frontend.Iservice;
using E_commerce_frontend.Models;
using Microsoft.Extensions.Configuration;

namespace E_commerce_frontend.Service
{
    public class ShoppingCartHttpClientService : IShoppingCartHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        string url = "";

        public ShoppingCartHttpClientService(HttpClient httpClient , IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
            url = _config["apisettings:ShoppingCart"];

        }

        public async Task AddToCartAsync(CartItemDTO cartItemDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/shoppingcart/add", cartItemDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCartItemAsync(CartItemUpdateDTO cartItemUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/shoppingcart/update", cartItemUpdateDto);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveFromCartAsync(int cartItemId)
        {
            var response = await _httpClient.DeleteAsync($"api/shoppingcart/remove/{cartItemId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<ShoppingCart>> GetCartItemsAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/shoppingcart?userId={userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ShoppingCart>>();
        }

        public async Task<decimal> GetCartTotalAmountAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/shoppingcart/total?userId={userId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<decimal>();
        }
    }

}
