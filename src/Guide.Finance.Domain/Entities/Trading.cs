using Math = System.Math;

namespace Guide.Finance.Domain.Entities;

public class Trading
{
    public Guid Id { get; }
    public string Symbol { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    public Trading(string symbol, decimal price, DateTime? createdAt = null)
    {
        Id = Guid.NewGuid();
        Symbol = symbol;
        Price = price;
        CreatedAt = createdAt ?? DateTime.Now;
    }
    
    public decimal GetPercentVariation(decimal tradingPrice)
    {
        var result = ((Price / tradingPrice) - 1) * 100;
        return Math.Truncate(result * 100) / 100;
    }
}