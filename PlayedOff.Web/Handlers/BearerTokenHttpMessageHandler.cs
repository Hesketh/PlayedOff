using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace PlayedOff.Web.Handlers;

public class BearerTokenHttpMessageHandler(IAccessTokenProvider accessTokenProvider) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessTokenResult = await accessTokenProvider.RequestAccessToken();
        AddAuthHeader(request, accessTokenResult);

        return await base.SendAsync(request, cancellationToken);
    }

    private void AddAuthHeader(HttpRequestMessage request, AccessTokenResult accessTokenResult)
    {
        if (accessTokenResult.TryGetToken(out var token) && !string.IsNullOrEmpty(token?.Value))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
        }
    }
}