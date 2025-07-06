using PlayedOff.Domain.Dto;

namespace PlayedOff.Api.Client;

public interface IProfileClient
{
    Task<User> GetAsync();
}

public sealed class ProfileClient(HttpClient httpClient) : Client(httpClient), IProfileClient
{
    public async Task<User> GetAsync()
        => await GetAsync<User>($"profile");
}