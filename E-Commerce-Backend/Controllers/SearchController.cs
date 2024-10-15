using AutoMapper;
using E_Commerce_Backend.DTO;
using E_Commerce_Backend.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        // GET: api/Products/search/name
        [HttpGet("search/name")]
        public ActionResult<IEnumerable<ProductDTO>> SearchProductByName(string name)
        {
            var products = _searchService.SearchProductByName(name);
            return Ok(products);
        }

        // GET: api/Products/search/price
        [HttpGet("search/price")]
        public ActionResult<IEnumerable<ProductDTO>> SearchProductByPrice(decimal price)
        {
            var products = _searchService.SearchProductByPrice(price);
            return Ok(products);
        }

        // GET: api/Products/search/category
        [HttpGet("search/category")]
        public ActionResult<IEnumerable<ProductDTO>> SearchProductByCategory(string category)
        {
            var products = _searchService.SearchProductByCategory(category);
            return Ok(products);
        }
    }
}
