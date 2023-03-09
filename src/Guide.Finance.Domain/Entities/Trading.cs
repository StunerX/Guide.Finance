namespace Guide.Finance.Domain.Entities;

public class Trading
{
    public Guid Id { get; }
    public string Symbol { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    public Trading(string symbol, decimal price)
    {
        Id = Guid.NewGuid();
        Symbol = symbol;
        Price = price;
        CreatedAt = DateTime.Now;
    }
}