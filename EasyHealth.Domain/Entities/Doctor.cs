using System.ComponentModel.DataAnnotations;
using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Domain.Entities;

public class Doctor : BaseEntity
{
    protected Doctor()
    {
    }

    public Doctor(
        string name,
        DateTime birthDate,
        EGender gender,
        Email email,
        Crm crm,
        Specialty specialty)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        Crm = crm;
        Email = email;
        Role = new Role(ERole.Doctor.ToString());
        AddSpecialty(specialty);

        IsValid = new DoctorValidator().Validate(this).IsValid;
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public EGender Gender { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public Role Role { get; private set; }
    public Crm Crm { get; private set; }
    public bool IsValid { get; private set; }
    public IReadOnlyCollection<Specialty> Specialties => _specialties.ToArray();
    private IList<Specialty> _specialties = null!;


    public void AddSpecialty(Specialty specialtyEntity)
    {
        Specialty? specialty = null!;

        var validator = new SpecialtyValidator();
        var result = validator.Validate(specialtyEntity);

        if (!result.IsValid)
            throw new DomainException(result.Errors);

        specialty = Specialties.FirstOrDefault(x => x.Title == specialtyEntity.Title);

        if (specialty is not null)
            throw new DomainException("O médico já possuí essa especialidade!");

        _specialties.Add(specialtyEntity);
    }

    public void RemoveSpecialty(Guid id)
    {
        var specialty = Specialties.FirstOrDefault(x => x.Id == id);

        if (specialty is null)
            throw new DomainException("Especialidade não encontrada!");

        _specialties.Remove(specialty);
    }

    public void UpdateCrm(Crm crm)
    {
        var validator = new CrmValidator();
        var result = validator.Validate(crm);

        if (!result.IsValid)
            throw new DomainException("Não foi possível alterar o CRM!", result.Errors);

        Crm = crm;
    }

    public void UpdateEmail(Email email)
    {
        var validator = new EmailValidator();
        var result = validator.Validate(email);

        if (!result.IsValid)
            throw new DomainException("Não foi possível alterar o email!", result.Errors);

        Email = email;
    }
    
    public void UpdateAddress(Address address)
    {
        var validator = new AddressValidator();
        var result = validator.Validate(address);

        if (!result.IsValid)
            throw new DomainException("Não foi possível alterar o endereço!", result.Errors);

        Address = address;
    }
}