using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeDescriptionException : DomainException
{
    public UnableToChangeDescriptionException(string message) : base(message)
    {
    }
}