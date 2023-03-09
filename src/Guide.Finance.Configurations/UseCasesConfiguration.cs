using Guide.Finance.Application.Interfaces;
using Guide.Finance.Application.UnitOfWork;
using Guide.Finance.Application.UseCases.Tradings.Create;
using Guide.Finance.Application.UseCases.Tradings.Get;
using Guide.Finance.Domain.Interfaces;
using Guide.Finance.EntityFramework.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Guide.Finance.Configurations;

public static class UseCasesConfiguration
{
  public static IServiceCollection AddUseCases(this IServiceCollection services)
  {
    services.AddMediatR(typeof(CreateTradingUseCase));
    services.AddMediatR(typeof(GetTradingPriceVariationUseCase));
    return services;
  }
  
  public static IServiceCollection AddRepositories(this IServiceCollection services)
  {
    services.AddTransient<ITradingRepository, TradingRepository>();
    services.AddTransient<IUnitOfWork, UnitOfWork>();
    return services;
  }
}