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
            Supply = data["supply"]?.ToString(),
            MaxSupply = string.IsNullOrEmpty(data["maxSupply"]?.ToString()) ? "null" : data["maxSupply"]?.ToString(),
            MarketCapUsd = data["marketCapUsd"]?.ToString(),
            VolumeUsd24Hr = data["volumeUsd24Hr"]?.ToString(),
            PriceUsd = data["priceUsd"]?.ToString(),
            ChangePercent24Hr = data["changePercent24Hr"]?.ToString(),
            Vwap24Hr = data["vwap24Hr"]?.ToString(),    
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
                    Supply = data["supply"]?.ToString(),
                    MaxSupply = string.IsNullOrEmpty(data["maxSupply"]?.ToString()) ? "null" : data["maxSupply"]?.ToString(),
                    MarketCapUsd = data["marketCapUsd"]?.ToString(),
                    VolumeUsd24Hr = data["volumeUsd24Hr"]?.ToString(),
                    PriceUsd = data["priceUsd"]?.ToString(),
                    ChangePercent24Hr = data["changePercent24Hr"]?.ToString(),
                    Vwap24Hr = data["vwap24Hr"]?.ToString(),
                    Explorer = data["explorer"]?.ToString()
                };

                cryptoList.Add(cryptoResponse);
            }
        }

        return cryptoList;
    }
}
