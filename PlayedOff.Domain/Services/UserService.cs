using PlayedOff.Domain.Dto;

namespace PlayedOff.Domain.Services;

public interface IUserService
{
    Task<User> FindUserByMsalOidAsync(Guid msalOid);
    Task<User> FindUserAsync(Guid userId);
}

public sealed class UserService : IUserService
{
    public Task<User> FindUserByMsalOidAsync(Guid msalOid)
    {
        return Task.FromResult(new User
        {
            UserId = Guid.NewGuid(),
            DisplayName = "Test User"
        });
    }

    public Task<User> FindUserAsync(Guid userId)
    {
        return Task.FromResult(new User
        {
            UserId = Guid.NewGuid(),
            DisplayName = "Test User FIND"
        });
    }
}