using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToAddSpecialityException : DomainException
{
    public UnableToAddSpecialityException(string message) : base(message)
    {
    }

    public UnableToAddSpecialityException(List<ValidationFailure> errors) : base(errors)
    {
    }
}