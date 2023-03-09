using MediatR;

namespace Guide.Finance.Application.UseCases.Tradings.Create;

public interface ICreateTradingUseCase : IRequestHandler<CreateTradingInput, CreateTradingOutput>
{
    
}