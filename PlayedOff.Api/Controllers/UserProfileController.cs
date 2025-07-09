using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayedOff.Domain.Dto;
using PlayedOff.Domain.Services;

namespace PlayedOff.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserProfileController(IUserProfileService userProfileService, ICurrentUserProvider currentUserProvider) : ControllerBase
{
    [HttpGet]
    public async Task<UserProfile> Get()
    {
        return await userProfileService.FindUserByAzureOidAsync(currentUserProvider.GetAzureOid());
    }

    [HttpPost]
    public async Task<ActionResult<UserProfile>> Create(UserProfileCreateRequest createRequest)
    {
        return await userProfileService.CreateUser(currentUserProvider.GetAzureOid(), createRequest);
    }
}