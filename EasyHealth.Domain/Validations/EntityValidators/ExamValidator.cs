using EasyHealth.Domain.Entities;
using EasyHealth.Domain.Validations.ValueObjectsValidators;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class ExamValidator : AbstractValidator<Exam>
{
    public ExamValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("O campo descrição não pode ser vazio!");
        RuleFor(x => x.Title).SetValidator(new TitleValidator());
        RuleFor(x => x.Category).SetValidator(new CategoryValidator());
    }
}