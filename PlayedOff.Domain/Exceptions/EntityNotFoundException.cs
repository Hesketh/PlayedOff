namespace PlayedOff.Domain.Exceptions;

public sealed class EntityNotFoundException(string message) : Exception(message)
{
    public EntityNotFoundException(Guid id, string type) 
        : this($"Could not find {type} with id {id}") { }
}