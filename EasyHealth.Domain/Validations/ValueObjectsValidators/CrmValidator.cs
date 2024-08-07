﻿using EasyHealth.Domain.ValueObjects;
using FluentValidation;

namespace EasyHealth.Domain.Validations.ValueObjectsValidators;

public sealed class CrmValidator : AbstractValidator<Crm>
{
    public CrmValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("O CRM não pode ser vázio!")
            .Length(6).WithMessage("O código deve ter seis números!");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("O campo estado não pode ser vázio!")
            .Length(2, 2).WithMessage("O campo estado deve ter no mínimo dois caracteres!");
    }
}