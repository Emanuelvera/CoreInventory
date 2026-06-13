using Microsoft.AspNetCore.Mvc;
using CoreInventory.Controllers;
using CoreInventory.Models;
using CoreInventory.Services;
using Xunit;

namespace CoreInventory.Tests.Controllers;

public class ProductsControllerTests
{
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        var service = new InMemoryProductService();
        _controller = new ProductsController(service);
    }

    [Fact]
    public void GetAll_ReturnsOkResult()
    {
        var result = _controller.GetAll();

        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetAll_ReturnsThreeProducts()
    {
        var result = _controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var products = Assert.IsType<List<Product>>(okResult.Value);
        Assert.Equal(3, products.Count);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsOk()
    {
        var result = _controller.GetById(1);

        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsCorrectProduct()
    {
        var result = _controller.GetById(1);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var product = Assert.IsType<Product>(okResult.Value);
        Assert.Equal("Mouse", product.Name);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNotFound()
    {
        var result = _controller.GetById(99);

        Assert.IsType<NotFoundResult>(result.Result);
    }
}
