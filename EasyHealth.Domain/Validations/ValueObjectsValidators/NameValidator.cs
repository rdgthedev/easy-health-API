using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public class NameValidator : AbstractValidator<Name>
{
    public NameValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("O primeiro nome não pode ser vazio!")
            .MinimumLength(3).WithMessage("O nome deve ter no mínimo três caracteres!");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("O sobrenome não pode ser vazio!")
            .MinimumLength(2).WithMessage("O sobrenome deve ter no mínimo três caracteres!");
    }
}