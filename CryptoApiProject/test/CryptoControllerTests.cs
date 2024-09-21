using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CryptoControllerTests
{
    [Fact]
    public async Task GetAllCryptos_ReturnsOkResult_WithApiResponse()
    {
        var mockCryptoService = new Mock<ICryptoService>();
        var mockResponse = new ApiResponse<List<CryptoResponseDto>>(true, "Data fetched successfully.", 
            new List<CryptoResponseDto>
            {
                new CryptoResponseDto { Id = "bitcoin", Name = "Bitcoin", PriceUsd = "50000" }
            });
        
        mockCryptoService.Setup(service => service.GetAllCryptos()).ReturnsAsync(mockResponse);
        var controller = new CryptoController(mockCryptoService.Object);

        var result = await controller.GetAllCryptos();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ApiResponse<List<CryptoResponseDto>>>(okResult.Value); 
        Assert.True(response.Status);
        Assert.Equal("Data fetched successfully.", response.Message);
        Assert.NotNull(response.Data);
        Assert.Equal("bitcoin", response.Data[0].Id);
    }

    [Fact]
    public async Task GetCryptoById_ReturnsOkResult_WithApiResponse()
    {
        var mockCryptoService = new Mock<ICryptoService>();   
        var mockResponse = new ApiResponse<CryptoResponseDto>(
            true, 
            "Data fetched successfully.", 
            new CryptoResponseDto { Id = "bitcoin", Name = "Bitcoin", PriceUsd = "50000" });
        
        mockCryptoService
            .Setup(service => service.GetCryptoById("bitcoin"))
            .ReturnsAsync(mockResponse);

        var controller = new CryptoController(mockCryptoService.Object);

        var result = await controller.GetCryptoById("bitcoin");

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<ApiResponse<CryptoResponseDto>>(okResult.Value); 
        Assert.True(response.Status);
        Assert.Equal("Data fetched successfully.", response.Message);
        Assert.NotNull(response.Data);
        Assert.Equal("bitcoin", response.Data.Id);
    }
}
