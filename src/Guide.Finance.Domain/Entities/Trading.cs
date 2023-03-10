using Math = System.Math;

namespace Guide.Finance.Domain.Entities;

public class Trading
{
    public Guid Id { get; }
    public string Symbol { get; }
    public decimal Price { get; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; }
    

    public Trading()
    {
        
    }
    public Trading(string symbol, decimal price, DateTime date)
    {
        Id = Guid.NewGuid();
        Symbol = symbol;
        Price = price;
        Date = date;
        CreatedAt = DateTime.UtcNow;
    }
    
    public decimal GetPercentVariation(decimal tradingPrice)
    {
        var result = ((Price / tradingPrice) - 1) * 100;
        return Math.Truncate(result * 100) / 100;
    }
}