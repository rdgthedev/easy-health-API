using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.ValueObjects;
using FluentValidation.Results;

namespace EasyHealth.Domain.Entities;

public class Exam : BaseEntity
{
    protected Exam()
    {
    }

    public Exam(
        Title title,
        string description)
    {
        Title = title;
        Description = description;
        Status = EStatus.Active;
    }

    public Title Title { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public EStatus Status { get; private set; }

    public ValidationResult Validate()
        => new ExamValidator().Validate(this);

    public void Update(
        Title title,
        string description,
        EStatus status)
    {
        Title = title;
        Description = description;
        Status = status;
    }
}