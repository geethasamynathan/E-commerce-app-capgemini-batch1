using AutoMapper;
using E_Commerce_Backend.DTO;
using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;

namespace E_Commerce_Backend.Service
{
    public class SearchService : ISearchService
    {
        private readonly EcommerceContext _context;
        private readonly IMapper _mapper;

        public SearchService(EcommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProductDTO> SearchProductByName(string name)
        {
            var products = _context.Products
                .Where(p => p.ProductName.Contains(name))
                .ToList();
            _context.SaveChanges();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public List<ProductDTO> SearchProductByPrice(decimal price)
        {
            var products = _context.Products
                .Where(p => p.Price <= price)
                .ToList();
            _context.SaveChanges();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public List<ProductDTO> SearchProductByCategory(string category)
        {
            var products = _context.Products
                .Where(p => p.Category == category)
                .ToList();
            _context.SaveChanges();
            return _mapper.Map<List<ProductDTO>>(products);
        }
    }


}
