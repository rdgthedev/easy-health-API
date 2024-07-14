using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;
using EasyHealth.Domain.ValueObjects;
using FluentValidation.Results;

namespace EasyHealth.Domain.Entities;

public class Category : BaseEntity
{
    private IList<Exam> _exams;

    protected Category()
    {
    }

    public Category(Title title)
    {
        Title = title;
        Status = EStatus.Active;
        _exams = new List<Exam>();
    }

    public Title Title { get; private set; }
    public EStatus Status { get; private set; }
    public IReadOnlyCollection<Exam> Exams => _exams.ToArray();

    public ValidationResult Validate()
        => new CategoryValidator().Validate(this);

    public void AddExam(Exam exam)
        => _exams.Add(exam);

    public void Update(Title title, EStatus status)
    {
        Title = title;
        Status = status;
    }
}