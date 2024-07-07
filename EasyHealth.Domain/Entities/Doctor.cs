using EasyHealth.Domain.Enums;
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
        AddSpecialty(specialty);
        Crm = crm;
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public Address Address { get; set; }
    public Email Email { get; set; }
    public List<Specialty> Specialties { get; private set; } = [];
    public Crm Crm { get; private set; }

    public bool IsValid() => Verify(this);

    private static bool Verify(Doctor doctor) => true;

    public void AddSpecialty(Specialty specialty)
    {
        Specialties.Add(specialty);
    }

    public void RemoveSpecialty(Guid id)
    {
        
    }

    public void UpdateCrm(Crm crm)
    {
        Crm = crm;
    }
}