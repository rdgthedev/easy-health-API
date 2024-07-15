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
        Role = role;
    }

    public Name Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public EGender Gender { get; private set; }
    public Document Document { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public string Sector { get; private set; }
    public Role Role { get; private set; }

    public ValidationResult Validate()
        => new EmployeeValidator().Validate(this);

    public void Update(
        Email email,
        Address address,
        string sector,
        Role role)
    {
        Email = email;
        Address = address;
        Sector = sector;
        Role = role;
    }
}