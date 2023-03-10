using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Guide.Finance.Yahoo.Integration;

public class YahooApi
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<YahooApi> _logger;
    
    public YahooApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<YahooChartResponse> GetTradingInfo(string symbol, DateTime period)
    {
        var timestamp = (period.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        var url =
            $"https://query2.finance.yahoo.com/v8/finance/chart/{symbol}?interval=1d&dataGranularity=1d&period2={timestamp}";
        
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
            {
                var response = await httpClient.SendAsync(request);
                
                if (!response.IsSuccessStatusCode)
                {
                    var message = $"Error getting data from Yahoo Finance API. Status Code: {response.StatusCode}";
                    _logger.LogError(message);
                    throw new Exception(message);
                }

                var content = await response.Content.ReadAsStringAsync();
                var tradings = JsonConvert.DeserializeObject<YahooChartResponse>(content);
                return tradings;
            }
        }
    }
}