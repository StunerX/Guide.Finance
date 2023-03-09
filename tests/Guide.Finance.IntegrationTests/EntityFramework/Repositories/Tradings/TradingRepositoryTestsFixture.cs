using Guide.Finance.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Guide.Finance.IntegrationTests.EntityFramework.Repositories.Tradings;

public class TradingRepositoryTestsFixture
{
    public GuideFinanceDbContext CreateDbContext()
    {
        var dbContext = new GuideFinanceDbContext(
            new DbContextOptionsBuilder<GuideFinanceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();

        return dbContext;
    }
}

[CollectionDefinition(nameof(TradingRepositoryTestsFixture))]
public class TradingRepositoryTestsFixtureCollection : ICollectionFixture<TradingRepositoryTestsFixture>
{
}