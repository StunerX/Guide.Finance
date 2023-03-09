namespace Guide.Finance.Domain.Entities;

public class Trading
{
    public string Id { get; }
    public string Symbol { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    public Trading(string symbol, decimal price)
    {
        Id = Guid.NewGuid().ToString();
        Symbol = symbol;
        Price = price;
        CreatedAt = DateTime.Now;
    }
}