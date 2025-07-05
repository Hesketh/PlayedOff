namespace PlayedOff.Domain.Dto;

public sealed class User
{
    public Guid UserId { get; set; } = Guid.Empty;
    public string DisplayName { get; set; } = string.Empty;
}