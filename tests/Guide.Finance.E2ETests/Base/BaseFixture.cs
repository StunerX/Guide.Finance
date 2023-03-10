using Bogus;
using Guide.Finance.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Guide.Finance.E2ETests.Base;

public class BaseFixture
{
    protected Faker Faker { get; }
    public ApiClient ApiClient { get; }
    public CustomWebApplicationFactory<Program> WebFactory { get; }
    public HttpClient HttpClient { get; }
    private readonly string _dbConnectionString;
    
    protected BaseFixture()
    {
        Faker = new Faker();
        WebFactory = new CustomWebApplicationFactory<Program>();
        HttpClient = WebFactory.CreateClient();
        ApiClient = new ApiClient(HttpClient);
        var configuration = WebFactory.Services.GetService(typeof(IConfiguration));
        _dbConnectionString = ((IConfiguration)configuration).GetConnectionString("GuideFinanceDb");
    }
    
    public GuideFinanceDbContext CreateDbContext()
    {
        var dbContext = new GuideFinanceDbContext(
            new DbContextOptionsBuilder<GuideFinanceDbContext>()
                .UseMySql(_dbConnectionString, ServerVersion.AutoDetect(_dbConnectionString)).Options);

        return dbContext;
    }
    
    public void Cleanup()
    {
        using var dbContext = CreateDbContext();
        dbContext.Tradings.RemoveRange(dbContext.Tradings);
        dbContext.SaveChanges();
    }
}