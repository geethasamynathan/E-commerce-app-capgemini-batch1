using E_commerce_frontend.Models;
using E_commerce_frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_frontend.Controllers
{
    
    public class UserProductController : Controller
    {
        private readonly IUserProductService _userProductService;

        public UserProductController(IUserProductService userProductService)
        {
            _userProductService = userProductService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserProduct> products = await _userProductService.GetAllUserProducts(); // Await the asynchronous method
            return View(products); // Pass the products to the view
        }
    }

}
