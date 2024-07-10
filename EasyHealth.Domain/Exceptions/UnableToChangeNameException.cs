using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeNameException : DomainException
{
    public UnableToChangeNameException(string message):base(message)
    {
    }
}