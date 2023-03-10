using FluentAssertions;
using Guide.Finance.Application.UnitOfWork;
using Guide.Finance.Application.UseCases.Tradings.Create;
using Guide.Finance.Domain.Entities;
using Guide.Finance.EntityFramework.Repositories;

namespace Guide.Finance.IntegrationTests.Application.UseCases.Tradings.Create;

[Collection(nameof(CreateTradingUseCaseTestsFixture))]
public class CreateTradingUseCaseTests
{
    private readonly CreateTradingUseCaseTestsFixture _fixture;

    public CreateTradingUseCaseTests(CreateTradingUseCaseTestsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task ShouldCreateTrading()
    {
        var trading = new Trading("Trading 1", 10m, DateTime.Now);
        var createTradingInput = new CreateTradingInput() { Symbol = trading.Symbol, Price = trading.Price };
        var dbContext = _fixture.CreateDbContext();
        var tradingRepository = new TradingRepository(dbContext);
        var unitOfWork = new UnitOfWork(dbContext);
        var createTradingUseCase = new CreateTradingUseCase(tradingRepository, unitOfWork);
        var result = await createTradingUseCase.Handle(createTradingInput, CancellationToken.None);
        result.Should().NotBeNull();
        result.Id.Should().NotBeEmpty();
        result.Symbol.Should().Be(trading.Symbol);
        result.Price.Should().Be(trading.Price);
        result.CreatedAt.Should().NotBe(default);
    }
}