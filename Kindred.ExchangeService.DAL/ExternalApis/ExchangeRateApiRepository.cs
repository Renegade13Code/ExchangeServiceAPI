using Kindred.ExchangeService.BAL.Models;
using Kindred.ExchangeService.DAL.Models;
using Kindred.ExchangeService.BAL.Contracts;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Kindred.ExchangeService.DAL.ExternalApis;

internal class ExchangeRateApiRepository(HttpClient httpClient, IConfiguration configuration) : IExchangeRateApiRepository
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _configuration = configuration;

    public async Task<Dictionary<CurrencyCode, double>> GetExchangeRatesForCurrency(CurrencyCode currency)
    {
        var baseUrl = _configuration["Services:ExchangeRateService:BaseUrl"];

        var httpResponse = await _httpClient.GetAsync($"{baseUrl}/{currency}");
        httpResponse.EnsureSuccessStatusCode();

        var content = await httpResponse.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<ExchangeRateApiResponse>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (response == null)
            throw new Exception("ExchangeRate API response null");

        return response.Rates;
    }
}
