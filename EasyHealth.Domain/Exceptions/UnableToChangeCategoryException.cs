using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeCategoryException : DomainException
{
    public UnableToChangeCategoryException(string message, IList<ValidationFailure> errors) : base(message)
        => errors.ToList().ForEach(error => Errors.Add(error.ErrorMessage));
}