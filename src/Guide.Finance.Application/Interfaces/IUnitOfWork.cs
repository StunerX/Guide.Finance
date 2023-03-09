namespace Guide.Finance.Application.Interfaces;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken = default);
}