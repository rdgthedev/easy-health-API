using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;

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
        string crm)
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
    public List<Specialty> Specialty { get; private set; } = [];
    public string Crm { get; private set; }

    public bool IsValid() => true;

    public void ChangeSpecialty(string specialty)
    {
    }

    public void AddSpecialty(Specialty specialty)
    {
    }
}