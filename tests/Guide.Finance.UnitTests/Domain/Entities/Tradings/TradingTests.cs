using FluentAssertions;
using Guide.Finance.Domain.Entities;

namespace Guide.Finance.UnitTests.Domain.Entities.Tradings;

public class TradingTests
{
    [Fact]
    public void ShouldCreateTrading()
    {
        var trading = new Trading("Trading 1", 10m);
        trading.Should().NotBeNull();
        trading.Id.Should().NotBeEmpty();
        trading.Symbol.Should().Be("Trading 1");
        trading.Price.Should().Be(10m);
        trading.CreatedAt.Should().NotBe(default);
    }
}