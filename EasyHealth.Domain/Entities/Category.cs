﻿using EasyHealth.Domain.Enums;
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
        Title = name;
        CreateDate = DateTime.UtcNow;
        Status = ECategoryStatus.Active;

        IsValid = new CategoryValidator().Validate(this).IsValid;
    }

    public string Title { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public ECategoryStatus Status { get; private set; }
    public bool IsValid { get; private set; }
    private IList<Exam> _exams = new List<Exam>();
    public IReadOnlyCollection<Exam> Exams => _exams.ToArray();


    public void AddExam(Exam exam)
    {
        var validator = new ExamValidator();
        var result = validator.Validate(exam);

        if (!result.IsValid)
            throw new DomainException("Exame inválido!", result.Errors);

        var examExists = _exams.Any(x => x.Name == exam.Name);

        if (examExists)
            throw new DomainException("A categoria já possuí esse exame!");

        _exams.Add(exam);
    }

    public void UpdateName(string name)
        => Title = name ?? throw new DomainException("Não foi possível alterar o título!");

    public void UpdateStatus(ECategoryStatus status)
    {
        if (Status.Equals(status))
            throw new DomainException("Este é o status atual da categoria!");
        
        Status = status;
        LastUpdateDate = DateTime.UtcNow;
    }
}