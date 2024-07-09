using EasyHealth.Domain.Entities;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class ExamValidator : AbstractValidator<Exam>
{
    public ExamValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O campo nome não pode ser vázio!");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("O campo description não pode ser vázio!");

        RuleFor(x => x.Category).SetValidator(new CategoryValidator());
    }
}