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

    [HttpPost]
    public ActionResult<Product> Create(Product product)
    {
        var created = _productService.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        var updated = _productService.Update(id, product);
        if (updated == null)
        {
            return NotFound();
        }

        return Ok(updated);
    }
}
