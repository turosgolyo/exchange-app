namespace Exchange.WebAPI.Controllers;

[ApiController]
[ProducesResponseType(statusCode: 400, type: typeof(BadRequestObjectResult))]
public class SecurityController(ISecurityService securityService) : ControllerBase
{
    [HttpPost]
    [Route("api/register")]
    [ProducesResponseType(type: typeof(Success), statusCode:  200)]
    [EndpointDescription("Register user using email and password.")]
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

