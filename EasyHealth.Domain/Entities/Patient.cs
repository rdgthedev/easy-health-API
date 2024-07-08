using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.ValueObject;

namespace EasyHealth.Domain.Entities;

public class Patient : BaseEntity
{
    protected Patient()
    {
    }

    public Patient(
        string name,
        Email email,
        Address address,
        DateTime birthDate,
        Gender gender)
    {
        Name = name;
        Email = email;
        Address = address;
        BirthDate = birthDate;
        Gender = gender;
    }

    public string Name { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Role Role { get; private set; }
    public Gender Gender { get; private set; }

    public bool IsValid() => Validate();

    private bool Validate()
    {
        if (string.IsNullOrEmpty(Name))
            return false;

        if (Email is null)
            return false;

        if (Address is null)
            return false;

        if (string.IsNullOrEmpty(Gender.ToString()))
            return false;

        return true;
    }

    public void UpdateEmail(Email email)
        => Email = email ?? throw new UnableToChangeEmail();

    public void UpdateAddress(Address address)
        => Address = address ?? throw new UnableToChangeAddress();
}