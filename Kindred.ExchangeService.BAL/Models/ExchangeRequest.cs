namespace Kindred.ExchangeService.BAL.Models;
using System.ComponentModel.DataAnnotations;

public class ExchangeRequest
{
    public CurrencyCode InputCurrency { get; set; }
    public CurrencyCode OutputCurrency { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Amount must be non negative number")]
    public double Amount { get; set; }
}
