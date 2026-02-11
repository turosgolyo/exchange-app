namespace Exchange.WebAPI.Controllers;

[ApiController]
[ProducesResponseType(statusCode: 400, type: typeof(BadRequestObjectResult))]
public class ExchangeRateController(IExchangeRateService exchangeRateService) : ControllerBase
{
    [HttpGet]
    [Route("/api/statistics")]
    [Authorize]
    [ProducesResponseType(type: typeof(ErrorOr<List<ExchangeRateModel>>), statusCode: 200)]
    [EndpointDescription("This endpoint will get exchange rate statistics from the database.")]
    public async Task<IActionResult> GetStatisticsAsync()
    {
        var result = await exchangeRateService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => errors.ToProblemResult()
        );
    }

    [HttpPost]
    [Route("api/exchange-rates")]
    [Authorize]
    [ProducesResponseType(type: typeof(ErrorOr<ExchangeRateModel>), statusCode: 201)]
    [EndpointDescription("This endpoint will create an exchange rate.")]
    public async Task<IActionResult> CreateExchangeRateAsync([FromBody][Required] ExchangeRateModel exchangeRate)
    {
        var result = await exchangeRateService.CreateAsync(exchangeRate);
        return result.Match(
            result => Ok(result),
            errors => errors.ToProblemResult()
        );
    }

    [HttpPut]
    [Route("api/exchange-rates")]
    [Authorize]
    [ProducesResponseType(type: typeof(ErrorOr<Success>), statusCode: 201)]
    [EndpointDescription("This endpoint will update an exchange rate from the database.")]
    public async Task<IActionResult> UpdateExchangeRateAsync([FromBody][Required] ExchangeRateModel exchangeRate)
    {
        var result = await exchangeRateService.UpdateAsync(exchangeRate);
        return result.Match(
            result => Ok(result),
            errors => errors.ToProblemResult()
        );
    }
}
