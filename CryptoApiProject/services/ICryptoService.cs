using System.Threading.Tasks;

namespace CryptoApiProject.Services {

    public interface ICryptoService {

        Task<string> GetAllCryptosAsync();

        Task<string> GetCryptoByIdAsync(string id);

    }
}
