using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public class TitleValidator : AbstractValidator<Title>
{
    public TitleValidator()
    {
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("O título não pode ser vazio!")
            .MinimumLength(3).WithMessage("O título deve ter no mínimo três letras!");
    }
}