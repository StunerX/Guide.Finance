using FluentAssertions;
using Guide.Finance.Domain.Entities;
using Guide.Finance.EntityFramework.Repositories;

namespace Guide.Finance.IntegrationTests.EntityFramework.Repositories.Tradings;

[Collection(nameof(TradingRepositoryTestsFixture))]
public class TradingRepositoryTests
{
    private readonly TradingRepositoryTestsFixture _fixture;
    
    public TradingRepositoryTests(TradingRepositoryTestsFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public async Task ShouldCreateTrading()
    {
        var trading = new Trading("Trading 1", 10m);
        var dbContext = _fixture.CreateDbContext();
        var tradingRepository = new TradingRepository(dbContext);
        await tradingRepository.Create(trading, CancellationToken.None);
        var result = await dbContext.Tradings.FindAsync(trading.Id);
        result.Should().NotBeNull();
        result!.Id.Should().NotBeEmpty();
        result.Symbol.Should().Be("Trading 1");
        result.Price.Should().Be(10m);
        result.CreatedAt.Should().NotBe(default);
    }
}