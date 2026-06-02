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
}
