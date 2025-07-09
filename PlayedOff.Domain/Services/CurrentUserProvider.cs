using Microsoft.AspNetCore.Http;
using PlayedOff.Domain.Dto;

namespace PlayedOff.Domain.Services;

public class CurrentUserProvider(IHttpContextAccessor httpContextAccessor) : ICurrentUserProvider
{
    public Guid GetAzureOid()
    {
        return httpContextAccessor.HttpContext.User.GetAzureOid();
    }
}