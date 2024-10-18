using E_commerce_frontend.Models;
using E_commerce_frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_frontend.Controllers
{
        public class ProductController : Controller
        {
            private readonly IProductService _productService;

            public ProductController(IProductService productService)
            {
                _productService = productService;
            }

            // GET: Products
            public async Task<IActionResult> Index()
            {
                var products = await _productService.GetAllProducts();
                return View(products);
            }

            // GET: Products/Details/{id}
            public async Task<IActionResult> Details(int id)
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

            // GET: Products/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Products/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Product product)
            {
                if (ModelState.IsValid)
                {
                    await _productService.AddNewProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }

            // GET: Products/Edit/{id}
            public async Task<IActionResult> Edit(int id)
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

            // POST: Products/Edit/{id}
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Product product)
            {
                if (id != product.ProductId)
                {
                    return BadRequest();
                }

                if (ModelState.IsValid)
                {
                    await _productService.EditProduct(product);
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            }

            // GET: Products/Delete/{id}
            public async Task<IActionResult> Delete(int id)
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }

            // POST: Products/Delete/{id}
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                try
                {
                    await _productService.DeleteProduct(id);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log error, display message)
                    ModelState.AddModelError("", "Unable to delete product. It may be referenced by other entities.");
                    return View();
                }
            }
        }
    }

    //public class ProductController : Controller
    //{
    //    private readonly IProductService _productService;

    //    public ProductController(IProductService productService)
    //    {
    //        _productService = productService;
    //    }

    //    // GET: Products
    //    public async Task<IActionResult> Index()
    //    {
    //        var products = await _productService.GetAllProducts();
    //        return View(products);
    //    }

    //    // GET: Products/Details/{id}
    //    public async Task<IActionResult> Details(int id)
    //    {
    //        var product = await _productService.GetProductById(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(product);
    //    }

    //    // GET: Products/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Products/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(Product product)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            await _productService.AddNewProduct(product);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(product);
    //    }


    //    // GET: Products/Edit/{id}
    //    public IActionResult Edit(int id)
    //    {
    //        var product = _productService.GetProductById(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(product);
    //    }

    //    // POST: Products/Edit/{id}
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, Product product)
    //    {
    //        if (id != product.ProductId)
    //        {
    //            return BadRequest();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //           await _productService.EditProduct(product);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(product);
    //    }

    //    // GET: Products/Delete/{id}
    //    public IActionResult Delete(int id)
    //    {
    //        var product = _productService.GetProductById(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(product);
    //    }

    //    // POST: Products/Delete/{id}
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        await _productService.DeleteProduct(id);
    //        return RedirectToAction(nameof(Index));
    //    }
    //}

