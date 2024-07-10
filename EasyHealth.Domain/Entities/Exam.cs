using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;

namespace EasyHealth.Domain.Entities;

public class Exam : BaseEntity
{
    protected Exam()
    {
    }

    public Exam(
        string name,
        string description)
    {
        Name = name;
        Description = description;
        Status = EStatus.Active;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public EStatus Status { get; private set; }
    public bool IsValid => new ExamValidator().Validate(this).IsValid;

    public void UpdateName(string name)
    {
        if (!string.IsNullOrEmpty(name))
            throw new UnableToChangeNameException("O campo nome não pode ser vázio!");

        Name = name;
        LastUpdateDate = DateTime.UtcNow;
    }

    public void UpdateDescription(string description)
    {
        if (!string.IsNullOrEmpty(description))
            throw new UnableToChangeDescriptionException("O campo descrição não pode ser vázio!");

        Name = description;
        LastUpdateDate = DateTime.UtcNow;
    }

    public void UpdateStatus(EStatus status)
    {
        if (Status.Equals(status))
            throw new UnableToChangeStatusException("O exame já se encontra neste eStatus!");

        Status = status;
        LastUpdateDate = DateTime.UtcNow;
    }
}