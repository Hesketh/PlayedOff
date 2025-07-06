using PlayedOff.Domain.Dto;

namespace PlayedOff.Domain.Services;

// Semantics.
// GET is for low complexity and cost operations
// FIND is for high complexity and cost operations
// Try indicates that null is supported

public interface IUserService
{
    Task<User?> TryFindUserByMsalIdAsync(Guid msalId);
    Task<User> FindUserByUserIdAsync(Guid userId);

    Task<User> CreateUser(UserCreateRequest createRequest);
}

public sealed class UserService : IUserService
{
    // TODO: this is a temporary store
    private static Dictionary<Guid, User> _users = new();

    public async Task<User?> TryFindUserByMsalIdAsync(Guid msalId)
    {
        await Task.Delay(100); // Simulate some async operation
        return _users.GetValueOrDefault(msalId);
    }

    public Task<User> FindUserByUserIdAsync(Guid userId)
    {
        return Task.FromResult(new User
        {
            UserId = Guid.NewGuid(),
            DisplayName = "Test User FIND"
        });
    }

    public Task<User> CreateUser(UserCreateRequest createRequest)
    {
        _users[createRequest.MsalId] = new User
        {
            UserId = Guid.NewGuid(),
            DisplayName = createRequest.DisplayName
        };
        return Task.FromResult(_users[createRequest.MsalId]);
    }
}