using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeSectorException : DomainException
{
    public UnableToChangeSectorException(string message) : base(message)
    {
    }
}