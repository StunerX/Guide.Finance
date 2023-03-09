using Bogus;
using Guide.Finance.Domain.Entities;

namespace Guide.Finance.UnitTests.Application.UseCases.Tradings.Get;

public class GetTradingPriceVariationUseCaseTestsFixture
{
    private Faker Faker { get; }

    public GetTradingPriceVariationUseCaseTestsFixture()
    {
        Faker = new Faker("pt_BR");
    }
    
    public Trading RandomTrading()
    {
        var symbol = Faker.Name.JobArea();
        var price = Faker.Random.Decimal(0, 1000);
        var date = Faker.Date.Past();
        return new Trading(symbol, price, date);
    }
    
    public decimal CalculateVariation(decimal firstPrice, decimal lastPrice)
    {
        var result = ((firstPrice / lastPrice) - 1) * 100;
        return Math.Truncate(result * 100) / 100;
    }
}

[CollectionDefinition(nameof(GetTradingPriceVariationUseCaseTestsFixture))]
public class GetTradingPriceVariationUseCaseTestsFixtureCollection : ICollectionFixture<GetTradingPriceVariationUseCaseTestsFixture>
{
}