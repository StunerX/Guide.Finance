using System.Text;
using FluentAssertions;
using Guide.Finance.Application.UseCases.Tradings.Create;
using Newtonsoft.Json;
using Xunit;

namespace Guide.Finance.E2ETests.Api.Tradings.Create;

[Collection(nameof(CreateTradingApiE2ETestsFixture))]
public class CreateTradingApiE2eTests
{
    private readonly CreateTradingApiE2ETestsFixture _fixture;
    
    public CreateTradingApiE2eTests(CreateTradingApiE2ETestsFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public async Task ShouldCreateTrading()
    {
        var createTradingInput = new CreateTradingInput()
        {
            Price = 1m,
            Symbol = "PETR4",
        };
        
        var jsonContent = JsonConvert.SerializeObject(createTradingInput);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _fixture.ApiClient.PostAsync("/tradings", content);
        response.Should().NotBeNull();
        var responseContent = await response.Content.ReadAsStringAsync();
        var trading = JsonConvert.DeserializeObject<CreateTradingOutput>(responseContent);

        trading.Should().NotBeNull();
    }
}