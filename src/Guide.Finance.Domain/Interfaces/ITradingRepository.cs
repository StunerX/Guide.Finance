using Guide.Finance.Domain.Entities;

namespace Guide.Finance.Domain.Interfaces;

public interface ITradingRepository
{
    Task Create(Trading trading, CancellationToken cancellationToken = default);
}