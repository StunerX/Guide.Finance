using MediatR;

namespace Guide.Finance.Application.UseCases.Tradings.Create;

public class CreateTradingInput : IRequest<CreateTradingOutput>
{
    public string Symbol { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
}