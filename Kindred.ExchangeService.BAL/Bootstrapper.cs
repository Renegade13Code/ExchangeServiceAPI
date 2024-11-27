using Kindred.ExchangeService.BAL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kindred.ExchangeService.BAL;

public static class Bootstrapper
{
    public static IServiceCollection AddBusinessAccessLayerServices(this IServiceCollection services)
    {
        return services.AddScoped<ICurrencyExchangeService, CurrencyExchangeService>();
    }
}
