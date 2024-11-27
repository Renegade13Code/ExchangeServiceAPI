using Kindred.ExchangeService.BAL.Contracts;
using Kindred.ExchangeService.BAL.Models;

namespace Kindred.ExchangeService.BAL.Services;

public class CurrencyExchangeService(IExchangeRateApiRepository exchangeRateRepository) : ICurrencyExchangeService
{
    private readonly IExchangeRateApiRepository exchangeRateRepository = exchangeRateRepository;

    public async Task<ExchangeResponse> Exchange(ExchangeRequest request)
    {
        var exchangeRates = await exchangeRateRepository.GetExchangeRatesForCurrency(request.InputCurrency);
        var convertedVal = request.Amount * exchangeRates[request.OutputCurrency];
        return new ExchangeResponse
        {
            Amount = request.Amount,
            InputCurrency = request.InputCurrency,
            OutputCurrency = request.OutputCurrency,
            Value = convertedVal
        };
    }
}
