using Guide.Finance.E2ETests.Base;
using Xunit;

namespace Guide.Finance.E2ETests.YahooIntegration.YahooApi;

public class YahooApiE2ETestsFixture : BaseFixture
{
}

[CollectionDefinition(nameof(YahooApiE2ETestsFixture))]
public class YahooApiE2ETestsFixtureCollection : ICollectionFixture<YahooApiE2ETestsFixture>
{
}