using Guide.Finance.Application.Interfaces;
using Guide.Finance.EntityFramework;

namespace Guide.Finance.Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly GuideFinanceDbContext _context;
    
    public UnitOfWork(GuideFinanceDbContext context)
    {
        _context = context;
    }
    
    public async Task Commit(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}