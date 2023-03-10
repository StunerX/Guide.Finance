using FluentAssertions;
using Guide.Finance.Application.Interfaces;
using Guide.Finance.Application.UseCases.Tradings.Create;
using Guide.Finance.Domain.Entities;
using Guide.Finance.Domain.Interfaces;
using Moq;

namespace Guide.Finance.UnitTests.Application.UseCases.Tradings.Create;

public class CreateTradingUseCaseTests
{
    [Fact]
    public async Task ShouldCreateTrading()
    {
        var trading = new Trading("Trading 1", 10m, DateTime.Now);
        var createTradingInput = new CreateTradingInput();
        var tradingRepository = new Mock<ITradingRepository>();
        
        tradingRepository.Setup(x => x.Create(
            trading, CancellationToken.None)).Returns(Task.CompletedTask);
        
        var unitOfWork = new Mock<IUnitOfWork>();
        var tradingIntegration = new Mock<ITradingIntegration>();
        var createTradingUseCase = new CreateTradingUseCase(tradingRepository.Object, unitOfWork.Object, tradingIntegration.Object);
        var result = await createTradingUseCase.Handle(createTradingInput, CancellationToken.None);
        result.Should().NotBeNull();
       
    }
}