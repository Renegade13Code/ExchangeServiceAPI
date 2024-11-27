using Kindred.ExchangeService.BAL.Models;

namespace Kindred.ExchangeService.BAL.Services;

public interface ICurrencyExchangeService
{
    Task<ExchangeResponse> Exchange(ExchangeRequest request);
}
