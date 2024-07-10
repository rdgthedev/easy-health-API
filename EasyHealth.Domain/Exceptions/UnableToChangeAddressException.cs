using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeAddressException : DomainException
{
    public UnableToChangeAddressException(string message, List<ValidationFailure> errors) : base(message)
    {
    }
}