using Kindred.ExchangeService.BAL.Contracts;
using Kindred.ExchangeService.DAL.ExternalApis;
using Microsoft.Extensions.DependencyInjection;

namespace Kindred.ExchangeService.DAL;

public static class Bootstrapper
{
    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services)
    {
        return services.AddScoped<IExchangeRateApiRepository, ExchangeRateApiRepository>();
    }
}
