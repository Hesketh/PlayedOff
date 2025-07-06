using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlayedOff.Domain.Dto;
using PlayedOff.Domain.Services;

namespace PlayedOff.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProfileController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<User> Get()
    {
        // Could maybe wrap all this stuff in a CurrentUserProvider since that makes it simple
        var msalAccountId = User.GetMsalId();

        // Obviously dont want to do this everywhere I get the profile
        var user = await userService.TryFindUserByMsalIdAsync(msalAccountId);
        if (user == null)
        {
            user = await userService.CreateUser(new UserCreateRequest
            {
                MsalId = msalAccountId,
                DisplayName = DateTime.UtcNow.ToShortTimeString()
            });
        }

        return user;
    }
}