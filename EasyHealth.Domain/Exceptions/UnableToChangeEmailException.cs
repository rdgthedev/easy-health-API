using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeEmailException : DomainException
{
    public UnableToChangeEmailException(
        string message,
        IList<ValidationFailure> errors) : base(message)
    {
    }
}