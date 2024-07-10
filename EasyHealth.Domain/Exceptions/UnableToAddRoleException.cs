using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToAddRoleException : DomainException
{
    public UnableToAddRoleException(string message) : base(message)
    {
    }

    public UnableToAddRoleException(string message, IList<ValidationFailure> errors) : base(message)
        => errors.ToList().ForEach(error => Errors.Add(error.ErrorMessage));
}