using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
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
        Crm crm,
        Specialty specialty)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        Crm = crm;
        Role = new Role(ERole.Doctor.ToString());

        AddSpecialty(specialty);
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public EGender Gender { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public Role Role { get; private set; }
    public IReadOnlyCollection<Specialty> Specialties => _specialties.ToArray();
    private IList<Specialty> _specialties = null!;
    public Crm Crm { get; private set; }

    public void AddSpecialty(Specialty specialtyEntity)
    {
        Specialty? specialty = null!;

        if (specialtyEntity.IsValid)
            specialty = Specialties.FirstOrDefault(x => x.Title == specialtyEntity.Title);

        if (specialty is not null)
            throw new UnableToAddSpecialityException();

        _specialties.Add(specialtyEntity);
    }

    public void RemoveSpecialty(Guid id)
    {
        var specialty = Specialties.FirstOrDefault(x => x.Id == id);

        if (specialty is null)
            throw new SpecialtyNotFoundException();

        _specialties.Remove(specialty);
    }

    public void UpdateCrm(Crm crm)
        => Crm = crm ?? throw new UnableToChangeCrmException();

    public void UpdateEmail(Email email)
        => Email = email ?? throw new UnableToChangeEmailException();

    public void UpdateAddress(Address address)
        => Address = address ?? throw new UnableToChangeAddressException();
}