using Guide.Finance.Application.UseCases.Tradings.Create;
using Guide.Finance.Domain.Interfaces;

namespace Guide.Finance.Application.UseCases.Tradings.Get;

public class GetTradingPriceVariationUseCase : IGetTradingPriceVariationUseCase
{
    private readonly ITradingRepository _tradingRepository;

    public GetTradingPriceVariationUseCase(ITradingRepository tradingRepository)
    {
        _tradingRepository = tradingRepository;
    }

    public async Task<IEnumerable<GetTradingPriceVariationOutput>> Handle(GetTradingPriceVariationInput request,
        CancellationToken cancellationToken)
    {
        var output = new List<GetTradingPriceVariationOutput>();
        var tradings = (await _tradingRepository.GetAll(cancellationToken))
            .OrderBy(x => x.Date).ToList();

        if (!tradings.Any())
            throw new Exception("No tradings found.");

        var tradingD1 = tradings.MinBy(x => x.CreatedAt);
        output.Add(new GetTradingPriceVariationOutput(tradingD1!.Id, tradingD1.Symbol, tradingD1.Price, 0, 0,
            tradingD1.Date,tradingD1.CreatedAt));

        for (var i = 1; i < tradings.Count; i++)
        {
            var trading = tradings.ElementAt(i);
            var variationFromFirst = trading.GetPercentVariation(tradingD1.Price);
            var variationFromLast = trading.GetPercentVariation(tradings.ElementAt(i - 1).Price);
            
            var tradingVariation = new GetTradingPriceVariationOutput(trading.Id, trading.Symbol, trading.Price,
                variationFromFirst, variationFromLast,trading.Date, trading.CreatedAt);
            output.Add(tradingVariation);
        }

        return output;
    }
}