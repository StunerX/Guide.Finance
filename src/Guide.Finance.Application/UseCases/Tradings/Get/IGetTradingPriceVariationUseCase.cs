using Guide.Finance.Application.UseCases.Tradings.Create;
using MediatR;

namespace Guide.Finance.Application.UseCases.Tradings.Get;

public interface IGetTradingPriceVariationUseCase : IRequestHandler<GetTradingPriceVariationInput, IEnumerable<GetTradingPriceVariationOutput>>
{
    
}