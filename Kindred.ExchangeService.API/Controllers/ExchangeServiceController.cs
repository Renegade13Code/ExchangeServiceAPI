using Kindred.ExchangeService.BAL.Models;
using Kindred.ExchangeService.BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace KindredExchangeServiceAPI.Controllers;

//Future Improvements: Version this API 
[ApiController]
[Route("[controller]")]
public class ExchangeServiceController(ICurrencyExchangeService exchangeService, ILogger<ExchangeServiceController> logger) : ControllerBase
{
    private readonly ICurrencyExchangeService exchangeService = exchangeService;
    private readonly ILogger<ExchangeServiceController> logger = logger;

    [HttpPost(Name = "ExchangeCurrencies")]
    public async Task<IActionResult> ExchangeCurrencies([FromBody] ExchangeRequest request)
    {
        try
        {
            var result = await exchangeService.Exchange(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while processing the request");
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request");
        }
    }

    //Included for testing purposes
    [HttpGet]
    [Route("health")]
    public IActionResult HealthCheck()
    {
        return Ok("Service is up and running");
    }
}