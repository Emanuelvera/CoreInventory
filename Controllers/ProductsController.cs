using Microsoft.AspNetCore.Mvc;
using CoreInventory.Models;
using CoreInventory.Services;

namespace CoreInventory.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly InMemoryProductService _productService;

    public ProductsController(InMemoryProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _productService.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _productService.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        _productService.Delete(product);
        return NoContent();
    }
}
