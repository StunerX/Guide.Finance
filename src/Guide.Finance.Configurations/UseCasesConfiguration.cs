using Guide.Finance.Application.Interfaces;
using Guide.Finance.Application.UnitOfWork;
using Guide.Finance.Application.UseCases.Tradings.Create;
using Guide.Finance.Application.UseCases.Tradings.Get;
using Guide.Finance.Domain.Interfaces;
using Guide.Finance.EntityFramework.Repositories;
using Guide.Finance.Yahoo.Integration;
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
    services.AddScoped<ITradingRepository, TradingRepository>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    return services;
  }
  
  public static IServiceCollection AddIntegrators(this IServiceCollection services)
  {
    services.AddScoped<IYahooApi, YahooApi>();
    services.AddScoped<ITradingIntegration, TradingIntegration>();
    return services;
  }
}