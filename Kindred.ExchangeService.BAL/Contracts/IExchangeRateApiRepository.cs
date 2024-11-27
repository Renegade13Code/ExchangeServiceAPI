using Kindred.ExchangeService.BAL.Models;

namespace Kindred.ExchangeService.BAL.Contracts;

public interface IExchangeRateApiRepository
{
    Task<Dictionary<CurrencyCode,double>> GetExchangeRatesForCurrency(CurrencyCode currency);
}
