using PlayedOff.Domain.Dto;

namespace PlayedOff.Api.Client;

public interface IUserProfileClient
{
    Task<UserProfile> GetAsync();
}

public sealed class UserProfileClient(HttpClient httpClient) : Client(httpClient), IUserProfileClient
{
    private const string Route = "userProfile";

    public async Task<UserProfile> GetAsync()
        => await GetAsync<UserProfile>(Route);

    public async Task<UserProfile> CreateAsync(UserProfileCreateRequest createRequest)
        => await CreateAsync<UserProfileCreateRequest, UserProfile>(Route, createRequest);
}