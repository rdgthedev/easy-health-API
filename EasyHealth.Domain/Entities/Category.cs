using EasyHealth.Domain.Enums;
using EasyHealth.Domain.Exceptions;
using EasyHealth.Domain.Shared;

namespace EasyHealth.Domain.Entities;

public class Category : BaseEntity
{
    protected Category()
    {
    }

    public Category(
        string name)
    {
        Title = name;
        CreateDate = DateTime.UtcNow;
        Status = ECategoryStatus.Active;
    }

    public string Title { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public ECategoryStatus Status { get; private set; }
    private IList<Exam> _exams = new List<Exam>();
    public IReadOnlyCollection<Exam> Exams => _exams.ToArray();

    public void AddExam(Exam exam)
    {
        var result = _exams.Any(x => x.Name == exam.Name);

        if (!result)
            throw new UnableToAddExamException();

        _exams.Add(exam);
    }

    public void UpdateName(string name)
        => Title = name ?? throw new UnableToChangeNameException();

    public void UpdateStatus(bool status)
    {
        if (!status)
            Status = ECategoryStatus.Inactive;

        Status = ECategoryStatus.Active;
        LastUpdateDate = DateTime.UtcNow;
    }
}