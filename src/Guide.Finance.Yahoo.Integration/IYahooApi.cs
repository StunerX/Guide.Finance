namespace Guide.Finance.Yahoo.Integration;

public interface IYahooApi
{
    Task<YahooChartResponse> GetTradingInfo(string symbol, DateTime period);
}