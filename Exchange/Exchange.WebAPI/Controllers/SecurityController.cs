using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Exchange.Domain.Models.Requests.Security;
using Exchange.Domain.Models.Responses;
using Exchange.Services.Security;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exchange.WebAPI.Controllers;

[ApiController]
public class SecurityController(ISecurityService securityService) : ControllerBase
{
    [HttpPost]
    [Route("api/register")]
    [ProducesResponseType(type: typeof(Success), statusCode:  200)]
    [EndpointDescription("Register a user using email and password.")]
    public async Task<IActionResult> RegisterAsync([FromBody][Required] RegisterRequestModel model)
    {
        var result = await securityService.RegisterAsync(model);
        return result.Match(
            value => Ok(value),
            errors => errors.ToProblemResult()
        );
    }

    [HttpPost]
    [Route("api/login")]
    [ProducesResponseType(type: typeof(TokenResponseModel), statusCode: 200)]
    [EndpointDescription("Login using email and password.")]
    public async Task<IActionResult> LoginAsync([FromBody][Required] LoginRequestModel model)
    {
        var result = await securityService.LoginAsync(model);
        return result.Match(
            value => Ok(value),
            errors => errors.ToProblemResult()
        );
    }
}

