using Microsoft.AspNetCore.Mvc;
using CoreInventory.Controllers;
using Xunit;

namespace CoreInventory.Tests.Controllers;

public class StatusControllerTests
{
    private readonly StatusController _controller;

    public StatusControllerTests()
    {
        _controller = new StatusController();
    }

    [Fact]
    public void Ping_ReturnsOkResult()
    {
        var result = _controller.Ping();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Ping_ReturnsPongString()
    {
        var result = _controller.Ping();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("pong", okResult.Value);
    }
}
