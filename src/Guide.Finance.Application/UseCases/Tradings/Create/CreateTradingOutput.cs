namespace Guide.Finance.Application.UseCases.Tradings.Create;

public class CreateTradingOutput
{
    public string Id { get; }
    public string Symbol { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }
    
    public CreateTradingOutput(string id, string symbol, decimal price, DateTime createdAt)
    {
        Id = id;
        Symbol = symbol;
        Price = price;
        CreatedAt = createdAt;
    }
}