using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Service
{
    public class UserProductService:IUserProductService
    {

        private readonly EcommerceContext _context;

        public UserProductService(EcommerceContext context)
        {
            _context = context;
        }

        public void AddProduct(UserProduct products)
        {
            _context.UserProducts.Add(products);
            _context.SaveChanges();
        }

        public void EditProduct(UserProduct product)
        {
            _context.UserProducts.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        //public IEnumerable<UserProduct> GetAllProducts()
        //{
        //    return _context.UserProducts.ToList();
        //}
        public IEnumerable<UserProduct> GetAllProducts()
        {
         
            var products = from product in _context.UserProducts
                           select product;

            return products.ToList();
        }


        public UserProduct GetProductById(int productId)
        {
            return _context.UserProducts.Find(productId);
        }
    }

}
