using Guide.Finance.Domain.Entities;
using Guide.Finance.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Guide.Finance.EntityFramework.Repositories;

public class TradingRepository : ITradingRepository
{
    private readonly GuideFinanceDbContext _dbContext;
    private DbSet<Trading> Tradings => _dbContext.Set<Trading>();
    
    public TradingRepository(GuideFinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Create(Trading trading, CancellationToken cancellationToken = default)
    {
        await Tradings.AddAsync(trading, cancellationToken);
    }

    public async Task<IEnumerable<Trading>> GetAll(CancellationToken cancellationToken = default)
    {
        return await Tradings.ToListAsync(cancellationToken);
    }
}