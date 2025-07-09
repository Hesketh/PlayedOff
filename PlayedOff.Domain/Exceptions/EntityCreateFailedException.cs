namespace PlayedOff.Domain.Exceptions;

public sealed class EntityCreateFailedException(string message) : Exception(message)
{
    public EntityCreateFailedException(string type, string reason)
        : this($"Could not create {type} as {reason}") { }
}