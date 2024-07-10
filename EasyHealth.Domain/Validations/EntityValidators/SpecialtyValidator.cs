using EasyHealth.Domain.Entities;
using FluentValidation;

namespace EasyHealth.Domain.Validations.EntityValidators;

public sealed class SpecialtyValidator : AbstractValidator<Specialty>
{
    public SpecialtyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O título não pode ser vázio!");
    }
}