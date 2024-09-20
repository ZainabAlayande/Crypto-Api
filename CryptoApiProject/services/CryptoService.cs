using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoApiProject.Services
{
    public class CryptoService : ICryptoService {
        
        private readonly HttpClient _httpClient;

        public CryptoService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<string> GetAllCryptosAsync() {
            var apiUrl = "https://api.coincap.io/v2/assets";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode) {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> GetCryptoByIdAsync(string id) {
            var apiUrl = $"https://api.coincap.io/v2/assets/{id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode) {
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
