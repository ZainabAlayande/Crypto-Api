using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public static class CryptoMapper
{
    public static CryptoResponseDto MapToCryptoResponseDto(string jsonData)
    {
        var jsonObject = JObject.Parse(jsonData);
        var data = jsonObject["data"];
        
        return new CryptoResponseDto
        {
            Id = data["id"]?.ToString(),
            Rank = data["rank"]?.ToString(),
            Symbol = data["symbol"]?.ToString(),
            Name = data["name"]?.ToString(),
            Supply = decimal.TryParse(data["supply"]?.ToString(), out var supply) ? supply : 0,
            MaxSupply = decimal.TryParse(data["maxSupply"]?.ToString(), out var maxSupply) ? maxSupply : (decimal?)null,
            MarketCapUsd = decimal.TryParse(data["marketCapUsd"]?.ToString(), out var marketCapUsd) ? marketCapUsd : 0,
            VolumeUsd24Hr = decimal.TryParse(data["volumeUsd24Hr"]?.ToString(), out var volumeUsd24Hr) ? volumeUsd24Hr : 0,
            PriceUsd = decimal.TryParse(data["priceUsd"]?.ToString(), out var priceUsd) ? priceUsd : 0,
            ChangePercent24Hr = decimal.TryParse(data["changePercent24Hr"]?.ToString(), out var changePercent24Hr) ? changePercent24Hr : 0,
            Vwap24Hr = decimal.TryParse(data["vwap24Hr"]?.ToString(), out var vwap24Hr) ? vwap24Hr : 0,
            Explorer = data["explorer"]?.ToString()
        };
    }

 
    public static List<CryptoResponseDto> MapToCryptoList(string jsonData)
    {
        var jsonObject = JObject.Parse(jsonData);
        var cryptoList = new List<CryptoResponseDto>();

        var dataArray = jsonObject["data"] as JArray;

        if (dataArray != null)
        {
            foreach (var data in dataArray)
            {
                var cryptoResponse = new CryptoResponseDto
                {
                    Id = data["id"]?.ToString(),
                    Rank = data["rank"]?.ToString(),
                    Symbol = data["symbol"]?.ToString(),
                    Name = data["name"]?.ToString(),
                    Supply = decimal.TryParse(data["supply"]?.ToString(), out var supply) ? supply : 0,
                    MaxSupply = decimal.TryParse(data["maxSupply"]?.ToString(), out var maxSupply) ? maxSupply : (decimal?)null,
                    MarketCapUsd = decimal.TryParse(data["marketCapUsd"]?.ToString(), out var marketCapUsd) ? marketCapUsd : 0,
                    VolumeUsd24Hr = decimal.TryParse(data["volumeUsd24Hr"]?.ToString(), out var volumeUsd24Hr) ? volumeUsd24Hr : 0,
                    PriceUsd = decimal.TryParse(data["priceUsd"]?.ToString(), out var priceUsd) ? priceUsd : 0,
                    ChangePercent24Hr = decimal.TryParse(data["changePercent24Hr"]?.ToString(), out var changePercent24Hr) ? changePercent24Hr : 0,
                    Vwap24Hr = decimal.TryParse(data["vwap24Hr"]?.ToString(), out var vwap24Hr) ? vwap24Hr : 0,
                    Explorer = data["explorer"]?.ToString()
                };

                cryptoList.Add(cryptoResponse);
            }
        }

        return cryptoList;
    }
}
