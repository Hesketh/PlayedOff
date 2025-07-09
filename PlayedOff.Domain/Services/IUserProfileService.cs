using PlayedOff.Domain.Dto;

namespace PlayedOff.Domain.Services;

public interface IUserProfileService
{
    Task<UserProfile> FindUserByAzureOidAsync(Guid azureOid);
    Task<UserProfile> FindUserByUserIdAsync(Guid userId);

    Task<UserProfile> CreateUser(Guid azureOid, UserProfileCreateRequest profileCreateRequest);
}