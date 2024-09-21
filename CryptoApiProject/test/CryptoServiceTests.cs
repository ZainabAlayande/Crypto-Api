using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


public class CryptoServiceTests
{
    [Fact]
    public async Task GetAllCryptosAsync_ReturnsSuccessResponse()
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("mockedCryptoData")
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var cryptoService = new CryptoService(httpClient);

        // Act
        var result = await cryptoService.GetAllCryptos();

        // Assert
        Assert.True(result.Status);
        Assert.Equal("Data fetched successfully.", result.Message);
    }


 

    [Fact]
    public async Task GetCryptoByIdAsync_ReturnsNotFound()
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object);
        var cryptoService = new CryptoService(httpClient);

        // Act
        var result = await cryptoService.GetCryptoById("invalid-id");

        // Assert
        Assert.False(result.Status);
        Assert.Equal("Crypto not found.", result.Message);
        Assert.Null(result.Data);
    }
}
