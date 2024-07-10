using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
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

    public void UpdateEmail(string email)
    {
        var validator = new EmailValidator();
        var result = validator.Validate(email);

        if (!result.IsValid)
            throw new UnableToChangeEmailException("Não foi possível alterar o email!", result.Errors);

        Email = email;
    }

    public void UpdateAddress(Address address)
    {
        var validator = new AddressValidator();
        var result = validator.Validate(address);
        
        if (!result.IsValid)
            throw new UnableToChangeAddressException("Não foi possível alterar o endereço!", result.Errors);

        Address = address;
    }
}