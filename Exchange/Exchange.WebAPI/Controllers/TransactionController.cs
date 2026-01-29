using ErrorOr;
using Exchange.Domain.Models;
using Exchange.Services.Transaction;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Exchange.WebAPI.Controllers;

public class TransactionController(ITransactionService transactionService) : ControllerBase
{

    [HttpPost]
    [Route("api/transactions/buy")]
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
    public async Task<IActionResult> SellAsync([FromBody][Required] TransactionModel transaction)
    {
        var result = await transactionService.CreateAsync(transaction);
        return result.Match(
            result => Ok(result),
            errors => errors.ToProblemResult()
        );
    }
}
