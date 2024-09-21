public class CryptoService : ICryptoService
{
    private readonly HttpClient _httpClient;

    public CryptoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    
    public async Task<ApiResponse<List<CryptoResponseDto>>> GetAllCryptos() 
    {
        var apiUrl = "https://api.coincap.io/v2/assets";
        var response = await _httpClient.GetAsync(apiUrl);

        if (!response.IsSuccessStatusCode) return new ApiResponse<List<CryptoResponseDto>>(false, Constant.CryptoNotFoundMessage, null);
        
        var jsonData = await response.Content.ReadAsStringAsync();
        var cryptoList = CryptoMapper.MapToCryptoList(jsonData);
        return new ApiResponse<List<CryptoResponseDto>>(true, Constant.DataFetchedMessage, cryptoList);
    }

    
    public async Task<ApiResponse<CryptoResponseDto>> GetCryptoById(string id)
    {
        var apiUrl = $"https://api.coincap.io/v2/assets/{id}";
        var response = await _httpClient.GetAsync(apiUrl);

        if (!response.IsSuccessStatusCode) return new ApiResponse<CryptoResponseDto>(false, Constant.CryptoNotFoundMessage, null);

        var jsonData = await response.Content.ReadAsStringAsync();
        var cryptoDto = CryptoMapper.MapToCryptoResponseDto(jsonData);
        return new ApiResponse<CryptoResponseDto>(true, Constant.DataFetchedMessage, cryptoDto);
    }
}
