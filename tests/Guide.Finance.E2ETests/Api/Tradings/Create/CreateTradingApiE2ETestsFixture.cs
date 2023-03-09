using Guide.Finance.E2ETests.Base;
using Xunit;

namespace Guide.Finance.E2ETests.Api.Tradings.Create;

public class CreateTradingApiE2ETestsFixture : BaseFixture
{
    
}

[CollectionDefinition(nameof(CreateTradingApiE2ETestsFixture))]
public class CreateCategoryE2ETestsFixtureCollection : ICollectionFixture<CreateTradingApiE2ETestsFixture>
{
}