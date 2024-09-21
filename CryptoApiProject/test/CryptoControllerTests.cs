// using Moq;
// using Xunit;
// using Microsoft.AspNetCore.Mvc;

// public class CryptoControllerTests
// {
//     [Fact]
//     public async Task GetAllCryptos_ReturnsOkResult_WithApiResponse()
//     {
//         // Arrange
//         var mockCryptoService = new Mock<ICryptoService>();
//         mockCryptoService
//             .Setup(service => service.GetAllCryptos())
//             .ReturnsAsync(new ApiResponse<string>(true, "Data fetched successfully.", "cryptoData"));

//         var controller = new CryptoController(mockCryptoService.Object);

//         // Act
//         var result = await controller.GetAllCryptos();

//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result);
//         var response = Assert.IsType<dynamic>(okResult.Value); // To handle the anonymous type
//         Assert.Equal("success", (string)response.status);
//         Assert.Equal("Cryptos retrieved successfully.", (string)response.message);
//         Assert.Equal("cryptoData", (string)response.data.Data); // Since `data` contains the ApiResponse's data field
//     }

//     [Fact]
//     public async Task GetCryptoById_ReturnsOkResult_WithApiResponse()
//     {
//         // Arrange
//         var mockCryptoService = new Mock<ICryptoService>();
//         mockCryptoService
//             .Setup(service => service.GetCryptoById("bitcoin"))
//             .ReturnsAsync(new ApiResponse<string>(true, "Data fetched successfully.", "bitcoinData"));

//         var controller = new CryptoController(mockCryptoService.Object);

//         // Act
//         var result = await controller.GetCryptoById("bitcoin");

//         // Assert
//         var okResult = Assert.IsType<OkObjectResult>(result);
//         var response = Assert.IsType<dynamic>(okResult.Value); // Handle anonymous type
//         Assert.Equal("success", (string)response.status);
//         Assert.Equal("Crypto retrieved successfully.", (string)response.message);
//         Assert.Equal("bitcoinData", (string)response.data.Data); // Accessing the data within ApiResponse
//     }
// }

