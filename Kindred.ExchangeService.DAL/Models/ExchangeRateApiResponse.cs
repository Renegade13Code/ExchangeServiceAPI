using Kindred.ExchangeService.BAL.Models;

namespace Kindred.ExchangeService.DAL.Models;

internal class ExchangeRateApiResponse
{
    public string Result { get; set; }
    public string Provider { get; set; }
    public string Documentation { get; set; }
    public string TermsOfUse { get; set; }
    public int TimeLastUpdateUnix { get; set; }
    public string TimeLastUpdateUtc { get; set; }
    public int TimeNextUpdateUnix { get; set; }
    public string TimeNextUpdateUtc { get; set; }
    public int TimeEolUnix { get; set; }
    public CurrencyCode BaseCode { get; set; }
    public Dictionary<CurrencyCode, double> Rates { get; set; }
}
