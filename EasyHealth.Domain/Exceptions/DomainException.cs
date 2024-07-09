using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using FluentValidation.Results;

namespace EasyHealth.Domain.Exceptions;

public sealed class DomainException : ValidationException
{
    public List<string> Errors { get; private set; }

    private DomainException()
        => Errors = new List<string>();

    public DomainException(string message) : base(message)
    {
    }

    public DomainException(string message, IList<string> errors) : this(message)
        => Errors.AddRange(errors);

    public DomainException(string message, string error) : this(message)
        => Errors.Add(error);

    public DomainException(IEnumerable<ValidationFailure> errors) : this()
        => errors.ToList().ForEach(error => Errors.Add(error.ErrorMessage));

    public DomainException(string message, IList<ValidationFailure> errors) : this(message)
        => errors.ToList().ForEach(error => Errors.Add(error.ErrorMessage));

    public DomainException(string message, ValidationFailure error) : this(message)
        => Errors.Add(error.ErrorMessage);
}