﻿using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public sealed class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("O campo rua não pode ser vázio!");

        RuleFor(x => x.Number)
            .LessThanOrEqualTo(0).WithMessage("O campo número deve ser maior que zero!");

        RuleFor(x => x.Neighbordhood)
            .NotEmpty().WithMessage("O campo bairro não pode ser vázio!");

        RuleFor(x => x.Complement)
            .NotEmpty().WithMessage("O campo complemento não pode ser vázio!");
        
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("O campo cidade não pode ser vázio!");
        
        RuleFor(x => x.State.ToString())
            .NotEmpty().WithMessage("O campo estado não pode ser vázio!")
            .Length(2, 2). WithMessage("O campo estado deve ter no mínimo dois caracteres!");
    }
}