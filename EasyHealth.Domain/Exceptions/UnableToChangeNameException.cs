using System.Reflection.Metadata.Ecma335;
using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToChangeNameException : DomainException
{
    public UnableToChangeNameException(string message, List<ValidationFailure> errors) : base(message, errors)
    {
    }
}