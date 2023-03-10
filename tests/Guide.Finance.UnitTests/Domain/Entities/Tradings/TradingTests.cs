using FluentAssertions;
using Guide.Finance.Domain.Entities;

namespace Guide.Finance.UnitTests.Domain.Entities.Tradings;

public class TradingTests
{
    [Fact]
    public void ShouldCreateTrading()
    {
        var trading = new Trading("Trading 1", 10m, DateTime.Now);
        trading.Should().NotBeNull();
        trading.Id.Should().NotBeEmpty();
        trading.Symbol.Should().Be("Trading 1");
        trading.Price.Should().Be(10m);
        trading.CreatedAt.Should().NotBe(default);
    }

    [Fact]
    public void ShouldGetPercentVariation()
    {
        var today = DateTime.Now;
        var trading1 = new Trading("Trading 1", 1m, today.AddDays(-4));
        var trading2 = new Trading("Trading 2", 1.10m, today.AddDays(-3));
        var trading3 = new Trading("Trading 3", 1.05m, today.AddDays(-2));
        var trading4 = new Trading("Trading 4", 1.90m, today.AddDays(-1));

        trading1.GetPercentVariation(trading1.Price).Should().Be(0m);
        trading2.GetPercentVariation(trading1.Price).Should().Be(10m);
        trading3.GetPercentVariation(trading2.Price).Should().Be(-4.54m);
        trading3.GetPercentVariation(trading1.Price).Should().Be(5m);
        trading4.GetPercentVariation(trading3.Price).Should().Be(80.95m);
        trading4.GetPercentVariation(trading1.Price).Should().Be(90m);
    }

}