namespace Guide.Finance.Application.UseCases.Tradings.Create;

public class CreateTradingOutput
{
    public Guid Id { get; }
    public string Symbol { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    public CreateTradingOutput(Guid id, string symbol, decimal price, DateTime createdAt)
    {
        Id = id;
        Symbol = symbol;
        Price = price;
        CreatedAt = createdAt;
    }
}