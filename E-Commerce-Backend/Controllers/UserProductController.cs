using AutoMapper;
using E_Commerce_Backend.DTO;
using E_Commerce_Backend.IService;
using E_Commerce_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
            private readonly IUserProductService _productService;
            private readonly IMapper _mapper;
            public UserProductController(IUserProductService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }

            // GET: api/Products
            [HttpGet]
            public ActionResult<IEnumerable<UserProductDTO>> GetProducts()
            {
                var products = _productService.GetAllProducts();
                var productDtos = _mapper.Map<IEnumerable<UserProductDTO>>(products);
                return Ok(productDtos);
            }


            //// GET: api/Products/{id}
            //[HttpGet("{id}")]
            //public ActionResult<UserProductDTO> GetProduct(int id)
            //{
            //    var product = _productService.GetProductById(id);

            //    if (product == null)
            //    {
            //        return NotFound();
            //    }

            //    var productDto = _mapper.Map<UserProductDTO>(product);
            //    return Ok(productDto);
            //}

            //// POST: api/Products
            //[HttpPost]
            //public ActionResult<UserProduct> PostProduct(UserProductDTO productDto)
            //{
            //    UserProduct product = _mapper.Map<UserProduct>(productDto);
            //    _productService.AddProduct(product);
            //    return CreatedAtAction("GetProduct", new { id = product.UserProductId }, product);
            //}

            //// PUT: api/Products/{id}
            //[HttpPut("{id}")]
            //public IActionResult PutProduct(int id, ProductDTO productDto)
            //{
            //    if (id != productDto.ProductId)
            //    {
            //        return BadRequest();
            //    }

            //    var product = _mapper.Map<UserProduct>(productDto);

            //    try
            //    {
            //        _productService.EditProduct(product);
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!_productService.GetAllProducts().Any(p => p.UserProductId == id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return NoContent();
            //}

            //// DELETE: api/Products/{id}
            //[HttpDelete("{id}")]
            //public IActionResult DeleteProduct(int id)
            //{
            //    var product = _productService.GetProductById(id);

            //    if (product == null)
            //    {
            //        return NotFound();
            //    }

            //    _productService.DeleteProduct(id);
            //    return NoContent();
            //}

        }
}
