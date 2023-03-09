using Guide.Finance.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Guide.Finance.IntegrationTests.Base;

public abstract class BaseFixture
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