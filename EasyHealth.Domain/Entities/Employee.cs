using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using EasyHealth.Domain.ValueObjects;
using FluentValidation;
using FluentValidation.Results;

namespace EasyHealth.Domain.Entities;

public class Employee : BaseEntity
{
    private IList<Role> _roles = null!;

    protected Employee()
    {
    }

    public Employee(
        Name name,
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
        _roles.Add(role);
    }

    public Name Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public EGender Gender { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public string Sector { get; private set; }
    public IReadOnlyCollection<Role> Roles => _roles.ToArray();

    public ValidationResult Validate()
        => new EmployeeValidator().Validate(this);

    public void AddRole(Role role)
        => _roles.Add(role);

    public void Update(
        Email email,
        Address address,
        string sector)
    {
        Email = email ?? Email;
        Address = address ?? Address;
        Sector = sector ?? Sector;
    }
}