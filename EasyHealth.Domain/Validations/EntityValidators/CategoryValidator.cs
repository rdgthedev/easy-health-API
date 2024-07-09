using EasyHealth.Domain.Entities;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("O campo título não pode ser vázio!");

        RuleForEach(x => x.Exams)
            .SetValidator(new ExamValidator());
    }
}