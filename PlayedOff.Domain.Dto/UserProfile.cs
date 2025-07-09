namespace PlayedOff.Domain.Dto;

public sealed class UserProfile
{
    public Guid UserId { get; set; } = Guid.Empty;
    public string DisplayName { get; set; } = string.Empty;
}