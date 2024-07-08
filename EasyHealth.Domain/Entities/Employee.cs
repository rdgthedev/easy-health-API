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
        Gender gender,
        Address address,
        Email email,
        string sector,
        Role role)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        Address = address;
        Email = email;
        Sector = sector;

        Roles.Add(role);
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public string Sector { get; private set; }
    public List<Role> Roles { get; private set; } = new();

    public bool IsValid => Verify();

    private bool Verify()
    {
        if (string.IsNullOrEmpty(Name))
            return false;

        if (Roles.Count == 0)
            return false;

        if (string.IsNullOrEmpty(Gender.ToString()))
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

    public void AddRole(Role role)
    {
        if (role is null)
            throw new UnableToAddRoleException("O perfil não pode ser vázio!");

        var roleResult = Roles.Any(x => x.Name == role.Name);
        
        if(roleResult)
            throw new UnableToAddRoleException("O perfil já existe!");
        
        Roles.Add(role);
    }
}