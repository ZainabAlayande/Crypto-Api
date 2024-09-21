using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/crypto")]
public class CryptoController : ControllerBase
{
    private readonly ICryptoService _cryptoService;

    public CryptoController(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCryptos() 
    {
        var response = await _cryptoService.GetAllCryptos();
        if (!response.Status) return NotFound(response);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCryptoById(string id) 
    {
        var response = await _cryptoService.GetCryptoById(id);
        if (!response.Status) return NotFound(response);
        return Ok(response);
    }

    
}

