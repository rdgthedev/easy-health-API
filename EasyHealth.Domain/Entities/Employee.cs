using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.ValueObject;

namespace EasyHealth.Domain.Entities;

public class Employee : BaseEntity
{
    public Employee(
        string name,
        DateTime birthDate,
        EGender eGender,
        Address address,
        Email email,
        string sector,
        ERole role)
    {
        Name = name;
        BirthDate = birthDate;
        EGender = eGender;
        Address = address;
        Email = email;
        Sector = sector;

        AddRole(role);
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public EGender EGender { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public string Sector { get; private set; }
    public IReadOnlyCollection<Role> Roles => _roles.ToArray();
    private IList<Role> _roles = null!;

    public bool IsValid => Validate();

    private bool Validate()
    {
        if (string.IsNullOrEmpty(Name))
            return false;

        if (Roles.Count == 0)
            return false;

        if (string.IsNullOrEmpty(EGender.ToString()))
            return false;

        if (BirthDate <= DateTime.Now.AddYears(-18))
            return false;

        if (Address is null)
            return false;

        if (Email is null)
            return false;

        if (Sector is null)
            return false;

        return true;
    }

    public void AddRole(ERole role)
    {
        if (role.ToString() is null)
            throw new UnableToAddRoleException("O perfil não pode ser vázio!");

        var roleResult = Roles.Any(x => x.Name == role);

        if (roleResult)
            throw new UnableToAddRoleException("O perfil já existe!");

        _roles.Add(new Role(role));
    }

    public void UpdateEmail(Email email)
        => Email = email ?? throw new UnableToChangeEmailException();

    public void UpdateAddress(Address address)
        => Address = address ?? throw new UnableToChangeAddressException();

    public void UpdateSector(string sector)
        => Sector = sector ?? throw new UnableToChangeSectorException();
}