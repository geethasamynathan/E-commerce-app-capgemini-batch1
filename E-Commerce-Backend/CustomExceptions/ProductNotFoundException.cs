namespace E_Commerce_Backend.CustomExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(int productId)
            : base($"Product with ID {productId} was not found.")
        {
        }
    }
    public class CartItemNotFoundException : Exception
    {
        public CartItemNotFoundException(int cartItemId)
            : base($"Cart item with ID {cartItemId} was not found.")
        {
        }
    }

}
