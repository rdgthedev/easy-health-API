using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using EasyHealth.Domain.ValueObjects;
using FluentValidation.Results;

namespace EasyHealth.Domain.Entities;

public class Patient : BaseEntity
{
    protected Patient()
    {
    }

    public Patient(
        Name name,
        Email email,
        Address address,
        Document document,
        DateTime birthDate,
        EGender gender)
    {
        Name = name;
        Email = email;
        Address = address;
        BirthDate = birthDate;
        Gender = gender;
        Document = document;
        Role = new Role(ERole.Patient.ToString());
    }

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Role Role { get; private set; }
    public EGender Gender { get; private set; }

    public ValidationResult Validate()
        => new PatientValidator().Validate(this);

    public void Update(Email email, Address adress)
    {
        Email = email;
        Address = adress;
    }
}