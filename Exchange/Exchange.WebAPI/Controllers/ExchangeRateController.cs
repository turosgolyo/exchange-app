using ErrorOr;
using Exchange.Domain.Models;
using Exchange.Services.ExchangeRate;
using Exchange.Services.Transaction;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Exchange.WebAPI.Controllers;

public class ExchangeRateController(IExchangeRateService exchangeRateService) : ControllerBase
{

    [HttpPost]
    [Route("api/exchange-rates")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] ExchangeRateModel exchangeRate)
    {
        var result = await exchangeRateService.CreateAsync(exchangeRate);
        return result.Match(
            result => Ok(result),
            errors => errors.ToProblemResult()
        );
    }

    [HttpPut]
    [Route("api/exchange-rates")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] ExchangeRateModel exchangeRate)
    {
        var result = await exchangeRateService.UpdateAsync(exchangeRate);
        return result.Match(
            result => Ok(result),
            errors => errors.ToProblemResult()
        );
    }
}
