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
        string description,
        Category category)
    {
        Name = name;
        Description = description;
        Category = category;
        Status = EExamStatus.Active;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public EExamStatus Status { get; private set; }
    public bool IsValid => new ExamValidator().Validate(this).IsValid;

    public void UpdateCategory(Category category)
    {
        var validator = new CategoryValidator();
        var result = validator.Validate(category);

        if (!result.IsValid)
            throw new DomainException("Não foi possível alterar a categoria", result.Errors);

        Category = category;
    }
    public void UpdateName(string name)
    {
        if (!string.IsNullOrEmpty(name))
            throw new DomainException("O campo nome não pode ser vázio!");

        Name = name;
    }

    public void UpdateDescription(string description)
    {
        if (!string.IsNullOrEmpty(description))
            throw new DomainException("O campo descrição não pode ser vázio!");

        Name = description;
    }

    public void UpdateStatus(EExamStatus status)
    {
        if (Status == status)
            throw new DomainException("O exame já se encontra neste status!");

        Status = status;
    }
}