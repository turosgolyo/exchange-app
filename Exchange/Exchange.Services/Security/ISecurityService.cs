using ErrorOr;
using Exchange.Domain.Models.Requests.Security;
using Exchange.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Services.Security;

public interface ISecurityService
{
    Task<ErrorOr<TokenResponseModel>> LoginAsync(LoginRequestModel model);
    Task<ErrorOr<Success>> RegisterAsync(RegisterRequestModel model);
}

