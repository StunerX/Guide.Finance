using FluentAssertions;
using Guide.Finance.Application.UseCases.Tradings.Get;
using Guide.Finance.Domain.Entities;
using Guide.Finance.Domain.Interfaces;
using Moq;

namespace Guide.Finance.UnitTests.Application.UseCases.Tradings.Get;

[Collection(nameof(GetTradingPriceVariationUseCaseTestsFixture))]
public class GetTradingPriceVariationUseCaseTests
{
    private GetTradingPriceVariationUseCaseTestsFixture _fixture;

    public GetTradingPriceVariationUseCaseTests(GetTradingPriceVariationUseCaseTestsFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetTradingPriceVariationShouldReturnPriceVariation()
    {
        var tradings = new List<Trading>
        {
            _fixture.RandomTrading(),
            _fixture.RandomTrading(),
            _fixture.RandomTrading(),
            _fixture.RandomTrading(),
            _fixture.RandomTrading()
        };

        var tradingRepository = new Mock<ITradingRepository>();
        tradingRepository
            .Setup(x => x.GetAll(CancellationToken.None))
            .ReturnsAsync(tradings);
        
        var getTradingPriceVariationUseCase = new GetTradingPriceVariationUseCase(tradingRepository.Object);
        var result = await getTradingPriceVariationUseCase
            .Handle(It.IsAny<GetTradingPriceVariationInput>(), CancellationToken.None);
        
        result.Should().NotBeNull();
        
        var firstTrading = result.MinBy(x => x.CreatedAt);

        for (var i = 1; i < result.Count(); i++)
        {
            var trading = result.ElementAt(i);
            var variationFromFirst = _fixture.CalculateVariation(trading.Price, firstTrading!.Price);
            var variationFromLast = _fixture.CalculateVariation(trading.Price, result.ElementAt(i - 1).Price);
            
            trading.PercentVariationFromFirst.Should().Be(variationFromFirst);
            trading.PercentVariationFromLast.Should().Be(variationFromLast);
        }
    }
}