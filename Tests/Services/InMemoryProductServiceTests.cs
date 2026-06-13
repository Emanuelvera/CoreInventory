using CoreInventory.Models;
using CoreInventory.Services;
using Xunit;

namespace CoreInventory.Tests.Services;

public class InMemoryProductServiceTests
{
    private readonly InMemoryProductService _service;

    public InMemoryProductServiceTests()
    {
        _service = new InMemoryProductService();
    }

    [Fact]
    public void GetAll_ReturnsThreeProducts()
    {
        var result = _service.GetAll();

        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void GetAll_FirstProduct_IsMouse()
    {
        var result = _service.GetAll();

        var first = result[0];
        Assert.Equal(1, first.Id);
        Assert.Equal("Mouse", first.Name);
        Assert.Equal("M001", first.Code);
        Assert.Equal(10, first.Stock);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsProduct()
    {
        var result = _service.GetById(2);

        Assert.NotNull(result);
        Assert.Equal("Teclado", result.Name);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        var result = _service.GetById(99);

        Assert.Null(result);
    }
}
