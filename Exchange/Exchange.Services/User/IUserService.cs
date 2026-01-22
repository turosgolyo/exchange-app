using ErrorOr;
using Exchange.Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange.Services.User;

public interface IUserService
{
    Task<ErrorOr<ICollection<UserModel>>> GetAllUsers();
}

