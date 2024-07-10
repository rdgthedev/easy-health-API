using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeStatusException : DomainException
{
    public UnableToChangeStatusException(string message) : base(message)
    {
    }
}