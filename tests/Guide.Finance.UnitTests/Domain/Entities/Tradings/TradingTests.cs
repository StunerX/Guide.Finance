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

    [Fact]
    public void ShouldGetPercentVariation()
    {
        var trading1 = new Trading("Trading 1", 1m);
        var trading2 = new Trading("Trading 2", 1.10m);
        var trading3 = new Trading("Trading 3", 1.05m);
        var trading4 = new Trading("Trading 4", 1.90m);

        trading1.GetPercentVariation(trading1.Price).Should().Be(0m);
        trading2.GetPercentVariation(trading1.Price).Should().Be(10m);
        trading3.GetPercentVariation(trading2.Price).Should().Be(-4.54m);
        trading3.GetPercentVariation(trading1.Price).Should().Be(5m);
        trading4.GetPercentVariation(trading3.Price).Should().Be(80.95m);
        trading4.GetPercentVariation(trading1.Price).Should().Be(90m);
    }

}