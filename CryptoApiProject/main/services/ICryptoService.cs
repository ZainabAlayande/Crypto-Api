using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICryptoService
{
    
    Task<ApiResponse<List<CryptoResponseDto>>> GetAllCryptos();

    
    Task<ApiResponse<CryptoResponseDto>> GetCryptoById(string id);
    
}

