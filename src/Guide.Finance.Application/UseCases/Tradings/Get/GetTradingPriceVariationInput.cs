using Guide.Finance.Application.UseCases.Tradings.Create;
using MediatR;

namespace Guide.Finance.Application.UseCases.Tradings.Get;

public class GetTradingPriceVariationInput : IRequest<IEnumerable<GetTradingPriceVariationOutput>>
{
}