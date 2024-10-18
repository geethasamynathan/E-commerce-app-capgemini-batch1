using E_commerce_frontend.Models;

namespace E_commerce_frontend.Services
{
    public interface IUserProductService
    {
        Task<IEnumerable<UserProduct>> GetAllUserProducts();
    }
}
