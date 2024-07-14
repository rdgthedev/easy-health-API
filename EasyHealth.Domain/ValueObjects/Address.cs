using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation.Results;

namespace EasyHealth.Domain.ValueObjects;

public class Address : Shared.ValueObject
{
    public Address(
        string street,
        string neighbordhood,
        int number,
        string city,
        string state,
        string zipCode,
        string? complement = null!)
    {
        Street = street;
        Neighbordhood = neighbordhood;
        Number = number;
        Complement = complement;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public string Street { get; private set; }
    public string Neighbordhood { get; private set; }
    public int Number { get; private set; }
    public string? Complement { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }

    public ValidationResult Validate()
        => new AddressValidator().Validate(this);
}