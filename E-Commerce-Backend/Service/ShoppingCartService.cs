using E_Commerce_Backend.CustomExceptions;

using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;

using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.Service
{

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly EcommerceContext _context;

        public ShoppingCartService(EcommerceContext context)
        {
            _context = context;
        }

        public async Task AddToCart(int userId, int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new ProductNotFoundException(productId);
            }

            var cartItem = await _context.ShoppingCarts
                .SingleOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

            if (cartItem == null)
            {
                cartItem = new ShoppingCart
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                };

                _context.ShoppingCarts.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
                _context.ShoppingCarts.Update(cartItem);
            }

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ShoppingCart>> GetCartItems(int userId)
        {
            return await _context.ShoppingCarts
                .Include(ci => ci.Product)
                .Where(ci => ci.UserId == userId)
                .ToListAsync();
        }
        public async Task UpdateCartItem(int cartItemId, int quantity)
        {
            var cartItem = await _context.ShoppingCarts.FindAsync(cartItemId);
            if (cartItem == null)
            {
                throw new CartItemNotFoundException(cartItemId);
            }

            cartItem.Quantity = quantity;
            _context.ShoppingCarts.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromCart(int cartItemId)
        {
            var cartItem = await _context.ShoppingCarts.FindAsync(cartItemId);
            if (cartItem == null)
            {
                throw new CartItemNotFoundException(cartItemId);
            }

            _context.ShoppingCarts.Remove(cartItem);
            await _context.SaveChangesAsync();


        }

        public async Task<decimal> GetCartTotalAmount(int userId)
        {
            var totalAmount = await _context.ShoppingCarts
                .Where(ci => ci.UserId == userId)
                .SumAsync(ci => ci.Quantity * ci.Product.Price);

            return totalAmount;
        }
    }

}

    //public class ShoppingCartService : IShoppingCartService
    //{
    //    private readonly EcommerceContext _context;

    //    public ShoppingCartService(EcommerceContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task AddToCart(int userId, int productId, int quantity)
    //    {
    //        var product = await _context.Products.FindAsync(productId);
    //        if (product == null)
    //        {
    //            throw new ProductNotFoundException(productId);
    //        }

    //        var cartItem = await _context.ShoppingCarts
    //            .SingleOrDefaultAsync(ci => ci.UserId == userId && ci.ProductId == productId);

    //        if (cartItem == null)
    //        {
    //            cartItem = new ShoppingCart
    //            {
    //                UserId = userId,
    //                ProductId = productId,
    //                Quantity = quantity
    //            };

    //            _context.ShoppingCarts.Add(cartItem);
    //        }
    //        else
    //        {
    //            cartItem.Quantity += quantity;
    //            _context.ShoppingCarts.Update(cartItem);
    //        }

    //        await _context.SaveChangesAsync();
    //    }
    //    public async Task<IEnumerable<ShoppingCart>> GetCartItems(int userId)
    //    {
    //        return await _context.ShoppingCarts
    //            .Include(ci => ci.Product)
    //            .Where(ci => ci.UserId == userId)
    //            .ToListAsync();
    //    }
    //    public async Task UpdateCartItem(int cartItemId, int quantity)
    //    {
    //        var cartItem = await _context.ShoppingCarts.FindAsync(cartItemId);
    //        if (cartItem == null)
    //        {
    //            throw new CartItemNotFoundException(cartItemId);
    //        }

    //        cartItem.Quantity = quantity;
    //        _context.ShoppingCarts.Update(cartItem);
    //        await _context.SaveChangesAsync();
    //    }

    //    public async Task RemoveFromCart(int cartItemId)
    //    {
    //        var cartItem = await _context.ShoppingCarts.FindAsync(cartItemId);
    //        if (cartItem == null)
    //        {
    //            throw new CartItemNotFoundException(cartItemId);
    //        }

    //        _context.ShoppingCarts.Remove(cartItem);
    //        await _context.SaveChangesAsync();


    //    }

    //    public async Task<decimal> GetCartTotalAmount(int userId)
    //    {
    //        var totalAmount = await _context.ShoppingCarts
    //            .Where(ci => ci.UserId == userId)
    //            .SumAsync(ci => ci.Quantity * ci.Product.Price);

    //        return totalAmount;
    //    }
    //}
}

