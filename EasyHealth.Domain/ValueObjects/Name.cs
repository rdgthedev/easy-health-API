using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation.Results;

namespace EasyHealth.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(
        string firstName,
        string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public ValidationResult Validate() => new NameValidator().Validate(this);

    public override string ToString()
        => $"{FirstName} {LastName}";
}