using Guide.Finance.Domain.Entities;
using Guide.Finance.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Guide.Finance.EntityFramework;

public class GuideFinanceDbContext : DbContext
{
    public DbSet<Trading> Tradings => Set<Trading>();
    public GuideFinanceDbContext(DbContextOptions<GuideFinanceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TradingConfiguration());
    }
}