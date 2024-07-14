using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.ValueObjects;
using FluentValidation.Results;

namespace EasyHealth.Domain.Entities;

public class Doctor : BaseEntity
{
    private IList<Specialty> _specialties = null!;

    protected Doctor()
    {
    }

    public Doctor(
        Name name,
        DateTime birthDate,
        EGender gender,
        Email email,
        Crm crm,
        Specialty specialty,
        Document document)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        Crm = crm;
        Email = email;
        Document = document;
        Role = new Role(ERole.Doctor.ToString());

        _specialties = new List<Specialty>();
        _specialties.Add(specialty);
    }

    public Name Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public EGender Gender { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public Role Role { get; private set; }
    public Crm Crm { get; private set; }
    public IReadOnlyCollection<Specialty> Specialties => _specialties.ToArray();


    public ValidationResult Validate()
        => new DoctorValidator().Validate(this);

    public void AddSpecialty(Specialty specialty)
        => _specialties.Add(specialty);

    public void RemoveSpecialty(Specialty specialty)
        => _specialties.Remove(specialty);

    public void Update(
        Crm crm,
        Email email,
        Address address)
    {
        Crm = crm ?? Crm;
        Email = email ?? Email;
        Address = address ?? Address;
    }
}