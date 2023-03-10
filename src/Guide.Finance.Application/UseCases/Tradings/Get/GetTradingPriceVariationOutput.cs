namespace Guide.Finance.Application.UseCases.Tradings.Get;

public class GetTradingPriceVariationOutput
{
    public Guid Id { get; }
    public string Symbol { get; }
    public decimal Price { get; }
    public decimal PercentVariationFromFirst { get; }
    public decimal PercentVariationFromLast { get; }
    public DateTime Date { get; set; }
    public DateTime CreatedAt { get; }
    
    public GetTradingPriceVariationOutput(Guid id, string symbol, decimal price, decimal percentVariationFromFirst, decimal percentVariationFromLast, DateTime date, DateTime createdAt)
    {
        Id = id;
        Symbol = symbol;
        Price = price;
        PercentVariationFromFirst = percentVariationFromFirst;
        PercentVariationFromLast = percentVariationFromLast;
        Date = date;
        CreatedAt = createdAt;
    }
}