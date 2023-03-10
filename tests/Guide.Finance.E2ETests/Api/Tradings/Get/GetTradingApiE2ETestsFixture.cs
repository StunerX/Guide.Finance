using Guide.Finance.E2ETests.Base;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Guide.Finance.E2ETests.Api.Tradings.Get;

public class GetTradingApiE2ETestsFixture : BaseFixture
{
    public readonly DbContext DbContext;
    public GetTradingApiE2ETestsFixture() : base()
    {
        DbContext = CreateDbContext();
    }
}

[CollectionDefinition(nameof(GetTradingApiE2ETestsFixture))]
public class GetTradingApiE2ETestsFixtureCollection : ICollectionFixture<GetTradingApiE2ETestsFixture>
{
}