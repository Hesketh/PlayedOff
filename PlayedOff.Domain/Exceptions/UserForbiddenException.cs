namespace PlayedOff.Domain.Exceptions;

public sealed class UserForbiddenException(string message) : Exception(message)
{
}