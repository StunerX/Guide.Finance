using Guide.Finance.Application.Interfaces;
using Guide.Finance.Domain.Interfaces;

namespace Guide.Finance.Application.UseCases.Tradings.Create;

public class CreateTradingUseCase : ICreateTradingUseCase
{
    private const string symbol = "PETR4.SA";

    private readonly ITradingRepository _tradingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITradingIntegration _tradingIntegration;

    public CreateTradingUseCase(ITradingRepository tradingRepository, IUnitOfWork unitOfWork,
        ITradingIntegration tradingIntegration
    )
    {
        _tradingRepository = tradingRepository;
        _unitOfWork = unitOfWork;
        _tradingIntegration = tradingIntegration;
    }

    public async Task<CreateTradingOutput> Handle(CreateTradingInput request, CancellationToken cancellationToken)
    {
        var tradings = await _tradingIntegration.GetTradingInfo(symbol, DateTime.UtcNow);
        
        foreach (var trading in tradings)
        {
            await _tradingRepository.Create(trading, cancellationToken);
        }
        
        await _unitOfWork.Commit(cancellationToken);

        return new CreateTradingOutput(Guid.NewGuid(), symbol, 10m, DateTime.UtcNow);
    }
}