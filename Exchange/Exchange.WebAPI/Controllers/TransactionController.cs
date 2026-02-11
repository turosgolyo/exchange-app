namespace Exchange.WebAPI.Controllers;

[ApiController]
[ProducesResponseType(statusCode: 400, type: typeof(BadRequestObjectResult))]
public class TransactionController(ITransactionService transactionService) : ControllerBase
{

    [HttpPost]
    [Route("api/transactions/buy")]
    [Authorize]
    [ProducesResponseType(type: typeof(ErrorOr<TransactionModel>), statusCode: 201)]
    [EndpointDescription("This endpoint will create a buy transaction.")]
    public async Task<IActionResult> BuyAsync([FromBody][Required] TransactionModel transaction)
    {
        var result = await transactionService.CreateAsync(transaction);
        return result.Match(
            result => Ok(result),
            errors => errors.ToProblemResult()
        );
    }

    [HttpPost]
    [Route("api/transactions/sell")]
    [Authorize]
    [ProducesResponseType(type: typeof(ErrorOr<TransactionModel>), statusCode: 201)]
    [EndpointDescription("This endpoint will create a sell transaction.")]
    public async Task<IActionResult> SellAsync([FromBody][Required] TransactionModel transaction)
    {
        var result = await transactionService.CreateAsync(transaction);
        return result.Match(
            result => Ok(result),
            errors => errors.ToProblemResult()
        );
    }
}
