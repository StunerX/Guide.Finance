using FluentAssertions;
using Guide.Finance.Yahoo.Integration;
using Xunit;

namespace Guide.Finance.E2ETests.YahooIntegration.YahooApi;

[Collection(nameof(YahooApiE2ETestsFixture))]
public class YahooApiE2ETests
{
    private readonly YahooApiE2ETestsFixture _fixture;
    
    public YahooApiE2ETests(YahooApiE2ETestsFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public async Task ShouldGetTradingsInfo()
    {
        var yahooApi = new Yahoo.Integration.YahooApi(_fixture.HttpClient);

        var result = await yahooApi.GetTradingInfo("PETR4.SA", DateTime.Now);
        result.Should().NotBeNull();
        result.Should().BeOfType<YahooChartResponse>();
    }
}