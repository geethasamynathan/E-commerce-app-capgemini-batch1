using AutoMapper;
using E_Commerce_Backend.DTO;
using E_Commerce_Backend.IService;
using E_Commerce_Backend.Mappings;
using E_Commerce_Backend.Models;
using E_Commerce_Backend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = _productService.GetAllProducts();
            var productDtos = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productDtos);
        }


        // GET: api/Products/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDTO>(product);
            return Ok(productDto);
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<Product> PostProduct(ProductDTO productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            _productService.AddProduct(product);
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // PUT: api/Products/{id}
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, ProductDTO productDto)
        {
            if (id != productDto.ProductId)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(productDto);

            try
            {
                _productService.EditProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_productService.GetAllProducts().Any(p => p.ProductId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);
            return NoContent();
        }

    }

}
