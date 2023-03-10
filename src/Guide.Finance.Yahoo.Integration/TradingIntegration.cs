using Guide.Finance.Domain.Entities;
using Guide.Finance.Domain.Interfaces;

namespace Guide.Finance.Yahoo.Integration;

public class TradingIntegration : ITradingIntegration
{
    private readonly IYahooApi _yahooApi;

    public TradingIntegration(IYahooApi yahooApi)
    {
        _yahooApi = yahooApi;
    }

    public async Task<List<Trading>> GetTradingInfo(string symbol, DateTime period)
    {
        var result = await _yahooApi.GetTradingInfo(symbol, period);
        var lastTimestamps = result!.chart.result.FirstOrDefault().timestamp.TakeLast(30).ToList();
        var lastPrices = result.chart.result.FirstOrDefault().indicators.quote.FirstOrDefault().open.TakeLast(30)
            .ToList();

        return lastTimestamps.Select(t => new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))
            .Select((dateTime, i) => dateTime.AddSeconds(lastTimestamps.ElementAt(i))).Select((dateTime, i) =>
                new Trading(symbol, Convert.ToDecimal(lastPrices.ElementAt(i)), dateTime)).ToList();
    }
}