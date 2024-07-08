using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.ValueObject;

namespace EasyHealth.Domain.Entities;

public class Doctor : BaseEntity
{
    protected Doctor()
    {
    }

    public Doctor(
        string name,
        DateTime birthDate,
        Gender gender,
        Specialty specialty,
        Crm crm)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        Crm = crm;

        AddSpecialty(specialty);
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public List<Specialty> Specialties { get; private set; } = [];
    public Crm Crm { get; private set; }

    public bool IsValid => Verify();

    private bool Verify()
    {
        if (string.IsNullOrEmpty(Name))
            return false;

        if (Specialties.Count == 0)
            return false;

        return true;
    }

    public void AddSpecialty(Specialty specialtyEntity)
    {
        Specialty? specialty = null!;

        if (specialtyEntity.IsValid)
            specialty = Specialties.FirstOrDefault(x => x.Title == specialtyEntity.Title);

        if (specialty is null)
            Specialties.Add(specialtyEntity);

        throw new UnableToAddSpeciality();
    }

    public void RemoveSpecialty(Guid id)
    {
        var specialty = Specialties.FirstOrDefault(x => x.Id == id);

        if (specialty is null)
            throw new SpecialtyNotFoundException();

        Specialties.Remove(specialty);
    }

    public void UpdateCrm(Crm crm)
    {
        Crm = crm ?? throw new UnableToChangeCrm();
    }

    public void UpdateEmail(Email email)
    {
        Email = email ?? throw new UnableToChangeEmail();
    }

    public void UpdateAddress(Address address)
    {
        Address = address ?? throw new UnableToChangeAddress();
    }
}