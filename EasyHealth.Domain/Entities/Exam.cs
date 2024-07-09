using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Entities;

public sealed class Exam : BaseEntity
{
    private Exam()
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

    public void UpdateName(string name)
        => Name = name ?? throw new UnableToChangeNameException();

    public void UpdateDescription(string description)
        => Description = description ?? throw new UnableToChangeDescriptionException();

    public void UpdateStatus()
    {
    }

    public void UpdatePrice()
    {
    }
}