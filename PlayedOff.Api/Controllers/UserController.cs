using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using PlayedOff.Domain.Dto;
using PlayedOff.Domain.Services;

namespace PlayedOff.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{userId}")]
    public async Task<User> Get(Guid userId)
    {
        return await userService.FindUserAsync(userId);
    }

    [HttpGet("oid={maslOid}")]
    public async Task<User> GetByMaslOid(Guid maslOid)
    {
        return await userService.FindUserAsync(maslOid);
    }
}