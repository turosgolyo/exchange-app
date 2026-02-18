using Microsoft.AspNetCore.Identity;
using Exchange.Domain.Models.Views;

namespace Exchange.Services.User;

public class UserService(ApplicationDbContext dbContext) : IUserService
{
    public async Task<ErrorOr<ICollection<UserModel>>> GetAllUsers() => await dbContext.Users.Select(x => new UserModel(x)).ToListAsync();
}