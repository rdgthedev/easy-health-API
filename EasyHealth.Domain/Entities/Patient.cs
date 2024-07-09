using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.ValueObjects;

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
        EGender gender)
    {
        Name = name;
        Email = email;
        Address = address;
        BirthDate = birthDate;
        Gender = gender;
        Role = new Role(ERole.Patient.ToString());
    }

    public string Name { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Role Role { get; private set; }
    public EGender Gender { get; private set; }

    public bool IsValid => new PatientValidator().Validate(this).IsValid;

    public void UpdateEmail(Email email)
        => Email = email ?? throw new UnableToChangeEmailException();

    public void UpdateAddress(Address address)
        => Address = address ?? throw new UnableToChangeAddressException();
}