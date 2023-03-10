using System.Text;
using FluentAssertions;
using Guide.Finance.Application.UseCases.Tradings.Create;
using Guide.Finance.Application.UseCases.Tradings.Get;
using Guide.Finance.E2ETests.Api.Tradings.Get;
using Newtonsoft.Json;
using Xunit;

namespace Guide.Finance.E2ETests.Api.Tradings.Get;

[Collection(nameof(GetTradingApiE2ETestsFixture))]
public class GetTradingApiE2ETests
{
    private readonly GetTradingApiE2ETestsFixture _fixture;
    
    public GetTradingApiE2ETests(GetTradingApiE2ETestsFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public async Task ShouldGetTradingVariationPrice()
    {
        var today = DateTime.Now;
        var trading1 = new Domain.Entities.Trading("PETR4", 1m, today.AddDays(-3));
        Thread.Sleep(1000);
        var trading2 = new Domain.Entities.Trading("PETR4", 1.10m, today.AddDays(-2));
        Thread.Sleep(1000);
        var trading3 = new Domain.Entities.Trading("PETR4", 1.05m, today.AddDays(-1));
        Thread.Sleep(1000);
        var trading4 = new Domain.Entities.Trading("PETR4", 1.90m, today);
        Thread.Sleep(1000);

        await _fixture.DbContext.AddAsync(trading1);
        await _fixture.DbContext.AddAsync(trading2);
        await _fixture.DbContext.AddAsync(trading3);
        await _fixture.DbContext.AddAsync(trading4);
        await _fixture.DbContext.SaveChangesAsync();
        
        var response = await _fixture.ApiClient.GetAsync("/tradings");
        response.Should().NotBeNull();
        response.IsSuccessStatusCode.Should().BeTrue();

        var responseContent = await response.Content.ReadAsStringAsync();
        var tradings = JsonConvert.DeserializeObject<List<GetTradingPriceVariationOutput>>(responseContent);

        tradings.Should().NotBeNull();
        tradings.Count.Should().Be(4);

    }
}