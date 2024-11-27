namespace Kindred.ExchangeService.BAL.Models;

public class ExchangeResponse
{
    public double Amount { get; set; }
    public CurrencyCode InputCurrency { get; set; }
    public CurrencyCode OutputCurrency { get; set; }
    public double Value { get; set; }
}
