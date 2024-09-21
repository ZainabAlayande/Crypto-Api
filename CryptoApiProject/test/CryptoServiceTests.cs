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
       
    var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
    mockHttpMessageHandler.Protected()
        .Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
        .ReturnsAsync(new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent("{\"data\":[{\"id\":\"bitcoin\",\"rank\":\"1\",\"symbol\":\"BTC\",\"name\":\"Bitcoin\",\"supply\":\"19757015\",\"maxSupply\":\"21000000\",\"marketCapUsd\":\"1249296361387.56\",\"volumeUsd24Hr\":\"10384722868.35\",\"priceUsd\":\"63233.05\",\"changePercent24Hr\":\"0.38\",\"vwap24Hr\":\"63022.28\",\"explorer\":\"https://blockchain.info/\"}]}")
        });

    var httpClient = new HttpClient(mockHttpMessageHandler.Object);
    var cryptoService = new CryptoService(httpClient);

    var result = await cryptoService.GetAllCryptos();

    Assert.True(result.Status);
    Assert.Equal("Data fetched successfully.", result.Message);
    Assert.NotNull(result.Data);
    }


 

    [Fact]
    public async Task GetCryptoById_ReturnsNotFound()
    {
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

        var result = await cryptoService.GetCryptoById("invalid-id");

        Assert.False(result.Status);
        Assert.Equal("Crypto not found.", result.Message);
        Assert.Null(result.Data);
    }
}
