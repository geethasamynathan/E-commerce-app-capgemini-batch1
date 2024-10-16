using E_commerce_frontend.DTO;
using E_commerce_frontend.Models;

namespace E_commerce_frontend.Iservice
{
    public interface IShoppingCartHttpClientService
    {
        Task AddToCartAsync(CartItemDTO cartItemDto);
        Task UpdateCartItemAsync(CartItemUpdateDTO cartItemUpdateDto);
        Task RemoveFromCartAsync(int cartItemId);
        Task<IEnumerable<ShoppingCart>> GetCartItemsAsync(int userId);
        Task<decimal> GetCartTotalAmountAsync(int userId);
    }

}
