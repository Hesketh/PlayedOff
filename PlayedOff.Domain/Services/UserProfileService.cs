using Microsoft.EntityFrameworkCore;
using PlayedOff.DataAccess;
using PlayedOff.Domain.Dto;

namespace PlayedOff.Domain.Services;

public sealed class UserProfileService(PlayedOffDbContext dbContext) : IUserProfileService
{
    public async Task<UserProfile> FindUserByAzureOidAsync(Guid azureOid)
    {
        var dbProfile = await dbContext.UserProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(up => up.AzureOid == azureOid);
        if (dbProfile == null)
            throw new UserForbiddenException("The user has not completed their profile");

        return dbProfile.ToDto();
    }

    public async Task<UserProfile> FindUserByUserIdAsync(Guid userId)
    {
        var dbProfile = await dbContext.UserProfiles
            .AsNoTracking()
            .FirstOrDefaultAsync(up => up.UserId == userId);
        if (dbProfile == null)
            throw new EntityNotFoundException(userId, nameof(UserProfile));

        return dbProfile.ToDto();
    }

    public async Task<UserProfile> CreateUser(Guid azureOid, UserProfileCreateRequest profileCreateRequest)
    {
        try
        {
            var dbProfile = new DataAccess.Entities.UserProfile
            {
                AzureOid = azureOid,
                DisplayName = profileCreateRequest.DisplayName,
            };

            dbContext.Add(dbProfile);

            await dbContext.SaveChangesAsync();

            return dbProfile.ToDto();
        }
        catch (Exception e)
        {
            throw new EntityCreateFailedException(nameof(UserProfile), e.Message);
        }
    }
}