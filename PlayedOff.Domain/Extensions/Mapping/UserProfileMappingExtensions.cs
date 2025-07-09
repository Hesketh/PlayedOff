namespace PlayedOff.Domain.Extensions.Mapping;

public static class UserProfileMappingExtensions
{
    public static Dto.UserProfile ToDto(this DataAccess.Entities.UserProfile db)
    {
        return new Dto.UserProfile
        {
            DisplayName = db.DisplayName,
            UserId = db.UserId
        };
    }
}