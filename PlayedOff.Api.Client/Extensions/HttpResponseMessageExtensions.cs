namespace PlayedOff.Api.Client.Extensions;

public static class HttpResponseMessageExtensions
{
    public static async Task EnsureSuccessStatusCodeWithResponseAsync(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return;

        var content = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(content))
        {
            // Fallback to default error handling if no content is available
            response.EnsureSuccessStatusCode();
        }

        throw new HttpRequestException(
            content,
            null,
            response.StatusCode
        );
    }
}