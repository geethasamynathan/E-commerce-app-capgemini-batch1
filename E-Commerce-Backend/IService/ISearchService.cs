using E_Commerce_Backend.DTO;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.IService
{
    public interface ISearchService
    {
         
        List<ProductDTO> SearchProductByName(string name);
        List<ProductDTO> SearchProductByPrice(decimal price);

        List<ProductDTO> SearchProductByCategory(string category);
    }


}
