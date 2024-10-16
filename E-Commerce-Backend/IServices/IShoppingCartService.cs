//using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.IServices
{
    public interface IShoppingCartService
    {
        
            Task AddToCart(int userId, int productId, int quantity);
            Task UpdateCartItem(int cartItemId, int quantity);
            Task RemoveFromCart(int cartItemId);
          //  Task<IEnumerable<ShoppingCart>> GetCartItems(int userId);
            Task<decimal> GetCartTotalAmount(int userId);
        

    }
}
