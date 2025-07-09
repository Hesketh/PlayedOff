namespace PlayedOff.Domain.Services;

public interface ICurrentUserProvider
{
    Guid GetAzureOid();
}