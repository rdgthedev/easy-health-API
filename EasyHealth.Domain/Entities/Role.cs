using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.ValueObjects;
using FluentValidation.Results;

namespace EasyHealth.Domain.Entities;

public class Role : BaseEntity
{
    protected Role()
    {
    }

    public Role(Title title)
        => Title = title;

    public Title Title { get; private set; }
    public EStatus Status { get; private set; }
    public List<Employee> Employees { get; private set; }
    public Doctor Doctor { get; private set; }
    public Patient Patient { get; private set; }

    public ValidationResult Validate()
        => new RoleValidator().Validate(this);

    public void Update(Title title, EStatus status)
    {
        Title = title;
        Status = status;
    }
}