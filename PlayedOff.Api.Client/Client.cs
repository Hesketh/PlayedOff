using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlayedOff.Api.Client;

public abstract class Client
{
    protected JsonSerializerOptions JsonOptions { get; }
    protected HttpClient HttpClient { get; }

    protected Client(HttpClient httpClient)
    {
        HttpClient = httpClient;

        JsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        JsonOptions.Converters.Add(new JsonStringEnumConverter());
    }

    protected async Task<T> GetAsync<T>(string route)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, route);
        using var response = await HttpClient.SendAsync(request);
        await response.EnsureSuccessStatusCodeWithResponseAsync();

        var result = await response.Content.ReadFromJsonAsync<T>(JsonOptions);
        return result ?? throw new UnexpectedNullContentException();
    }

    protected async Task DeleteAsync(string route)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, route);
        using var response = await HttpClient.SendAsync(request);
        await response.EnsureSuccessStatusCodeWithResponseAsync();
    }

    public async Task<TResponse> UpdateAsync<TCreate, TResponse>(string route, TCreate item)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, route);
        request.Content = JsonContent.Create(item, options: JsonOptions);

        using var response = await HttpClient.SendAsync(request);
        await response.EnsureSuccessStatusCodeWithResponseAsync();

        var result = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);
        return result ?? throw new UnexpectedNullContentException();
    }

    protected async Task<TResponse> CreateAsync<TCreate, TResponse>(string route, TCreate item)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, route);
        request.Content = JsonContent.Create(item, options: JsonOptions);

        using var response = await HttpClient.SendAsync(request);
        await response.EnsureSuccessStatusCodeWithResponseAsync();

        var result = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);
        return result ?? throw new UnexpectedNullContentException();
    }
}