using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeCrmException : DomainException
{
    public UnableToChangeCrmException(string message, List<ValidationFailure> errors) : base(message)
    {
    }
}