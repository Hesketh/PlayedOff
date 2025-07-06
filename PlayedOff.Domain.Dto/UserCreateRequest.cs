namespace PlayedOff.Domain.Dto;

public sealed class UserCreateRequest
{
    public Guid MsalId { get; set; } = Guid.Empty;
    public string DisplayName { get; set; } = string.Empty;
}