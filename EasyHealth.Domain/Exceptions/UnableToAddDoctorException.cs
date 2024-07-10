using EasyHealth.Domain.Shared;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public class UnableToAddDoctorException : DomainException
{
    public UnableToAddDoctorException(string message) : base(message)
    {
        
    }
    public UnableToAddDoctorException(string message, IList<ValidationFailure> errors) : base(message)
        => errors.ToList().ForEach(error => Errors.Add(error.ErrorMessage));
}