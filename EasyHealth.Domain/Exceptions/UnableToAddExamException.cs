using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToAddExamException : DomainException
{
    public UnableToAddExamException(string message) : base(message)
    {
    }

    public UnableToAddExamException(string message, IList<ValidationFailure> errors) : base(message)
    {
    }
}