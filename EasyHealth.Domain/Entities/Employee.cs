using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using EasyHealth.Domain.ValueObjects;

namespace EasyHealth.Domain.Entities;

public class Employee : BaseEntity
{
    private IList<Role> _roles = null!;

    protected Employee()
    {
    }

    public Employee(
        string name,
        DateTime birthDate,
        EGender gender,
        Address address,
        Email email,
        string sector,
        Document document,
        Role role)
    {
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        Address = address;
        Email = email;
        Sector = sector;
        Document = document;
        _roles = new List<Role>();
        AddRole(role);
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public EGender Gender { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public string Sector { get; private set; }
    public IReadOnlyCollection<Role> Roles => _roles.ToArray();
    public bool IsValid => new EmployeeValidator().Validate(this).IsValid;

    public void AddRole(Role role)
    {
        var validator = new RoleValidator();
        var result = validator.Validate(role);

        if (!result.IsValid)
            throw new UnableToAddRoleException("Perfil inválido!", result.Errors);

        var roleExists = Roles.Any(x => x.Name == role.Name);

        if (roleExists)
            throw new UnableToAddRoleException("O perfil já existe!");

        _roles.Add(role);
    }

    public void UpdateEmail(Email email)
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

    public void UpdateSector(string sector)
    {
        if (!string.IsNullOrEmpty(sector.Trim()))
            throw new UnableToChangeSectorException("O campo setor não pode ser vázio!");

        Sector = sector;
    }
}