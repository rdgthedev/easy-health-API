using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;
using EasyHealth.Domain.Validations.EntityValidators;

namespace EasyHealth.Domain.Entities;

public class Category : BaseEntity
{
    protected Category()
    {
    }

    public Category(string name)
    {
        Name = name;
        Status = EStatus.Active;
    }

    public string Name { get; private set; }
    public EStatus Status { get; private set; }
    public bool IsValid => new CategoryValidator().Validate(this).IsValid;
    private IList<Exam> _exams = new List<Exam>();
    public IReadOnlyCollection<Exam> Exams => _exams.ToArray();

    public void AddExam(Exam exam)
    {
        var validator = new ExamValidator();
        var result = validator.Validate(exam);

        if (!result.IsValid)
            throw new UnableToAddExamException("Exame inválido!", result.Errors);

        var examExists = _exams.Any(x => x.Name == exam.Name);

        if (examExists)
            throw new UnableToAddExamException("A categoria já possuí esse exame!");

        _exams.Add(exam);
    }

    public void UpdateName(string name)
        => Name = name ?? throw new UnableToChangeNameException("Não foi possível alterar o título!");

    public void UpdateStatus(EStatus status)
    {
        if (Status.Equals(status))
            throw new UnableToChangeStatusException("Este é o status atual da categoria!");

        Status = status;
        LastUpdateDate = DateTime.UtcNow;
    }
}