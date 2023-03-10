using Guide.Finance.Application.Interfaces;
using Guide.Finance.Domain.Entities;
using Guide.Finance.Domain.Interfaces;

namespace Guide.Finance.Application.UseCases.Tradings.Create;

public class CreateTradingUseCase : ICreateTradingUseCase
{
    private readonly ITradingRepository _tradingRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateTradingUseCase(ITradingRepository tradingRepository, IUnitOfWork unitOfWork)
    {
        _tradingRepository = tradingRepository;
        _unitOfWork = unitOfWork;        
    }
    public async Task<CreateTradingOutput> Handle(CreateTradingInput request, CancellationToken cancellationToken)
    {
        var trading = new Trading(request.Symbol, request.Price, request.Date);
        
        await _tradingRepository.Create(trading, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);
        
        return new CreateTradingOutput(trading.Id, trading.Symbol, trading.Price, trading.CreatedAt);
    }
}