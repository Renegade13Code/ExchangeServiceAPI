using AutoFixture.Xunit2;
using Kindred.ExchangeService.BAL.Contracts;
using Kindred.ExchangeService.BAL.Models;
using Kindred.ExchangeService.BAL.Services;
using Moq;
using Xunit;

namespace Kindred.ExchangeService.BAL.Test.Services;

public class CurrencyExchangeServiceTests
{
    [Theory]
    [AutoMoqData]
    public async Task CurrencyExchangeService_CorrectlyCalculatesAmount(
        [Frozen] Mock<IExchangeRateApiRepository> exchangeRateApiRepositoryMock,
        CurrencyExchangeService sut
        )
    {
        // Arrange
        var exchangeRates = new Dictionary<CurrencyCode, double>
        {
            { CurrencyCode.USD, 0.65 },
            { CurrencyCode.ALL, 0.45 },
            { CurrencyCode.ZAR, 0.78 }
        };
        
        exchangeRateApiRepositoryMock.Setup(x => x.GetExchangeRatesForCurrency(It.IsAny<CurrencyCode>()))
            .ReturnsAsync(exchangeRates);

        var request = new ExchangeRequest
        {
            InputCurrency = CurrencyCode.AUD,
            OutputCurrency = CurrencyCode.USD,
            Amount = 10
        };

        // Act
        var result = await sut.Exchange(request);

        // Assert
        exchangeRateApiRepositoryMock.Verify(x => x.GetExchangeRatesForCurrency(It.Is<CurrencyCode>(val => val == CurrencyCode.AUD)), Times.Once);
        
        Assert.Equal(10, result.Amount);
        Assert.Equal(CurrencyCode.AUD, result.InputCurrency);
        Assert.Equal(CurrencyCode.USD, result.OutputCurrency);
        Assert.Equal(6.5, result.Value);
    }
}
