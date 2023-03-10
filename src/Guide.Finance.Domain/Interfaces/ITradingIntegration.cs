using Guide.Finance.Domain.Entities;

namespace Guide.Finance.Domain.Interfaces;

public interface ITradingIntegration
{
    Task<List<Trading>> GetTradingInfo(string symbol, DateTime period);
}