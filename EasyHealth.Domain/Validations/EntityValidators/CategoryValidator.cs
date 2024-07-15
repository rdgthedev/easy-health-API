using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Title)
            .SetValidator(new TitleValidator());

        RuleFor(x => x.Exams)
            .Must(ValidateExam).WithMessage("Não são permitidos exames repetidos!");

        RuleForEach(x => x.Exams)
            .Must(exam =>
            {
                var examValidator = new ExamValidator();
                return examValidator.Validate(exam).IsValid;
            }).WithMessage("O exame adicionado é inválido!");
            
    }

    private bool ValidateExam(IReadOnlyCollection<Exam> exam)
        => exam.DistinctBy(e => e.Title).Count() == exam.Select(x => x.Title).Count();
}